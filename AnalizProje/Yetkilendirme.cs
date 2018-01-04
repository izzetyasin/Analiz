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
    public partial class Yetkilendirme : Form
    {
        Manager manager = new Manager();
        string analizConStr = "";
        string wolVoxConStr = "";
        DataTable dtUygulama = new DataTable();
        DataTable dtKullanicilar = new DataTable();
        DataTable dtYetkileri = new DataTable();

        public Yetkilendirme()
        {
            InitializeComponent();
            analizConStr = manager.conStrAnaliz;
            wolVoxConStr = manager.conStrWolvox;
        }

        private void Yetkilendirme_Load(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM KULLANICI WHERE AKTIF=1 ORDER BY ADI, SOYADI";
            dtKullanicilar = manager.BasitSorguDT(sorgu, analizConStr);
            dgvKullanicilar.DataSource = dtKullanicilar;
            dgvKullanicilar.Columns[0].Visible = false;
            dgvKullanicilar.Columns[5].Visible = false;
            dgvKullanicilar.Columns[6].Visible = false;
            dgvKullanicilar.Columns[7].Visible = false;
            dgvKullanicilar.Columns[8].Visible = false;
            dgvKullanicilar.Columns[9].Visible = false;
            dgvKullanicilar.Columns[10].Visible = false;
            dgvKullanicilar.Columns[11].Visible = false;
            dgvKullanicilar.Columns[12].Visible = false;
            dgvKullanicilar.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            dgvKullanicilar.CurrentCell = dgvKullanicilar[1, 0];
            


            sorgu = "SELECT UYGULAMA_ADI FROM YETKI GROUP BY UYGULAMA_ADI ORDER BY UYGULAMA_ADI";
            dtUygulama = manager.BasitSorguDT(sorgu, analizConStr);
            dgvUygulamalar.DataSource = dtUygulama;
            dgvUygulamalar.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            dgvUygulamalar.CurrentCell = dgvUygulamalar[0, 0];

            
            kullaniciAyarla();
            YetkiSorgula();
            //yetkilerTxtye();
        }
        private void YetkiSorgula()
        {
            try
            {
                string sorgu = "SELECT YETKI_ID, YETKI_ADI FROM YETKI WHERE UYGULAMA_ADI ='" + dtUygulama.Rows[dgvUygulamalar.CurrentRow.Index][0] + "' GROUP BY YETKI_ID, YETKI_ADI ORDER BY YETKI_ADI";
                dtYetkileri = manager.BasitSorguDT(sorgu, analizConStr);
                dgvYetkiler.DataSource = dtYetkileri;
                dgvYetkiler.Columns[0].Visible = false;
                dgvYetkiler.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);


            }
            catch (Exception)
            {
                dgvYetkiler.DataSource = null;

            }

        }

        private void dgvUygulamalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            YetkiSorgula();
            kullaniciAyarla();
        }

        private void dgvKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            kullaniciAyarla();
        }
        private void kullaniciAyarla()
        {
            //lblKullanici.Text = dgvKullanicilar[1, 0].Value.ToString();
            lblKullanici.Text = dgvKullanicilar[1,dgvKullanicilar.CurrentRow.Index].Value.ToString()+" : "+ 
                dgvKullanicilar[2, dgvKullanicilar.CurrentRow.Index].Value.ToString()+" "+ 
                dgvKullanicilar[3, dgvKullanicilar.CurrentRow.Index].Value.ToString();
            lblKullanici.Refresh();

            txtKullaniciID.Text = dgvKullanicilar[0, dgvKullanicilar.CurrentRow.Index].Value.ToString();
            txtKullaniciID.Refresh();

            DataTable sonuc = new DataTable();
            sonuc = manager.BasitSorguDT("SELECT YETKI.YETKI_ID, YETKI.UYGULAMA_ADI, YETKI.YETKI_ADI FROM KULLANICI_YETKI " +
                "JOIN YETKI ON YETKI.YETKI_ID = KULLANICI_YETKI.YETKI_ID WHERE "+
                "KULLANICI_ID = "+ dgvKullanicilar[0, dgvKullanicilar.CurrentRow.Index].Value.ToString() + " ORDER BY YETKI.UYGULAMA_ADI", analizConStr);
            dgvUygulamaVeYetkiler.DataSource = sonuc;
            dgvUygulamaVeYetkiler.Columns[0].Visible = false;
            dgvUygulamaVeYetkiler.Refresh();
            dgvUygulamaVeYetkiler.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            lblUygulama.Text = dgvUygulamalar.Rows[dgvUygulamalar.CurrentRow.Index].Cells[0].Value.ToString();//  dgvUygulamalar[1, dgvUygulamalar.CurrentRow.Index].Value.ToString();
            lblUygulama.Refresh();

            yetkilerTxtye();


        }

        private void dgvYetkiler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            yetkilerTxtye();
        }

        private void yetkilerTxtye()
        {
            try
            {
                lblYetki.Text = dgvYetkiler.Rows[dgvYetkiler.CurrentRow.Index].Cells[1].Value.ToString();//  dgvUygulamalar[1, dgvUygulamalar.CurrentRow.Index].Value.ToString();
                lblYetki.Refresh();

                txtYetkiId.Text = dgvYetkiler.Rows[dgvYetkiler.CurrentRow.Index].Cells[0].Value.ToString();
                txtYetkiId.Refresh();
            }
            catch (Exception)
            {
                lblYetki.Text = "";
                lblYetki.Refresh();
                txtYetkiId.Text = "0";
                txtYetkiId.Refresh();
            }
        }

        private void btnYetkiver_Click(object sender, EventArgs e)
        {
            if (txtYetkiId.Text == "0")
            {
                MessageBox.Show("Lütfen Yetki Seçiniz");
                return;
            }

            string sorgu = "SELECT KULLANICI_ID, YETKI_ID FROM KULLANICI_YETKI WHERE KULLANICI_ID="+ txtKullaniciID.Text + " AND YETKI_ID=" + txtYetkiId.Text;
            DataTable sorgusonuc = new DataTable();
            sorgusonuc = manager.BasitSorguDT(sorgu, analizConStr);
            if (sorgusonuc.Rows.Count > 0)
            {
                MessageBox.Show("Kullanıcı Zaten Bu Yetkiye Sahip!");
                return;
            }


            sorgu = "INSERT INTO KULLANICI_YETKI (KULLANICI_ID, YETKI_ID, GECERLILIK_TARIHI, AKTIF, KAYDEDEN, KAYIT_TARIHI, GUNCELLEYEN, GUNCELLEME_TARIHI) "+
                " VALUES("+txtKullaniciID.Text+", "+txtYetkiId.Text+", NULL, 1, '"+ Manager._kullaniciAdSoyad + "', NULL, '"+ Manager._kullaniciAdSoyad + "', NULL); ";
            if (manager.sqlCalistir(sorgu,analizConStr))
            {
                //MessageBox.Show("İşlem Başarılı");
                kullaniciAyarla();
                YetkiSorgula();
            }
            else
            {
                MessageBox.Show("Kayıt Gerçekleşmedi!");
            }
        }

        private void btnYetkiSil_Click(object sender, EventArgs e)
        {
            DialogResult Soru = new DialogResult();

            Soru = MessageBox.Show("Kullanıcı Yetkisini Silmek İstiyor Musunuz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Soru == DialogResult.No)
            {
                return;
            }

            string sorgu = "DELETE FROM KULLANICI_YETKI WHERE KULLANICI_ID=" + txtKullaniciID.Text + " AND YETKI_ID=" + txtYetkiId.Text;
            if (manager.sqlCalistir(sorgu, analizConStr))
            {
                kullaniciAyarla();
                YetkiSorgula();
            }
            else
            {
                MessageBox.Show("Kayıt Gerçekleşmedi!");
            }
        }
    }
}
