using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Collections;
using System.IO;
using System.Drawing.Printing;


namespace AnalizProje
{
    public partial class Raporlar : Form
    {
        Manager manager = new Manager();

        string analizConStr = "";
        string wolVoxConStr = "";
        string sql = "";
        string raporAdi = "";
        Ean13 barcode = new Ean13();
        PrintDocument doc = new PrintDocument();
        BarkodSinif barkodSinif = new BarkodSinif();

        //StringFormat strFormat;
        //ArrayList arrColumnLefts = new ArrayList();
        //ArrayList arrColumnWidths = new ArrayList();
        //int iCellHeight = 0;
        //int iTotalWidth = 0;
        int iRow = 0;
        bool bFirstPage = false;
        bool bNewPage = false;
        //int iHeaderHeight = 0;
        int totalrecord = 0;
        int sayfa = 0;

        public Raporlar()
        {
            InitializeComponent();
            analizConStr = manager.conStrAnaliz;
            wolVoxConStr = manager.conStrWolvox;
        }

        private void btnCariAra_Click(object sender, EventArgs e)
        {
            raporAdi = "BirimBasliSatis";
            sql = "SELECT SUM(SATISLAR.MIKTARI) AS MIKTAR, SATISLAR.BIRIMI, SATISLAR.STOKKODU , STOK.STOK_ADI " +
                        "FROM " +
                        "(SELECT " +
                        "FATURAHR.MIKTARI, FATURAHR.BIRIMI, FATURAHR.STOK_ADI, FATURA.CARIKODU, FATURA.TARIHI, " +
                        "FATURA.FATURA_NO, FATURA.FATURA_SERI, FATURA.SILINDI, FATURA.KARGO_FIRMASI, FATURA.KARGO_NO, FATURA.FATURA_KESILDI, " +
                        "FATURA.BLCRKODU, FATURA.SEVK_ADRESI, FATURA.SEVK_ILI, FATURA.SEVK_ILCESI, FATURA.SEVK_ULKESI, FATURA.TOPLAM_ALT_KPB, " +
                        "FATURA.YUVARLAMA_KPB, FATURA.TOPLAM_KDV_KPB, FATURA.TOPLAM_GENEL_KPB, FATURA.MIKTAR1_TOPLAM, FATURAHR.SIRA_NO, " +
                        "FATURAHR.EVRAK_NO, FATURAHR.BLSTKODU, FATURAHR.KPB_FIYATI, FATURAHR.KDV_ORANI, FATURAHR.KDV_TUTARI, FATURAHR.KPB_KDV_HARICFY, " +
                        "FATURAHR.KPB_IND_FIYAT, FATURAHR.KPB_IND_TUTAR, FATURAHR.KPB_TOPLAM_TUTAR, FATURAHR.KPB_KDVLI_TUTAR, FATURAHR.EKBILGI_1, " +
                        "FATURAHR.EKBILGI_2, FATURAHR.STOKKODU " +
                        "FROM FATURA, FATURAHR " +
                        "WHERE FATURAHR.BLFTKODU = FATURA.BLKODU " +
                        "ORDER BY FATURAHR.MIKTARI DESC, FATURA.TARIHI, FATURA.FATURA_NO, FATURA.ADI_SOYADI, TICARI_UNVANI " +
                        ") AS SATISLAR " +
                        "LEFT JOIN STOK ON STOK.STOKKODU = SATISLAR.STOKKODU " +
                        "GROUP BY SATISLAR.BIRIMI,SATISLAR.STOKKODU,STOK.STOK_ADI, SATISLAR.BIRIMI " +
                        "ORDER BY SATISLAR.BIRIMI,MIKTAR DESC";
            grideBas(sql, wolVoxConStr);

        }

        private void Raporlar_Load(object sender, EventArgs e)
        {
            txtTarihliSiparisler.Text = DateTime.Now.ToString("dd.MM.yyyy");
            if (Manager.KullaniciAdSoyad.ToString() != "Admin Adı Admin Soyadı")
            {
                grbSorgu.Enabled = false;
            }
        }

        private void btnSiparisler_Click(object sender, EventArgs e)
        {
            grpSonuc.Text = "Bekleyen Siparişler";
            raporAdi = "BekleyenSiparisler";

            sql = "SELECT " +
                  "TARIHI,TICARI_UNVANI, ADI_SOYADI,SIPARIS_NO, STOKKODU, STOK_ADI, MIKTARI, BIRIMI, SUM(MERKEZDEPO) AS MERKEZDEPO,SUM(GIDADEPO) AS GIDADEPO," +
                  "KPB_FIYATI, KDV_ORANI, KPB_TOPLAM_TUTAR, BARKODU," +
                  "SUM(STOK_MIKTARI) AS TOPLAM_STOK " +
                  "FROM ( " +
                  "SELECT " +
                  "SIPARISHR.SIRA_NO, SIPARIS.TARIHI, SIPARIS.TICARI_UNVANI, SIPARIS.ADI_SOYADI, SIPARIS.SIPARIS_NO, SIPARISHR.STOKKODU, SIPARISHR.STOK_ADI, SIPARISHR.BIRIMI, SIPARISHR.MIKTARI, " +
                  "SIPARISHR.KPB_FIYATI, SIPARISHR.KDV_ORANI, SIPARISHR.KPB_TOPLAM_TUTAR, STOKHR.DEPO_ADI, STOK.BARKODU, " +
                  "SUM(STOKHR.KPB_GMIK) - SUM(STOKHR.KPB_CMIK) AS STOK_MIKTARI, " +
                  "IIF(STOKHR.DEPO_ADI = 'MERKEZDEPO', SUM(STOKHR.KPB_GMIK) - SUM(STOKHR.KPB_CMIK), 0) AS MERKEZDEPO, " +
                  "IIF(STOKHR.DEPO_ADI = 'GIDADEPO', SUM(STOKHR.KPB_GMIK) - SUM(STOKHR.KPB_CMIK), 0) AS GIDADEPO " +
                  "FROM SIPARIS " +
                  "JOIN SIPARISHR ON SIPARISHR.BLMASKODU = SIPARIS.BLKODU " +
                  "JOIN STOK ON STOK.BLKODU = SIPARISHR.BLSTKODU " +
                  "JOIN STOKHR ON STOKHR.BLSTKODU = STOK.BLKODU " +
                  "WHERE SIPARIS.SIPARIS_DURUMU = 1 AND SIPARIS.SILINDI = 0 AND STOK.AKTIF = 1 AND STOKHR.DEPO_ADI <> 'BLOKEDEPO' AND STOK.STOKKODU <> 'krg01' " +
                  "GROUP BY " +
                  "SIPARIS.TARIHI, SIPARIS.TICARI_UNVANI, SIPARIS.ADI_SOYADI, SIPARISHR.SIRA_NO, SIPARIS.SIPARIS_NO, SIPARISHR.STOKKODU, SIPARISHR.STOK_ADI, SIPARISHR.BIRIMI, SIPARISHR.MIKTARI, " +
                  "SIPARISHR.KPB_FIYATI, SIPARISHR.KDV_ORANI, SIPARISHR.KPB_TOPLAM_TUTAR, STOKHR.DEPO_ADI, STOK.BARKODU) AA " +
                  "GROUP BY SIRA_NO, TARIHI, TICARI_UNVANI, ADI_SOYADI, SIPARIS_NO, STOKKODU, STOK_ADI, BIRIMI, MIKTARI, " +
                  "KPB_FIYATI, KDV_ORANI, KPB_TOPLAM_TUTAR, BARKODU " +
                  "ORDER BY TARIHI, TICARI_UNVANI, ADI_SOYADI, SIRA_NO";
            grideBas(sql, wolVoxConStr);
        }

        public void grideBas(string sql, string hedef)
        {
            this.Enabled = false;
            DataTable sonuc = new DataTable();
            try
            {
                //this.Enabled = false;
                sonuc = manager.BasitSorguDT(sql, hedef);
                dgvSonuc.DataSource = sonuc;
                dgvSonuc.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                //this.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata :" + ex.ToString());
                //this.Enabled = true;
            }
            this.Enabled = true;
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("RAPORSQL", "SORGULA")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: RAPORSQL - Yetki: SORGULA)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            grpSonuc.Text = "#";
            sql = txtSorgu.Text.ToString();
            dgvSonuc.DataSource = null;
            grideBas(sql, wolVoxConStr);

            if (Manager.HataMesajiTasi != null)
            {
                MessageBox.Show(Manager.HataMesajiTasi.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Manager.HataMesajiTasi = null;
            }
        }

