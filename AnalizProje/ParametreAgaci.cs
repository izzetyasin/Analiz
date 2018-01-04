using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizProje
{
    public partial class ParametreAgaci : Form
    {
        Manager manager = new Manager();
        string analizConStr = "";
        string wolVoxConStr = "";
        bool nodMuyum = true;
        bool secCikisi = false;
        string arananYol = "";

        public ParametreAgaci()
        {
            InitializeComponent();
            analizConStr = manager.conStrAnaliz;
            wolVoxConStr = manager.conStrWolvox;
        }

        private void ParametreAgaci_Load(object sender, EventArgs e)
        {
            treeDataDoldur();
        }
        private void treeDataDoldur()
        {
            treeView1.Nodes.Clear();
            String Sequel = "";

            if (Manager.NodTasi == null)
            {
                Sequel = "SELECT PARAMETRE_ID,SEVIYE_ADI,UST_SEVIYE_ID, SEVIYE FROM PARAMETRE WHERE UST_SEVIYE_ID=0 AND AKTIF=1 ORDER BY SEVIYE_ADI";
            }
            else
            {
                bool arama = true;
                string yol = "";
                arananYol = "";
                string sorgu = "";
                DataTable yolSor = new DataTable();

                sorgu = "SELECT * FROM PARAMETRE WHERE PARAMETRE_ID=" + Manager.NodTasi.ToString();

                yolSor = manager.BasitSorguDT(sorgu, analizConStr);

                if (yolSor== null || yolSor.Rows.Count==0)
                {
                    MessageBox.Show("Yol Değerine Ait Bir Tanım Bulunamadı!");
                    Manager.NodTasi = null;
                    this.Dispose();
                    return;
                }

                yol = yolSor.Rows[0]["PARAMETRE_ID"].ToString();
                arananYol = yolSor.Rows[0]["SEVIYE_ADI"].ToString();

                if (yolSor.Rows[0]["UST_SEVIYE_ID"].ToString() != "0")
                {
                    do
                    {
                        sorgu = "SELECT * FROM PARAMETRE WHERE PARAMETRE_ID=" + yolSor.Rows[0]["UST_SEVIYE_ID"].ToString();
                        yolSor = manager.BasitSorguDT(sorgu, analizConStr);
                        arananYol = yolSor.Rows[0]["SEVIYE_ADI"].ToString() + @"\" + arananYol;
                        if (yolSor.Rows[0]["UST_SEVIYE_ID"].ToString() == "0")
                        {
                            yol = yolSor.Rows[0]["PARAMETRE_ID"].ToString();
                            arama = false;
                        }

                    } while (arama);
                }
                Sequel = "SELECT PARAMETRE_ID,SEVIYE_ADI,UST_SEVIYE_ID, SEVIYE FROM PARAMETRE WHERE PARAMETRE_ID="+yol+" AND UST_SEVIYE_ID=0 AND AKTIF=1 ORDER BY SEVIYE_ADI";
            }
            DataTable dt = new DataTable();
            dt = manager.BasitSorguDT(Sequel, analizConStr);
            foreach (DataRow dr in dt.Rows)
            {
                int parametreId = int.Parse(dr["PARAMETRE_ID"].ToString());
                string seviyeAdi = dr["SEVIYE_ADI"].ToString();
                int ustSeviyeId = int.Parse(dr["UST_SEVIYE_ID"].ToString());
                int seviye = int.Parse(dr["SEVIYE"].ToString());
                int isParent = 1;

                ParametreSanal parametreSanal = new ParametreSanal(parametreId, seviyeAdi, ustSeviyeId, seviye, isParent);
                DataTreeNode node1 = new DataTreeNode(parametreSanal);
                treeView1.Nodes.Add(node1);
                PopulateTreeView(Convert.ToInt32(dr["PARAMETRE_ID"].ToString()), node1);
            }
            treeView1.LineColor = Color.Teal;
            nodeBul(arananYol);
            //treeView1.CollapseAll();
            //treeView1.ExpandAll();

        }
        private void PopulateTreeView(int parentId, DataTreeNode parentNode)
        {
            String Sequel = "SELECT PARAMETRE_ID,SEVIYE_ADI,UST_SEVIYE_ID, SEVIYE FROM PARAMETRE WHERE UST_SEVIYE_ID=" + parentId + " AND AKTIF=1 ORDER BY SEVIYE_ADI";
            DataTable dt = new DataTable();
            dt = manager.BasitSorguDT(Sequel, analizConStr);
            //TreeNode childNode;
            nodMuyum = false;
            foreach (DataRow dr in dt.Rows)
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

        private void btnIptal_Click(object sender, EventArgs e)
        {            
            Manager.NodId = Manager.NodTasi;
            Manager.NodTasi = null;
            this.Dispose();
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(treeView1.SelectedNode.FullPath.ToString());
            secCikisi = true;
            Manager.NodTasi = treeView1.SelectedNode.FullPath.ToString();
            Manager.NodId = txtPARAMETRE_ID.Text.ToString();
            this.Dispose();
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
            //MessageBox.Show(treeView1.SelectedNode.FullPath.ToString());

            if (oParentNode.FullPath.ToString() == aranan)
            {
                treeView1.SelectedNode = oParentNode;
                treeView1.SelectedNode.BackColor = Color.Blue;
            }
            // Start recursion on all subnodes.
            foreach (DataTreeNode oSubNode in oParentNode.Nodes)
            {
                ShowTreeNodesRecursive(oSubNode, aranan);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DataTreeNode node = (DataTreeNode)e.Node; // <--- Node DataTreeNode tipinde

            txtPARAMETRE_ID.DataBindings.Clear();
            txtSEVIYE_ADI.DataBindings.Clear();
            txtUST_SEVIYE_ID.DataBindings.Clear();
            txtSEVIYE.DataBindings.Clear();
            txtISPARENT.DataBindings.Clear();

            txtPARAMETRE_ID.DataBindings.Add("Text", node.Data, "PARAMETRE_ID");
            txtSEVIYE_ADI.DataBindings.Add("Text", node.Data, "SEVIYE_ADI");
            txtUST_SEVIYE_ID.DataBindings.Add("Text", node.Data, "UST_SEVIYE_ID");
            txtSEVIYE.DataBindings.Add("Text", node.Data, "SEVIYE");
            txtISPARENT.DataBindings.Add("Text", node.Data, "ISPARENT");
        }

        private void ParametreAgaci_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!secCikisi)
            {
                Manager.NodId = Manager.NodTasi;
                Manager.NodTasi = null;
            }
            this.Dispose();
        }

        //private void btnYolBul_Click(object sender, EventArgs e)
        //{
        //    string yol = manager.parametreTreeYolBul(txtId.Text.ToString());
        //    //MessageBox.Show(yol);
        //    //nodeBul(yol);
        //}
    }
}
