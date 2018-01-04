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
using System.Collections;

namespace AnalizProje
{
    public partial class RaporlarSatis : Form
    {
        Manager manager = new Manager();

        string analizConStr = "";
        string wolVoxConStr = "";
        string sql = "";
        string raporAdi = "";
        string cariAdisoyadi = "";
        string cariTicariUnvani = "";

        public RaporlarSatis()
        {
            InitializeComponent();
            analizConStr = manager.conStrAnaliz;
            wolVoxConStr = manager.conStrWolvox;
        }

        private void btnCariAra_Click(object sender, EventArgs e)
        {
            raporAdi = "BirimBasliSatis";
             sql = "SELECT SUM(SATISLAR.MIKTARI) AS MIKTAR, SATISLAR.BIRIMI, SATISLAR.STOKKODU , STOK.STOK_ADI "+
                         "FROM "+
                         "(SELECT "+
                         "FATURAHR.MIKTARI, FATURAHR.BIRIMI, FATURAHR.STOK_ADI, FATURA.CARIKODU, FATURA.TARIHI, "+
                         "FATURA.FATURA_NO, FATURA.FATURA_SERI, FATURA.SILINDI, FATURA.KARGO_FIRMASI, FATURA.KARGO_NO, FATURA.FATURA_KESILDI, "+
                         "FATURA.BLCRKODU, FATURA.SEVK_ADRESI, FATURA.SEVK_ILI, FATURA.SEVK_ILCESI, FATURA.SEVK_ULKESI, FATURA.TOPLAM_ALT_KPB, "+ 
                         "FATURA.YUVARLAMA_KPB, FATURA.TOPLAM_KDV_KPB, FATURA.TOPLAM_GENEL_KPB, FATURA.MIKTAR1_TOPLAM, FATURAHR.SIRA_NO, "+
                         "FATURAHR.EVRAK_NO, FATURAHR.BLSTKODU, FATURAHR.KPB_FIYATI, FATURAHR.KDV_ORANI, FATURAHR.KDV_TUTARI, FATURAHR.KPB_KDV_HARICFY, "+
                         "FATURAHR.KPB_IND_FIYAT, FATURAHR.KPB_IND_TUTAR, FATURAHR.KPB_TOPLAM_TUTAR, FATURAHR.KPB_KDVLI_TUTAR, FATURAHR.EKBILGI_1, "+
                         "FATURAHR.EKBILGI_2, FATURAHR.STOKKODU "+
                         "FROM FATURA, FATURAHR "+
                         "WHERE FATURAHR.BLFTKODU = FATURA.BLKODU "+
                         "ORDER BY FATURAHR.MIKTARI DESC, FATURA.TARIHI, FATURA.FATURA_NO, FATURA.ADI_SOYADI, TICARI_UNVANI "+
                         ") AS SATISLAR "+
                         "LEFT JOIN STOK ON STOK.STOKKODU = SATISLAR.STOKKODU "+
                         "GROUP BY SATISLAR.BIRIMI,SATISLAR.STOKKODU,STOK.STOK_ADI, SATISLAR.BIRIMI "+
                         "ORDER BY SATISLAR.BIRIMI,MIKTAR DESC";
            grideBas(sql,wolVoxConStr);

        }

        private void RaporlarSatis_Load(object sender, EventArgs e)
        {

        }

