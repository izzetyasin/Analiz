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
    public partial class CariKart : Form
    {
        Manager manager = new Manager();
        string analizConStr = "";
        string wolVoxConStr = "";
        DataTable cariKartCariIdsorgu = new DataTable();
        string cariAdisoyadi = "";
        string cariTicariUnvani = "";

        public CariKart()
        {
            InitializeComponent();
            analizConStr = manager.conStrAnaliz;
            wolVoxConStr = manager.conStrWolvox;
        }

        private void btnAdresEkle_Click(object sender, EventArgs e)
        {
            if(txtCariId.Text=="0")
            {
                MessageBox.Show("Lütfen Bir Cari Seçiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("ADRESLER", "GIRIS")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: ADRESLER - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Manager.CariIdTasi = txtCariId.Text.ToString();
            Adresler adresler = new Adresler();
            //adresler.MdiParent = this;
            adresler.Text = "Adresler";
            adresler.ShowDialog();
        }

        private void btnGorusmeler_Click(object sender, EventArgs e)
        {
            if (txtCariId.Text == "0")
            {
                MessageBox.Show("Lütfen Bir Cari Seçiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("GORUSMELER", "GIRIS")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: GORUSMELER - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Manager.CariIdTasi = txtCariId.Text.ToString();
            Gorusmeler gorusmeler = new Gorusmeler();
            //adresler.MdiParent = this;
            string baslik = txtAdi.Text.ToString().Trim() + " " + txtSoyadi.Text.ToString().Trim() + " - " + txtTicariUnvani.Text.ToString().Trim();
            Manager.CariAdTasi = null;
            //Manager.CariAdTasi = baslik + "- Tel:" + txtCepTelefonu.Text.Trim();
            gorusmeler.Text = baslik;
            gorusmeler.ShowDialog();
        }

        private void btnCariGrubuBul_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("PARAMETREAGACI", "GIRIS")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: PARAMETREAGACI - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ParametreAgaci parametreAgaci = new ParametreAgaci();
            //parametreAgaci.MdiParent = this;
            if (txtCariGrubu.Text.ToString() == "0")
            {
                Manager.NodTasi = 8;
            }
            else
            {
                Manager.NodTasi = txtCariGrubu.Text.ToString();
            }

            parametreAgaci.Text = "Parametre Ağacı";
            parametreAgaci.ShowDialog();

            if (Manager.NodTasi != null)
            {
                //lblCariGrubu.Text = Manager.NodTasi.ToString();
                lblCariGrubu.Text = manager.parametreTreeYolBul(Manager.NodId.ToString());
                lblCariGrubu.Refresh();
                txtCariGrubu.Text = Manager.NodId.ToString();
            }
            

            ////MessageBox.Show(Manager.NodTasi.ToString());

            //string yol = manager.parametreTreeYolBul(txtCariGrubu.Text.ToString());
            //if (yol != null)
            //{
            //    lblCariGrubu.Text = yol;
            //}
            //else
            //{
            //    MessageBox.Show("Aranan Değer Bulunamadı!");
            //}
        }

        private void CariKart_Load(object sender, EventArgs e)
        {
            cmbDoldur();


            if (Manager.CariIdTasi != null)
            {
                txtCariId.Text = Manager.CariIdTasi.ToString();
                txtCariAra.Enabled = false;
                btnCariAra.Enabled = false;
                btnYeni.Enabled = false;
                txtCariKodu.Enabled = false;
                dgvCariListesi.Enabled = false;

                if (Manager.NodId != null)
                {
                    txtCariGrubu.Text = Manager.NodId.ToString();
                    lblCariGrubu.Text = manager.parametreTreeYolBul(Manager.NodId.ToString());
                }
                cariIdenBul();
            }
            else
            {
                txtCariId.Text = "0";
            }
        }
        public void cariIdenBul()
        {
            string sql = "SELECT * FROM CARI WHERE CARI_ID="+txtCariId.Text.ToString();
            //DataTable cariIdsorgu = new DataTable();
            cariKartCariIdsorgu = manager.BasitSorguDT(sql, analizConStr);
            cariEkrana();
            //dgvCariListesi.DataSource = sorgu;
            //dgvCariListesi.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

        }
        public void cariEkrana()
        {
            ekraniTemizle();

            txtCariKodu.Text = txtCariId.Text.ToString();
            txtAdi.Text = cariKartCariIdsorgu.Rows[0]["ADI"].ToString();
            txtSoyadi.Text = cariKartCariIdsorgu.Rows[0]["SOYADI"].ToString();

            lblCariGrubu.Text = manager.parametreTreeYolBul(cariKartCariIdsorgu.Rows[0]["GRUBU"].ToString());
            txtCariGrubu.Text = cariKartCariIdsorgu.Rows[0]["GRUBU"].ToString();

            txtTicariUnvani.Text = cariKartCariIdsorgu.Rows[0]["TICARI_UNVANI"].ToString();
            txtVergiDairesi.Text = cariKartCariIdsorgu.Rows[0]["VERGI_DAIRESI"].ToString();
            txtVergiNo.Text = cariKartCariIdsorgu.Rows[0]["VERGI_NO"].ToString();
            txtTCKimlikNo.Text = cariKartCariIdsorgu.Rows[0]["TC_KIMLIK_NO"].ToString();
            if (cariKartCariIdsorgu.Rows[0]["SEKTOR"] != null && cariKartCariIdsorgu.Rows[0]["SEKTOR"].ToString() != "")
            {
                cmbSektor.SelectedValue = cariKartCariIdsorgu.Rows[0]["SEKTOR"].ToString();
                cmbSektor.Refresh();
            }
            if (cariKartCariIdsorgu.Rows[0]["ARA_GRUBU"] != null && cariKartCariIdsorgu.Rows[0]["ARA_GRUBU"].ToString() != "")
            {
                cmbAraGrubu.SelectedValue = cariKartCariIdsorgu.Rows[0]["ARA_GRUBU"].ToString();
                cmbAraGrubu.Refresh();
            }
            if (cariKartCariIdsorgu.Rows[0]["ALT_GRUBU"] != null && cariKartCariIdsorgu.Rows[0]["ALT_GRUBU"].ToString() != "")
            {
                cmbAltGrubu.SelectedValue = cariKartCariIdsorgu.Rows[0]["ALT_GRUBU"].ToString();
                cmbAltGrubu.Refresh();
            }
            txtDogumYeri.Text = cariKartCariIdsorgu.Rows[0]["DOGUM_YERI"].ToString();

            if(cariKartCariIdsorgu.Rows[0]["DOGUM_TARIHI"].ToString()!="") txtDogumTarihi.Text = (DateTime.Parse(cariKartCariIdsorgu.Rows[0]["DOGUM_TARIHI"].ToString())).ToString("MM.dd.yyyy");

            if (cariKartCariIdsorgu.Rows[0]["UYRUGU"]!=null && cariKartCariIdsorgu.Rows[0]["UYRUGU"].ToString()!="") cmbUyrugu.SelectedValue = cariKartCariIdsorgu.Rows[0]["UYRUGU"].ToString();

            txtAnaadi.Text = cariKartCariIdsorgu.Rows[0]["ANA_ADI"].ToString();
            txtBabaAdi.Text = cariKartCariIdsorgu.Rows[0]["BABA_ADI"].ToString();
            if (cariKartCariIdsorgu.Rows[0]["MEDENI_HALI"] != null && cariKartCariIdsorgu.Rows[0]["MEDENI_HALI"].ToString() != "")
            {
                cmbMedeniHal.SelectedValue = cariKartCariIdsorgu.Rows[0]["MEDENI_HALI"].ToString();
                cmbMedeniHal.Refresh();
            }
            if (cariKartCariIdsorgu.Rows[0]["CINSIYETI"] != null && cariKartCariIdsorgu.Rows[0]["CINSIYETI"].ToString() != "")
            {
                cmbCinsiyet.SelectedValue = cariKartCariIdsorgu.Rows[0]["CINSIYETI"].ToString();
                cmbCinsiyet.Refresh();
            }
            if (cariKartCariIdsorgu.Rows[0]["MESLEGI"] != null && cariKartCariIdsorgu.Rows[0]["MESLEGI"].ToString() != "")
            {
                cmbMeslek.SelectedValue = cariKartCariIdsorgu.Rows[0]["MESLEGI"].ToString();
                cmbMeslek.Refresh();
            }
            if (cariKartCariIdsorgu.Rows[0]["ONCELIK_SEVIYE"] != null && cariKartCariIdsorgu.Rows[0]["ONCELIK_SEVIYE"].ToString() != "")
            {
                cmbOncelikSeviyesi.SelectedValue = cariKartCariIdsorgu.Rows[0]["ONCELIK_SEVIYE"].ToString();
                cmbOncelikSeviyesi.Refresh();
            }
            if (cariKartCariIdsorgu.Rows[0]["RISK_SEVIYESI"] != null && cariKartCariIdsorgu.Rows[0]["RISK_SEVIYESI"].ToString() != "")
            {
                cmbRiskSeviyesi.SelectedValue = cariKartCariIdsorgu.Rows[0]["RISK_SEVIYESI"].ToString();
                cmbRiskSeviyesi.Refresh();
            }
            if (cariKartCariIdsorgu.Rows[0]["ISKONTO_ORANI"] != null && cariKartCariIdsorgu.Rows[0]["ISKONTO_ORANI"].ToString() != "")
            {
                cmbIskontoOrani.SelectedValue = cariKartCariIdsorgu.Rows[0]["ISKONTO_ORANI"].ToString();
                cmbIskontoOrani.Refresh();
            }
            txtCepTelefonu.Text = cariKartCariIdsorgu.Rows[0]["CEP_TEL"].ToString();
            txtEvTelefonu.Text = cariKartCariIdsorgu.Rows[0]["EV_TEL"].ToString();
            txtFaks.Text = cariKartCariIdsorgu.Rows[0]["FAKS"].ToString();
            txtEkTelefon1.Text = cariKartCariIdsorgu.Rows[0]["TELEFON1"].ToString();
            txtEkTelefon2.Text = cariKartCariIdsorgu.Rows[0]["TELEFON2"].ToString();
            txtEmail1.Text = cariKartCariIdsorgu.Rows[0]["EMAIL1"].ToString();
            txtEmail2.Text = cariKartCariIdsorgu.Rows[0]["EMAIL2"].ToString();
            txtWebAdresi.Text = cariKartCariIdsorgu.Rows[0]["WEBADRESI"].ToString();
            txtBankaAdi1.Text = cariKartCariIdsorgu.Rows[0]["BANKA1"].ToString();
            txtBankaSube1.Text = cariKartCariIdsorgu.Rows[0]["BANKASUBE1"].ToString();
            txtHesapIban1.Text = cariKartCariIdsorgu.Rows[0]["BANKAHESAP1"].ToString();
            txtBankaAdi2.Text = cariKartCariIdsorgu.Rows[0]["BANKA2"].ToString();
            txtBankaSube2.Text = cariKartCariIdsorgu.Rows[0]["BANKASUBE2"].ToString();
            txtHesapIban2.Text = cariKartCariIdsorgu.Rows[0]["BANKAHESAP2"].ToString();
            txtKronikHastaliklar.Text = cariKartCariIdsorgu.Rows[0]["KRONIK_HASTALIK"].ToString();
            txtAciklama.Text = cariKartCariIdsorgu.Rows[0]["ACIKLAMA"].ToString();
            cariAdresGridDoldur();
            cariKisiDoldur();
            cariGorusmeDoldur();
        }

        public void cariGorusmeDoldur()
        {
            string sql = "SELECT * FROM CARI_GORUSMELER WHERE CARI_ID=" + txtCariId.Text.ToString() + " AND UST_GORUSME_ID=0";
            //string sql = "SELECT * FROM CARI_GORUSMELER WHERE CARI_ID=" + txtCariId.Text.ToString() ;

            DataTable dtGorusmeler = new DataTable();
            dtGorusmeler = manager.BasitSorguDT(sql, analizConStr);
            dgvGorusmeler.DataSource = dtGorusmeler;

            dgvGorusmeler.Columns["CARI_GORUSMELER_ID"].Visible = false;
            dgvGorusmeler.Columns["CARI_ID"].Visible = false;

            dgvGorusmeler.Columns["ILETISIM_SEKLI"].Visible = false;
            dgvGorusmeler.Columns["ILETISIM_TURU"].Visible = false;
            dgvGorusmeler.Columns["ILISKILI_FATURA_BLKODU"].Visible = false;
            dgvGorusmeler.Columns["GENEL_BILGILENDIRME_ID"].Visible = false;
            dgvGorusmeler.Columns["UST_GORUSME_ID"].Visible = false;

            dgvGorusmeler.Columns["AKTIF"].Visible = false;
            dgvGorusmeler.Columns["KAYIT_TARIHI"].Visible = false;
            dgvGorusmeler.Columns["KAYDEDEN"].Visible = false;
            dgvGorusmeler.Columns["GUNCELLEME_TARIHI"].Visible = false;
            dgvGorusmeler.Columns["GUNCELLEYEN"].Visible = false;

            dgvGorusmeler.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        public void cariAdresGridDoldur()
        {
            DataTable cariKartrCariAdresSor = new DataTable();
            string sql = "SELECT * FROM CARI_ADRES WHERE CARI_ID=" + txtCariId.Text.ToString();
            cariKartrCariAdresSor = manager.BasitSorguDT(sql, analizConStr);
            dgvAdresler.DataSource = cariKartrCariAdresSor;
            dgvAdresler.Columns["CARI_ADRES_ID"].Visible = false;
            dgvAdresler.Columns["CARI_ID"].Visible = false;
            dgvAdresler.Columns["KAYIT_TARIHI"].Visible = false;
            dgvAdresler.Columns["KAYDEDEN"].Visible = false;
            dgvAdresler.Columns["GUNCELLEME_TARIHI"].Visible = false;
            dgvAdresler.Columns["GUNCELLEYEN"].Visible = false;

            dgvAdresler.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

         public void cariKisiDoldur()
        {
            DataTable cariKartrCariKisiSor = new DataTable();
            string sql = "SELECT * FROM CARI_KISILER WHERE CARI_ID=" + txtCariId.Text.ToString();
            cariKartrCariKisiSor = manager.BasitSorguDT(sql, analizConStr);
            dgvKisiler.DataSource = cariKartrCariKisiSor;
            dgvKisiler.Columns["CARI_KISILER_ID"].Visible = false;
            dgvKisiler.Columns["CARI_ID"].Visible = false;
            dgvKisiler.Columns["KAYIT_TARIHI"].Visible = false;
            dgvKisiler.Columns["KAYDEDEN"].Visible = false;
            dgvKisiler.Columns["GUNCELLEME_TARIHI"].Visible = false;
            dgvKisiler.Columns["GUNCELLEYEN"].Visible = false;

            dgvKisiler.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        public void ekraniTemizle()
        {
            cmbDoldur();
            txtCariKodu.Text = "0";
            txtAdi.Text = "";
            txtSoyadi.Text = "";

            lblCariGrubu.Text = "...";
            txtCariGrubu.Text = "0";

            txtTicariUnvani.Text = "";
            txtVergiDairesi.Text = "";
            txtVergiNo.Text = "";
            txtTCKimlikNo.Text = "";
            txtDogumYeri.Text = "";
            txtDogumTarihi.Text = "";
            txtAnaadi.Text = "";
            txtBabaAdi.Text = "";
            txtCepTelefonu.Text = "";
            txtEvTelefonu.Text = "";
            txtFaks.Text = "";
            txtEkTelefon1.Text = "";
            txtEkTelefon2.Text = "";
            txtEmail1.Text = "";
            txtEmail2.Text = "";
            txtWebAdresi.Text = "";
            txtBankaAdi1.Text = "";
            txtBankaSube1.Text = "";
            txtHesapIban1.Text = "";
            txtBankaAdi2.Text = "";
            txtBankaSube2.Text = "";
            txtHesapIban2.Text = "";
            txtKronikHastaliklar.Text = "";
            txtAciklama.Text = "";
        }
        public void cmbDoldur()
        {
            cmbSektorDoldur();
            cmbUyruguDoldur();
            cmbMedeniHalDoldur();
            cmbCinsiyetDoldur();
            cmbMeslekDoldur();
            cmbOncelikSeviyesiDoldur();
            cmbRiskSeviyesiDoldur();
            cmbIskontoOraniDoldur();
        }
        public void cmbMeslekDoldur()
        {
            cmbMeslek.DataSource = manager.GetDataTableFull("PARAMETRE", "UST_SEVIYE_ID=58", analizConStr);
            cmbMeslek.DisplayMember = "SEVIYE_ADI";
            cmbMeslek.ValueMember = "PARAMETRE_ID";
            cmbMeslek.SelectedIndex = 0;
            cmbMeslek.Refresh();
        }
        public void cmbSektorDoldur()
        {
            cmbSektor.DataSource = manager.GetDataTableFull("PARAMETRE", "UST_SEVIYE_ID=66", analizConStr);
            cmbSektor.DisplayMember = "SEVIYE_ADI";
            cmbSektor.ValueMember = "PARAMETRE_ID";
            cmbSektor.SelectedIndex = 27;
            cmbSektor.Refresh();
        }
        public void cmbUyruguDoldur()
        {
            cmbUyrugu.DataSource = manager.GetDataTableFull("PARAMETRE", "UST_SEVIYE_ID=95", analizConStr);
            cmbUyrugu.DisplayMember = "SEVIYE_ADI";
            cmbUyrugu.ValueMember = "PARAMETRE_ID";
            cmbUyrugu.SelectedIndex = 0;
            cmbUyrugu.Refresh();
        }
        public void cmbMedeniHalDoldur()
        {
            cmbMedeniHal.DataSource = manager.GetDataTableFull("PARAMETRE", "UST_SEVIYE_ID=39", analizConStr);
            cmbMedeniHal.DisplayMember = "SEVIYE_ADI";
            cmbMedeniHal.ValueMember = "PARAMETRE_ID";
            cmbMedeniHal.SelectedIndex = 1;
            cmbMedeniHal.Refresh();
        }
        public void cmbCinsiyetDoldur()
        {
            cmbCinsiyet.DataSource = manager.GetDataTableFull("PARAMETRE", "UST_SEVIYE_ID=44", analizConStr);
            cmbCinsiyet.DisplayMember = "SEVIYE_ADI";
            cmbCinsiyet.ValueMember = "PARAMETRE_ID";
            cmbCinsiyet.SelectedIndex = 3;
            cmbCinsiyet.Refresh();
        }
        public void cmbOncelikSeviyesiDoldur()
        {
            cmbOncelikSeviyesi.DataSource = manager.GetDataTableFull("PARAMETRE", "UST_SEVIYE_ID=16", analizConStr);
            cmbOncelikSeviyesi.DisplayMember = "SEVIYE_ADI";
            cmbOncelikSeviyesi.ValueMember = "PARAMETRE_ID";
            cmbOncelikSeviyesi.SelectedIndex = 0;
            cmbOncelikSeviyesi.Refresh();
        }
        public void cmbRiskSeviyesiDoldur()
        {
            cmbRiskSeviyesi.DataSource = manager.GetDataTableFull("PARAMETRE", "UST_SEVIYE_ID=16", analizConStr);
            cmbRiskSeviyesi.DisplayMember = "SEVIYE_ADI";
            cmbRiskSeviyesi.ValueMember = "PARAMETRE_ID";
            cmbRiskSeviyesi.SelectedIndex = 0;
            cmbRiskSeviyesi.Refresh();
        }
        public void cmbIskontoOraniDoldur()
        {
            cmbIskontoOrani.DataSource = manager.GetDataTableFull("PARAMETRE", "UST_SEVIYE_ID=101", analizConStr);
            cmbIskontoOrani.DisplayMember = "SEVIYE_ADI";
            cmbIskontoOrani.ValueMember = "PARAMETRE_ID";
            cmbIskontoOrani.SelectedIndex = 0;
            cmbIskontoOrani.Refresh();
        }

        private void btnCariAra_Click(object sender, EventArgs e)
        {
            cariBul();
        }

        private void txtCariAra_TextChanged(object sender, EventArgs e)
        {
            cariBul();
        }

        public void cariBul()
        {
            string sql = "SELECT ADI_SOYADI, TICARI_UNVANI FROM CARI " +
                        "WHERE (UPPER(ADI_SOYADI) LIKE('%" + txtCariAra.Text.ToUpper() + "%') OR UPPER(TICARI_UNVANI) LIKE('%" + txtCariAra.Text.ToUpper() + "%') " +
                        "OR CEP_TEL LIKE('%" + txtCariAra.Text + "%') OR TELEFON1 LIKE('%" + txtCariAra.Text + "%') " +
                        "OR TELEFON2 LIKE('%" + txtCariAra.Text + "%') OR EV_TEL LIKE('%" + txtCariAra.Text + "%')) " +
                        "GROUP BY ADI_SOYADI, TICARI_UNVANI ORDER BY ADI_SOYADI, TICARI_UNVANI";
            DataTable cariKartSorgu = new DataTable();
            cariKartSorgu = manager.BasitSorguDT(sql, analizConStr);
            dgvCariListesi.DataSource = cariKartSorgu;
            dgvCariListesi.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

        }

        private void dgvCariListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cariAdisoyadi = dgvCariListesi.CurrentRow.Cells[0].Value.ToString();
            cariTicariUnvani = dgvCariListesi.CurrentRow.Cells[1].Value.ToString();

            //if (cariAdisoyadi == "")
            //{
            //    cariAdisoyadi = "";
            //}
            //if (cariTicariUnvani == "=''")
            //{
            //    cariTicariUnvani = " IS NULL ";
            //}

            if (cariAdisoyadi=="" && cariTicariUnvani == "")
            {
                return;
            }

            string sql = "SELECT CARI_ID " +
             "FROM CARI " +
             "WHERE ADI_SOYADI ='" + cariAdisoyadi + "' AND (TICARI_UNVANI = '" + cariTicariUnvani + "' OR TICARI_UNVANI IS NULL)" +
             "ORDER BY ADI_SOYADI, TICARI_UNVANI";

            DataTable cariKartCariSor = new DataTable();
            cariKartCariSor = manager.BasitSorguDT(sql, analizConStr);
            txtCariId.Text = cariKartCariSor.Rows[0]["CARI_ID"].ToString();
            cariIdenBul();
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("CARIKART", "YENIKAYIT")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: CARIKART - Yetki: YENIKAYIT)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ekraniTemizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("CARIKART", "KAYDET")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: CARIKART - Yetki: KAYDET)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtAdi.Text.ToString().Trim() == "" && txtTicariUnvani.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Cari Adı ve Ticari Ünvanı Aynı Anda Boş Olamaz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            kontroller();

            DataTable cariKartDtSonuc = new DataTable();
            cariKartDtSonuc = manager.GetDataTableFull("CARI", "CARI_ID=" + txtCariId.Text.ToString(), analizConStr);
            bool kayitVar = true;
            if (cariKartDtSonuc.Rows.Count == 0)
            {
                cariKartDtSonuc.Rows.Add();
                kayitVar = false;
            }

            //cariKartDtSonuc.Rows[0]["CARI_KODU"] = txtCariId.Text.ToString();
            cariKartDtSonuc.Rows[0]["ADI"] = txtAdi.Text.ToString();
            cariKartDtSonuc.Rows[0]["SOYADI"] = txtSoyadi.Text.ToString();
            cariKartDtSonuc.Rows[0]["ADI_SOYADI"] = txtAdi.Text.ToString()+" "+txtSoyadi.Text.ToString();
            cariKartDtSonuc.Rows[0]["TICARI_UNVANI"] = txtTicariUnvani.Text.ToString();
            cariKartDtSonuc.Rows[0]["GRUBU"] = int.Parse(txtCariGrubu.Text.ToString());
            cariKartDtSonuc.Rows[0]["VERGI_DAIRESI"] = txtVergiDairesi.Text.ToString();
            cariKartDtSonuc.Rows[0]["VERGI_NO"] = txtVergiNo.Text.ToString();
            cariKartDtSonuc.Rows[0]["TC_KIMLIK_NO"] = txtTCKimlikNo.Text.ToString();

            if(cmbSektor.SelectedValue != null) cariKartDtSonuc.Rows[0]["SEKTOR"] = cmbSektor.SelectedValue;
            if(cmbAraGrubu.SelectedValue != null) cariKartDtSonuc.Rows[0]["ARA_GRUBU"] = cmbAraGrubu.SelectedValue;
            if(cmbAltGrubu.SelectedValue != null) cariKartDtSonuc.Rows[0]["ALT_GRUBU"] = cmbAltGrubu.SelectedValue;

            cariKartDtSonuc.Rows[0]["DOGUM_YERI"] = txtDogumYeri.Text.ToString();

            try
            {
                cariKartDtSonuc.Rows[0]["DOGUM_TARIHI"] = txtDogumTarihi.Text.ToString();
            }
            catch (Exception)
            {
            }

            if (cmbUyrugu.SelectedValue != null) cariKartDtSonuc.Rows[0]["UYRUGU"] = cmbUyrugu.SelectedValue;
            cariKartDtSonuc.Rows[0]["ANA_ADI"] = txtAnaadi.Text.ToString();
            cariKartDtSonuc.Rows[0]["BABA_ADI"] = txtBabaAdi.Text.ToString();
            if (cmbMedeniHal.SelectedValue != null) cariKartDtSonuc.Rows[0]["MEDENI_HALI"] = cmbMedeniHal.SelectedValue;
            if (cmbCinsiyet.SelectedValue != null) cariKartDtSonuc.Rows[0]["CINSIYETI"] = cmbCinsiyet.SelectedValue;
            if (cmbMeslek.SelectedValue != null) cariKartDtSonuc.Rows[0]["MESLEGI"] = cmbMeslek.SelectedValue;
            if (cmbOncelikSeviyesi.SelectedValue != null) cariKartDtSonuc.Rows[0]["ONCELIK_SEVIYE"] = cmbOncelikSeviyesi.SelectedValue;
            if (cmbRiskSeviyesi.SelectedValue != null) cariKartDtSonuc.Rows[0]["RISK_SEVIYESI"] = cmbRiskSeviyesi.SelectedValue;
            if (cmbIskontoOrani.SelectedValue != null) cariKartDtSonuc.Rows[0]["ISKONTO_ORANI"] = cmbIskontoOrani.SelectedValue;
            cariKartDtSonuc.Rows[0]["CEP_TEL"] = txtCepTelefonu.Text.ToString();
            cariKartDtSonuc.Rows[0]["EV_TEL"] = txtCepTelefonu.Text.ToString();
            cariKartDtSonuc.Rows[0]["FAKS"] = txtFaks.Text.ToString();
            cariKartDtSonuc.Rows[0]["TELEFON1"] = txtEkTelefon1.Text.ToString();
            cariKartDtSonuc.Rows[0]["TELEFON2"] = txtEkTelefon2.Text.ToString();
            cariKartDtSonuc.Rows[0]["EMAIL1"] = txtEmail1.Text.ToString();
            cariKartDtSonuc.Rows[0]["EMAIL2"] = txtEmail2.Text.ToString();
            cariKartDtSonuc.Rows[0]["WEBADRESI"] = txtWebAdresi.Text.ToString();
            cariKartDtSonuc.Rows[0]["BANKA1"] = txtBankaAdi1.Text.ToString();
            cariKartDtSonuc.Rows[0]["BANKASUBE1"] = txtBankaSube1.Text.ToString();
            cariKartDtSonuc.Rows[0]["BANKAHESAP1"] = txtHesapIban1.Text.ToString();
            cariKartDtSonuc.Rows[0]["BANKA2"] = txtBankaAdi1.Text.ToString();
            cariKartDtSonuc.Rows[0]["BANKASUBE2"] = txtBankaSube1.Text.ToString();
            cariKartDtSonuc.Rows[0]["BANKAHESAP2"] = txtHesapIban1.Text.ToString();
            cariKartDtSonuc.Rows[0]["KRONIK_HASTALIK"] = txtKronikHastaliklar.Text.ToString();
            cariKartDtSonuc.Rows[0]["ACIKLAMA"] = txtAciklama.Text.ToString();

            if (!kayitVar)
            {
                cariKartDtSonuc.Rows[0]["KAYDEDEN"] = Manager.KullaniciAdSoyad.ToString();
            }
            cariKartDtSonuc.Rows[0]["GUNCELLEYEN"] = Manager.KullaniciAdSoyad.ToString();

            int deger = int.Parse(txtCariId.Text.ToString());

            // kaydetme if koşulu içinde oluyor
            if (manager.kaydetGuncelle("CARI", "CARI_ID", deger, cariKartDtSonuc, analizConStr))
            {
                cariKartDtSonuc = manager.GetDataTableFull("CARI", "CARI_ID=" + txtCariId.Text.ToString(), analizConStr);
                //GridEkrana(0);
                MessageBox.Show("Kaydetme İşlemi Tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnKaydet.Text = "Kaydet";
            }
            else
            {
                MessageBox.Show("Kaydetme İşleminde Hata. Kayıt Gerçekleşmedi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            cariBul();
        }

        public bool kontroller()
        {
            try
            {
                DateTime.Parse(txtDogumTarihi.Text.ToString());
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Lütfen Doğum Tarihini Kontrol Ediniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
            
        }

        private void btnKisiler_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("KISILER", "GIRIS")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: KISILER - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Kisiler kisiler = new Kisiler();
            //parametreAgaci.MdiParent = this;
            Manager.CariIdTasi = txtCariId.Text.ToString();
            kisiler.Text = "Kişiler";
            kisiler.Show();
        }
    }
}
