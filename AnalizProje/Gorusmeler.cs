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
    public partial class Gorusmeler : Form
    {
        Manager manager = new Manager();
        string analizConStr = "";
        string wolVoxConStr = "";
        int gorusmeTipi = 0;
        public Gorusmeler()
        {
            InitializeComponent();
            analizConStr = manager.conStrAnaliz;
            wolVoxConStr = manager.conStrWolvox;
        }

        private void Gorusmeler_Load(object sender, EventArgs e)
        {
            txtCariId.Text = Manager.CariIdTasi.ToString();

            DataTable cariBilgi = new DataTable();
            string sql = "SELECT * FROM CARI WHERE CARI_ID=" + txtCariId.Text.ToString();

            cariBilgi = manager.BasitSorguDT(sql, analizConStr);

            lblBaslik.Text = cariBilgi.Rows[0]["ADI"].ToString().Trim()+" " + cariBilgi.Rows[0]["SOYADI"].ToString().Trim() + " - " + cariBilgi.Rows[0]["TICARI_UNVANI"].ToString().Trim()+"- Tel:" + cariBilgi.Rows[0]["CEP_TEL"].ToString().Trim();

            txtGorusmeTarihi.Text = DateTime.Now.ToString("dd.MM.yyyy");
            //txtDonusTarihi.Text = DateTime.Now.ToString("dd.MM.yyyy");

            grpGeriDonus.Enabled = false;
            //lblBaslik.Text = Manager.CariAdTasi.ToString();
            cmbDoldur();
            faturalariBul();
            gorusmeDoldur();
            if (Manager.VeriTasi != null)
            {
                gorusmeTipi = 1;
            }
        }
        public void cmbDoldur()
        {
            cmbKisilerGorusmeDoldur();
            cmbKisilerGeriDonusDoldur();
            cmbIlkletisimSekliDoldur();
            cmbDonusIletisimSekliDoldur();

        }
        public void gorusmeDoldur()
        {
            string sql = "SELECT * FROM CARI_GORUSMELER WHERE CARI_ID="+txtCariId.Text.ToString()+" AND UST_GORUSME_ID=0 ";
            if(Manager.VeriTasi!=null)
            {
                sql = sql + "AND CARI_GORUSMELER_ID=" + Manager.VeriTasi.ToString();
            }
            //string sql = "SELECT * FROM CARI_GORUSMELER WHERE CARI_ID=" + txtCariId.Text.ToString() ;

            DataTable dtGorusmeler = new DataTable();
            dtGorusmeler = manager.BasitSorguDT(sql, analizConStr);
            dgvGorusmeler.DataSource = dtGorusmeler;

            //dgvGorusmeler.Columns["CARI_GORUSMELER_ID"].Visible = false;
            dgvGorusmeler.Columns["CARI_ID"].Visible = false;

            dgvGorusmeler.Columns["GERI_DONUS"].Visible = false;
            dgvGorusmeler.Columns["GORUSULEN_KISI"].Visible = false;
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

            if (Manager.VeriTasi != null)
            {
                txtDonusTarihi.Text = DateTime.Now.ToString("dd.MM.yyyy");
                gorusmelerDolsur();
            }
        }

        public void faturalariBul()
        {
            txtFaturaId.Text = "0";
            txtFaturaBlKodu.Text = "0";
            txtFaturaIletimTarihi.Text = "";
            txtSeciliFaturaBilgi.Text = "";
            txtSeciliKargoBilgi.Text = "";

            DataTable faturaSor = new DataTable();

            string sql = "SELECT BLKODU FROM CARI_ALT WHERE CARI_ID=" + txtCariId.Text.ToString();
            faturaSor = manager.BasitSorguDT(sql, analizConStr);
            if (faturaSor.Rows.Count==0)
            { return; }

            string cariKriteri = "";

            for (int i = 0; i < faturaSor.Rows.Count; i++)
            {
                cariKriteri = cariKriteri+faturaSor.Rows[i]["BLKODU"].ToString()+",";
            }
            cariKriteri = cariKriteri + "0";



            DataTable kayitliFaturaSor = new DataTable();

            sql = "SELECT FATURA_BLKODU FROM CARI_FATURALAR WHERE CARI_ID=" + txtCariId.Text.ToString();
            kayitliFaturaSor = manager.BasitSorguDT(sql, analizConStr);
            if (faturaSor.Rows.Count == 0)
            { return; }

            string faturaKriteri = "";

            if (chkSadeceIletilmeyenler.Checked)
            {
               for (int i = 0; i < kayitliFaturaSor.Rows.Count; i++)
                {
                    faturaKriteri = faturaKriteri + kayitliFaturaSor.Rows[i]["FATURA_BLKODU"].ToString() + ",";
                }
                faturaKriteri = "AND BLKODU NOT IN("+faturaKriteri + "0)";
            }

            sql = "SELECT " +
                "BLKODU, TARIHI, FATURA_NO, FATURA_SERI, TOPLAM_GENEL_KPB,TOPLAM_ALT_KPB, TOPLAM_KDV_KPB, KARGO_FIRMASI, KARGO_NO, FATURA_KESILDI,  " +
                "BLCRKODU, SEVK_ADRESI, SEVK_ILI, SEVK_ILCESI, SEVK_ULKESI ,BLKODU " +
                "FROM FATURA " +
                "WHERE SILINDI=0 AND BLCRKODU IN ("+cariKriteri+") "+ faturaKriteri+
                " ORDER BY TARIHI DESC, FATURA_NO";

            faturaSor = new DataTable();
            faturaSor = manager.BasitSorguDT(sql, wolVoxConStr);
            dgvFaturalar.DataSource = faturaSor;
            dgvFaturalar.Columns["BLKODU"].Visible = false;
            dgvFaturalar.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

        }

        public void cmbIlkletisimSekliDoldur()
        {
            cmbIlkletisimSekli.DataSource = manager.GetDataTableFull("PARAMETRE", "UST_SEVIYE_ID=105", analizConStr);
            cmbIlkletisimSekli.DisplayMember = "SEVIYE_ADI";
            cmbIlkletisimSekli.ValueMember = "PARAMETRE_ID";
            cmbIlkletisimSekli.SelectedIndex = 0;
            cmbIlkletisimSekli.Refresh();
        }

        public void cmbDonusIletisimSekliDoldur()
        {
            cmbDonusIletisimSekli.DataSource = manager.GetDataTableFull("PARAMETRE", "UST_SEVIYE_ID=105", analizConStr);
            cmbDonusIletisimSekli.DisplayMember = "SEVIYE_ADI";
            cmbDonusIletisimSekli.ValueMember = "PARAMETRE_ID";
            cmbDonusIletisimSekli.SelectedIndex = 0;
            cmbDonusIletisimSekli.Refresh();
        }

        public void cmbKisilerGorusmeDoldur()
        {
            DataTable dtKisilerGorusme = new DataTable();

            dtKisilerGorusme = manager.GetDataTableFull(" CARI_KISILER ", " CARI_KISILER_ID, ADI||' '||SOYADI AS ADI_SOYADI ", "CARI_ID=" + txtCariId.Text.ToString(), "ADI", analizConStr);

            if (dtKisilerGorusme.Rows.Count==0)
            {
                cmbKisilerGorusme.DataSource = null;
                cmbKisilerGorusme.Enabled = false;
                btnKisiEkle1.Enabled = false;
                return;
            }
            cmbKisilerGorusme.DataSource = dtKisilerGorusme;
            cmbKisilerGorusme.DisplayMember = "ADI_SOYADI";
            cmbKisilerGorusme.ValueMember = "CARI_KISILER_ID";
            cmbKisilerGorusme.SelectedIndex = 0;
            cmbKisilerGorusme.Refresh();
        }

        public void cmbKisilerGeriDonusDoldur()
        {
            DataTable dtKisilerGeriDonus = new DataTable();

            dtKisilerGeriDonus = manager.GetDataTableFull(" CARI_KISILER ", " CARI_KISILER_ID, ADI||' '||SOYADI AS ADI_SOYADI ", "CARI_ID=" + txtCariId.Text.ToString(), "ADI", analizConStr);

            if (dtKisilerGeriDonus.Rows.Count == 0)
            {
                cmbKisilerGeriDonus.DataSource = null;
                cmbKisilerGeriDonus.Enabled = false;
                btnKisiEkle2.Enabled = false;
                return;
            }
            cmbKisilerGeriDonus.DataSource = dtKisilerGeriDonus;
            cmbKisilerGeriDonus.DisplayMember = "ADI_SOYADI";
            cmbKisilerGeriDonus.ValueMember = "CARI_KISILER_ID";
            cmbKisilerGeriDonus.SelectedIndex = 0;
            cmbKisilerGeriDonus.Refresh();
        }

        private void btnIlkIletisismTuru_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("PARAMETREAGACI", "GIRIS")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: PARAMETREAGACI - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ParametreAgaci parametreAgaci = new ParametreAgaci();
            //parametreAgaci.MdiParent = this;
            if (txtIlkAramaIletisimTuruId.Text.ToString() == "0")
            {
                Manager.NodTasi = 109;
            }
            else
            {
                Manager.NodTasi = txtIlkAramaIletisimTuruId.Text.ToString();
            }

            parametreAgaci.Text = "Parametre Ağacı";
            parametreAgaci.ShowDialog();

            if (Manager.NodTasi != null)
            {
                //lblCariGrubu.Text = Manager.NodTasi.ToString();
                //lbllkAramaIletisimSekli.Text = manager.parametreTreeYolBul(Manager.NodId.ToString());
                txtGorusmeTuru.Text = manager.parametreTreeYolBul(Manager.NodId.ToString());
                txtIlkAramaIletisimTuruId.Text = Manager.NodId.ToString();
            }
        }

        private void btnGenelBilgilendirme_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("PARAMETREAGACI", "GIRIS")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: PARAMETREAGACI - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ParametreAgaci parametreAgaci = new ParametreAgaci();
            //parametreAgaci.MdiParent = this;
            if (txtGenelBilgilendirmeId.Text.ToString() == "0")
            {
                Manager.NodTasi = 166;
            }
            else
            {
                Manager.NodTasi = txtGenelBilgilendirmeId.Text.ToString();
            }

            parametreAgaci.Text = "Parametre Ağacı";
            parametreAgaci.ShowDialog();

            if (Manager.NodTasi != null)
            {
                //lblCariGrubu.Text = Manager.NodTasi.ToString();
                //lblGenelBilgilendirme.Text = manager.parametreTreeYolBul(Manager.NodId.ToString());
                txtGenelBilgilendirme.Text = manager.parametreTreeYolBul(Manager.NodId.ToString());
                txtGenelBilgilendirmeId.Text = Manager.NodId.ToString();
            }
        }

        private void btnDonusIletisimSekli_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("PARAMETREAGACI", "GIRIS")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: PARAMETREAGACI - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ParametreAgaci parametreAgaci = new ParametreAgaci();
            //parametreAgaci.MdiParent = this;
            if (txtGeriDonusIletisimTuruId.Text.ToString() == "0")
            {
                Manager.NodTasi = 109;
            }
            else
            {
                Manager.NodTasi = txtGeriDonusIletisimTuruId.Text.ToString();
            }

            parametreAgaci.Text = "Parametre Ağacı";
            parametreAgaci.ShowDialog();

            if (Manager.NodTasi != null)
            {
                //lblCariGrubu.Text = Manager.NodTasi.ToString();
                //lblDonusTuru.Text = manager.parametreTreeYolBul(Manager.NodId.ToString());
                txtGeriDonusIletisimTuruId.Text = Manager.NodId.ToString();
                txtDonusTuru.Text = manager.parametreTreeYolBul(Manager.NodId.ToString());
            }
        }

        public void kisiEkle()
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
            cmbKisilerGorusmeDoldur();
            cmbKisilerGeriDonusDoldur();
        }

        private void btnKisiEkle1_Click(object sender, EventArgs e)
        {
            kisiEkle();
        }

        private void btnKisiEkle2_Click(object sender, EventArgs e)
        {
            kisiEkle();
        }

        private void dgvFaturalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            faturaDetayBul();
        }

        public void faturaDetayBul()
        {
            txtFaturaBlKodu.Text = dgvFaturalar.CurrentRow.Cells["BLKODU"].Value.ToString();
            txtSeciliFaturaBilgi.Text = dgvFaturalar.CurrentRow.Cells["TARIHI"].Value.ToString()+" / "+ 
                                        dgvFaturalar.CurrentRow.Cells["FATURA_NO"].Value.ToString()+ " / " +
                                        dgvFaturalar.CurrentRow.Cells["FATURA_SERI"].Value.ToString();
            txtSeciliKargoBilgi.Text = dgvFaturalar.CurrentRow.Cells["KARGO_NO"].Value.ToString();

            DataTable faturaDetaySor = new DataTable();
            string sql = "SELECT " +
                "FATURAHR.MIKTARI,FATURAHR.BIRIMI, FATURAHR.STOK_ADI,FATURAHR.KPB_FIYATI,FATURAHR.KPB_KDVLI_TUTAR,FATURA.TOPLAM_ALT_KPB, " +
                "FATURAHR.EVRAK_NO, FATURAHR.BLSTKODU, FATURAHR.KDV_TUTARI, FATURAHR.SIRA_NO," +
                "FATURAHR.KPB_KDV_HARICFY, FATURAHR.KPB_IND_FIYAT, FATURAHR.KPB_IND_TUTAR, FATURAHR.KPB_TOPLAM_TUTAR,  " +
                "FATURAHR.EKBILGI_1, FATURAHR.EKBILGI_2 " +
                "FROM FATURA ,FATURAHR " +
                "WHERE FATURAHR.BLFTKODU = FATURA.BLKODU AND FATURA.BLKODU="+ dgvFaturalar.CurrentRow.Cells["BLKODU"].Value.ToString()+" "+
                "ORDER BY FATURA.TARIHI DESC, FATURA.FATURA_NO, FATURAHR.SIRA_NO";

            faturaDetaySor = new DataTable();
            faturaDetaySor = manager.BasitSorguDT(sql, wolVoxConStr);
            dgvFaturaDetaylar.DataSource = faturaDetaySor;
            dgvFaturaDetaylar.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            DataTable onayBul = new DataTable();
            sql = "SELECT * FROM CARI_FATURALAR WHERE FATURA_BLKODU="+txtFaturaBlKodu.Text.ToString();
            onayBul = manager.BasitSorguDT(sql, analizConStr);
            if (onayBul.Rows.Count>0)
            {
                txtFaturaIletimTarihi.Text = onayBul.Rows[0]["ILETIM_ONAY_TARIHI"].ToString();
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("GORUSMELER", "KAYDET")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: GORUSMELER - Yetki: KAYDET)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (gorusmeTipi==0)
            {
                if(txtGorusmeNotu.Text.ToString().Trim()=="")
                {
                    MessageBox.Show("Görüşme İçeriği Girmelisiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtIlkAramaIletisimTuruId.Text.ToString() == "0")
                {
                    MessageBox.Show("İletişim Türü Seçmelisiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                DataTable dtIlkGorusmelerSonuc = new DataTable();
                dtIlkGorusmelerSonuc = manager.GetDataTableFull("CARI_GORUSMELER", "CARI_GORUSMELER_ID=" + txtIlkGorusmelerId.Text.ToString(), analizConStr);
                bool kayitVar = true;
                if (dtIlkGorusmelerSonuc.Rows.Count == 0)
                {
                    dtIlkGorusmelerSonuc.Rows.Add();
                    kayitVar = false;
                }
                dtIlkGorusmelerSonuc.Rows[0]["CARI_GORUSMELER_ID"] = txtIlkGorusmelerId.Text.ToString();
                dtIlkGorusmelerSonuc.Rows[0]["CARI_ID"] = txtCariId.Text.ToString();
                dtIlkGorusmelerSonuc.Rows[0]["ILETISIM_SEKLI"] = cmbIlkletisimSekli.SelectedValue;
                dtIlkGorusmelerSonuc.Rows[0]["ILETISIM_TURU"] = txtIlkAramaIletisimTuruId.Text.ToString();
                try
                {
                    dtIlkGorusmelerSonuc.Rows[0]["GORUSME_TARIHI"] = txtGorusmeTarihi.Text.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                dtIlkGorusmelerSonuc.Rows[0]["GORUSME_ICERIGI"] = txtGorusmeNotu.Text.ToString();

                if (chkFaturaIleIliskilendir.Checked)
                {
                    dtIlkGorusmelerSonuc.Rows[0]["ILISKILI_FATURA_BLKODU"] = int.Parse(txtFaturaBlKodu.Text.ToString());
                    dtIlkGorusmelerSonuc.Rows[0]["GORUSME_ICERIGI"] = dtIlkGorusmelerSonuc.Rows[0]["GORUSME_ICERIGI"].ToString() + " (Fatura Bilgileri : " + txtSeciliFaturaBilgi.Text.ToString() + ")";
                }
                
                dtIlkGorusmelerSonuc.Rows[0]["GERI_DONUS"] = chkGeriDonusYapilacak.Checked;
                dtIlkGorusmelerSonuc.Rows[0]["UZMAN_ARAMASI"] = chkUzmanAramasi.Checked;
                dtIlkGorusmelerSonuc.Rows[0]["GORUSULEN_KISI"] = cmbKisilerGorusme.Text.ToString();
                if(txtGenelBilgilendirmeId.Text!="0") dtIlkGorusmelerSonuc.Rows[0]["GENEL_BILGILENDIRME_ID"] = txtGenelBilgilendirmeId.Text.ToString();
                dtIlkGorusmelerSonuc.Rows[0]["UST_GORUSME_ID"] =0 ;

                

                if (!kayitVar)
                {
                    dtIlkGorusmelerSonuc.Rows[0]["KAYDEDEN"] = Manager.KullaniciAdSoyad.ToString();
                }
                dtIlkGorusmelerSonuc.Rows[0]["GUNCELLEYEN"] = Manager.KullaniciAdSoyad.ToString();

                int deger = int.Parse(txtIlkGorusmelerId.Text.ToString());

                // kaydetme if koşulu içinde oluyor
                if (manager.kaydetGuncelle("CARI_GORUSMELER", "CARI_GORUSMELER_ID", deger, dtIlkGorusmelerSonuc, analizConStr))
                {
                    gorusmeDoldur();
                    MessageBox.Show("Kaydetme İşlemi Tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kaydetme İşleminde Hata. Kayıt Gerçekleşmedi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (txtGeriDonusNotu.Text.ToString().Trim() == "")
                {
                    MessageBox.Show("Görüşme İçeriği Girmelisiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtGeriDonusIletisimTuruId.Text.ToString() == "0")
                {
                    MessageBox.Show("İletişim Türü Seçmelisiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //if (txtGenelBilgilendirmeId.Text.ToString() == "0")
                //{
                //    MessageBox.Show("Genel Bilgilendirme Seçmelisiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                DataTable dtDonusGorusmelerSonuc = new DataTable();
                dtDonusGorusmelerSonuc = manager.GetDataTableFull("CARI_GORUSMELER", "CARI_GORUSMELER_ID=" + txtSonrakiGorusmelerId.Text.ToString(), analizConStr);
                bool kayitVar = true;
                if (dtDonusGorusmelerSonuc.Rows.Count == 0)
                {
                    dtDonusGorusmelerSonuc.Rows.Add();
                    kayitVar = false;
                }
                dtDonusGorusmelerSonuc.Rows[0]["CARI_GORUSMELER_ID"] = txtSonrakiGorusmelerId.Text.ToString();
                dtDonusGorusmelerSonuc.Rows[0]["CARI_ID"] = txtCariId.Text.ToString();
                dtDonusGorusmelerSonuc.Rows[0]["ILETISIM_SEKLI"] = cmbDonusIletisimSekli.SelectedValue;
                dtDonusGorusmelerSonuc.Rows[0]["UZMAN_ARAMASI"] = chkUzmanAramasi.Checked;
                dtDonusGorusmelerSonuc.Rows[0]["ILETISIM_TURU"] = txtGeriDonusIletisimTuruId.Text.ToString();
                try
                {
                    dtDonusGorusmelerSonuc.Rows[0]["GORUSME_TARIHI"] = txtDonusTarihi.Text.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                dtDonusGorusmelerSonuc.Rows[0]["GORUSME_ICERIGI"] = txtGeriDonusNotu.Text.ToString();

                if (chkFaturaIleIliskilendir.Checked)
                {
                    dtDonusGorusmelerSonuc.Rows[0]["ILISKILI_FATURA_BLKODU"] = null;
                }

                //dtDonusGorusmelerSonuc.Rows[0]["GERI_DONUS"] = chkGeriDonusYapilacak.Checked;
                dtDonusGorusmelerSonuc.Rows[0]["GORUSULEN_KISI"] = cmbKisilerGeriDonus.Text.ToString();
                //dtDonusGorusmelerSonuc.Rows[0]["GENEL_BILGILENDIRME_ID"] = txtGenelBilgilendirmeId.Text.ToString();
                dtDonusGorusmelerSonuc.Rows[0]["UST_GORUSME_ID"] = txtIlkGorusmelerId.Text.ToString();

                if (!kayitVar)
                {
                    dtDonusGorusmelerSonuc.Rows[0]["KAYDEDEN"] = Manager.KullaniciAdSoyad.ToString();
                }
                dtDonusGorusmelerSonuc.Rows[0]["GUNCELLEYEN"] = Manager.KullaniciAdSoyad.ToString();

                int deger = int.Parse(txtSonrakiGorusmelerId.Text.ToString());

                // kaydetme if koşulu içinde oluyor
                if (manager.kaydetGuncelle("CARI_GORUSMELER", "CARI_GORUSMELER_ID", deger, dtDonusGorusmelerSonuc, analizConStr))
                {
                    gorusmeDoldur();
                    geriDonusDoldur();
                    MessageBox.Show("Kaydetme İşlemi Tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kaydetme İşleminde Hata. Kayıt Gerçekleşmedi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            temizle();
        }

        public void temizle()
        {
            btnKaydet.Enabled = true;
            gorusmeTipi = 0;
            grpGeriDonus.Enabled = false;
            grpGenelBilgilendirme.Enabled = true;
            grpIlkArama.Enabled = true;
            txtIlkAramaIletisimTuruId.Text = "0";
            txtGorusmeTuru.Text = "";
            txtIlkGorusmelerId.Text = "0";
            txtGorusmeNotu.Text = "";
            chkFaturaIleIliskilendir.Checked = false;
            chkGeriDonusYapilacak.Checked = false;
            chkUzmanAramasi.Checked = false;
            txtGenelBilgilendirmeId.Text = "0";
            txtGenelBilgilendirme.Text = "";
            txtDonusTuru.Text = "";
            txtGeriDonusIletisimTuruId.Text = "0";
            txtSonrakiGorusmelerId.Text = "0";
            txtGeriDonusNotu.Text = "";
            txtGorusmeTarihi.Text = DateTime.Now.ToString("dd.MM.yyyy");
            txtDonusTarihi.Text = DateTime.Now.ToString("dd.MM.yyyy");
            txtFaturaIletimTarihi.Text = DateTime.Now.ToString("dd.MM.yyyy");
            
        }

        private void dgvGorusmeler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGorusmeler.CurrentRow.Cells["CARI_GORUSMELER_ID"].Value.ToString() == "")
            {
                return;
            }
            temizle();
            gorusmelerDolsur();

        }

        public void gorusmelerDolsur()
        {
            txtFaturaIletimTarihi.Text = "";

            gorusmeTipi = 1;
            grpGeriDonus.Enabled = true;
            grpIlkArama.Enabled = false;
            grpGenelBilgilendirme.Enabled = false;

            txtIlkGorusmelerId.Text = dgvGorusmeler.CurrentRow.Cells["CARI_GORUSMELER_ID"].Value.ToString();
            cmbIlkletisimSekli.SelectedValue = dgvGorusmeler.CurrentRow.Cells["ILETISIM_SEKLI"].Value;
            txtIlkAramaIletisimTuruId.Text = dgvGorusmeler.CurrentRow.Cells["ILETISIM_TURU"].Value.ToString();
            txtGorusmeTarihi.Text = dgvGorusmeler.CurrentRow.Cells["GORUSME_TARIHI"].Value.ToString();
            txtGorusmeNotu.Text = dgvGorusmeler.CurrentRow.Cells["GORUSME_ICERIGI"].Value.ToString();
            chkGeriDonusYapilacak.Checked = false;
            if (dgvGorusmeler.CurrentRow.Cells["GERI_DONUS"].Value.ToString()=="1");
            {
                chkGeriDonusYapilacak.Checked = true;
            }
            chkUzmanAramasi.Checked = false;
            if (dgvGorusmeler.CurrentRow.Cells["UZMAN_ARAMASI"].Value.ToString() == "1") ;
            {
                chkUzmanAramasi.Checked = true;
            }
            //txtIliskiliFatura.Text = dgvGorusmeler.CurrentRow.Cells["ILISKILI_FATURA_BLKODU"].ToString();
            //chkGeriDonusYapilacak.Checked = false;
            if (dgvGorusmeler.CurrentRow.Cells["GERI_DONUS"].Value.ToString() == "1") chkGeriDonusYapilacak.Checked = true;

            txtGorusmeNotu.Text = dgvGorusmeler.CurrentRow.Cells["GORUSME_ICERIGI"].Value.ToString();
            cmbKisilerGorusme.Text = dgvGorusmeler.CurrentRow.Cells["GORUSULEN_KISI"].Value.ToString();
            txtGenelBilgilendirmeId.Text = dgvGorusmeler.CurrentRow.Cells["GENEL_BILGILENDIRME_ID"].Value.ToString();

            txtGorusmeTuru.Text = manager.parametreTreeYolBul(txtIlkAramaIletisimTuruId.Text.ToString());
            txtGenelBilgilendirme.Text = manager.parametreTreeYolBul(txtGenelBilgilendirmeId.Text.ToString());
            geriDonusDoldur();
        }

        private void geriDonusDoldur()
        {
            string sql = "SELECT * FROM CARI_GORUSMELER WHERE UST_GORUSME_ID=" + txtIlkGorusmelerId.Text.ToString();
            DataTable dtDonusGorusmeleri = new DataTable();
            dtDonusGorusmeleri = manager.BasitSorguDT(sql, analizConStr);
            dgvDonusler.DataSource = dtDonusGorusmeleri;

            if (dtDonusGorusmeleri.Rows.Count == 0)
            {
                return;
            }

            dgvDonusler.DataSource = dtDonusGorusmeleri;

            dgvDonusler.Columns["CARI_GORUSMELER_ID"].Visible = false;
            dgvDonusler.Columns["CARI_ID"].Visible = false;

            dgvDonusler.Columns["GERI_DONUS"].Visible = false;
            dgvDonusler.Columns["GORUSULEN_KISI"].Visible = false;

            dgvDonusler.Columns["ILETISIM_SEKLI"].Visible = false;
            dgvDonusler.Columns["ILETISIM_TURU"].Visible = false;
            dgvDonusler.Columns["ILISKILI_FATURA_BLKODU"].Visible = false;
            dgvDonusler.Columns["GENEL_BILGILENDIRME_ID"].Visible = false;
            dgvDonusler.Columns["UST_GORUSME_ID"].Visible = false;

            dgvDonusler.Columns["AKTIF"].Visible = false;
            dgvDonusler.Columns["KAYIT_TARIHI"].Visible = false;
            dgvDonusler.Columns["KAYDEDEN"].Visible = false;
            dgvDonusler.Columns["GUNCELLEME_TARIHI"].Visible = false;
            dgvDonusler.Columns["GUNCELLEYEN"].Visible = false;

            dgvDonusler.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);


            if (dtDonusGorusmeleri.Rows.Count == 0)
            {
                return;
            }

            if (dtDonusGorusmeleri.Rows.Count == 1)
            {
                grpGeriDonus.Enabled = false;
                btnKaydet.Enabled = false;

                txtSonrakiGorusmelerId.Text = dtDonusGorusmeleri.Rows[0]["CARI_GORUSMELER_ID"].ToString();
                cmbDonusIletisimSekli.SelectedValue = dtDonusGorusmeleri.Rows[0]["ILETISIM_SEKLI"];
                txtGeriDonusIletisimTuruId.Text = dtDonusGorusmeleri.Rows[0]["ILETISIM_TURU"].ToString();
                txtDonusTarihi.Text = dtDonusGorusmeleri.Rows[0]["GORUSME_TARIHI"].ToString();
                txtGeriDonusNotu.Text = dtDonusGorusmeleri.Rows[0]["GORUSME_ICERIGI"].ToString();
                cmbKisilerGeriDonus.Text = dtDonusGorusmeleri.Rows[0]["GORUSULEN_KISI"].ToString();
                txtDonusTuru.Text = manager.parametreTreeYolBul(txtGeriDonusIletisimTuruId.Text.ToString());
            }
            manager.parametreTreeYolBul(txtGeriDonusIletisimTuruId.Text.ToString());
            grpGeriDonus.Enabled = false;
            btnKaydet.Enabled = false;

        }

        private void btnYeniDonus_Click(object sender, EventArgs e)
        {
            if (txtSonrakiGorusmelerId.Text.ToString() != "0")
            {
                btnKaydet.Enabled = true;
                gorusmeTipi = 1;
                grpGeriDonus.Enabled = true;
                grpGenelBilgilendirme.Enabled = false;
                btnYeniDonus.Enabled = true;

                txtDonusTuru.Text = "";
                txtGeriDonusIletisimTuruId.Text = "0";
                txtSonrakiGorusmelerId.Text = "0";
                txtGeriDonusNotu.Text = "";
                txtDonusTarihi.Text = DateTime.Now.ToString("dd.MM.yyyy");
            }
        }

        private void dgvDonusler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSonrakiGorusmelerId.Text = dgvDonusler.CurrentRow.Cells["CARI_GORUSMELER_ID"].Value.ToString();
            txtSonrakiGorusmelerId.Text = dgvDonusler.CurrentRow.Cells["CARI_GORUSMELER_ID"].Value.ToString();
            cmbDonusIletisimSekli.SelectedValue = dgvDonusler.CurrentRow.Cells["ILETISIM_SEKLI"].Value;
            txtGeriDonusIletisimTuruId.Text = dgvDonusler.CurrentRow.Cells["ILETISIM_TURU"].Value.ToString();
            txtDonusTarihi.Text = dgvDonusler.CurrentRow.Cells["GORUSME_TARIHI"].Value.ToString();
            txtGeriDonusNotu.Text = dgvDonusler.CurrentRow.Cells["GORUSME_ICERIGI"].Value.ToString();
            cmbKisilerGeriDonus.Text = dgvDonusler.CurrentRow.Cells["GORUSULEN_KISI"].Value.ToString();
            txtDonusTuru.Text = manager.parametreTreeYolBul(txtGeriDonusIletisimTuruId.Text.ToString());
        }

        private void btnTarihiOnayla_Click(object sender, EventArgs e)
        {
            if (txtSeciliFaturaBilgi.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Bir Fatura Seçmelisiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtFaturaIletimTarihi.Text = DateTime.Now.ToString("dd.MM.yyyy");
            DataTable dtFaturaKaydet = new DataTable();
            dtFaturaKaydet = manager.GetDataTableFull("CARI_FATURALAR", "FATURA_BLKODU=" + txtFaturaBlKodu.Text.ToString(), analizConStr);
            bool kayitVar = true;
            if (dtFaturaKaydet.Rows.Count == 0)
            {
                dtFaturaKaydet.Rows.Add();
                kayitVar = false;
            }
            else
            {
                if (MessageBox.Show("Fatura Daha Önce Onaylanmış. Onay Tarihi Değiştirilecektir. Devam Edilsin mi?", "Uyarı...", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
                {
                    txtFaturaIletimTarihi.Text = "";
                    return;
                }
                txtFaturaId.Text = dtFaturaKaydet.Rows[0]["CARI_FATURALAR_ID"].ToString();
            }
            dtFaturaKaydet.Rows[0]["CARI_FATURALAR_ID"] = txtFaturaId.Text.ToString();
            dtFaturaKaydet.Rows[0]["CARI_ID"] = txtCariId.Text.ToString();
            dtFaturaKaydet.Rows[0]["FATURA_BLKODU"] = txtFaturaBlKodu.Text.ToString();
            try
            {
                dtFaturaKaydet.Rows[0]["ILETIM_ONAY_TARIHI"] = txtFaturaIletimTarihi.Text.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (!kayitVar)
            {
                dtFaturaKaydet.Rows[0]["KAYDEDEN"] = Manager.KullaniciAdSoyad.ToString();
            }
            dtFaturaKaydet.Rows[0]["GUNCELLEYEN"] = Manager.KullaniciAdSoyad.ToString();

            int deger = int.Parse(txtFaturaId.Text.ToString());

            // kaydetme if koşulu içinde oluyor
            if (manager.kaydetGuncelle("CARI_FATURALAR", "CARI_FATURALAR_ID", deger, dtFaturaKaydet, analizConStr))
            {
                faturalariBul();
                MessageBox.Show("Onay İşlemi Tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Onay İşleminde Hata. Kayıt Gerçekleşmedi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void chkSadeceIletilmeyenler_CheckedChanged(object sender, EventArgs e)
        {
            faturalariBul();
        }
    }
}