        private void dgvSonuc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (raporAdi == "Siparişler")
            {
                if (dgvSonuc.Rows.Count < 2)
                {
                    return;
                }
                //Yetki Sorgulama
                if (!(manager.YetkiSorgula("SIPARISLER", "GIRIS")))
                {
                    MessageBox.Show("Yetkiniz Yok! (Uygulama: SIPARISLER - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                sql = "SELECT SIPARIS.TICARI_UNVANI, SIPARIS.ADI_SOYADI, SIPARIS.EKBILGI_1,SIPARISHR.STOKKODU, SIPARISHR.STOK_ADI,SIPARISHR.BIRIMI, SIPARISHR.MIKTARI," +
                    "SIPARIS.SEVK_ADRESI, SIPARIS.ILCESI, SIPARIS.ILI , ROUND(SIPARISHR.KPB_KDVLI_TUTAR,2) AS TUTARI FROM SIPARIS JOIN SIPARISHR ON SIPARISHR.BLMASKODU = SIPARIS.BLKODU  WHERE SIPARIS.BLKODU = " +
                    dgvSonuc.CurrentRow.Cells["BLKODU"].Value.ToString();

                DataTable detay = new DataTable();
                try
                {
                    //this.Enabled = false;
                    detay = manager.BasitSorguDT(sql, wolVoxConStr);
                    //this.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata :" + ex.ToString());
                    //this.Enabled = true;
                }

                Manager.VeriTasi = detay;
                GridGoster gridGoster = new GridGoster();
                gridGoster.Text = "Sipariş Detay";
                gridGoster.ShowDialog();
                Manager.VeriTasi = null;

            }
        }

        private void btnWolvox_Click(object sender, EventArgs e)
        {
            lblAdetSiparisVar.Text = "...";
            grpSonuc.Text = "Siparişler";
            raporAdi = "Siparişler";
            //sql = "SELECT * FROM FATURA_DISMODUL WHERE TARIHI>'" + DateTime.Parse(txtTarihliSiparisler.Text.ToString()).ToString("yyyy.MM.dd")+"'"+
            //    "AND TARIHI<'"+DateTime.Parse(txtTarihliSiparisler.Text.ToString()).AddDays(1).ToString("yyyy.MM.dd")+"'";

            sql = "SELECT SIPARIS.TARIHI, SIPARIS.BLKODU,SIPARIS_DURUM_TANIM.TANIMI, SIPARIS.CARIKODU, SIPARIS.TICARI_UNVANI, SIPARIS.ADI_SOYADI, SIPARIS.TEL1, " +
                  "SIPARIS.ACIKLAMA, SIPARIS.ILI, SIPARIS.ILCESI, SIPARIS.ADRESI FROM SIPARIS " +
                  "JOIN SIPARIS_DURUM_TANIM ON SIPARIS_DURUM_TANIM.KODU = SIPARIS.SIPARIS_DURUMU " +
                  "WHERE TARIHI>'" +
                  DateTime.Parse(txtTarihliSiparisler.Text.ToString()).ToString("yyyy.MM.dd") + "'" +
                  "AND TARIHI<'" + DateTime.Parse(txtTarihliSiparisler.Text.ToString()).AddDays(1).ToString("yyyy.MM.dd") + "' " +
                  "ORDER BY TARIHI,ADI_SOYADI";

            dgvSonuc.DataSource = null;
            grideBas(sql, wolVoxConStr);
            lblAdetSiparisVar.Text = "Toplam " + (dgvSonuc.RowCount - 1).ToString() + " Adet";
        }

        private void btnStokMiktari_Click(object sender, EventArgs e)
        {
            if (txtStokBilgi.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Arama Sahası Boş Olamaz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            grpSonuc.Text = "Stok Miktarı";
            sql = "SELECT " +
                "STOK.STOKKODU, STOK.STOK_ADI, STOK.OZEL_KODU1, STOK.GRUBU,  STOK.ARA_GRUBU, STOK.ALT_GRUBU, STOK.BIRIMI, STOK.BIRIMLER, " +
                "STOK.AKTIF,STOKHR.IADE, STOKHR.SILINDI,STOKHR.DEPO_ADI, SUM(STOKHR.KPB_GMIK) AS GIRIS_MIKTAR, SUM(STOKHR.KPB_CMIK) AS CIKIS_MIKTAR, " +
                "SUM(STOKHR.KPB_GMIK)-SUM(STOKHR.KPB_CMIK) AS STOK_MIKTARI, SUM(STOKHR.KPB_GTUT) AS GIRIS_TUTAR, SUM(STOKHR.KPB_CTUT) AS CIKIS_TUTAR, " +
                "SUM(STOKHR.KPB_GTUT)-SUM(STOKHR.KPB_CTUT) AS STOK_DEGERI FROM STOK " +
                "JOIN STOKHR ON STOKHR.BLSTKODU = STOK.BLKODU " +
                "WHERE (STOKKODU LIKE('%" + txtStokBilgi.Text.ToString() + "%')" + " OR STOK_ADI LIKE('%" + txtStokBilgi.Text.ToString() + "%')) " +
                //"AND STOKHR.DEPO_ADI <>'BLOKEDEPO' " +
                "GROUP BY STOK.STOKKODU, STOK.STOK_ADI, STOK.OZEL_KODU1, STOK.GRUBU,  STOK.ARA_GRUBU, STOK.ALT_GRUBU, STOK.BIRIMI, STOK.BIRIMLER, " +
                "STOK.AKTIF, STOKHR.IADE, STOKHR.SILINDI,STOKHR.DEPO_ADI " +
                "ORDER BY STOK.STOKKODU, STOK.GRUBU, STOK.ARA_GRUBU, STOK.ALT_GRUBU, STOKHR.DEPO_ADI";



            //

            dgvSonuc.DataSource = null;
            grideBas(sql, wolVoxConStr);
        }

        private void btnSiparisteAra_Click(object sender, EventArgs e)
        {
            if (txtSiparisteAra.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Aranacak Değer Girmelisiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            grpSonuc.Text = "Siparişte Ara";
            raporAdi = "Siparişler";
            //sql = "SELECT * FROM FATURA_DISMODUL WHERE TARIHI>'" + DateTime.Parse(txtTarihliSiparisler.Text.ToString()).ToString("yyyy.MM.dd")+"'"+
            //    "AND TARIHI<'"+DateTime.Parse(txtTarihliSiparisler.Text.ToString()).AddDays(1).ToString("yyyy.MM.dd")+"'";

            sql = "SELECT " +
                  "SIPARIS.BLKODU, SIPARIS.TARIHI, SIPARIS.CARIKODU, SIPARIS.TICARI_UNVANI, SIPARIS.ADI_SOYADI, SIPARIS.VERGI_NO, SIPARIS.VERGI_DAIRESI, " +
                  "SIPARIS.TEL1, SIPARIS.ADRESI, SIPARIS.ILI,SIPARIS.ILCESI, SIPARIS.SIPARIS_NO, SIPARIS.ACIKLAMA, SIPARIS.EKBILGI_1, " +
                  "SIPARIS.EKBILGI_2, SIPARIS.SEVK_ADRESI, SIPARIS.SEVK_ILI, SIPARIS.SEVK_ILCESI, SIPARIS.CEP_TEL, " +
                  "SIPARISHR.STOKKODU, SIPARISHR.STOK_ADI, SIPARISHR.EKBILGI_1, SIPARISHR.EKBILGI_2 " +
                  "FROM SIPARISHR JOIN SIPARIS ON SIPARIS.BLKODU = SIPARISHR.BLMASKODU " +
                  "WHERE " +
                  "SIPARIS.CARIKODU LIKE('%" + txtSiparisteAra.Text.ToString() + "%') OR " +
                  "SIPARIS.TICARI_UNVANI LIKE('%" + txtSiparisteAra.Text.ToString() + "%') OR " +
                  "SIPARIS.ADI_SOYADI LIKE('%" + txtSiparisteAra.Text.ToString() + "%') OR " +
                  "SIPARIS.VERGI_NO LIKE('%" + txtSiparisteAra.Text.ToString() + "%') OR " +
                  "SIPARIS.VERGI_DAIRESI LIKE('%" + txtSiparisteAra.Text.ToString() + "%') OR " +
                  "SIPARIS.TEL1 LIKE('%" + txtSiparisteAra.Text.ToString() + "%') OR " +
                  "SIPARIS.ADRESI LIKE('%" + txtSiparisteAra.Text.ToString() + "%') OR " +
                  "SIPARIS.ILI LIKE('%" + txtSiparisteAra.Text.ToString() + "%') OR " +
                  "SIPARIS.ILCESI LIKE('%" + txtSiparisteAra.Text.ToString() + "%') OR " +
                  "SIPARIS.SIPARIS_NO LIKE('%" + txtSiparisteAra.Text.ToString() + "%') OR " +
                  "SIPARIS.ACIKLAMA LIKE('%" + txtSiparisteAra.Text.ToString() + "%') OR " +
                  "SIPARIS.EKBILGI_1 LIKE('%" + txtSiparisteAra.Text.ToString() + "%') OR " +
                  "SIPARIS.EKBILGI_2 LIKE('%" + txtSiparisteAra.Text.ToString() + "%') OR " +
                  "SIPARISHR.STOKKODU LIKE('%" + txtSiparisteAra.Text.ToString() + "%') OR " +
                  "SIPARISHR.STOK_ADI LIKE('%" + txtSiparisteAra.Text.ToString() + "%') OR " +
                  "SIPARISHR.EKBILGI_1 LIKE('%" + txtSiparisteAra.Text.ToString() + "%') OR " +
                  "SIPARISHR.EKBILGI_2 LIKE('%" + txtSiparisteAra.Text.ToString() + "%')";

            dgvSonuc.DataSource = null;
            grideBas(sql, wolVoxConStr);

        }

        private void btnEksikler_Click(object sender, EventArgs e)
        {
            grpSonuc.Text = "Eksik Listesi";
            raporAdi = "Eksik Listesi";

            sql = "SELECT KAYNAK_STOK_ADI,MARKASI ,ROUND(ISTENEN_MIKTAR+ENAZSEVIYE-STOK_MIKTARI,3) AS ALINACAKLAR, KAYNAK_BIRIMI AS TEMIN_BIRIMI,ROUND(STOK_MIKTARI,3) AS STOK_MIKTARI, KAYNAK_STOKKODU,  KAYNAK_BLKODU, ROUND(ISTENEN_MIKTAR,3) AS ISTENEN_MIKTAR,  ENAZSEVIYE " +
                "FROM( " +
                "SELECT  MARKASI, KAYNAK_STOKKODU, KAYNAK_STOK_ADI, KAYNAK_BLKODU, KAYNAK_BIRIMI, ISTENEN_MIKTAR, " +
                "iif(STOK_DURUM.STOK_MIKTARI IS NULL, 0, STOK_DURUM.STOK_MIKTARI) AS STOK_MIKTARI, iif(SEVIYEBUL.SEVIYE IS NULL, 1, SEVIYEBUL.SEVIYE) AS ENAZSEVIYE " +
                "FROM( " +
                "SELECT  MARKASI, KAYNAK_STOKKODU, KAYNAK_STOK_ADI, KAYNAK_BLKODU, KAYNAK_BIRIMI, SUM(ISTENEN_MIKTAR) AS ISTENEN_MIKTAR " +
                "FROM( " +
                "SELECT MARKASI, iif(KAYNAK_STOKKODU IS NULL, STOKKODU, KAYNAK_STOKKODU) AS KAYNAK_STOKKODU, " +
                "iif(KAYNAK_STOK_ADI IS NULL, STOK_ADI, KAYNAK_STOK_ADI)  AS KAYNAK_STOK_ADI, " +
                "iif(KAYNAKSTOK_BLKODU IS NULL, BLKODU, KAYNAKSTOK_BLKODU) AS KAYNAK_BLKODU, " +
                "iif(KAYNAK_BIRIMI IS NULL, BIRIMI, KAYNAK_BIRIMI) AS KAYNAK_BIRIMI, " +
                "iif(URETIM_CARPANI IS NULL, SIPARISMIKTARI, URETIM_CARPANI * SIPARISMIKTARI) AS ISTENEN_MIKTAR, URETIM_CARPANI, SIPARISMIKTARI " +
                "FROM( " +
                "SELECT SONUC.BLKODU, SONUC.STOKKODU, SONUC.STOK_ADI, SONUC.MARKASI, SONUC.BIRIMI, URETIM_CARPANI, " +
                "KAYNAK_BIRIMI, URETILEN_BLKODU, URETILEN_STOKKODU, URETILEN_STOKADI, URETILEN_MIKTAR, KAYNAKSTOK_BLKODU, " +
                "KAYNAK_STOKKODU, KAYNAK_STOK_ADI, SIPARISMIKTARI " +
                "FROM( " +
                "SELECT STOKTAN.BLKODU, SIPARISHR.STOKKODU, SIPARISHR.STOK_ADI, STOKTAN.MARKASI, STOKTAN.BIRIMI, " +
                "SUM(SIPARISHR.MIKTARI) AS SIPARISMIKTARI " +
                "FROM SIPARIS " +
                "JOIN SIPARISHR ON SIPARISHR.BLMASKODU = SIPARIS.BLKODU " +
                "JOIN( " +
                "SELECT BLKODU, STOKKODU, STOK_ADI, BIRIMI, MARKASI " +
                "FROM( " +
                "SELECT STOK.BLKODU, STOK.STOKKODU, STOK.STOK_ADI, STOK.GRUBU, STOK.ARA_GRUBU, STOK.ALT_GRUBU, STOK.BIRIMI, STOK.MARKASI, STOK.BIRIMLER, STOK.AKTIF, STOKHR.SILINDI " +
                "FROM STOKHR " +
                "JOIN STOK ON STOK.BLKODU = STOKHR.BLSTKODU " +
                "WHERE(STOKHR.SILINDI = 0) " +
                "GROUP BY STOK.BLKODU, STOK.STOKKODU, STOK.STOK_ADI, STOK.GRUBU, STOK.ARA_GRUBU, STOK.ALT_GRUBU, STOK.BIRIMI, STOK.BIRIMLER, STOK.AKTIF, STOKHR.SILINDI, STOK.MARKASI " +
                ") GENEL_TOPAM " +
                ") STOKTAN ON STOKTAN.STOK_ADI = SIPARISHR.STOK_ADI " +
                "WHERE SIPARIS.SILINDI = 0 AND(SIPARIS.SIPARIS_DURUMU = 1 OR SIPARIS.SIPARIS_DURUMU = 6) AND SIPARISHR.STOKKODU <> 'krg01' " +
                "GROUP BY STOKTAN.BLKODU, SIPARISHR.STOKKODU, SIPARISHR.STOK_ADI, SIPARISHR.BIRIMI, STOKTAN.STOKKODU, STOKTAN.STOK_ADI, " +
                "STOKTAN.BIRIMI, STOKTAN.MARKASI " +
                ") SONUC " +
                "LEFT JOIN( " +
                "SELECT STOK.BLKODU AS URETILEN_BLKODU, STOK.STOKKODU AS URETILEN_STOKKODU, STOK.STOK_ADI AS URETILEN_STOKADI, BASIT_URETIM.MIKTARI AS URETILEN_MIKTAR, " +
                "BASIT_URETIMHR.BLSTKODU AS KAYNAKSTOK_BLKODU, BASIT_URETIMHR.STOKKODU AS KAYNAK_STOKKODU, BASIT_URETIMHR.STOK_ADI AS KAYNAK_STOK_ADI, " +
                "(BASIT_URETIMHR.TOPLAM_MIKTAR - BASIT_URETIMHR.FIRE_MIKTARI)  AS URETIM_CARPANI, BASIT_URETIMHR.BIRIMI AS KAYNAK_BIRIMI " +
                "FROM BASIT_URETIM " +
                "JOIN BASIT_URETIMHR ON BASIT_URETIMHR.BLMASKODU = BASIT_URETIM.BLKODU " +
                "JOIN STOK ON STOK.BLKODU = BASIT_URETIM.BLSTKODU " +
                "WHERE BASIT_URETIM.DURUMU = 1 " +
                ") URETIM ON URETIM.URETILEN_BLKODU = SONUC.BLKODU " +
                ") SIPARISGENEL " +
                ")SIPARIS GROUP BY MARKASI, KAYNAK_STOKKODU, KAYNAK_STOK_ADI, KAYNAK_BLKODU, KAYNAK_BIRIMI " +
                ") SIPARIS_GRUP " +
                "LEFT JOIN( " +
                "SELECT BLKODU, STOKKODU, STOK_ADI, (GIREN_MIKTAR - CIKAN_MIKTAR) - 100 AS STOK_MIKTARI " +
                "FROM( " +
                "SELECT STOK.BLKODU, STOK.STOKKODU, STOK.STOK_ADI, STOK.GRUBU, STOK.ARA_GRUBU, STOK.ALT_GRUBU, STOK.BIRIMI, STOK.MARKASI, STOK.BIRIMLER, STOK.AKTIF, " +
                "STOKHR.SILINDI, SUM(iif(STOKHR.KPB_GMIK IS NULL, 0, STOKHR.KPB_GMIK))  AS GIREN_MIKTAR, SUM(iif(STOKHR.KPB_CMIK IS NULL, 0, STOKHR.KPB_CMIK)) AS CIKAN_MIKTAR, " +
                "iif(SEVIYEBUL.SEVIYE IS NULL, 1, SEVIYEBUL.SEVIYE) AS ENAZSEVIYE " +
                "FROM STOKHR " +
                "JOIN STOK ON STOK.BLKODU = STOKHR.BLSTKODU " +
                "LEFT JOIN(SELECT BLSTKODU, iif(SUM(MIKTAR_MINIMUM) IS NULL, 0, SUM(MIKTAR_MINIMUM)) AS SEVIYE FROM STOK_DEPO GROUP BY BLSTKODU) SEVIYEBUL ON SEVIYEBUL.BLSTKODU = STOKHR.BLSTKODU " +
                "WHERE(STOKHR.SILINDI = 0) " +
                "GROUP BY STOK.BLKODU, STOK.STOKKODU, STOK.STOK_ADI, STOK.GRUBU, STOK.ARA_GRUBU, STOK.ALT_GRUBU, STOK.BIRIMI, STOK.BIRIMLER, STOK.AKTIF, STOKHR.SILINDI, STOK.MARKASI, SEVIYEBUL.SEVIYE " +
                ") STOK_TOPLAM " +
                ") STOK_DURUM ON STOK_DURUM.BLKODU = SIPARIS_GRUP.KAYNAK_BLKODU " +
                "LEFT JOIN(SELECT BLSTKODU, iif(SUM(MIKTAR_MINIMUM) IS NULL, 0, SUM(MIKTAR_MINIMUM)) AS SEVIYE FROM STOK_DEPO GROUP BY BLSTKODU) SEVIYEBUL ON SEVIYEBUL.BLSTKODU = KAYNAK_BLKODU " +
                ") SIPARIS_ISTENEN " +
                "WHERE ISTENEN_MIKTAR+ENAZSEVIYE-STOK_MIKTARI>0 " +
                "ORDER BY MARKASI, KAYNAK_STOK_ADI, KAYNAK_BLKODU, KAYNAK_STOKKODU ";

            dgvSonuc.DataSource = null;
            grideBas(sql, wolVoxConStr);
            lblAdetSiparisVar.Text = "Toplam " + (dgvSonuc.RowCount - 1).ToString() + " Adet";
        }

        private void btnEksikYazdir_Click(object sender, EventArgs e)
        {
            if (raporAdi == "Eksik Listesi")
            {
                //Yetki Sorgulama
                if (!(manager.YetkiSorgula("EKSIKLISTESI", "YAZDIR")))
                {
                    MessageBox.Show("Yetkiniz Yok! (Uygulama: EKSIKLISTESI - Yetki: YAZDIR)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Doğrudan Yazıcıya
                sayfa = 1;
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();

                return;

                //PrintDialog printDialog = new PrintDialog();
                printDialog1.Document = printDocument1;
                printDialog1.UseEXDialog = true;
                if (DialogResult.OK == printDialog1.ShowDialog())
                {
                    printDocument1.DocumentName = "Eksik Listesi";
                    sayfa = 1;
                    printDocument1.Print();
                }

            }
            if (raporAdi == "Sepet Siparişler")
            {

                if (!(manager.YetkiSorgula("SEPETLISTESI", "YAZDIR")))
                {
                    MessageBox.Show("Yetkiniz Yok! (Uygulama: SEPETLISTESI - Yetki: YAZDIR)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                sayfa = 1;

                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();

                return;


                ////Doğrudan Yazıcıya
                //PrintDialog printDialog = new PrintDialog();
                printDialog1.Document = printDocument1;
                printDialog1.UseEXDialog = true;
                if (DialogResult.OK == printDialog1.ShowDialog())
                {
                    printDocument1.DocumentName = "Sipariş Sepet Listesi";
                    sayfa = 1;
                    printDocument1.Print();
                }
            }

            if (raporAdi == "Stok Sayım")
            {
                //Yetki Sorgulama
                if (!(manager.YetkiSorgula("SAYIMLISTESI", "YAZDIR")))
                {
                    MessageBox.Show("Yetkiniz Yok! (Uygulama: SAYIMLISTESI - Yetki: YAZDIR)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Doğrudan Yazıcıya
                sayfa = 1;
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();

                return;

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {   //Yazı fontumu ve çizgi çizmek için fırçamı ve kalem nesnemi oluşturdum
            Font myFont = new Font("Calibri", 10, FontStyle.Bold);
            SolidBrush sbrush = new SolidBrush(Color.Black);
            Pen myPen = new Pen(Color.Black);
            string siparisNo = "";
                
            //DataGridView sepetGrid = new DataGridView();
            DataTable tekSatir = new DataTable();

            int y = 180;
            int x = 50;
            if (raporAdi == "Eksik Listesi")
            {
                try
                {

                    int iLeftMargin = e.MarginBounds.Left;
                    int iTopMargin = e.MarginBounds.Top;
                    bool bMorePagesToPrint = false;

                    while (iRow <= dgvSonuc.Rows.Count - 1)
                    {
                        DataGridViewRow GridRow = dgvSonuc.Rows[iRow];

                        double totalcount = Convert.ToDouble(iRow) % Convert.ToDouble(45);
                        if (totalcount == 0 && iRow != 0 && totalrecord == 0)
                        {
                            y = 130;
                            bNewPage = true;
                            bFirstPage = false;
                            bMorePagesToPrint = true;
                            totalrecord = 1;
                            break;
                        }
                        else
                        {
                            if (bNewPage)
                            {
                                myFont = new Font("Calibri", 10, FontStyle.Bold);
                                sbrush = new SolidBrush(Color.Black);
                                myPen = new Pen(Color.Black);
                                e.Graphics.DrawString(DateTime.Parse(txtTarihliSiparisler.Text.ToString()).ToString("dd.MM.yyyy") + " TARİHLİ EKSİK LİSTESİ        Sayfa:" + sayfa.ToString(), myFont, sbrush, 100 - x, 80);
                                e.Graphics.DrawString("Ürün Adı", myFont, sbrush, 100-x, 133);
                                e.Graphics.DrawString("Alınacak", myFont, sbrush, 600 - x, 120);
                                e.Graphics.DrawString(" Miktar", myFont, sbrush, 600 - x, 133);
                                e.Graphics.DrawString("  Birimi", myFont, sbrush, 670 - x, 133);
                                e.Graphics.DrawString(" Stok ", myFont, sbrush, 730 - x, 133);
                                myFont = new Font("Calibri", 10, FontStyle.Regular);
                            }
                            e.Graphics.DrawLine(myPen, 100 - x, y, 780 - x, y);
                            //e.Graphics.DrawString(lvi.Text, myFont, sbrush, 120, y);
                            if (dgvSonuc.Rows[iRow].Cells[0].Value != null) e.Graphics.DrawString(" (" + dgvSonuc.Rows[iRow].Cells["MARKASI"].Value.ToString().Trim() + ") " + dgvSonuc.Rows[iRow].Cells["KAYNAK_STOK_ADI"].Value.ToString(), myFont, sbrush, 100 - x, y);
                            if (dgvSonuc.Rows[iRow].Cells[2].Value != null) e.Graphics.DrawString(" (" + dgvSonuc.Rows[iRow].Cells["ALINACAKLAR"].Value.ToString() + ")", myFont, sbrush, 610 - x, y);
                            if (dgvSonuc.Rows[iRow].Cells[3].Value != null) e.Graphics.DrawString(dgvSonuc.Rows[iRow].Cells["TEMIN_BIRIMI"].Value.ToString(), myFont, sbrush, 680 - x, y);
                            if (dgvSonuc.Rows[iRow].Cells[4].Value != null) e.Graphics.DrawString(dgvSonuc.Rows[iRow].Cells["STOK_MIKTARI"].Value.ToString(), myFont, sbrush, 730 - x, y);

                            y += 20;
                            bNewPage = false;
                        }
                        iRow++;
                        totalrecord = 0;
                    }
                    if (bMorePagesToPrint)
                    {
                        e.HasMorePages = true;
                        sayfa++;
                    }
                    else
                        e.HasMorePages = false;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Bir Hata Oluştu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (raporAdi == "Sepet Siparişler")
            {
                try
                {
                    int iLeftMargin = e.MarginBounds.Left;
                    int iTopMargin = e.MarginBounds.Top;
                    bool bMorePagesToPrint = false;

                    //int sayac = 0;
                    string kontrol = "";

                    string onaliyli = "";
                    if (chkOnaylandi.Checked)
                    {
                        onaliyli = "SIPARIS.SIPARIS_DURUMU=5 OR ";
                    }

                    if (chkSeciliBarkod.Checked)
                    {
                        
                        sql = "SELECT SIPARIS.TICARI_UNVANI, SIPARIS.ADI_SOYADI,SIPARIS.CEP_TEL,SIPARIS.TEL1,SIPARIS.ADRESI,SIPARIS.ILI,SIPARIS.ILCESI, " +
                              "SIPARIS.SIPARIS_NO,SIPARIS.TARIHI,SIPARIS.KARGO_NO, SIPARISHR.SIRA_NO,SIPARISHR.STOKKODU,SIPARISHR.STOK_ADI,SIPARISHR.MIKTARI,STOK.BIRIMI , STOK.BARKODU , ROUND(SIPARISHR.KPB_KDVLI_TUTAR/SIPARISHR.MIKTARI,2) AS KDVLI_TUTAR " +
                              "FROM SIPARIS JOIN SIPARISHR ON SIPARISHR.BLMASKODU = SIPARIS.BLKODU JOIN STOK ON STOK.STOKKODU=SIPARISHR.STOKKODU " +
                              "WHERE SIPARISHR.STOKKODU <> 'krg01' AND SIPARIS.SILINDI = 0 AND ("+onaliyli+" SIPARIS.SIPARIS_DURUMU = 1 OR SIPARIS.SIPARIS_DURUMU = 6) AND SIPARIS.ADRESI LIKE '"+
                              dgvSonuc.CurrentRow.Cells["ADRESI"].Value.ToString().Replace("'","%") +"'";
                        try
                        {
                            tekSatir = manager.BasitSorguDT(sql, wolVoxConStr);
                            sepetGrid.DataSource = tekSatir;
                            sayfa = dgvSonuc.CurrentRow.Index;
                            sepetGrid.Refresh();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata :" + ex.ToString());
                            //this.Enabled = true;
                        }
                        
                    }
                    else
                    {
                        sepetGrid = dgvSonuc;
                        sepetGrid.Refresh();
                            
                    }
                    int kayitSay = 0;

                    while (iRow <= sepetGrid.Rows.Count)
                     {
                        double totalcount = 1;
                        //if (dgvSonuc.Rows[iRow].Cells[10].Value.ToString() == "1") totalcount = 0;

                        // if (chkSeciliBarkod.Checked && dgvSonuc.Rows[iRow].Cells[4].Value.ToString() == dgvSonuc.CurrentRow.Cells["ADRESI"].Value.ToString())
                        
                        if (kontrol != sepetGrid.Rows[iRow].Cells[4].Value.ToString())
                        {
                            totalcount = 0;
                            siparisNo = sepetGrid.Rows[iRow].Cells[7].Value.ToString();
                        }

                        kontrol = sepetGrid.Rows[iRow].Cells[4].Value.ToString();

                        if (totalcount == 0 && iRow != 0 && totalrecord == 0)
                        {
                            kayitSay = 0;
                            y = 180;
                            bNewPage = true;
                            bFirstPage = false;
                            bMorePagesToPrint = true;
                            totalrecord = 1;
                            sayfa = sayfa + 1;
                            break;
                        }
                        else
                        {
                            if (bNewPage)
                            {
                                myFont = new Font("Calibri", 10, FontStyle.Bold);
                                sbrush = new SolidBrush(Color.Black);
                                myPen = new Pen(Color.Black);
                                e.Graphics.DrawString(sepetGrid.Rows[iRow].Cells[8].Value.ToString() + " TARİHLİ SİPARİŞ LİSTESİ ", myFont, sbrush, x, 80);
                                //e.Graphics.DrawString("SEPET NO:" + sayfa.ToString(), myFont, sbrush, 450, 80);
                               // if (sepetGrid.Rows[iRow].Cells[0].Value != null) e.Graphics.DrawString("SEPET NO:  " + sayfa.ToString() + "  - " + sepetGrid.Rows[iRow].Cells[0].Value.ToString() + " - " + sepetGrid.Rows[iRow].Cells[1].Value.ToString(), myFont, sbrush, x, 95);
                                if (sepetGrid.Rows[iRow].Cells[0].Value != null) e.Graphics.DrawString("SEPET NO:  " + siparisNo.ToString() + "  - " + sepetGrid.Rows[iRow].Cells[0].Value.ToString() + " - " + sepetGrid.Rows[iRow].Cells[1].Value.ToString(), myFont, sbrush, x, 95);

                                if (sepetGrid.Rows[iRow].Cells[2].Value != null) e.Graphics.DrawString(sepetGrid.Rows[iRow].Cells[2].Value.ToString(), myFont, sbrush, x, 110);
                                if (sepetGrid.Rows[iRow].Cells[3].Value != null) e.Graphics.DrawString(sepetGrid.Rows[iRow].Cells[3].Value.ToString(), myFont, sbrush, x + 120, 110);
                                if (sepetGrid.Rows[iRow].Cells[4].Value != null) e.Graphics.DrawString(sepetGrid.Rows[iRow].Cells[4].Value.ToString(), myFont, sbrush, x, 125);
                                if (sepetGrid.Rows[iRow].Cells[5].Value != null) e.Graphics.DrawString(sepetGrid.Rows[iRow].Cells[5].Value.ToString() + "/" + sepetGrid.Rows[iRow].Cells[6].Value.ToString(), myFont, sbrush, x, 140);
                                if (sepetGrid.Rows[iRow].Cells[9].Value != null) e.Graphics.DrawString("Kargo No:" + sepetGrid.Rows[iRow].Cells[9].Value.ToString(), myFont, sbrush, x, 155);

                                myFont = new Font("Calibri", 10, FontStyle.Regular);
                            }
                            e.Graphics.DrawLine(myPen, x, y, 750, y);
                            //e.Graphics.DrawString(lvi.Text, myFont, sbrush, 120, y);
                            if (sepetGrid.Rows[iRow].Cells[10].Value != null) e.Graphics.DrawString(sepetGrid.Rows[iRow].Cells[10].Value.ToString().Trim(), myFont, sbrush, x, y);
                            if (sepetGrid.Rows[iRow].Cells[11].Value != null) e.Graphics.DrawString(" - " + sepetGrid.Rows[iRow].Cells[11].Value.ToString().Trim(), myFont, sbrush, x + 10, y);
                            if (sepetGrid.Rows[iRow].Cells[12].Value != null) e.Graphics.DrawString(sepetGrid.Rows[iRow].Cells[12].Value.ToString().Trim(), myFont, sbrush, x + 120, y);
                            if (sepetGrid.Rows[iRow].Cells[13].Value != null) e.Graphics.DrawString(sepetGrid.Rows[iRow].Cells[13].Value.ToString().Trim(), myFont, sbrush, x + 520, y);
                            if (sepetGrid.Rows[iRow].Cells[14].Value != null) e.Graphics.DrawString(sepetGrid.Rows[iRow].Cells[14].Value.ToString().Trim(), myFont, sbrush, x + 540, y);
                            if (sepetGrid.Rows[iRow].Cells[16].Value != null) e.Graphics.DrawString(sepetGrid.Rows[iRow].Cells[16].Value.ToString().Trim()+" TL. (1 Birim)", myFont, sbrush, x + 590, y);
                            y += 20;
                            bNewPage = false;
                        }
                        totalrecord = 0;
                        iRow++;
                        kayitSay++;
                        if (kayitSay % 15 == 0)// && sepetGrid.Rows[iRow+1].Cells[7].Value.ToString()== sepetGrid.Rows[iRow].Cells[7].Value.ToString())
                        {
                            y = 180;
                            bNewPage = true;
                            bFirstPage = true;
                            bMorePagesToPrint = true;
                            totalrecord = 1;
                            e.HasMorePages = true;
                            return;
                        }

                    }
                    if (bMorePagesToPrint)
                    {
                        e.HasMorePages = true;
                        //sayfa = sayfa + 1;
                    }
                }
                catch (Exception exc)
                {
                    //MessageBox.Show(exc.Message, "Bir Hata Oluştu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (raporAdi == "Sepet Barkod")
            {

                //y = 50;
                //int fark = 90;
                //int iLeftMargin = e.MarginBounds.Left;
                //int iTopMargin = e.MarginBounds.Top;
                //bool bMorePagesToPrint = false;

                //int konumx = int.Parse(txtX.Text.ToString());
                //int konumy = int.Parse(txtY.Text.ToString());

                //string myText = "Vertical text";


                //StringFormat stringFormat = new StringFormat();
                //SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));

                //stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;



                //myFont = new Font("Calibri", 8, FontStyle.Bold);
                //sbrush = new SolidBrush(Color.Black);
                //myPen = new Pen(Color.Black);
                //e.Graphics.DrawString("SEPET NUMARASI", myFont, sbrush, y, 50);
                //e.Graphics.DrawString(":", myFont, sbrush, y+ fark, 50);
                //e.Graphics.DrawString("ÜRÜN ADI", myFont, sbrush, y, 65);
                //e.Graphics.DrawString(":", myFont, sbrush, y + fark, 65);
                //e.Graphics.DrawString("GRAMAJ/MİKTAR", myFont, sbrush, y, 80);
                //e.Graphics.DrawString(":", myFont, sbrush, y + fark, 80);
                //e.Graphics.DrawString("SON KUL.TAR.", myFont, sbrush, y, 95);
                //e.Graphics.DrawString(":", myFont, sbrush, y + fark, 95);
                //e.Graphics.DrawString("ÜRETİM TAR.", myFont, sbrush, y, 110);
                //e.Graphics.DrawString(":", myFont, sbrush, y + fark, 110);
                //e.Graphics.DrawString("ÜRETİCİ KODU", myFont, sbrush, y, 125);
                //e.Graphics.DrawString(":", myFont, sbrush, y + fark, 125);
                //e.Graphics.DrawString("ÜRETİCİ ADI", myFont, sbrush, y, 140);
                //e.Graphics.DrawString(":", myFont, sbrush, y + fark, 140);

                //myFont = new Font("EAN-13 HALF HEIGHT", 40, FontStyle.Regular);

                //e.Graphics.DrawString("8690557064178", myFont, sbrush, 300, 65,stringFormat);


                ////e.Graphics.DrawLine(myPen, 100, y, 780, y);
                //////e.Graphics.DrawString(lvi.Text, myFont, sbrush, 120, y);
                ////if (dgvSonuc.Rows[iRow].Cells[0].Value != null) e.Graphics.DrawString(" (" + dgvSonuc.Rows[iRow].Cells["MARKASI"].Value.ToString().Trim() + ") " + dgvSonuc.Rows[iRow].Cells["URUNADI"].Value.ToString(), myFont, sbrush, 100, y);
                ////if (dgvSonuc.Rows[iRow].Cells[2].Value != null) e.Graphics.DrawString(" (" + dgvSonuc.Rows[iRow].Cells["ALINACAKLAR"].Value.ToString() + ")", myFont, sbrush, 650, y);
                ////if (dgvSonuc.Rows[iRow].Cells[3].Value != null) e.Graphics.DrawString(dgvSonuc.Rows[iRow].Cells["TEMIN_BIRIMI"].Value.ToString(), myFont, sbrush, 720, y);
            }
            if (raporAdi == "Stok Sayım")
            {
                try
                {
                    int iLeftMargin = e.MarginBounds.Left;
                    int iTopMargin = e.MarginBounds.Top;
                    bool bMorePagesToPrint = false;
                    y = 120;
                    while (iRow <= dgvSonuc.Rows.Count - 1)
                    {
                        DataGridViewRow GridRow = dgvSonuc.Rows[iRow];

                        double totalcount = Convert.ToDouble(iRow) % Convert.ToDouble(45);
                        if (totalcount == 0 && iRow != 0 && totalrecord == 0)
                        {
                            y = 120;
                            bNewPage = true;
                            bFirstPage = false;
                            bMorePagesToPrint = true;
                            totalrecord = 1;
                            break;
                        }
                        else
                        {
                            if (bNewPage)
                            {
                                myFont = new Font("Calibri", 10, FontStyle.Bold);
                                sbrush = new SolidBrush(Color.Black);
                                myPen = new Pen(Color.Black);
                                e.Graphics.DrawString(DateTime.Parse(txtTarihliSiparisler.Text.ToString()).ToString("dd.MM.yyyy") + " TARİHLİ SAYIM LİSTESİ        Sayfa:" + sayfa.ToString(), myFont, sbrush, 100, 80);
                                e.Graphics.DrawString("Stok Kodu", myFont, sbrush, 100, 100);
                                e.Graphics.DrawString("Stok Adı", myFont, sbrush, 220, 100);
                                myFont = new Font("Calibri", 10, FontStyle.Regular);
                            }
                            e.Graphics.DrawLine(myPen, 100, y, 780, y);
                            //e.Graphics.DrawString(lvi.Text, myFont, sbrush, 120, y);
                            if (dgvSonuc.Rows[iRow].Cells[0].Value != null) e.Graphics.DrawString(dgvSonuc.Rows[iRow].Cells["STOKKODU"].Value.ToString().Trim(), myFont, sbrush, 100, y);
                            if (dgvSonuc.Rows[iRow].Cells[1].Value != null) e.Graphics.DrawString(dgvSonuc.Rows[iRow].Cells["STOK_ADI"].Value.ToString(), myFont, sbrush, 200, y);

                            y += 20;
                            bNewPage = false;
                        }
                        iRow++;
                        totalrecord = 0;
                    }
                    if (bMorePagesToPrint)
                    {
                        e.HasMorePages = true;
                        sayfa++;
                    }
                    else
                        e.HasMorePages = false;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Bir Hata Oluştu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font myFont = new Font("Calibri", 10, FontStyle.Bold);
            SolidBrush sbrush = new SolidBrush(Color.Black);
            Pen myPen = new Pen(Color.Black);
            int y = 50;
            int fark = 100;
            int iLeftMargin = e.MarginBounds.Left;
            int iTopMargin = e.MarginBounds.Top;
            bool bMorePagesToPrint = false;

            int konumx = int.Parse(txtX.Text.ToString());
            int konumy = int.Parse(txtY.Text.ToString());

            StringFormat stringFormat = new StringFormat();
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));

            stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            myFont = new Font("Calibri", 8, FontStyle.Bold);
            sbrush = new SolidBrush(Color.Black);
            myPen = new Pen(Color.Black);

            stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            e.Graphics.DrawString("SEPET NUMARASI", myFont, sbrush, y, 50 + fark);
            e.Graphics.DrawString(": (" + DateTime.Now.ToString("dd.MM.yyyy") + ") " + barkodSinif._baslik, myFont, sbrush, y + fark, 50 + fark);
            e.Graphics.DrawString("ÜRÜN ADI", myFont, sbrush, y, 65 + fark);
            e.Graphics.DrawString(": " + barkodSinif._urunAdi.ToString(), myFont, sbrush, y + fark, 65 + fark);
            //e.Graphics.DrawString("GRAMAJ/MİKTAR", myFont, sbrush, y, 80 + fark);
            e.Graphics.DrawString("", myFont, sbrush, y, 80 + fark);
            e.Graphics.DrawString(": " + barkodSinif._gramaj, myFont, sbrush, y + fark, 80 + fark);
            e.Graphics.DrawString("SON KUL.TAR.", myFont, sbrush, y, 95 + fark);
            e.Graphics.DrawString(": " + barkodSinif._sonKullanimTarihi, myFont, sbrush, y + fark, 95 + fark);
            e.Graphics.DrawString("PKTLM. TAR.", myFont, sbrush, y, 110 + fark);
            e.Graphics.DrawString(": " + barkodSinif._uretimTarihi, myFont, sbrush, y + fark, 110 + fark);
            e.Graphics.DrawString("ÜRETİCİ KODU", myFont, sbrush, y, 125 + fark);
            e.Graphics.DrawString(": " + barkodSinif._ureticiKodu, myFont, sbrush, y + fark, 125 + fark);
            e.Graphics.DrawString("ÜRETİCİ ADI", myFont, sbrush, y, 140 + fark);
            e.Graphics.DrawString(": " + barkodSinif._ureticiAdi, myFont, sbrush, y + fark, 140 + fark);
            barcode.DrawEan13Barcode(e.Graphics, (new PointF(50, 68)));

            //myFont = new Font("EAN-13 HALF HEIGHT", 40, FontStyle.Regular);
            //e.Graphics.DrawString("8690557064178", myFont, sbrush, 300, 65 + fark, stringFormat);
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                sayfa = 1;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSepetSiparis_Click(object sender, EventArgs e)
        {
            //lblAdetSiparisVar.Text = "...";
            grpSonuc.Text = "Sepet Siparişiler";
            raporAdi = "Sepet Siparişler";

            sql = "SELECT SIPARIS.TICARI_UNVANI, SIPARIS.ADI_SOYADI,SIPARIS.CEP_TEL,SIPARIS.TEL1,SIPARIS.ADRESI,SIPARIS.ILI,SIPARIS.ILCESI, " +
                  "SIPARIS.SIPARIS_NO,SIPARIS.TARIHI,SIPARIS.KARGO_NO, SIPARISHR.SIRA_NO,SIPARISHR.STOKKODU,SIPARISHR.STOK_ADI,SIPARISHR.MIKTARI,STOK.BIRIMI , STOK.BARKODU, ROUND(SIPARISHR.KPB_KDVLI_TUTAR/SIPARISHR.MIKTARI,2) AS KDVLI_TUTAR " +
                  "FROM SIPARIS JOIN SIPARISHR ON SIPARISHR.BLMASKODU = SIPARIS.BLKODU JOIN STOK ON STOK.STOKKODU=SIPARISHR.STOKKODU " +
                  "WHERE ";
            if (chkSeciliTarih.Checked)
            {
                sql = sql + "SIPARIS.TARIHI>'" + DateTime.Parse(txtTarihliSiparisler.Text.ToString()).ToString("yyyy.MM.dd") + "' " +
                "AND SIPARIS.TARIHI<'" + DateTime.Parse(txtTarihliSiparisler.Text.ToString()).AddDays(1).ToString("yyyy.MM.dd") + "'  AND ";
            }
            string onaliyli = "";
            if (chkOnaylandi.Checked)
            {
                onaliyli = "SIPARIS.SIPARIS_DURUMU=5 OR ";
            }

            sql =sql+ "SIPARISHR.STOKKODU<>'krg01' AND SIPARIS.SILINDI=0 AND ("+onaliyli+" SIPARIS.SIPARIS_DURUMU=1 OR SIPARIS.SIPARIS_DURUMU=6) " +
            "ORDER BY SIPARIS.TARIHI, SIPARIS.ADI_SOYADI, SIPARISHR.SIRA_NO";

            dgvSonuc.DataSource = null;
            grideBas(sql, wolVoxConStr);
            lblAdetSiparisVar.Text = "Toplam " + (dgvSonuc.RowCount - 1).ToString() + " Adet";
        }

        private void btnSepetBarkod_Click(object sender, EventArgs e)
        {
            sql = "SELECT SIPARIS.TICARI_UNVANI, SIPARIS.ADI_SOYADI,SIPARIS.CEP_TEL,SIPARIS.TEL1,SIPARIS.ADRESI,SIPARIS.ILI,SIPARIS.ILCESI, " +
                  "SIPARIS.SIPARIS_NO,SIPARIS.TARIHI,SIPARIS.KARGO_NO, SIPARISHR.SIRA_NO,SIPARISHR.STOKKODU,SIPARISHR.STOK_ADI,SIPARISHR.MIKTARI,STOK.BIRIMI , " +
                  "STOK.BARKODU , STOK.BIRIM_AGIRLIK, STOK.MARKASI,STOK.URETICI_FIRMA " +
                  "FROM SIPARIS " +
                  "JOIN SIPARISHR ON SIPARISHR.BLMASKODU = SIPARIS.BLKODU " +
                  "JOIN STOK ON STOK.STOKKODU = SIPARISHR.STOKKODU " +
                  "WHERE ";
            if (chkSeciliTarih.Checked)
            {
                sql = sql + "SIPARIS.TARIHI>'" + DateTime.Parse(txtTarihliSiparisler.Text.ToString()).ToString("yyyy.MM.dd") + "' " +
                "AND SIPARIS.TARIHI<'" + DateTime.Parse(txtTarihliSiparisler.Text.ToString()).AddDays(1).ToString("yyyy.MM.dd") + "'  AND ";
            }
            string onaliyli = "";
            if (chkOnaylandi.Checked)
            {
                onaliyli = "SIPARIS.SIPARIS_DURUMU=5 OR ";
            }
            sql = sql + "SIPARISHR.STOKKODU<>'krg01' AND SIPARIS.SILINDI=0 AND (" + onaliyli + " SIPARIS.SIPARIS_DURUMU=1 OR SIPARIS.SIPARIS_DURUMU=6) " +
                  "ORDER BY SIPARIS.TARIHI, SIPARIS.ADI_SOYADI, SIPARISHR.SIRA_NO";

            this.Enabled = false;
            DataTable sonuc = new DataTable();

            try
            {
                //this.Enabled = false;
                sonuc = manager.BasitSorguDT(sql, wolVoxConStr);
                //this.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata :" + ex.ToString());
                //this.Enabled = true;
                return;
            }
            this.Enabled = true;

            raporAdi = "Sepet Barkod";
            grpSonuc.Text = "Sepet Barkod";

            //int sayac = 0;
            string kontrol = "";

            for (int i = 0; i < sonuc.Rows.Count; i++)
            {
                if (kontrol != sonuc.Rows[i]["ADRESI"].ToString())
                {
                    //sayac = sayac + 1;
                    barkodSinif._baslik = sonuc.Rows[i]["SIPARIS_NO"].ToString();
                }
                kontrol = sonuc.Rows[i]["ADRESI"].ToString();
                

                int tekrar = int.Parse(sonuc.Rows[i]["MIKTARI"].ToString());
                for (int ii = 0; ii < tekrar; ii++)
                {
                    //barkodSinif._baslik = sayac.ToString();
                    
                    if (sonuc.Rows[i]["STOK_ADI"].ToString().Length > 35)
                    {
                        barkodSinif._urunAdi = sonuc.Rows[i]["STOK_ADI"].ToString().Substring(0, 34);
                        barkodSinif._gramaj = sonuc.Rows[i]["STOK_ADI"].ToString().Substring(34);
                    }
                    else
                    {
                        barkodSinif._urunAdi = sonuc.Rows[i]["STOK_ADI"].ToString();
                        barkodSinif._gramaj = sonuc.Rows[i]["BIRIM_AGIRLIK"].ToString();
                    }
                    barkodSinif._sonKullanimTarihi = DateTime.Now.AddMonths(18).ToString("dd.MM.yyyy");
                    barkodSinif._uretimTarihi = DateTime.Now.ToString("dd.MM.yyyy");
                    barkodSinif._ureticiKodu = "";
                    barkodSinif._ureticiAdi = sonuc.Rows[i]["MARKASI"].ToString();

                    if (sonuc.Rows[i]["BARKODU"].ToString() != "" && sonuc.Rows[i]["BARKODU"].ToString().Length == 13)
                    {
                        //8690000070269
                        //bu kod barkodun ilk 2 hanesi -ülke kodu
                        barcode.CountryCode = sonuc.Rows[i]["BARKODU"].ToString().Substring(0, 2);  // txtUlke.Text.ToString(); //"90";
                                                                                                    //Bu kod üretici-imalatçı numarası -bu kısımın legal illegal gibi durumları da var
                        barcode.ManufacturerCode = sonuc.Rows[i]["BARKODU"].ToString().Substring(2, 4); //txtArakod.Text.ToString();// "0000";
                                                                                                        //Bu kod ürün kodu -ID si falanı felanı
                        barcode.ProductCode = sonuc.Rows[i]["BARKODU"].ToString().Substring(6, 6); //txtUrun.Text.ToString();// "600519";
                                                                                                   //Bu kısım boş geçilsede birşey değişmiyor EAN-13 te zaten 12 veri okuyorsunuz ,bu sayı  barkodun sonunda oluyor.
                        barcode.ChecksumDigit = sonuc.Rows[i]["BARKODU"].ToString().Substring(12, 1); //"0";// "5";
                        doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);

                        if (!chkSeciliBarkod.Checked)
                        {
                            doc.Print();
                        }
                        else
                        {
                            if (dgvSonuc.CurrentRow.Cells["ADRESI"].Value.ToString() == sonuc.Rows[i]["ADRESI"].ToString())
                            {
                                doc.Print();
                            }
                        }
                    }
                }

            }

            //return;
            #region

            //sayfa = 1;
            //printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            //printPreviewDialog1.ShowDialog();

            // Start Job 
            //SetMeasurement(2, 203); // Measurement=Centimeters Unit, nResolution=203 
            //SetMedia_LabelWithGaps(8, 4, 0.3, 0); // Label Width=8 cm, Label Len=4 cm, Gap Len=0.3 cm, Gap Offset=0 cm 
            //SetPrinter(3, 8, 1); // Speed=3, Darkness=8, Direct Thermal 
            //SetAfterPrint(1, 0); // Enable Tear-Off 
            //PrintTrueTypeFontA(0.213, 0.738, -10, 0, 0, 0, 0, 0, "Arial", "urunAdi"); // Tek satrl metin1 
            //PrintTrueTypeFontA(0.213, 1.21, -10, 0, 0, 0, 0, 0, "Arial", "gramaj"); // Tek satrl metin2 
            //PrintTrueTypeFontA(0.188, 1.75, -10, 0, 0, 0, 0, 0, "Arial", "sonKullanimTarihi"); // Tek satrl metin3 
            //PrintTrueTypeFontA(0.213, 2.28, -10, 0, 0, 0, 0, 0, "Arial", "uretimTarihi"); // Tek satrl metin4 
            //PrintTrueTypeFontA(0.238, 2.8, -10, 0, 0, 0, 0, 0, "Arial", "ureticiKodu"); // Tek satrl metin5 
            //PrintTrueTypeFontA(0.238, 3.33, -10, 0, 0, 0, 0, 0, "Arial", "ureticiAdi"); // Tek satrl metin6 
            //PrintTrueTypeFontA(0.238, 0.188, -10, 0, 0, 0, 0, 0, "Arial", "sepetNo"); // Tek satrl metin7 
            //PrintLabel(1, 1, 1); // Set=1, Copy=1, 180 degree printing 
            //PortClose(); // End Job 
            #endregion
        }

        private void btnSayfaAyarlari_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void btnStokAlisFaturalari_Click(object sender, EventArgs e)
        {
            if (txtStokBilgi.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Arama Sahası Boş Olamaz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            grpSonuc.Text = "Stok Alış Faturaları";
            sql = "SELECT * FROM (SELECT KAYNAK_STOKKODU AS STOK_KODU, URUNADI AS STOK_ADI, MARKASI,STOKLAR.BIRIMI, FATURA_NO, FATURALAR.TARIHI, TICARI_UNVANI, MIKTARI, KPB_FIYATI, KPB_TOPLAM_TUTAR, KPB_KDVLI_TUTAR " +
                "FROM( " +
                "SELECT  iif(KAYNAKSTOK_BLKODU IS NULL, BLKODU, KAYNAKSTOK_BLKODU) AS KAYNAKSTOK_BLKODU, " +
                        "iif(KAYNAK_STOKKODU <> '', KAYNAK_STOKKODU, STOKKODU) AS KAYNAK_STOKKODU, " +
                        "iif(KAYNAK_STOK_ADI <> '', KAYNAK_STOK_ADI, STOK_ADI) AS URUNADI, " +
                        "MARKASI, BIRIMI " +
                    "FROM " +
                            "(SELECT SONUC.BLKODU, SONUC.STOKKODU, SONUC.STOK_ADI, SONUC.MARKASI, SONUC.BIRIMI, SONUC.SIPARISMIKTARI, SONUC.STOK_MIKTARI, SONUC.TEMIN, " +
                                    "(SONUC.TEMIN * URETIM_CARPANI) AS ISTENEN_MIKTAR, KAYNAK_BIRIMI, URETILEN_BLKODU, URETILEN_STOKKODU, URETILEN_STOKADI, URETILEN_MIKTAR, KAYNAKSTOK_BLKODU, " +
                                    "KAYNAK_STOKKODU, KAYNAK_STOK_ADI, URETIM_CARPANI " +
                            "FROM " +
                                    "(SELECT STOKTAN.BLKODU, SIPARISHR.STOKKODU, SIPARISHR.STOK_ADI, STOKTAN.MARKASI, STOKTAN.BIRIMI, " +
                                            "SUM(SIPARISHR.MIKTARI) AS SIPARISMIKTARI, STOKTAN.STOK_MIKTARI, (SUM(SIPARISHR.MIKTARI) - STOKTAN.STOK_MIKTARI) + 1 AS TEMIN " +
                                    "FROM    SIPARIS " +
                                    "JOIN SIPARISHR ON SIPARISHR.BLMASKODU = SIPARIS.BLKODU " +
                                    "JOIN " +
                                        "(SELECT BLKODU, STOKKODU, STOK_ADI, STOK_MIKTARI, BIRIMI, MARKASI " +
                                        "FROM " +
                                            "(SELECT STOK.BLKODU, STOK.STOKKODU, STOK.STOK_ADI, STOK.GRUBU, STOK.ARA_GRUBU, STOK.ALT_GRUBU, STOK.BIRIMI, STOK.MARKASI, STOK.BIRIMLER, STOK.AKTIF, STOKHR.IADE, " +
                                                    "STOKHR.SILINDI, SUM(STOKHR.KPB_GMIK) - SUM(STOKHR.KPB_CMIK) AS STOK_MIKTARI " +
                                            "FROM    STOK " +
                                            "JOIN STOKHR ON STOKHR.BLSTKODU = STOK.BLKODU " +
                                            "WHERE(STOKHR.DEPO_ADI <> 'BLOKEDEPO'  AND STOKHR.SILINDI = 0) " +
                                            "GROUP BY STOK.BLKODU, STOK.STOKKODU, STOK.STOK_ADI, STOK.GRUBU, STOK.ARA_GRUBU, STOK.ALT_GRUBU, STOK.BIRIMI, STOK.BIRIMLER, STOK.AKTIF, STOKHR.IADE, STOKHR.SILINDI, STOK.MARKASI " +
                                            ") AA " +
                                        ") STOKTAN ON STOKTAN.STOK_ADI = SIPARISHR.STOK_ADI " +
                                        "WHERE SIPARISHR.STOKKODU <> 'krg01' " +
                                        "GROUP BY STOKTAN.BLKODU, SIPARISHR.STOKKODU, SIPARISHR.STOK_ADI, SIPARISHR.BIRIMI, STOKTAN.STOKKODU, STOKTAN.STOK_ADI, STOKTAN.STOK_MIKTARI, STOKTAN.BIRIMI, STOKTAN.MARKASI " +
                                    ") SONUC " +
                            "LEFT JOIN " +
                                    "(SELECT STOK.BLKODU AS URETILEN_BLKODU, STOK.STOKKODU AS URETILEN_STOKKODU, STOK.STOK_ADI AS URETILEN_STOKADI, BASIT_URETIM.MIKTARI AS URETILEN_MIKTAR, " +
                                            "BASIT_URETIMHR.BLSTKODU AS KAYNAKSTOK_BLKODU, BASIT_URETIMHR.STOKKODU AS KAYNAK_STOKKODU, BASIT_URETIMHR.STOK_ADI AS KAYNAK_STOK_ADI, " +
                                            "(BASIT_URETIMHR.TOPLAM_MIKTAR - BASIT_URETIMHR.FIRE_MIKTARI)  AS URETIM_CARPANI, BASIT_URETIMHR.BIRIMI AS KAYNAK_BIRIMI " +
                                    "FROM    BASIT_URETIM " +
                                    "JOIN BASIT_URETIMHR ON BASIT_URETIMHR.BLMASKODU = BASIT_URETIM.BLKODU " +
                                    "JOIN STOK ON STOK.BLKODU = BASIT_URETIM.BLSTKODU " +
                                    "WHERE BASIT_URETIM.DURUMU = 1 " +
                                    ") URETIM ON URETIM.URETILEN_BLKODU = SONUC.BLKODU " +
                            ") URETILEN " +
                    "LEFT JOIN " +
                            "(SELECT BLSTKODU, SUM(STOKHR.KPB_GMIK) - SUM(STOKHR.KPB_CMIK) AS ANA_STOK_MIKTARI " +
                            "FROM    STOKHR " +
                            "WHERE STOKHR.IADE = 0 AND  STOKHR.SILINDI = 0 " +
                            "GROUP BY DEPO_ADI, BLSTKODU " +
                            ") ANASAYIM ON ANASAYIM.BLSTKODU = KAYNAKSTOK_BLKODU " +
                    "WHERE(ANASAYIM.ANA_STOK_MIKTARI < ISTENEN_MIKTAR OR ANASAYIM.ANA_STOK_MIKTARI IS NULL) AND(SIPARISMIKTARI > STOK_MIKTARI OR STOK_MIKTARI IS NULL) " +
                ") STOKLAR " +
                "JOIN " +
                "( " +
                "SELECT " +
                "FATURAHR.STOKKODU, FATURA.FATURA_NO, FATURA.TARIHI, FATURA.TICARI_UNVANI, FATURAHR.BLKODU AS FATURAHRBLKODU, FATURAHR.BLSTKODU, FATURAHR.STOK_ADI, FATURAHR.BIRIMI, FATURAHR.MIKTARI, FATURAHR.KPB_FIYATI, KPB_TOPLAM_TUTAR, FATURAHR.KPB_KDVLI_TUTAR, " +
                "FATURA.BLKODU, FATURA.CARIKODU " +
                "FROM FATURAHR " +
                "JOIN FATURA ON FATURA.BLKODU = FATURAHR.BLFTKODU " +
                "WHERE FATURA_DURUMU = 5 AND FATURA.BLKODU = FATURAHR.BLFTKODU " +
                ") FATURALAR ON FATURALAR.STOKKODU = STOKLAR.KAYNAK_STOKKODU " +
                "WHERE FATURALAR.FATURA_NO IS NOT NULL AND FATURALAR.STOKKODU='" + txtStokBilgi.Text.ToString() + "' " +
                ") ALISFATURALARI "+
                "GROUP BY STOK_KODU, STOK_ADI, MARKASI,BIRIMI, FATURA_NO, TARIHI, TICARI_UNVANI, MIKTARI, KPB_FIYATI, KPB_TOPLAM_TUTAR, KPB_KDVLI_TUTAR "+
                "ORDER BY STOK_KODU";

            //FATURALAR.STOKKODU = '" + txtStokBilgi.Text.ToString() + "' " +


            dgvSonuc.DataSource = null;
            grideBas(sql, wolVoxConStr);
        }

        private void btnStokKontrol_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("STOKKONTROL", "GIRIS")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: STOKKONTROL - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            raporAdi = "Stok Sayım";

            Random rnd = new Random();
            int rastgele = 0;
            string sorgu = "";

            grpSonuc.Text = "Stok Alış Faturaları";
            sql = "SELECT STOK.STOKKODU, STOK.STOK_ADI, SUM(STOKHR.KPB_CMIK) AS MIKTARI " +
                  "FROM STOKHR " +
                  "JOIN STOK ON STOK.BLKODU = STOKHR.BLSTKODU " +
                  "WHERE STOKHR.TARIHI > '" + DateTime.Now.AddMonths(-1).ToString("yyyy.MM.dd") + "' AND STOKHR.KPB_CMIK IS NOT NULL AND STOKHR.KPB_CMIK > 0 " +
                  "GROUP BY STOK.STOKKODU, STOK.STOK_ADI " +
                  "ORDER BY MIKTARI DESC";

            this.Enabled = false;
            DataTable sayim = new DataTable();

            try
            {
                //this.Enabled = false;
                sayim = manager.BasitSorguDT(sql, wolVoxConStr);
                //this.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata :" + ex.ToString());
                this.Enabled = true;
                return;
            }
            for (int i = 0; i < 15; i++)
            {
                rastgele = rnd.Next(0, 500);
                sorgu = sorgu + "STOKKODU='" + sayim.Rows[rastgele]["STOKKODU"].ToString() + "' OR ";
            }
            sorgu = "SELECT STOKKODU, STOK_ADI FROM STOK WHERE " + sorgu + " 1<>1 ORDER BY STOK_ADI";

            dgvSonuc.DataSource = null;
            grideBas(sorgu, wolVoxConStr);

            this.Enabled = true;
        }

        private void btnBirimMaliyet_Click(object sender, EventArgs e)
        {
            if (txtStokBilgi.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Arama Sahası Boş Olamaz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            grpSonuc.Text = "Stok Alış Faturaları";
            sql = "SELECT FATURALARIM2.STOKKODU, FATURALARIM2.STOK_ADI, FATURALARIM2.TARIHI, FATURALARIM3.FATURA_STOK_ADI, FATURALARIM3.BIRIMI, FATURALARIM3.MIKTARI,ROUND(FATURALARIM3.KPB_KDVLI_TUTAR,2) AS BIRIM_ALIS_FIYATI, FATURALARIM3.BIRIM_MALIYETI, " +
            "FATURALARIM3.FATURA_NO,FATURALARIM3.TICARI_UNVANI "+
            "FROM("+
            "SELECT STOKKODU, STOK_ADI, MAX(TARIHI) AS TARIHI "+
            "FROM("+
            "SELECT STOKKODU, STOK_ADI, URETIM_CARPANI, FATURA_NO, MAXVALUE(TARIHI) AS TARIHI, TICARI_UNVANI, FATURA_STOK_ADI, BIRIMI, MIKTARI, KPB_FIYATI, KPB_TOPLAM_TUTAR, KPB_KDVLI_TUTAR, ROUND(URETIM_CARPANI * KPB_KDVLI_TUTAR,2) AS BIRIM_MALIYETI " +
            "FROM "+
            "("+
                "SELECT STOKLAR.STOKKODU, STOKLAR.STOK_ADI, iif(STOKLAR.URETIM_CARPANI IS NULL, 1, STOKLAR.URETIM_CARPANI) AS URETIM_CARPANI, "+
                "FATURALAR.FATURA_NO, FATURALAR.TARIHI, FATURALAR.TICARI_UNVANI, FATURALAR.STOK_ADI AS FATURA_STOK_ADI, FATURALAR.BIRIMI, FATURALAR.MIKTARI, FATURALAR.KPB_FIYATI, FATURALAR.KPB_TOPLAM_TUTAR, FATURALAR.KPB_KDVLI_TUTAR/FATURALAR.MIKTARI AS KPB_KDVLI_TUTAR " +
                "FROM("+
                    "SELECT  STOK.BLKODU, STOK.STOKKODU, STOK.STOK_ADI, STOK.URETICI_FIRMA, "+
                            "URETIMLER.KAYNAKSTOK_BLKODU, iif(URETIMLER.KAYNAK_STOKKODU IS NULL, STOK.STOKKODU, URETIMLER.KAYNAK_STOKKODU) AS KAYNAK_STOKKODU, URETIMLER.KAYNAK_STOK_ADI, "+
                           "URETIMLER.URETIM_CARPANI, URETIMLER.KAYNAK_BIRIMI "+
                    "FROM STOK "+
                    "LEFT JOIN("+
                            "SELECT  STOK.BLKODU AS URETILEN_BLKODU, STOK.STOKKODU AS URETILEN_STOKKODU, STOK.STOK_ADI AS URETILEN_STOKADI, BASIT_URETIM.MIKTARI AS URETILEN_MIKTAR, "+
                                    "BASIT_URETIMHR.BLSTKODU AS KAYNAKSTOK_BLKODU, BASIT_URETIMHR.STOKKODU AS KAYNAK_STOKKODU, BASIT_URETIMHR.STOK_ADI AS KAYNAK_STOK_ADI, "+
                                    "(BASIT_URETIMHR.TOPLAM_MIKTAR - BASIT_URETIMHR.FIRE_MIKTARI)  AS URETIM_CARPANI, BASIT_URETIMHR.BIRIMI AS KAYNAK_BIRIMI "+
                            "FROM    BASIT_URETIM "+
                            "JOIN    BASIT_URETIMHR ON BASIT_URETIMHR.BLMASKODU = BASIT_URETIM.BLKODU "+
                            "JOIN    STOK ON STOK.BLKODU = BASIT_URETIM.BLSTKODU "+
                            "WHERE BASIT_URETIM.DURUMU = 1 "+
                    ") URETIMLER ON URETIMLER.URETILEN_BLKODU = STOK.BLKODU "+
            ") STOKLAR "+
            "JOIN("+
                "SELECT  FATURAHR.STOKKODU, FATURA.FATURA_NO, FATURA.TARIHI, FATURA.TICARI_UNVANI, FATURAHR.BLKODU AS FATURAHRBLKODU, FATURAHR.BLSTKODU, FATURAHR.STOK_ADI, FATURAHR.BIRIMI, FATURAHR.MIKTARI, FATURAHR.KPB_FIYATI, "+
                        "KPB_TOPLAM_TUTAR, FATURAHR.KPB_KDVLI_TUTAR, FATURA.BLKODU, FATURA.CARIKODU "+
                "FROM FATURAHR "+
               "JOIN FATURA ON FATURA.BLKODU = FATURAHR.BLFTKODU "+
                "WHERE FATURA_DURUMU = 5 AND FATURA.BLKODU = FATURAHR.BLFTKODU "+
               " ORDER BY FATURA.TARIHI DESC "+
                ") FATURALAR ON FATURALAR.STOKKODU = STOKLAR.KAYNAK_STOKKODU "+
            ") BIRIM_FIYATLAR "+
            ") FATURALARIM "+
            "GROUP BY STOKKODU, STOK_ADI "+
            " ) FATURALARIM2 "+
             "JOIN("+
                     "SELECT STOKKODU, STOK_ADI, URETIM_CARPANI, FATURA_NO, TARIHI, TICARI_UNVANI, FATURA_STOK_ADI, BIRIMI, MIKTARI, KPB_FIYATI, KPB_TOPLAM_TUTAR, KPB_KDVLI_TUTAR, ROUND(URETIM_CARPANI * KPB_KDVLI_TUTAR,2) AS BIRIM_MALIYETI " +
                    "FROM "+
                    "("+
                        "SELECT STOKLAR.STOKKODU, STOKLAR.STOK_ADI, iif(STOKLAR.URETIM_CARPANI IS NULL, 1, STOKLAR.URETIM_CARPANI) AS URETIM_CARPANI, "+
                        "FATURALAR.FATURA_NO, FATURALAR.TARIHI, FATURALAR.TICARI_UNVANI, FATURALAR.STOK_ADI AS FATURA_STOK_ADI, FATURALAR.BIRIMI, FATURALAR.MIKTARI, FATURALAR.KPB_FIYATI, FATURALAR.KPB_TOPLAM_TUTAR, FATURALAR.KPB_KDVLI_TUTAR/FATURALAR.MIKTARI AS KPB_KDVLI_TUTAR " +
                        "FROM("+
                            "SELECT  STOK.BLKODU, STOK.STOKKODU, STOK.STOK_ADI, STOK.URETICI_FIRMA, "+
                                    "URETIMLER.KAYNAKSTOK_BLKODU, iif(URETIMLER.KAYNAK_STOKKODU IS NULL, STOK.STOKKODU, URETIMLER.KAYNAK_STOKKODU) AS KAYNAK_STOKKODU, URETIMLER.KAYNAK_STOK_ADI, "+
                                   " URETIMLER.URETIM_CARPANI, URETIMLER.KAYNAK_BIRIMI "+
                            "FROM STOK "+
                            "LEFT JOIN("+
                                   " SELECT  STOK.BLKODU AS URETILEN_BLKODU, STOK.STOKKODU AS URETILEN_STOKKODU, STOK.STOK_ADI AS URETILEN_STOKADI, BASIT_URETIM.MIKTARI AS URETILEN_MIKTAR, "+
                                            "BASIT_URETIMHR.BLSTKODU AS KAYNAKSTOK_BLKODU, BASIT_URETIMHR.STOKKODU AS KAYNAK_STOKKODU, BASIT_URETIMHR.STOK_ADI AS KAYNAK_STOK_ADI, "+
                                            "(BASIT_URETIMHR.TOPLAM_MIKTAR - BASIT_URETIMHR.FIRE_MIKTARI)  AS URETIM_CARPANI, BASIT_URETIMHR.BIRIMI AS KAYNAK_BIRIMI "+
                                    "FROM    BASIT_URETIM "+
                                    "JOIN    BASIT_URETIMHR ON BASIT_URETIMHR.BLMASKODU = BASIT_URETIM.BLKODU "+
                                   "JOIN    STOK ON STOK.BLKODU = BASIT_URETIM.BLSTKODU "+
                                   " WHERE BASIT_URETIM.DURUMU = 1 "+
                            ") URETIMLER ON URETIMLER.URETILEN_BLKODU = STOK.BLKODU "+
                    ") STOKLAR "+
                    "JOIN("+
                        "SELECT  FATURAHR.STOKKODU, FATURA.FATURA_NO, FATURA.TARIHI, FATURA.TICARI_UNVANI, FATURAHR.BLKODU AS FATURAHRBLKODU, FATURAHR.BLSTKODU, FATURAHR.STOK_ADI, FATURAHR.BIRIMI, FATURAHR.MIKTARI, FATURAHR.KPB_FIYATI, "+
                                "KPB_TOPLAM_TUTAR, FATURAHR.KPB_KDVLI_TUTAR, FATURA.BLKODU, FATURA.CARIKODU "+
                        "FROM FATURAHR "+
                        "JOIN FATURA ON FATURA.BLKODU = FATURAHR.BLFTKODU "+
                        "WHERE FATURA_DURUMU = 5 AND FATURA.BLKODU = FATURAHR.BLFTKODU "+
                        "ORDER BY FATURA.TARIHI DESC "+
                        ") FATURALAR ON FATURALAR.STOKKODU = STOKLAR.KAYNAK_STOKKODU "+
                    ") BIRIM_FIYATLAR "+
            ") FATURALARIM3 ON FATURALARIM3.STOKKODU = FATURALARIM2.STOKKODU AND FATURALARIM3.STOK_ADI = FATURALARIM2.STOK_ADI AND FATURALARIM3.TARIHI = FATURALARIM2.TARIHI "+
            "WHERE FATURALARIM3.STOKKODU='" + txtStokBilgi.Text.ToString() + "' " +
            "ORDER BY FATURALARIM3.STOK_ADI,FATURALARIM3.STOKKODU";
            dgvSonuc.DataSource = null;
            grideBas(sql, wolVoxConStr);
        }

        private void chkOnaylandi_CheckedChanged(object sender, EventArgs e)
        {
            chkSeciliTarih.Checked = true;
            chkSeciliTarih.Refresh();
        }
    }
}
