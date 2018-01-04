using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace AnalizProje
{
    public partial class Parametre : Form
    {
        Manager manager = new Manager();
        string analizConStr = "";
        string wolVoxConStr = "";

        private DataTable parametreDtGrup = new DataTable();
        private DataTable parametreDtDetay = new DataTable();
        int seviye = 1;
        bool basladi = false;
        string pTabloAdi = "Parametre";
        bool nodMuyum = true;


        public Parametre()
        {
            InitializeComponent();
            analizConStr = manager.conStrAnaliz;
            wolVoxConStr = manager.conStrWolvox;

            pTabloAdi = "PARAMETRE";

        }

        private void Parametre_Load(object sender, EventArgs e)
        {
            treeDataDoldur();

            if (Manager.VeriTasi == null)
            {
                cmbSeviye.SelectedItem = "1";
            }
            else
            {
                DataTable sorgu = manager.GetDataTableFull(pTabloAdi, "PARAMETRE_ID=" + Manager.VeriTasi.ToString() + " AND SABIT=1", analizConStr);
                cmbSeviye.SelectedItem = (int.Parse(sorgu.Rows[0]["SEVIYE"].ToString()) + 1).ToString();

                btnSec.Visible = true;
                cmbSeviye.Enabled = false;

            }
            acilis();
        }


        
        private void treeDataDoldur()
        {
            treeView1.Nodes.Clear();
            String Sequel = "SELECT PARAMETRE_ID,SEVIYE_ADI,UST_SEVIYE_ID, SEVIYE FROM PARAMETRE WHERE UST_SEVIYE_ID=0 AND AKTIF=1 ORDER BY SEVIYE_ADI";
            DataTable ParametreDt = new DataTable();
            ParametreDt = manager.BasitSorguDT(Sequel, analizConStr);
            foreach (DataRow dr in ParametreDt.Rows)
            {
                int parametreId = int.Parse(dr["PARAMETRE_ID"].ToString());
                string seviyeAdi = dr["SEVIYE_ADI"].ToString();
                int ustSeviyeId = int.Parse(dr["UST_SEVIYE_ID"].ToString());
                int seviye = int.Parse(dr["SEVIYE"].ToString());
                int isParent = 1;

                ParametreSanal parametreSanal = new ParametreSanal(parametreId, seviyeAdi, ustSeviyeId, seviye,isParent);
                DataTreeNode node1 = new DataTreeNode(parametreSanal);
                treeView1.Nodes.Add(node1);
                PopulateTreeView(Convert.ToInt32(dr["PARAMETRE_ID"].ToString()), node1);
            }
            treeView1.LineColor = Color.Teal;
            treeView1.CollapseAll();
            //treeView1.ExpandAll();

        }

        private void PopulateTreeView(int parentId, DataTreeNode parentNode)
        {
            String Sequel = "SELECT PARAMETRE_ID,SEVIYE_ADI,UST_SEVIYE_ID, SEVIYE FROM PARAMETRE WHERE UST_SEVIYE_ID=" + parentId + " AND AKTIF=1 ORDER BY SEVIYE_ADI";
            DataTable parametreTreeDt = new DataTable();
            parametreTreeDt = manager.BasitSorguDT(Sequel, analizConStr);
            //TreeNode childNode;
            nodMuyum = false;
            foreach (DataRow dr in parametreTreeDt.Rows)
            {
                int parametreId = int.Parse(dr["PARAMETRE_ID"].ToString());
                string seviyeAdi = dr["SEVIYE_ADI"].ToString();
                int ustSeviyeId = int.Parse(dr["UST_SEVIYE_ID"].ToString());
                int seviye = int.Parse(dr["SEVIYE"].ToString());
                int isparent = 0;

                ParametreSanal parametreSanal = new ParametreSanal(parametreId, seviyeAdi, ustSeviyeId, seviye, isparent);
                DataTreeNode node1 = new DataTreeNode(parametreSanal);
                if (parentNode == null)
                {
                    treeView1.Nodes.Add(node1);
                }
                else
                {
                    parentNode.Nodes.Add(node1);
                }
                PopulateTreeView(Convert.ToInt32(dr["PARAMETRE_ID"].ToString()), node1);
                nodMuyum = true;
             }
        }

        public class DataTreeNode : TreeNode
        {
            private object data;
            public DataTreeNode(object data) : base(data.ToString())
            {
                this.data = data;
            }
            public object Data
            {
                get { return data; }
            }
        }




        private void acilis()
        {
            basladi = false;
            temizle();
            cmbDoldur();

            basladi = true;
            gridYukle();
        }

        private void cmbDoldur()
        {
            cmbTipi.SelectedItem = "Metin";

            int seviye = (Int16.Parse(cmbSeviye.Text.ToString()) - 1);

            if (Manager.VeriTasi == null)
            {
                cmbUstSeviye.DataSource = manager.GetDataTableFull(pTabloAdi, "SEVIYE=" + seviye + " AND SABIT=1", analizConStr);
            }
            else
            {
                DataTable cmbDoldurSorgu = manager.GetDataTableFull(pTabloAdi, "PARAMETRE_ID=" + Manager.VeriTasi.ToString() + " AND SABIT=1", analizConStr);
                cmbUstSeviye.DataSource = cmbDoldurSorgu;
            }
            cmbUstSeviye.DisplayMember = "SEVIYE_ADI";
            cmbUstSeviye.ValueMember = "PARAMETRE_ID";

            //cmbDetayGrupKodu.SelectedIndex = 0;
            if (Manager.VeriTasi != null) cmbUstSeviye.SelectedValue = Manager.VeriTasi;

            cmbUstSeviye.Refresh();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtSeviyeAdi.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Seviye Adı Girmelisiniz. Kayıt Gerçekleşmedi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            kaydet();
            temizle();
            treeDataDoldur();
        }

        private void gridYukle()
        {
            if (!basladi) return;

            seviye = (Int16.Parse(cmbSeviye.Text.ToString()));

            string sorgu = "";
            sorgu += " SEVIYE=" + seviye.ToString();
            if (seviye > 1)
            {
                try
                {
                    sorgu += " AND UST_SEVIYE_ID=" + cmbUstSeviye.SelectedValue.ToString() + "  ORDER BY SEVIYE_ADI";
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Henüz Bu Seviyede Bir Tanımınız Yok!");
                    //cmbSeviye.SelectedItem = "1";
                    cmbSeviye.SelectedItem = txtSEVIYE.Text;
                    cmbSeviye.Refresh();
                    nodMuyum = false;
                    return;
                }
                
            }

            parametreDtDetay = manager.GetDataTableFull(pTabloAdi, sorgu, analizConStr);
            grdDetay.DataSource = parametreDtDetay;
            grdDetay.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            grdDetay.Columns[0].Visible = false;
            grdDetay.Columns[1].Visible = false;
            grdDetay.Columns[5].Visible = false;
            grdDetay.Columns[7].Visible = false;
            grdDetay.Columns[9].Visible = false;
        }

        private void kaydet()
        {
            DataTable kaydetDtSorgu = new DataTable();
            kaydetDtSorgu = manager.GetDataTableFull("PARAMETRE", "PARAMETRE_ID=" + txtId.Text.ToString(), analizConStr);
            bool kayitVar = true;
            if (kaydetDtSorgu.Rows.Count == 0)
            {
                kaydetDtSorgu.Rows.Add();
                kayitVar = false;
            }
            try
            {
                kaydetDtSorgu = manager.GetDataTableFull(pTabloAdi, " PARAMETRE_ID=" + txtId.Text.ToString(), analizConStr);
            }
            catch
            { }

            if (kaydetDtSorgu.Rows.Count == 0)
            {
                kaydetDtSorgu.Rows.Add();
            }
            if (cmbUstSeviye.SelectedValue == null)
            { kaydetDtSorgu.Rows[0]["UST_SEVIYE_ID"] = "0"; }
            else
            { kaydetDtSorgu.Rows[0]["UST_SEVIYE_ID"] = cmbUstSeviye.SelectedValue; }

            kaydetDtSorgu.Rows[0]["SEVIYE"] = cmbSeviye.Text.ToString();
            kaydetDtSorgu.Rows[0]["SEVIYE_KODU"] = txtSeviyeKodu.Text.ToString();
            kaydetDtSorgu.Rows[0]["SEVIYE_ADI"] = txtSeviyeAdi.Text.ToString();
            kaydetDtSorgu.Rows[0]["SEVIYE_ACIKLAMA"] = txtAciklama.Text.ToString();
            kaydetDtSorgu.Rows[0]["SEVIYE_DEGER"] = txtSeviyeDegeri.Text.ToString();
            kaydetDtSorgu.Rows[0]["SABIT"] = chkSabit.Checked;
            kaydetDtSorgu.Rows[0]["SILINEMEZ"] = chkSilinemez.Checked;
            kaydetDtSorgu.Rows[0]["TIPI"] = cmbTipi.Text.ToString();
            kaydetDtSorgu.Rows[0]["AKTIF"] = chkAktif.Checked;

            
            if (!kayitVar)
            {
                kaydetDtSorgu.Rows[0]["KAYDEDEN"] = Manager.KullaniciAdSoyad.ToString();
            }
            kaydetDtSorgu.Rows[0]["GUNCELLEYEN"] = Manager.KullaniciAdSoyad.ToString();



            int gidecekDeger = int.Parse(txtId.Text.ToString());
            if (manager.kaydetGuncelle(pTabloAdi,"PARAMETRE_ID", gidecekDeger, kaydetDtSorgu, analizConStr))
            {
                gridYukle();
                //MessageBox.Show("Kaydetme İşlemi Tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnKaydet.Text = "Kaydet";
            }
            else
            {
                MessageBox.Show("Kaydetme İşleminde Hata. Kayıt Gerçekleşmedi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void temizle()
        {
            btnKaydet.Text = "Kaydet";
            txtId.Text = "0";
            //cmbDetayGrupKodu.SelectedValue =0 ;
            //cmbSeviye.SelectedText = "1";
            txtSeviyeKodu.Text = "";
            txtSeviyeAdi.Text = "";
            txtAciklama.Text = "";
            txtSeviyeDegeri.Text = "";
            chkSabit.Checked = false;
            chkSilinemez.Checked = false;
            chkAktif.Checked = true;

        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            if (txtId.Text.ToString() != "0")
            {
                Manager.VeriTasi = Int32.Parse(txtId.Text.ToString());
            }
            else
            {
                Manager.VeriTasi = "0";
            }
            this.Dispose();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (chkSilinemez.Checked)
            {
                MessageBox.Show("Bu Kaydı Silemezsiniz!.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtId.Text.ToString() == "0")
            {
                MessageBox.Show("Lütfen Bir Kayıt Seçiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((grdDetay.Rows.Count > 0))
            {
                if (MessageBox.Show("Kaydı Silmek İstiyor Musunuz?", "Uyarı...", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    manager.Sil(pTabloAdi,"PARAMETRE_ID="+txtId.Text.ToString(), analizConStr);
                    temizle();
                    gridYukle();
                    treeDataDoldur();
                }
            }
        }

        private void grdDetay_DoubleClick(object sender, EventArgs e)
        {
            temizle();
            btnKaydet.Text = "Güncelle";
            txtId.Text = grdDetay.CurrentRow.Cells["PARAMETRE_ID"].Value.ToString();
            cmbUstSeviye.SelectedValue = grdDetay.CurrentRow.Cells["UST_SEVIYE_ID"].Value;
            cmbSeviye.Text = grdDetay.CurrentRow.Cells["SEVIYE"].Value.ToString();
            txtSeviyeKodu.Text = grdDetay.CurrentRow.Cells["SEVIYE_KODU"].Value.ToString();
            txtSeviyeAdi.Text = grdDetay.CurrentRow.Cells["SEVIYE_ADI"].Value.ToString();
            txtAciklama.Text = grdDetay.CurrentRow.Cells["SEVIYE_ACIKLAMA"].Value.ToString();
            txtSeviyeDegeri.Text = grdDetay.CurrentRow.Cells["SEVIYE_DEGER"].Value.ToString();

            if (grdDetay.CurrentRow.Cells["SABIT"].Value.ToString() == "1")  chkSabit.Checked = true;
            else chkSabit.Checked = false;

            cmbTipi.Text = grdDetay.CurrentRow.Cells["TIPI"].Value.ToString();

            if (grdDetay.CurrentRow.Cells["SILINEMEZ"].Value.ToString() == "1") chkSilinemez.Checked = true;
            else chkSilinemez.Checked = false;

            if (grdDetay.CurrentRow.Cells["AKTIF"].Value.ToString() == "1") chkAktif.Checked = true;
            else chkAktif.Checked = false;

        }

        private void cmbSeviye_SelectedIndexChanged(object sender, EventArgs e)
        {
            acilis();
        }

        private void cmbUstSeviye_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridYukle();
        }

        private void Parametre_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtId.Text.ToString() != "0")
            {
                Manager.VeriTasi = Int32.Parse(txtId.Text.ToString());
            }
            else
            {
                Manager.VeriTasi = "0";
            }
            this.Dispose();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DataTreeNode treeViewNode = (DataTreeNode)e.Node; // <--- Node DataTreeNode tipinde

            txtPARAMETRE_ID.DataBindings.Clear();
            txtSEVIYE_ADI.DataBindings.Clear();
            txtUST_SEVIYE_ID.DataBindings.Clear();
            txtSEVIYE.DataBindings.Clear();
            txtISPARENT.DataBindings.Clear();

            txtPARAMETRE_ID.DataBindings.Add("Text", treeViewNode.Data, "PARAMETRE_ID");
            txtSEVIYE_ADI.DataBindings.Add("Text", treeViewNode.Data, "SEVIYE_ADI");
            txtUST_SEVIYE_ID.DataBindings.Add("Text", treeViewNode.Data, "UST_SEVIYE_ID");
            txtSEVIYE.DataBindings.Add("Text", treeViewNode.Data, "SEVIYE");
            txtISPARENT.DataBindings.Add("Text", treeViewNode.Data, "ISPARENT");


            //MessageBox.Show(((System.Windows.Forms.TreeView)sender).SelectedNode.FullPath.ToString());
            //MessageBox.Show(((System.Windows.Forms.TreeView)sender).SelectedNode.Text.ToString());


            if (e.Node.Parent == null)  // || e.Node.Parent.GetType() == typeof(TreeNode))
            {
                cmbSeviye.SelectedIndex = int.Parse(txtSEVIYE.Text.ToString());
                cmbUstSeviye.SelectedValue = txtPARAMETRE_ID.Text;
            }
            else
            {
                nodMuyum = true;
                //MessageBox.Show("This is parent node.");
                if (e.Node.Parent.GetType() == typeof(DataTreeNode))
                {
                    //if (e.Node.LastNode != null)
                    {
                        cmbSeviye.SelectedIndex = int.Parse(txtSEVIYE.Text.ToString());
                    }
                    cmbUstSeviye.SelectedValue = txtPARAMETRE_ID.Text;


                    if (!nodMuyum)
                    {
                        cmbSeviye.SelectedIndex = int.Parse(txtSEVIYE.Text.ToString()) - 1;
                        cmbUstSeviye.SelectedValue = txtUST_SEVIYE_ID.Text;
                    }
                }
                else
                {
                    //cmbUstSeviye.SelectedValue = txtUST_SEVIYE_ID.Text;
                }
                //cmbUstSeviye.SelectedText = e.Node.Parent.Text.ToString();
            }

            //cmbSeviye.SelectedIndex = int.Parse(txtSEVIYE.Text.ToString());
            //cmbUstSeviye.SelectedValue = txtPARAMETRE_ID.Text;
            //cmbSeviye.Refresh();

        }

        private void cmbUstSeviye_SelectedValueChanged(object sender, EventArgs e)
        {
            gridYukle();
        }

        public void nodeBul(string aran)
        {
            foreach (DataTreeNode node in treeView1.Nodes)
            {
                ShowTreeNodesRecursive(node, aran);
            }
        }
        public void ShowTreeNodesRecursive(DataTreeNode oParentNode, string aranan)
        {
            //debug
            //Console.WriteLine(oParentNode.Text);
            //MessageBox.Show(((System.Windows.Forms.TreeView)sender).SelectedNode.Text.ToString());
            //MessageBox.Show(((System.Windows.Forms.TreeView)sender).SelectedNode.FullPath.ToString());

            if (oParentNode.FullPath.ToString()==aranan)
            {
                treeView1.SelectedNode = oParentNode;
                treeView1.SelectedNode.BackColor = Color.Blue;
            }
            // Start recursion on all subnodes.
                foreach (DataTreeNode oSubNode in oParentNode.Nodes)
            {
                ShowTreeNodesRecursive(oSubNode,aranan);
            }
        }

        private void btnYolBul_Click(object sender, EventArgs e)
        {
            string yol = manager.parametreTreeYolBul(txtId.Text.ToString());
            //MessageBox.Show(yol);
            nodeBul(yol);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("PARAMETREAGACI", "GIRIS")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: PARAMETREAGACI - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ParametreAgaci parametreAgaci = new ParametreAgaci();
            //parametreAgaci.MdiParent = this;
            Manager.NodTasi = txtId.Text;
            parametreAgaci.Text = "Parametre Ağacı";
            parametreAgaci.ShowDialog();
            //MessageBox.Show(Manager.NodTasi.ToString());
            nodeBul(Manager.NodTasi.ToString());
        }
    }
}