        private void btnSiparisler_Click(object sender, EventArgs e)
        {
            grpSonuc.Text = "Bekleyen Siparişler";
            raporAdi = "BekleyenSiparisler";

            sql = "SELECT "+
                  "TARIHI,TICARI_UNVANI, ADI_SOYADI,SIPARIS_NO, STOKKODU, STOK_ADI, MIKTARI, BIRIMI, SUM(MERKEZDEPO) AS MERKEZDEPO,SUM(GIDADEPO) AS GIDADEPO," +
                  "KPB_FIYATI, KDV_ORANI, KPB_TOPLAM_TUTAR, BARKODU,"+
                  "SUM(STOK_MIKTARI) AS TOPLAM_STOK "+
                  "FROM ( "+
                  "SELECT "+
                  "SIPARISHR.SIRA_NO, SIPARIS.TARIHI, SIPARIS.TICARI_UNVANI, SIPARIS.ADI_SOYADI, SIPARIS.SIPARIS_NO, SIPARISHR.STOKKODU, SIPARISHR.STOK_ADI, SIPARISHR.BIRIMI, SIPARISHR.MIKTARI, "+
                  "SIPARISHR.KPB_FIYATI, SIPARISHR.KDV_ORANI, SIPARISHR.KPB_TOPLAM_TUTAR, STOKHR.DEPO_ADI, STOK.BARKODU, "+
                  "SUM(STOKHR.KPB_GMIK) - SUM(STOKHR.KPB_CMIK) AS STOK_MIKTARI, "+
                  "IIF(STOKHR.DEPO_ADI = 'MERKEZDEPO', SUM(STOKHR.KPB_GMIK) - SUM(STOKHR.KPB_CMIK), 0) AS MERKEZDEPO, "+
                  "IIF(STOKHR.DEPO_ADI = 'GIDADEPO', SUM(STOKHR.KPB_GMIK) - SUM(STOKHR.KPB_CMIK), 0) AS GIDADEPO "+
                  "FROM SIPARIS "+
                  "JOIN SIPARISHR ON SIPARISHR.BLMASKODU = SIPARIS.BLKODU "+
                  "JOIN STOK ON STOK.BLKODU = SIPARISHR.BLSTKODU "+
                  "JOIN STOKHR ON STOKHR.BLSTKODU = STOK.BLKODU "+
                  "WHERE SIPARIS.SIPARIS_DURUMU = 1 AND SIPARIS.SILINDI = 0 AND STOK.AKTIF = 1 AND STOKHR.DEPO_ADI <> 'BLOKEDEPO' AND STOK.STOKKODU <> 'krg01' "+
                  "GROUP BY "+
                  "SIPARIS.TARIHI, SIPARIS.TICARI_UNVANI, SIPARIS.ADI_SOYADI, SIPARISHR.SIRA_NO, SIPARIS.SIPARIS_NO, SIPARISHR.STOKKODU, SIPARISHR.STOK_ADI, SIPARISHR.BIRIMI, SIPARISHR.MIKTARI, "+
                  "SIPARISHR.KPB_FIYATI, SIPARISHR.KDV_ORANI, SIPARISHR.KPB_TOPLAM_TUTAR, STOKHR.DEPO_ADI, STOK.BARKODU) AA "+
                  "GROUP BY SIRA_NO, TARIHI, TICARI_UNVANI, ADI_SOYADI, SIPARIS_NO, STOKKODU, STOK_ADI, BIRIMI, MIKTARI, "+
                  "KPB_FIYATI, KDV_ORANI, KPB_TOPLAM_TUTAR, BARKODU "+
                  "ORDER BY TARIHI, TICARI_UNVANI, ADI_SOYADI, SIRA_NO";
             grideBas(sql,wolVoxConStr);
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


        private void btnCevapBekleyenGorusmeler_Click(object sender, EventArgs e)
        {
            grpSonuc.Text = "Görüşmeler";
            raporAdi = "Gorusmeler";
            sql = "SELECT "+
                    "AAA.ADI_SOYADI, AAA.TICARI_UNVANI, " +
                    "ABB.SEVIYE_ADI AS ILK_ARAMA_ILETISIM_SEKLI, " +
                    "ACC.SEVIYE_ADI AS ILK_ILETISIM_TURU, " +
                    "LST1.AAGORUSME_TARIHI AS ILK_GORUSME_TARIHI, " +
                    "LST1.AAGORUSME_ICERIGI AS ILK_GORUSME_ICERIGI, " +
                    "LST1.AAGORUSULEN_KISI AS ILK_GORUSULEN_KISI, " +
                    "LST1.AAPERSONEL AS ILK_GORUSEN_PERSONEL, " +
                    "BBB.SEVIYE_ADI AS DONUS_ARAMA_ILETISIM_SEKLI, " +
                    "BCC.SEVIYE_ADI AS DONUS_ILETISIM_TURU, " +
                    "LST1.BBGORUSME_TARIHI AS DONUS_GORUSME_TARIHI, " +
                    "LST1.BBGORUSME_ICERIGI AS DONUS_GORUSME_ICERIGI, " +
                    "LST1.BBGORUSULEN_KISI AS DONUS_GORUSULEN_KISI, " +
                    "LST1.BBPERSONEL AS DONUS_GORUSEN_PERSONEL " +
                    "FROM(" +
                    "SELECT " +
                    "AA.CARI_ID, " +
                    "AA.ILETISIM_SEKLI AS AAILETISIMSEKLI, AA.ILETISIM_TURU AS AAILETISIMTURU, AA.GORUSME_TARIHI AS AAGORUSME_TARIHI, " +
                    "AA.GORUSME_ICERIGI AS AAGORUSME_ICERIGI, AA.GORUSULEN_KISI AS AAGORUSULEN_KISI, AA.KAYDEDEN AS AAPERSONEL, AA.KAYIT_TARIHI AS AAKAYIT_TARIHI, " +
                    "BB.ILETISIM_SEKLI AS BBILETISIMSEKLI, BB.ILETISIM_TURU AS BBILETISIMTURU, BB.GORUSME_TARIHI AS BBGORUSME_TARIHI, " +
                    "BB.GORUSME_ICERIGI AS BBGORUSME_ICERIGI, BB.GORUSULEN_KISI AS BBGORUSULEN_KISI, BB.KAYDEDEN AS BBPERSONEL, BB.KAYIT_TARIHI AS BBKAYIT_TARIHI " +
                    "FROM CARI_GORUSMELER AA " +
                    "LEFT JOIN CARI_GORUSMELER BB ON BB.UST_GORUSME_ID = AA.CARI_GORUSMELER_ID " +
                    "WHERE AA.GERI_DONUS = 1) LST1 " +
                    "JOIN CARI AAA ON AAA.CARI_ID = LST1.CARI_ID " +
                    "JOIN PARAMETRE ABB ON ABB.PARAMETRE_ID = LST1.AAILETISIMSEKLI " +
                    "JOIN PARAMETRE ACC ON ACC.PARAMETRE_ID = LST1.AAILETISIMTURU " +
                    "LEFT JOIN PARAMETRE BBB ON BBB.PARAMETRE_ID = LST1.BBILETISIMSEKLI " +
                    "LEFT JOIN PARAMETRE BCC ON BCC.PARAMETRE_ID = LST1.BBILETISIMTURU";
            dgvSonuc.DataSource = null;
            grideBas(sql,analizConStr);
        }

        private void btnCevapsiz_Click(object sender, EventArgs e)
        {
            grpSonuc.Text = "Cevapsız Görüşmeler";
            rprCevapsizGorusmeler();
        }

        public void rprCevapsizGorusmeler()
        {
            raporAdi = "CevapsizGorusmeler";
            sql = "SELECT LST1.CARI_GORUSMELER_ID," +
                "AAA.CARI_ID,AAA.ADI_SOYADI, AAA.TICARI_UNVANI, " +
                "ABB.SEVIYE_ADI AS ILK_ARAMA_ILETISIM_SEKLI, " +
                "ACC.SEVIYE_ADI AS ILK_ILETISIM_TURU, " +
                "LST1.AAGORUSME_TARIHI AS ILK_GORUSME_TARIHI, " +
                "LST1.AAGORUSME_ICERIGI AS ILK_GORUSME_ICERIGI, " +
                "LST1.AAGORUSULEN_KISI AS ILK_GORUSULEN_KISI, " +
                "LST1.AAPERSONEL AS ILK_GORUSEN_PERSONEL " +
                "FROM(" +
                "SELECT AA.CARI_GORUSMELER_ID," +
                "AA.CARI_ID, " +
                "AA.ILETISIM_SEKLI AS AAILETISIMSEKLI, AA.ILETISIM_TURU AS AAILETISIMTURU, AA.GORUSME_TARIHI AS AAGORUSME_TARIHI, " +
                "AA.GORUSME_ICERIGI AS AAGORUSME_ICERIGI, AA.GORUSULEN_KISI AS AAGORUSULEN_KISI, AA.KAYDEDEN AS AAPERSONEL, AA.KAYIT_TARIHI AS AAKAYIT_TARIHI, " +
                "BB.ILETISIM_SEKLI AS BBILETISIMSEKLI, BB.ILETISIM_TURU AS BBILETISIMTURU, BB.GORUSME_TARIHI AS BBGORUSME_TARIHI, " +
                "BB.GORUSME_ICERIGI AS BBGORUSME_ICERIGI, BB.GORUSULEN_KISI AS BBGORUSULEN_KISI, BB.KAYDEDEN AS BBPERSONEL, BB.KAYIT_TARIHI AS BBKAYIT_TARIHI " +
                "FROM CARI_GORUSMELER AA " +
                "LEFT JOIN CARI_GORUSMELER BB ON BB.UST_GORUSME_ID = AA.CARI_GORUSMELER_ID " +
                "WHERE (AA.GERI_DONUS = 1 OR AA.UZMAN_ARAMASI =1)  AND BB.ILETISIM_TURU IS NULL) LST1 " +
                "JOIN CARI AAA ON AAA.CARI_ID = LST1.CARI_ID " +
                "JOIN PARAMETRE ABB ON ABB.PARAMETRE_ID = LST1.AAILETISIMSEKLI " +
                "JOIN PARAMETRE ACC ON ACC.PARAMETRE_ID = LST1.AAILETISIMTURU " +
                "ORDER BY AAA.ADI_SOYADI, AAA.TICARI_UNVANI,ILK_GORUSME_TARIHI ";

            dgvSonuc.DataSource = null;
            grideBas(sql, analizConStr);

        }

        private void dgvSonuc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (raporAdi == "CevapsizGorusmeler")
            {
                if (dgvSonuc.Rows.Count<2)
                {
                    return;
                }
                //Yetki Sorgulama
                if (!(manager.YetkiSorgula("GORUSMELER", "GIRIS")))
                {
                    MessageBox.Show("Yetkiniz Yok! (Uygulama: GORUSMELER - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Manager.CariIdTasi = dgvSonuc.CurrentRow.Cells["CARI_ID"].Value.ToString();
                Manager.VeriTasi = dgvSonuc.CurrentRow.Cells["CARI_GORUSMELER_ID"].Value.ToString();
                Gorusmeler gorusmeler = new Gorusmeler();
                //adresler.MdiParent = this;
                gorusmeler.Text = "Görüşmeler";
                grpButonlar.Enabled = false;

                gorusmeler.ShowDialog();
                rprCevapsizGorusmeler();

                grpButonlar.Enabled = true;
                Manager.VeriTasi = null;
            }
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
                sql = "SELECT SIPARIS.TICARI_UNVANI, SIPARIS.ADI_SOYADI, SIPARIS.EKBILGI_1,SIPARISHR.STOKKODU, SIPARISHR.STOK_ADI,SIPARISHR.BIRIMI, SIPARISHR.MIKTARI,"+
                    "SIPARIS.SEVK_ADRESI, SIPARIS.ILCESI, SIPARIS.ILI FROM SIPARIS JOIN SIPARISHR ON SIPARISHR.BLMASKODU = SIPARIS.BLKODU  WHERE SIPARIS.BLKODU = "+
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
            if (raporAdi== "Müşteri Araması")
            {
                DataTable analizDtSonuc = new DataTable();
                int cariVar = 0;
                int deger = 0;
                int blkodu = 0;
                string sonCariId = "0";
                bool kayitVar = false;

                //Manager.CariIdTasi = dgvSonuc.CurrentRow.Cells["CARI_ID"].Value.ToString();

                sql = "SELECT * FROM CARI WHERE ADI_SOYADI='" + dgvSonuc.CurrentRow.Cells["ADI_SOYADI"].Value.ToString() + "' AND " +
                    " TICARI_UNVANI='" + dgvSonuc.CurrentRow.Cells["TICARI_UNVANI"].Value.ToString() + "' AND " +
                            "(CEP_TEL='" + dgvSonuc.CurrentRow.Cells["CEP_TEL"].Value.ToString() + "' OR CEP_TEL IS NULL OR CEP_TEL='' ) AND " +
                            "(TELEFON1='" + dgvSonuc.CurrentRow.Cells["TEL1"].Value.ToString() + "' OR TELEFON1 IS NULL  OR TELEFON1='')";

                DataTable cariAra = new DataTable();
                try
                {
                    this.Enabled = false;
                    cariAra = manager.BasitSorguDT(sql, analizConStr);
                    this.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata :" + ex.ToString());
                    this.Enabled = true;
                    return;
                }
                if (cariAra !=null && cariAra.Rows.Count>0)
                {
                    //Yetki Sorgulama
                    if (!(manager.YetkiSorgula("GORUSMELER", "GIRIS")))
                    {
                        MessageBox.Show("Yetkiniz Yok! (Uygulama: GORUSMELER - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    Manager.CariIdTasi = cariAra.Rows[0]["CARI_ID"].ToString();
                }
                else
                {


                    sql = "SELECT * FROM CARI WHERE ADI_SOYADI='" + dgvSonuc.CurrentRow.Cells["ADI_SOYADI"].Value.ToString() + "' AND " +
                            " TICARI_UNVANI='" + dgvSonuc.CurrentRow.Cells["TICARI_UNVANI"].Value.ToString() + "' AND " +
                            "(CEP_TEL='" + dgvSonuc.CurrentRow.Cells["CEP_TEL"].Value.ToString() + "' OR CEP_TEL IS NULL) AND " +
                            "(TEL1='" + dgvSonuc.CurrentRow.Cells["TEL1"].Value.ToString() + "' OR TEL1 IS NULL)";

                    DataTable wolvoxcariAra = new DataTable();
                    try
                    {
                        this.Enabled = false;
                        wolvoxcariAra = manager.BasitSorguDT(sql, wolVoxConStr);
                        this.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata :" + ex.ToString());
                        this.Enabled = true;
                        return;
                    }

                    cariAra = new DataTable();
                    cariAra = manager.GetDataTableFull("CARI", "CARI_ID=" + "0", analizConStr);

                    cariAra.Rows.Add();
                    deger = 0;// int.Parse(cariAra.Rows[0]["CARI_ID"].ToString());
                    cariAra.Rows[0]["ADI"] = dgvSonuc.CurrentRow.Cells["ADI"].Value.ToString();
                    cariAra.Rows[0]["SOYADI"] = dgvSonuc.CurrentRow.Cells["SOYADI"].Value.ToString();
                    cariAra.Rows[0]["ADI_SOYADI"] = dgvSonuc.CurrentRow.Cells["ADI_SOYADI"].Value.ToString();
                    cariAra.Rows[0]["TICARI_UNVANI"] = dgvSonuc.CurrentRow.Cells["TICARI_UNVANI"].Value.ToString();
                    cariAra.Rows[0]["CEP_TEL"] = dgvSonuc.CurrentRow.Cells["CEP_TEL"].Value.ToString();
                    cariAra.Rows[0]["FAKS"] = dgvSonuc.CurrentRow.Cells["FAKS"].Value.ToString();
                    cariAra.Rows[0]["TELEFON1"] = dgvSonuc.CurrentRow.Cells["TEL1"].Value.ToString();
                    cariAra.Rows[0]["VERGI_NO"] = dgvSonuc.CurrentRow.Cells["VERGI_NO"].Value.ToString();
                    cariAra.Rows[0]["EMAIL1"] = dgvSonuc.CurrentRow.Cells["EMAIL1"].Value.ToString();
                    cariAra.Rows[0]["SEKTOR"] = 94;


                    cariAra.Rows[0]["GRUBU"] = 9; // Parametre Bireysel
                    if (cariAra.Rows[0]["VERGI_NO"].ToString() != "")
                    {
                       cariAra.Rows[0]["GRUBU"] = 49; // Parametre Kurumsal
                    }

                    if (!kayitVar)
                    {
                       cariAra.Rows[0]["KAYDEDEN"] = Manager.KullaniciAdSoyad.ToString();
                    }
                    cariAra.Rows[0]["GUNCELLEYEN"] = Manager.KullaniciAdSoyad.ToString();


                    // kaydetme if koşulu içinde oluyor
                    if (manager.kaydetGuncelle("CARI", "CARI_ID", deger, cariAra, analizConStr))
                    {
                        cariAdisoyadi = cariAra.Rows[0]["ADI_SOYADI"].ToString();
                        cariTicariUnvani = "='" + cariAra.Rows[0]["TICARI_UNVANI"].ToString() + "'";

                        if (cariAdisoyadi == "")
                        {
                            cariAdisoyadi = "";
                        }
                        if (cariTicariUnvani == "=''")
                        {
                            cariTicariUnvani = " IS NULL ";
                        }

                        string sorgum = "ADI_SOYADI='" + cariAdisoyadi + "' " +
                            " AND TICARI_UNVANI" + cariTicariUnvani +
                            " AND KAYDEDEN='" + Manager.KullaniciAdSoyad.ToString() + "'";

                        analizDtSonuc = manager.GetDataTableFull("CARI", sorgum, analizConStr);
                        deger = int.Parse(analizDtSonuc.Rows[0]["CARI_ID"].ToString());
                        //MessageBox.Show("Kaydetme İşlemi Tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cari Güncelleme İşleminde Hata. Kayıt Gerçekleşmedi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                        

                     //CARI_ALT ile wolvox cari verileri kaydedilir
                     analizDtSonuc = manager.GetDataTableFull("CARI_ALT", "CARI_ID=" + deger.ToString() + " AND BLKODU=" + dgvSonuc.CurrentRow.Cells["CARI_BLKODU"].Value.ToString(), analizConStr);
                     if (analizDtSonuc.Rows.Count == 0)
                     {
                         analizDtSonuc.Rows.Add();
                         cariVar = 0;
                     }
                     else
                     {
                         cariVar = 1;
                     }
                     analizDtSonuc.Rows[0]["CARI_ID"] = deger;

                     for (int ii = 0; ii < wolvoxcariAra.Columns.Count; ii++)
                     {
                         analizDtSonuc.Rows[0][0] = deger;
                         analizDtSonuc.Rows[0][ii + 1] = wolvoxcariAra.Rows[0][ii];
                     }
                     blkodu = int.Parse(analizDtSonuc.Rows[0]["BLKODU"].ToString());

                     manager.kaydetGuncelleCari("CARI_ALT", "CARI_ID", cariVar, blkodu, analizDtSonuc, analizConStr);


                    Manager.CariIdTasi = deger.ToString();


                    //AdresleriKaydet
                    DataTable adresVarMi = new DataTable();
                    string adresSql = "";
                    adresSql = "SELECT * FROM(" +
                    "SELECT NULL AS CARI_ADRES_ID, CARI_ID, BLKODU, " +
                    "ADRESI_1 AS ACIK_ADRES, ILCESI_1 AS ADRES_ILCE , ILI_1 AS ADRES_IL, ULKESI_1 AS ULKE, " +
                    "NULL AS POSTA_KODU, 0 AS ILETISIM_ADRESI_MI, " +
                    "KONUM1_LAT AS KONUM_LAT, KONUM1_LNG AS KONUM_LNG, 1 AS AKTIF, " +
                    "NULL AS KAYDEDEN, NULL AS KAYIT_TARIHI, NULL AS GUNCELLEYEN, NULL AS GUNCELLEME_TARIGI " +
                    "FROM CARI_ALT WHERE ADRESI_1 IS NOT NULL " +
                    "UNION ALL " +
                    "SELECT NULL AS CARI_ADRES_ID, CARI_ID, BLKODU, " +
                    "ADRESI_2 AS ACIK_ADRES, ILCESI_2 AS ADRES_ILCE ,ILI_2 AS ADRES_IL,  ULKESI_2 AS ULKE, " +
                    "NULL AS POSTA_KODU, 0 AS ILETISIM_ADRESI_MI, " +
                    "NULL AS KONUM_LAT, NULL AS KONUM_LNG, 1 AS AKTIF, " +
                    "NULL AS KAYDEDEN, NULL AS KAYIT_TARIHI, NULL AS GUNCELLEYEN, NULL AS GUNCELLEME_TARIGI " +
                    "FROM CARI_ALT WHERE ADRESI_2 IS NOT NULL " +
                    "UNION ALL " +
                    "SELECT NULL AS CARI_ADRES_ID, CARI_ID, BLKODU, " +
                    "ADRESI_FATURA AS ACIK_ADRES, ILCESI_FATURA AS ADRES_ILCE ,ILI_FATURA AS ADRES_IL,  ULKESI_FATURA AS ULKE, " +
                    "NULL AS POSTA_KODU, 0 AS ILETISIM_ADRESI_MI,  " +
                    "NULL AS KONUM_LAT, NULL AS KONUM_LNG,1 AS AKTIF, " +
                    "NULL AS KAYDEDEN, NULL AS KAYIT_TARIHI, NULL AS GUNCELLEYEN, NULL AS GUNCELLEME_TARIGI " +
                    "FROM CARI_ALT WHERE ADRESI_FATURA IS NOT NULL) " +
                    "WHERE CARI_ID = " + deger.ToString() + " " +
                    "ORDER BY CARI_ID, BLKODU";
                    analizDtSonuc = manager.BasitSorguDT(adresSql, analizConStr);

                    for (int i = 0; i < analizDtSonuc.Rows.Count; i++)
                    {
                        sql = "SELECT * FROM CARI_ADRES WHERE CARI_ID=" + deger.ToString() + " AND BLKODU=" + analizDtSonuc.Rows[i]["BLKODU"].ToString();
                        adresVarMi = manager.BasitSorguDT(sql, analizConStr);
                        if (adresVarMi.Rows.Count == 0)
                        {
                            adresVarMi.Rows.Add();
                            for (int ii = 0; ii < adresVarMi.Columns.Count; ii++)
                            {
                                adresVarMi.Rows[0][ii] = analizDtSonuc.Rows[i][ii];
                            }
                            if (adresVarMi.Rows[0]["KAYDEDEN"].ToString() == "") adresVarMi.Rows[0]["KAYDEDEN"] = Manager.KullaniciAdSoyad.ToString();
                            adresVarMi.Rows[0]["GUNCELLEYEN"] = Manager.KullaniciAdSoyad.ToString();
                            manager.kaydetGuncelle("CARI_ADRES", "CARI_ADRES_ID", 0, adresVarMi, analizConStr);
                        }
                    }

                    //***********************************************

                }
                
                Gorusmeler gorusmeler = new Gorusmeler();
                //adresler.MdiParent = this;
                string baslik = cariAra.Rows[0]["ADI"].ToString().Trim() + " " + cariAra.Rows[0]["SOYADI"].ToString().Trim() + " - " + cariAra.Rows[0]["TICARI_UNVANI"].ToString().Trim();
                Manager.CariAdTasi = null;
                //Manager.CariAdTasi = baslik + "- Tel:" + txtCepTelefonu.Text.Trim();
                gorusmeler.Text = baslik;
                gorusmeler.ShowDialog();
                return;
                
            }
        }

        private void btnSiparisteAra_Click(object sender, EventArgs e)
        {
            if (txtSiparisteAra.Text.ToString().Trim()=="")
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

        private void btnTarihArasiMusteri_Click(object sender, EventArgs e)
        {
            grpSonuc.Text = "Müşteri Araması";
            raporAdi = "Müşteri Araması";
            sql = "SELECT "+
                  "CARI.BLKODU AS CARI_BLKODU, SIPARIS.BLKODU, SIPARIS.CARIKODU, SIPARIS.TICARI_UNVANI, SIPARIS.ADI_SOYADI, SIPARIS.TEL1,SIPARIS.CEP_TEL, SIPARIS.ACIKLAMA, SIPARIS.KARGO_FIRMASI, "+
                  "SIPARIS.KARGO_NO, SIPARIS.ADRESI, SIPARIS.ILI, SIPARIS.ILCESI, SIPARIS.TARIHI, SIPARIS.SEVK_ADRESI, SIPARIS.SEVK_ILI, SIPARIS.SEVK_ILCESI, "+
                  "CARI.ADI, CARI.SOYADI, CARI.FAKS, CARI.E_MAIL AS EMAIL1, CARI.VERGI_NO " +
                  "FROM SIPARIS JOIN CARI ON CARI.BLKODU = SIPARIS.BLCRKODU " +
                  "WHERE " +
                  "TARIHI >'" + DateTime.Parse(txtBaslamaTarihi.Text.ToString()).ToString("yyyy.MM.dd") + "' AND " +
                  "TARIHI < '" + DateTime.Parse(txtBitisTarihi.Text.ToString()).AddDays(1).ToString("yyyy.MM.dd")+"' " +
                  "ORDER BY TARIHI";
            dgvSonuc.DataSource = null;
            grideBas(sql, wolVoxConStr);
            dgvSonuc.Columns["CARI_BLKODU"].Visible = false;
            dgvSonuc.Columns["BLKODU"].Visible = false;
        }

        private void btnIkıTarihArasiKar_Click(object sender, EventArgs e)
        {
            if (txtBaslamaTarihi.Text.ToString() == ".  ." || txtBitisTarihi.Text.ToString() == ".  .")
            {
                MessageBox.Show("Tarih Değerlerini Girmelisiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }

            grpSonuc.Text = "Kar Analizi";
            raporAdi = "Kar Analizi";
            sql = "SELECT "+
                    "SIPARIS_TARIHI, SIPARIS_CARI_KODU, TICARI_UNVANI, ADI_SOYADI, SIPARIS_TOPLAM_MIKTAR, TOPLAM_GENEL_KPB, SIPARIS_HR_STOK_ADI,  "+
                    "ROUND(URETIM_CARPANI,2) AS URETIM_CARPANI, FATURA_TICARI_UNVANI , FATURA_ILK_TARIHI, FATURA_NO, FATURA_MIKTARI ,KPB_KDVLI_TUTAR, SIPARISHR_MIKTAR, " +
                    "ROUND((KPB_KDVLI_TUTAR/FATURA_MIKTARI)*URETIM_CARPANI,2) AS BIRIM_ALIS_FIYATI, "+
                    "ROUND((SIPARISHR_KPB_KDVLI_TUTAR / SIPARISHR_MIKTAR), 2) AS BIRIM_SATIS_FIYATI, " +
                    "SIPARISHR_KPB_KDVLI_TUTAR, " +
                    "ROUND(((SIPARISHR_KPB_KDVLI_TUTAR / SIPARISHR_MIKTAR) - (((KPB_KDVLI_TUTAR / FATURA_MIKTARI) * URETIM_CARPANI) + (SIPARISHR_KPB_KDVLI_TUTAR / SIPARISHR_MIKTAR) * 0.2 + 2)), 2) AS BIRIM_KAZANC, " +
                    "ROUND((((SIPARISHR_KPB_KDVLI_TUTAR / SIPARISHR_MIKTAR) - (((KPB_KDVLI_TUTAR / FATURA_MIKTARI) * URETIM_CARPANI) + (SIPARISHR_KPB_KDVLI_TUTAR / SIPARISHR_MIKTAR) * 0.2 + 2)) * SIPARISHR_MIKTAR), 2) AS GENEL_KAZANC "+
                    "FROM ( " +
                    "SELECT  " +
                    "SIPARIS_CARI_KODU, TICARI_UNVANI, ADI_SOYADI, ADRESI, SIPARIS_TOPLAM_MIKTAR, SIPARIS_TARIHI, TOPLAM_GENEL_KPB,  " +
                    "SIPARISHR_BLSTKODU ,SIPARISHR_STOKKODU, SIPARIS_HR_STOK_ADI, SIPARISHR_MIKTAR, SIPARISHR_KPB_KDVLI_TUTAR, " +
                    "KAYNAKSTOK_BLKODU, KAYNAK_STOKKODU, KAYNAK_STOK_ADI, URETIM_CARPANI, KAYNAK_BIRIMI,  " +
                    "FATURAHR_STOKKODU, iif(FATURA_NO IS NULL,'-',FATURA_NO) AS FATURA_NO, iif(FATURA_ILK_TARIHI IS NULL,'-',FATURA_ILK_TARIHI) AS FATURA_ILK_TARIHI, iif(FATURA_TICARI_UNVANI IS NULL,'-',FATURA_TICARI_UNVANI) AS FATURA_TICARI_UNVANI, FATURAHRBLKODU, FATURA_BLSTKODU, FATURA_STOK_ADI, " +
                    "FATURA_BIRIMI, iif(FATURA_MIKTARI IS NULL,1,FATURA_MIKTARI) AS FATURA_MIKTARI, KPB_FIYATI, KPB_TOPLAM_TUTAR, iif(KPB_KDVLI_TUTAR IS NULL,1,KPB_KDVLI_TUTAR) AS KPB_KDVLI_TUTAR, FATURA_BLKODU, FATURACARI " +
                    "FROM( " +
                    "SELECT SIPARIS.CARIKODU AS SIPARIS_CARI_KODU, SIPARIS.TICARI_UNVANI, SIPARIS.ADI_SOYADI, SIPARIS.ADRESI, SIPARIS.MIKTAR1_TOPLAM AS SIPARIS_TOPLAM_MIKTAR, SIPARIS.TARIHI AS SIPARIS_TARIHI, SIPARIS.TOPLAM_GENEL_KPB, " +
                    "SIPARISHR.BLSTKODU AS SIPARISHR_BLSTKODU, SIPARISHR.STOKKODU AS SIPARISHR_STOKKODU, SIPARISHR.STOK_ADI AS SIPARIS_HR_STOK_ADI, SIPARISHR.MIKTARI AS SIPARISHR_MIKTAR, ROUND(SIPARISHR.KPB_KDVLI_TUTAR, 2) AS SIPARISHR_KPB_KDVLI_TUTAR, " +
                    "URETIMLER.KAYNAKSTOK_BLKODU, " +
                    "iif(URETIMLER.KAYNAK_STOKKODU IS NULL, SIPARISHR.STOKKODU, URETIMLER.KAYNAK_STOKKODU) AS KAYNAK_STOKKODU, " +
                    "iif(URETIMLER.KAYNAK_STOK_ADI IS NULL, SIPARISHR.STOK_ADI, URETIMLER.KAYNAK_STOK_ADI) AS KAYNAK_STOK_ADI, " +
                    "iif(URETIMLER.URETIM_CARPANI IS NULL, 1, URETIMLER.URETIM_CARPANI) AS URETIM_CARPANI, URETIMLER.KAYNAK_BIRIMI " +
                    "FROM SIPARIS JOIN SIPARISHR ON SIPARISHR.BLMASKODU = SIPARIS.BLKODU " +
                    "LEFT JOIN( " +
                            "SELECT  STOK.BLKODU AS URETILEN_BLKODU, STOK.STOKKODU AS URETILEN_STOKKODU, STOK.STOK_ADI AS URETILEN_STOKADI, BASIT_URETIM.MIKTARI AS URETILEN_MIKTAR, " +
                                    "BASIT_URETIMHR.BLSTKODU AS KAYNAKSTOK_BLKODU, BASIT_URETIMHR.STOKKODU AS KAYNAK_STOKKODU, BASIT_URETIMHR.STOK_ADI AS KAYNAK_STOK_ADI, " +
                                    "(BASIT_URETIMHR.TOPLAM_MIKTAR - BASIT_URETIMHR.FIRE_MIKTARI)  AS URETIM_CARPANI, BASIT_URETIMHR.BIRIMI AS KAYNAK_BIRIMI " +
                                    "FROM    BASIT_URETIM " +
                                    "JOIN    BASIT_URETIMHR ON BASIT_URETIMHR.BLMASKODU = BASIT_URETIM.BLKODU " +
                                    "JOIN    STOK ON STOK.BLKODU = BASIT_URETIM.BLSTKODU " +
                                    "WHERE BASIT_URETIM.DURUMU = 1 AND STOK.STOKKODU <> 'krg01' " +
                            ") URETIMLER ON URETIMLER.URETILEN_BLKODU = SIPARISHR.BLSTKODU " +
                    "WHERE SIPARISHR.STOKKODU <> 'krg01' AND SIPARIS.SILINDI =0 AND SIPARIS.SIPARIS_DURUMU<>4 AND SIPARIS.SIPARIS_DURUMU<>3 AND " +
                           "SIPARIS.TARIHI>'" + DateTime.Parse(txtBaslamaTarihi.Text.ToString()).ToString("yyyy.MM.dd") + "' AND " +
                           "SIPARIS.TARIHI<'" + DateTime.Parse(txtBitisTarihi.Text.ToString()).AddDays(1).ToString("yyyy.MM.dd") + "' " +
                    ") STOKLARIM " +
                    "LEFT JOIN( " +
                            "SELECT * FROM( " +
                            "SELECT  FATURAHR.STOKKODU AS FATURAHR_ILK_STOKKODU, MAX(FATURA.TARIHI) AS FATURA_ILK_TARIHI " +
                            "FROM FATURAHR " +
                            "JOIN FATURA ON FATURA.BLKODU = FATURAHR.BLFTKODU " +
                            "WHERE FATURA_DURUMU = 5 AND FATURA.BLKODU = FATURAHR.BLFTKODU AND FATURAHR.STOKKODU IS NOT NULL " +
                            "GROUP BY    FATURAHR.STOKKODU " +
                            ") FATURA_TEKTARIH " +
                            "JOIN " +
                            "(SELECT FATURAHR.STOKKODU AS FATURAHR_STOKKODU, FATURA.FATURA_NO, FATURA.TARIHI AS FATURA_A_TARIHI, FATURA.TICARI_UNVANI AS FATURA_TICARI_UNVANI, FATURAHR.BLKODU AS FATURAHRBLKODU, " +
                                    "FATURAHR.BLSTKODU AS FATURA_BLSTKODU, FATURAHR.STOK_ADI AS FATURA_STOK_ADI, " +
                                    "FATURAHR.BIRIMI AS FATURA_BIRIMI, FATURAHR.MIKTARI AS FATURA_MIKTARI, FATURAHR.KPB_FIYATI, " +
                                    "ROUND(KPB_TOPLAM_TUTAR, 2) AS KPB_TOPLAM_TUTAR, ROUND(FATURAHR.KPB_KDVLI_TUTAR, 2) AS KPB_KDVLI_TUTAR, FATURA.BLKODU AS FATURA_BLKODU, FATURA.CARIKODU AS FATURACARI " +
                            "FROM FATURAHR " +
                            "JOIN FATURA ON FATURA.BLKODU = FATURAHR.BLFTKODU " +
                            "WHERE FATURA_DURUMU = 5 AND FATURA.BLKODU = FATURAHR.BLFTKODU AND FATURAHR.STOKKODU IS NOT NULL " +
                            "GROUP BY FATURAHR.STOKKODU, FATURA.FATURA_NO, FATURA.TARIHI, FATURA.TICARI_UNVANI, FATURAHR.BLKODU, FATURAHR.BLSTKODU, FATURAHR.STOK_ADI, FATURAHR.BIRIMI, FATURAHR.MIKTARI, FATURAHR.KPB_FIYATI, " +
                                     "KPB_TOPLAM_TUTAR, FATURAHR.KPB_KDVLI_TUTAR, FATURA.BLKODU, FATURA.CARIKODU " +
                            ") FATURADETAY ON FATURADETAY.FATURA_A_TARIHI = FATURA_TEKTARIH.FATURA_ILK_TARIHI AND FATURADETAY.FATURAHR_STOKKODU = FATURA_TEKTARIH.FATURAHR_ILK_STOKKODU " +
                        ") FATURALAR ON FATURALAR.FATURAHR_STOKKODU = STOKLARIM.KAYNAK_STOKKODU " +
            "ORDER BY SIPARIS_CARI_KODU,SIPARIS_TARIHI, SIPARIS_HR_STOK_ADI) ANASORGU ";

            this.Enabled = false;
            DataTable sonuc = new DataTable();
            try
            {
                //this.Enabled = false;
                sonuc = manager.BasitSorguDT(sql, wolVoxConStr);
                //dgvSonuc.DataSource = sonuc;
                //dgvSonuc.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                //this.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata :" + ex.ToString());
                //this.Enabled = true;
            }
            this.Enabled = true;

            int sepetSayisi = 0;
            int siparisSayisi = 0;
            decimal birimAlisFiyati = 0;
            decimal birimSatisFiyati = 0;
            decimal satisTutari = 0;
            decimal olusanKar = 0;
            string cari = "";


            for (int i = 0; i < sonuc.Rows.Count; i++)
            {
                if (sonuc.Rows[i]["SIPARIS_CARI_KODU"].ToString()!=cari)
                {
                    cari = sonuc.Rows[i]["SIPARIS_CARI_KODU"].ToString();
                    sepetSayisi = sepetSayisi+1;
                }
                siparisSayisi = siparisSayisi + Convert.ToInt16(sonuc.Rows[i]["SIPARISHR_MIKTAR"].ToString());
                birimAlisFiyati = birimAlisFiyati + Convert.ToDecimal(sonuc.Rows[i]["BIRIM_ALIS_FIYATI"].ToString());
                birimSatisFiyati = birimSatisFiyati + Convert.ToDecimal(sonuc.Rows[i]["BIRIM_SATIS_FIYATI"].ToString());
                satisTutari = satisTutari + Convert.ToDecimal(sonuc.Rows[i]["SIPARISHR_KPB_KDVLI_TUTAR"].ToString());
                olusanKar = olusanKar + Convert.ToDecimal(sonuc.Rows[i]["GENEL_KAZANC"].ToString());
            }
            txtSepetSayisi.Text = sepetSayisi.ToString();
            txtSiparisSayisi.Text = siparisSayisi.ToString();
            txtBirimAlisFiyati.Text = birimAlisFiyati.ToString();
            txtBirimSatisFiyati.Text = birimSatisFiyati.ToString();
            txtSatisTutari.Text = satisTutari.ToString();
            txtGenelKazanc.Text = olusanKar.ToString();
            txtKarYuzdesi.Text = Convert.ToDecimal((100 * olusanKar)/ satisTutari).ToString();

            dgvSonuc.DataSource = sonuc;
            dgvSonuc.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            //dgvSonuc.Columns["CARI_BLKODU"].Visible = false;
            //dgvSonuc.Columns["BLKODU"].Visible = false;
        }
    }
}
