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
    public partial class Adresler : Form
    {
        Manager manager = new Manager();
        DataTable adresler = new DataTable();
        string analizConStr = "";
        string wolVoxConStr = "";
        bool basladi = false;


        public Adresler()
        {
            InitializeComponent();
            analizConStr = manager.conStrAnaliz;
            wolVoxConStr = manager.conStrWolvox;
        }

        private void Adresler_Load(object sender, EventArgs e)
        {
            txtCariId.Text = Manager.CariIdTasi.ToString();
            adresYukle();

            cmbILDoldur();
            basladi = true;
            cmbIlceDoldur();
            cmbUlkeDoldur();
        }

        public void cmbUlkeDoldur()
        {
            cmbUlke.DataSource = manager.GetDataTableFull("PARAMETRE", "UST_SEVIYE_ID=95", analizConStr);
            cmbUlke.DisplayMember = "SEVIYE_ADI";
            cmbUlke.ValueMember = "PARAMETRE_ID";
            cmbUlke.SelectedIndex = 182;
            cmbUlke.Refresh();
        }

        public void cmbILDoldur()
        {
            cmbIl.DataSource = manager.GetDataTableFull("PARAMETRE", "UST_SEVIYE_ID=2211", analizConStr);
            cmbIl.DisplayMember = "SEVIYE_ADI";
            cmbIl.ValueMember = "PARAMETRE_ID";
            cmbIl.SelectedIndex = 0;
            cmbIl.Refresh();
        }
        public void cmbIlceDoldur()
        { if (basladi)
            {
                cmbIlce.DataSource = manager.GetDataTableFull("PARAMETRE", "UST_SEVIYE_ID=" + cmbIl.SelectedValue.ToString(), analizConStr);
                cmbIlce.DisplayMember = "SEVIYE_ADI";
                cmbIlce.ValueMember = "PARAMETRE_ID";
                cmbIlce.SelectedIndex = 0;
                cmbIlce.Refresh();
            }
        }
        private void adresYukle()
        {
            string sql = "SELECT * FROM CARI_ADRES WHERE CARI_ID=" + Manager.CariIdTasi.ToString() ;
            
            adresler = manager.BasitSorguDT(sql, analizConStr);
            dgvAdresler.DataSource = adresler;
            dgvAdresler.Columns["CARI_ADRES_ID"].Visible = false;
            dgvAdresler.Columns["CARI_ID"].Visible = false;
            dgvAdresler.Columns["KAYIT_TARIHI"].Visible = false;
            dgvAdresler.Columns["KAYDEDEN"].Visible = false;
            dgvAdresler.Columns["GUNCELLEME_TARIHI"].Visible = false;
            dgvAdresler.Columns["GUNCELLEYEN"].Visible = false;

            dgvAdresler.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        private void dgvAdresler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAdresler.CurrentRow.Cells["CARI_ADRES_ID"].Value.ToString()=="")
            {
                return;
            }

            txtAdresId.Text = dgvAdresler.CurrentRow.Cells["CARI_ADRES_ID"].Value.ToString();
            //txtCariId.Text = dgvAdresler.CurrentRow.Cells["CARI_ID"].Value.ToString();
            txtBlkodu.Text = dgvAdresler.CurrentRow.Cells["BLKODU"].Value.ToString();
            txtAdres.Text = dgvAdresler.CurrentRow.Cells["ACIK_ARES"].Value.ToString();

            cmbIl.Text = dgvAdresler.CurrentRow.Cells["ADRES_IL"].Value.ToString();
            cmbIlce.Text = dgvAdresler.CurrentRow.Cells["ADRES_ILCE"].Value.ToString();

            cmbUlke.Text = dgvAdresler.CurrentRow.Cells["ADRES_ULKE"].Value.ToString();
            txtPostaKodu.Text = dgvAdresler.CurrentRow.Cells["POSTA_KODU"].Value.ToString();
            chkIletisimAdresiMi.Checked = false;
            if (dgvAdresler.CurrentRow.Cells["ILETISIM_ADRESI_MI"].Value.ToString()=="1") chkIletisimAdresiMi.Checked = true;
            txtKonumLAT.Text = dgvAdresler.CurrentRow.Cells["KONUM_LAT"].Value.ToString();
            txtKonumLNG.Text = dgvAdresler.CurrentRow.Cells["KONUM_LNG"].Value.ToString();
            chkAktif.Checked = false;
            if (dgvAdresler.CurrentRow.Cells["AKTIF"].Value.ToString() == "1") chkAktif.Checked = true;

        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("CARIADRES", "YENIKAYIT")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: CARIADRES - Yetki: YENIKAYIT)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtAdresId.Text = "0";
            //txtCariId.Text = "0";
            txtBlkodu.Text = "0";
            txtAdres.Text = "";
            cmbIlce.Text = "";
            cmbIl.Text = "";
            cmbUlke.Text = "";
            txtPostaKodu.Text = "";
            chkIletisimAdresiMi.Checked = false;
            txtKonumLAT.Text = "";
            txtKonumLNG.Text = "";
            chkAktif.Checked = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("CARIADRES", "KAYDET")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: CARIADRES - Yetki: KAYDET)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtCariId.Text.ToString()=="" || txtAdres.Text.ToString().Trim()=="")
            {
                return;
            }

            DataTable dtSonuc = new DataTable();
            dtSonuc = manager.GetDataTableFull("CARI_ADRES", "CARI_ADRES_ID=" + txtAdresId.Text.ToString(), analizConStr);
            bool kayitVar = true;
            if (dtSonuc.Rows.Count == 0)
            {
                dtSonuc.Rows.Add();
                kayitVar = false;
            }
            dtSonuc.Rows[0]["CARI_ID"] = txtCariId.Text.ToString();
            dtSonuc.Rows[0]["BLKODU"] = int.Parse(txtBlkodu.Text.ToString());
            dtSonuc.Rows[0]["ACIK_ARES"] = txtAdres.Text.ToString();
            dtSonuc.Rows[0]["ADRES_ILCE"] = cmbIlce.Text.ToString();
            dtSonuc.Rows[0]["ADRES_IL"] = cmbIl.Text.ToString();
            dtSonuc.Rows[0]["ADRES_ULKE"] = cmbUlke.Text.ToString();
            dtSonuc.Rows[0]["POSTA_KODU"] = txtPostaKodu.Text.ToString();
            dtSonuc.Rows[0]["ILETISIM_ADRESI_MI"] = chkIletisimAdresiMi.Checked;
            dtSonuc.Rows[0]["KONUM_LAT"] = txtKonumLAT.Text.ToString();
            dtSonuc.Rows[0]["KONUM_LNG"] = txtKonumLNG.Text.ToString();
            dtSonuc.Rows[0]["AKTIF"] = chkAktif.Checked;

            if (!kayitVar)
            {
                dtSonuc.Rows[0]["KAYDEDEN"] = Manager.KullaniciAdSoyad.ToString();
            }
            dtSonuc.Rows[0]["GUNCELLEYEN"] = Manager.KullaniciAdSoyad.ToString();

            int deger = int.Parse(txtAdresId.Text.ToString());

            // kaydetme if koşulu içinde oluyor
            if (manager.kaydetGuncelle("CARI_ADRES", "CARI_ADRES_ID", deger, dtSonuc, analizConStr))
            {
                adresYukle();
                MessageBox.Show("Kaydetme İşlemi Tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kaydetme İşleminde Hata. Kayıt Gerçekleşmedi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("CARIADRES", "SIL")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: CARIADRES - Yetki: SIL)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((dgvAdresler.Rows.Count > 0))
            {
                if (MessageBox.Show("Kaydı Silmek İstiyor Musunuz?", "Uyarı...", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    manager.Sil("CARI_ADRES", "CARI_ADRES_ID=" + txtAdresId.Text.ToString(), analizConStr);
                    adresYukle();
                }
            }
        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIlceDoldur();
        }
    }
}
