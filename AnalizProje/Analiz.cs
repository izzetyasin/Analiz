using System;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using FirebirdSql.Data.FirebirdClient;


namespace AnalizProje
{
    public partial class FrmAnalizProje : Form
    {
        Manager manager = new Manager();

        string analizConStr ="" ;
        string wolVoxConStr = "";
        string cariAdisoyadi = "";
        string cariTicariUnvani = "";

        public FrmAnalizProje()
        {
            InitializeComponent();
            analizConStr = manager.conStrAnaliz;
            wolVoxConStr = manager.conStrWolvox;
        }

        private void FrmAnalizProje_Load(object sender, EventArgs e)
        {
            cmbDoldur();
        }
        public void cmbDoldur()
        {
            cmbCariGrubuDoldur();
            cmbSektorDoldur();
            cmbCinsiyetDoldur();
        }

        public void cmbCariGrubuDoldur()
        {
            cmbCariGrubu.DataSource = manager.GetDataTableFull("PARAMETRE", "UST_SEVIYE_ID=27", "SEVIYE_ADI", analizConStr);
            cmbCariGrubu.DisplayMember = "SEVIYE_ADI";
            cmbCariGrubu.ValueMember = "PARAMETRE_ID";
            cmbCariGrubu.SelectedIndex = 0;
        }
        public void cmbCinsiyetDoldur()
        {
            cmbCinsiyet.DataSource = manager.GetDataTableFull("PARAMETRE", "UST_SEVIYE_ID=44", analizConStr);
            cmbCinsiyet.DisplayMember = "SEVIYE_ADI";
            cmbCinsiyet.ValueMember = "PARAMETRE_ID";
            cmbCinsiyet.SelectedIndex = 3;
            cmbCinsiyet.Refresh();
        }
        public void cmbSektorDoldur()
        {
            cmbSektor.DataSource = manager.GetDataTableFull("PARAMETRE", "UST_SEVIYE_ID=66", analizConStr);
            cmbSektor.DisplayMember = "SEVIYE_ADI";
            cmbSektor.ValueMember = "PARAMETRE_ID";
            cmbSektor.SelectedIndex = 27;
            cmbSektor.Refresh();
        }
        private void btnCariAra_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("ANALIZ", "LISTELEME")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: ANALIZ - Yetki: LISTELEME)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cariBul();
        }

        public void cariBul()
        {
            string sql = "SELECT ADI_SOYADI, TICARI_UNVANI FROM CARI " +
                        "WHERE (UPPER(ADI_SOYADI) LIKE('%" + txtCariAra.Text.ToUpper() + "%') OR UPPER(TICARI_UNVANI) LIKE('%" + txtCariAra.Text.ToUpper() + "%') " +
                        "OR CEP_TEL LIKE('%" + txtCariAra.Text + "%') OR TEL1 LIKE('%" + txtCariAra.Text + "%') " +
                        "OR TEL2 LIKE('%" + txtCariAra.Text + "%') OR EV_TEL LIKE('%" + txtCariAra.Text + "%')) " +// AND GRUBU<>'Tedarikçi' " +
                        "GROUP BY ADI_SOYADI, TICARI_UNVANI ORDER BY ADI_SOYADI, TICARI_UNVANI";
            DataTable sorgu = new DataTable();
            sorgu = manager.BasitSorguDT(sql, wolVoxConStr);
            dgvCariListesi.DataSource = sorgu;
            dgvCariListesi.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        private void txtCariAra_TextChanged(object sender, EventArgs e)
        {
            cariBul();
        }

        private void dgvCariListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Enabled = false;
            cariDetayBul();
            this.Enabled = true;
        }

        private void cariDetayBul()
        {
            cariAdisoyadi = dgvCariListesi.CurrentRow.Cells[0].Value.ToString();
            cariTicariUnvani = "='"+dgvCariListesi.CurrentRow.Cells[1].Value.ToString()+"'";

            if (cariAdisoyadi == "")
            {
                cariAdisoyadi = "";
            }
            if (cariTicariUnvani == "=''")
            {
                cariTicariUnvani = " IS NULL ";
            }


            string sql = "SELECT GRUBU, CARIKODU, ADI_SOYADI, ADI, SOYADI, TICARI_UNVANI, CEP_TEL, TEL1, TC_KIMLIK_NO, VERGI_NO, " +
                         "ADRESI_1, ILCESI_1, ILI_1, ULKESI_1, E_MAIL, KAYIT_TARIHI, AKTIF "+
                         "FROM CARI " +
                         "WHERE ADI_SOYADI ='" + cariAdisoyadi + "' AND TICARI_UNVANI " + cariTicariUnvani +" "+
                         "ORDER BY ADI_SOYADI, TICARI_UNVANI";

            DataTable analizCariSor = new DataTable();
            analizCariSor = manager.BasitSorguDT(sql, wolVoxConStr);
            dgvCariDetay.DataSource = analizCariSor;
            dgvCariDetay.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);


            /*Faturalar bulunuyor */
            sql = "SELECT "+
                "FATURA.TARIHI,FATURAHR.MIKTARI,FATURAHR.BIRIMI, FATURAHR.STOK_ADI,FATURAHR.KPB_FIYATI,FATURAHR.KPB_KDVLI_TUTAR,FATURA.TOPLAM_ALT_KPB, "+
                "FATURA.CARIKODU,  FATURA.FATURA_NO, FATURA.FATURA_SERI, FATURAHR.SIRA_NO,"+
                "FATURA.KARGO_FIRMASI, FATURA.KARGO_NO, FATURA.FATURA_KESILDI,  " +
                "FATURA.BLCRKODU, FATURA.SEVK_ADRESI, FATURA.SEVK_ILI, FATURA.SEVK_ILCESI, FATURA.SEVK_ULKESI, "+
                "FATURA.YUVARLAMA_KPB, FATURA.TOPLAM_KDV_KPB, FATURA.TOPLAM_GENEL_KPB, FATURA.MIKTAR1_TOPLAM,  FATURAHR.EVRAK_NO, "+
                "FATURAHR.BLSTKODU,     FATURAHR.KDV_ORANI, FATURAHR.KDV_TUTARI, "+
                "FATURAHR.KPB_KDV_HARICFY, FATURAHR.KPB_IND_FIYAT, FATURAHR.KPB_IND_TUTAR, FATURAHR.KPB_TOPLAM_TUTAR,  "+
                "FATURAHR.EKBILGI_1, FATURAHR.EKBILGI_2, FATURA.SILINDI "+
                "FROM FATURA ,FATURAHR "+
                "WHERE FATURAHR.BLFTKODU = FATURA.BLKODU AND " +
                "FATURA.ADI_SOYADI='" + cariAdisoyadi + "' AND TICARI_UNVANI " + cariTicariUnvani +" "+
                "AND FATURA.SILINDI=0 "+
                "ORDER BY FATURA.TARIHI DESC, FATURA.FATURA_NO, FATURAHR.SIRA_NO";

            DataTable faturaSor = new DataTable();
            faturaSor = manager.BasitSorguDT(sql, wolVoxConStr);
            dgvAldigiUrunler.DataSource = faturaSor;
            dgvAldigiUrunler.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            /* Cari Güncelleme İşlemleri */
            sql = "SELECT * " +
                         "FROM CARI " +
                         "WHERE ADI_SOYADI ='" + cariAdisoyadi + "' AND TICARI_UNVANI " + cariTicariUnvani +" "+
                         "ORDER BY ADI_SOYADI, TICARI_UNVANI";
            DataTable analizCariGuncelle = new DataTable();
            analizCariGuncelle = manager.BasitSorguDT(sql, wolVoxConStr);
            cariGuncellemeIslemleri(analizCariGuncelle);

            cariEkrana();
            //MessageBox.Show(dgvCariListesi.CurrentRow.Cells[0].Value.ToString() + " - " + dgvCariListesi.CurrentRow.Cells[1].Value.ToString());
        }

        public void cariEkrana()
        {
            cmbDoldur();

            string sql = "SELECT * FROM CARI WHERE CARI_ID="+txtCariId.Text.ToString();

            DataTable cariSor = new DataTable();
            cariSor = manager.BasitSorguDT(sql,analizConStr);

            txtCariKodu.Text = cariSor.Rows[0]["CARI_ID"].ToString();
            txtCariAdi.Text = cariSor.Rows[0]["ADI"].ToString();
            txtCariSoyadi.Text = cariSor.Rows[0]["SOYADI"].ToString();
            txtTicariUnvani.Text = cariSor.Rows[0]["TICARI_UNVANI"].ToString();
            txtVergiDairesi.Text = cariSor.Rows[0]["VERGI_DAIRESI"].ToString();
            txtVergiNo.Text = cariSor.Rows[0]["VERGI_NO"].ToString();
            txtTcKimlikNo.Text = cariSor.Rows[0]["TC_KIMLIK_NO"].ToString();
            txtCariGrubu.Text = cariSor.Rows[0]["GRUBU"].ToString();
            lblCariGrubu.Text= manager.parametreTreeYolBul(txtCariGrubu.Text.ToString());

            if (cariSor.Rows[0]["SEKTOR"] != null && cariSor.Rows[0]["SEKTOR"].ToString() != "")
            {
                cmbSektor.SelectedValue = cariSor.Rows[0]["SEKTOR"].ToString();
                cmbSektor.Refresh();
            }

            txtEMail.Text = cariSor.Rows[0]["EMAIL1"].ToString();
            txtCepTel.Text = cariSor.Rows[0]["CEP_TEL"].ToString();
            txtFaks.Text = cariSor.Rows[0]["FAKS"].ToString();
            txtEkTelefon1.Text = cariSor.Rows[0]["TELEFON1"].ToString();

            if (cariSor.Rows[0]["CINSIYETI"] != null && cariSor.Rows[0]["CINSIYETI"].ToString() != "")
            {
                cmbCinsiyet.SelectedValue = cariSor.Rows[0]["CINSIYETI"].ToString();
                cmbCinsiyet.Refresh();
            }

            txtHastaliklari.Text = cariSor.Rows[0]["KRONIK_HASTALIK"].ToString();
            txtAciklama.Text = cariSor.Rows[0]["ACIKLAMA"].ToString();

            gorusmeleriGetir();

        }

        public void gorusmeleriGetir()
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


        private void btnSatislar_Click(object sender, EventArgs e)
        {
            Raporlar raporlar = new Raporlar();
            raporlar.ShowDialog();
        }

        private void FrmAnalizProje_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("ANALIZ", "GRUPLISTELE")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: ANALIZ - Yetki: GRUPLISTELE)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string kriterim = "'"+ cmbCariGrubu.Text+"'";
            if (cmbCariGrubu.Text == "NULL")
            {
                kriterim = "NULL";
            }
            string sql = "SELECT ADI_SOYADI, TICARI_UNVANI FROM CARI " +
            "WHERE (ADI_SOYADI LIKE('%" + txtCariAra.Text + "%') OR TICARI_UNVANI LIKE('%" + txtCariAra.Text + "%')) " +
            "AND GRUBU=" + kriterim + " "+
            "GROUP BY ADI_SOYADI, TICARI_UNVANI ORDER BY ADI_SOYADI, TICARI_UNVANI";
            DataTable btnBul = new DataTable();
            btnBul = manager.BasitSorguDT(sql, wolVoxConStr);
            dgvCariListesi.DataSource = btnBul;
            dgvCariListesi.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

        }

        private void btnCariDetyalar_Click(object sender, EventArgs e)
        {

            if (dgvCariListesi.Rows.Count == 0 || txtCariId.Text=="0")
            {
                MessageBox.Show("Cari Listesini Kullanınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("CARIKART", "GIRIS")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: CARIKART - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CariKart cariKart = new CariKart();
            Manager.CariIdTasi = txtCariId.Text.ToString();
            //Manager.NodId = txtCariGrubu.Text.ToString();
            cariKart.Text = "Cari Kart";
            cariKart.ShowDialog();
            cariEkrana();
        }

        public void cariGuncellemeIslemleri(DataTable gelenCari)
        {
            if (gelenCari.Rows.Count == 0)
            {
                return;
            }

            DataTable analizDtSonuc = new DataTable();
            bool kayitVar = true;

            string sql = "SELECT FIRST 1 * FROM CARI " +
                         "WHERE ADI_SOYADI ='" + gelenCari.Rows[0]["ADI_SOYADI"].ToString() + "' AND (TICARI_UNVANI ='" + gelenCari.Rows[0]["TICARI_UNVANI"].ToString() + "' " +
                         "OR TICARI_UNVANI IS NULL) "+ 
                         "ORDER BY ADI_SOYADI, TICARI_UNVANI";

            //dtSonuc = manager.GetDataTableFull("CARI", "ADI_SOYADI =" + gelenCari.Rows[0]["ADI_SOYADI"].ToString() + " AND TICARI_UNVANI =" + gelenCari.Rows[0]["TICARI_UNVANI"].ToString() , analizConStr);
            analizDtSonuc = manager.BasitSorguDT(sql, analizConStr);
            if (analizDtSonuc == null || analizDtSonuc.Rows.Count > 0)
            {
                txtCariId.Text = analizDtSonuc.Rows[0]["CARI_ID"].ToString();
                return;
            }


            int deger = 0;
            int blkodu = 0;
            int cariVar = 0;
            string sonCariId = "0";

            DataTable adrestenSor = new DataTable();

            sql = "SELECT CARI_ID FROM CARI_ALT WHERE BLKODU=" + gelenCari.Rows[0]["BLKODU"].ToString();
            adrestenSor = manager.BasitSorguDT(sql, analizConStr);

            if (adrestenSor.Rows.Count>0)
            {
                sonCariId = adrestenSor.Rows[0]["CARI_ID"].ToString();
            }

            if (analizDtSonuc == null || sonCariId.ToString()!="0")
            {
                analizDtSonuc = manager.GetDataTableFull("CARI", "CARI_ID="+sonCariId.ToString(), analizConStr);
            }


            for (int i = 0; i < gelenCari.Rows.Count; i++)
            {

                    kayitVar = true;
                    if ( analizDtSonuc.Rows.Count == 0)
                    {
                        analizDtSonuc.Rows.Add();
                        kayitVar = false;
                    }
                    else
                    {
                        deger = int.Parse(analizDtSonuc.Rows[0]["CARI_ID"].ToString());
                    }
                //İlk bulunan kayıt temel cari kaydı olarak alınıyor
                if (i == 0 && sonCariId.ToString()=="0")
                {
                    analizDtSonuc.Rows[0]["ADI"] = gelenCari.Rows[0]["ADI"];
                    analizDtSonuc.Rows[0]["SOYADI"] = gelenCari.Rows[0]["SOYADI"];
                    analizDtSonuc.Rows[0]["ADI_SOYADI"] = gelenCari.Rows[0]["ADI_SOYADI"];
                    analizDtSonuc.Rows[0]["TICARI_UNVANI"] = gelenCari.Rows[0]["TICARI_UNVANI"];
                    analizDtSonuc.Rows[0]["CEP_TEL"] = gelenCari.Rows[0]["CEP_TEL"];
                    analizDtSonuc.Rows[0]["FAKS"] = gelenCari.Rows[0]["FAKS"];
                    analizDtSonuc.Rows[0]["TELEFON1"] = gelenCari.Rows[0]["TEL1"];
                    analizDtSonuc.Rows[0]["VERGI_NO"] = gelenCari.Rows[0]["VERGI_NO"];
                    analizDtSonuc.Rows[0]["EMAIL1"] = gelenCari.Rows[0]["E_MAIL"];
                    analizDtSonuc.Rows[0]["CINSIYETI"] = gelenCari.Rows[0]["CINSIYETI"];
                    analizDtSonuc.Rows[0]["SEKTOR"] = 94;


                    analizDtSonuc.Rows[0]["GRUBU"] = 9; // Parametre Bireysel
                    if (gelenCari.Rows[0]["VERGI_NO"].ToString() != "")
                    {
                        analizDtSonuc.Rows[0]["GRUBU"] = 49; // Parametre Kurumsal
                    }
                    
                    if (!kayitVar)
                    {
                        analizDtSonuc.Rows[0]["KAYDEDEN"] = Manager.KullaniciAdSoyad.ToString();
                    }
                    analizDtSonuc.Rows[0]["GUNCELLEYEN"] = Manager.KullaniciAdSoyad.ToString();                 


                    // kaydetme if koşulu içinde oluyor
                    if (manager.kaydetGuncelle("CARI", "CARI_ID", deger, analizDtSonuc, analizConStr))
                    {
                        cariAdisoyadi = gelenCari.Rows[0]["ADI_SOYADI"].ToString();
                        cariTicariUnvani = "='" + gelenCari.Rows[0]["TICARI_UNVANI"].ToString() + "'";

                        if (cariAdisoyadi == "")
                        {
                            cariAdisoyadi = "";
                        }
                        if (cariTicariUnvani == "=''")
                        {
                            cariTicariUnvani = " IS NULL ";
                        }

                        string sorgum = "ADI_SOYADI='" + cariAdisoyadi + "' " +
                            " AND TICARI_UNVANI"+cariTicariUnvani +
                            " AND KAYDEDEN='" + Manager.KullaniciAdSoyad.ToString() + "'";

                        analizDtSonuc = manager.GetDataTableFull("CARI", sorgum, analizConStr);
                        deger =int.Parse(analizDtSonuc.Rows[0]["CARI_ID"].ToString());
                        //MessageBox.Show("Kaydetme İşlemi Tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cari Güncelleme İşleminde Hata. Kayıt Gerçekleşmedi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //CARI_ALT ile wolvox cari verileri kaydedilir
                analizDtSonuc = manager.GetDataTableFull("CARI_ALT", "CARI_ID="+deger.ToString()+" AND BLKODU="+ gelenCari.Rows[i]["BLKODU"].ToString(), analizConStr);
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
                
                for (int ii = 0; ii < gelenCari.Columns.Count; ii++)
                    {
                    analizDtSonuc.Rows[0][0] = deger;
                    analizDtSonuc.Rows[0][ii+1] = gelenCari.Rows[i][ii];
                    }
                blkodu = int.Parse(analizDtSonuc.Rows[0]["BLKODU"].ToString());

                manager.kaydetGuncelleCari("CARI_ALT", "CARI_ID", cariVar,blkodu, analizDtSonuc, analizConStr);
            }

            txtCariId.Text = deger.ToString();


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
            "WHERE CARI_ID = " + deger.ToString()+" "+
            "ORDER BY CARI_ID, BLKODU";
            analizDtSonuc = manager.BasitSorguDT(adresSql, analizConStr);

            for (int i = 0; i < analizDtSonuc.Rows.Count; i++)
            {
                sql = "SELECT * FROM CARI_ADRES WHERE CARI_ID="+deger.ToString()+" AND BLKODU="+ analizDtSonuc.Rows[i]["BLKODU"].ToString();
                adresVarMi = manager.BasitSorguDT(sql, analizConStr);
                if (adresVarMi.Rows.Count==0)
                {
                    adresVarMi.Rows.Add();
                    for (int ii = 0; ii < adresVarMi.Columns.Count; ii++)
                    {
                        adresVarMi.Rows[0][ii] = analizDtSonuc.Rows[i][ii];
                    }
                    if (adresVarMi.Rows[0]["KAYDEDEN"].ToString() == "") adresVarMi.Rows[0]["KAYDEDEN"] = Manager.KullaniciAdSoyad.ToString();
                    adresVarMi.Rows[0]["GUNCELLEYEN"] = Manager.KullaniciAdSoyad.ToString();
                    manager.kaydetGuncelle("CARI_ADRES", "CARI_ADRES_ID",0, adresVarMi, analizConStr);
                }
            }



        }

        private void btnCariGuncelle_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvCariListesi.Rows.Count; i++)
            {
                dgvCariListesi.CurrentCell = dgvCariListesi[0, i];
                txtSayi.Text = i.ToString();
                txtSayi.Refresh();
                cariDetayBul();
            }
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
            string baslik = txtCariAdi.Text.ToString().Trim() + " " + txtCariSoyadi.Text.ToString().Trim() + " - " + txtTicariUnvani.Text.ToString().Trim();
            //Manager.CariAdTasi = baslik+"- Tel:"+ txtCepTel.Text.Trim();
            gorusmeler.Text = baslik;
            gorusmeler.ShowDialog();
            Manager.CariAdTasi = null;
        }

        private void chkYeniCariAc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYeniCariAc.Checked)
            {
                btnYeniCariAc.Enabled = true;
            }
            else
            {
                btnYeniCariAc.Enabled = false;
            }
        }
    }
}
