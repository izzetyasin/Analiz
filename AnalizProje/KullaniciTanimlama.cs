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
    public partial class KullaniciTanimlama : Form
    {
        Manager manager = new Manager();
        string analizConStr = "";
        string wolVoxConStr = "";
        bool yetkiDurumu = false; // false yetkisiz kullanıcı true yetkili kullanıcı

        public KullaniciTanimlama()
        {
            InitializeComponent();
            analizConStr = manager.conStrAnaliz;
            wolVoxConStr = manager.conStrWolvox;
        }

        private void KullaniciTanimlama_Load(object sender, EventArgs e)
        {

            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("KULLANICITANIM", "LISTELE")))
            {
                yetkiDurumu = false;
                yetkisiz();
            }
            else
            {
                yetkiDurumu = true;
                yetkili();
            }
        }
        private void yetkisiz()
        {
            //MessageBox.Show("Kullanıcı Listesi Görme Yetkiniz Yok! (Uygulama: KULLANICITANIM - Yetki: LISTELE)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnYeni.Enabled = false;
            txtKullaniciAdi.Enabled = false;
            txtAdi.Enabled = false;
            txtSoyadi.Enabled = false;
            txtGorevi.Enabled = false;
            chkKullaniciAktif.Enabled = false;
            dgvKullanicilar.Visible = false;
            lblUyari.Visible = true;

            string sorgu = "SELECT * FROM KULLANICI WHERE KULLANICI_ID=" + Manager.KullaniciID.ToString();
            dgvKullanicilar.VirtualMode = true;
            DataSet ds = new DataSet();
            ds = manager.BasitSorguDS(sorgu, analizConStr);
            dgvKullanicilar.DataSource = ds;
            dgvKullanicilar.DataMember = "table";
            dgvKullanicilar.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            //DataGridView1.Rows(1).Cells(0).Value.ToString
            GridEkrana(0);
        }
        private void yetkili()
        {
            sahalarıTemizle();
            
            string sorgu = "SELECT * FROM KULLANICI ORDER BY ADI, SOYADI";
            dgvKullanicilar.VirtualMode = true;
            DataSet ds = new DataSet();
            ds = manager.BasitSorguDS(sorgu, analizConStr);
            dgvKullanicilar.DataSource = ds;
            dgvKullanicilar.DataMember = "table";
            dgvKullanicilar.Columns[7].Visible = false;
            lblUyari.Visible = false;
        }

        private void kullaniciListele()
        {
            txtSeciliID.Text = "0";
            //txtKullaniciAdi.Text = "";
            txtAdi.Text = "";
            txtSoyadi.Text = "";
            txtGorevi.Text = "";
            txtTelefon.Text = "";
            txtMailAdres.Text = "";
            txtSuAnkiParola.Text = "";
            txtMevcutParola.Text = "";
            txtYeniParola.Text = "";
            txtYeniParolaTekrar.Text = "";
            chkKullaniciAktif.Checked = true;


            string sorgu = "SELECT * FROM KULLANICI WHERE KULLANICI_ADI='"+ txtKullaniciAdi.Text + "' ORDER BY ADI, SOYADI";
            dgvKullanicilar.VirtualMode = true;
            DataTable dt = new DataTable();
            dt = manager.BasitSorguDT(sorgu, analizConStr);

            if (dt.Rows.Count > 0)
            {
                txtSeciliID.Text = dt.Rows[0][0].ToString();
                //txtKullaniciAdi.Text = dt.Rows[0][1].ToString();
                txtAdi.Text = dt.Rows[0][2].ToString();
                txtSoyadi.Text = dt.Rows[0][3].ToString();
                txtGorevi.Text = dt.Rows[0][4].ToString();
                txtTelefon.Text = dt.Rows[0][5].ToString();
                txtMailAdres.Text = dt.Rows[0][6].ToString();
                txtSuAnkiParola.Text = dt.Rows[0][7].ToString();
                if (dt.Rows[0][8].ToString() == "1")
                {
                    chkKullaniciAktif.Checked = true;
                }
                else
                {
                    chkKullaniciAktif.Checked = false;
                }
            }
        }

        private void KullaniciTanimlama_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void GridEkrana(int satir)
        {
            sahalarıTemizle();
            txtSeciliID.Text = dgvKullanicilar.Rows[satir].Cells[0].Value.ToString();
            txtKullaniciAdi.Text = dgvKullanicilar.Rows[satir].Cells[1].Value.ToString();
            txtAdi.Text = dgvKullanicilar.Rows[satir].Cells[2].Value.ToString();
            txtSoyadi.Text = dgvKullanicilar.Rows[satir].Cells[3].Value.ToString();
            txtGorevi.Text = dgvKullanicilar.Rows[satir].Cells[4].Value.ToString();
            txtTelefon.Text = dgvKullanicilar.Rows[satir].Cells[5].Value.ToString();
            txtMailAdres.Text = dgvKullanicilar.Rows[satir].Cells[6].Value.ToString();
            txtSuAnkiParola.Text = dgvKullanicilar.Rows[satir].Cells[7].Value.ToString();

            if (dgvKullanicilar.Rows[satir].Cells[8].Value.ToString() == "1")
            {
                chkKullaniciAktif.Checked = true;
            }
            else
            {
                chkKullaniciAktif.Checked = false;
            }
        }

        private void dgvKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sahalarıTemizle();
            int satir = dgvKullanicilar.CurrentRow.Index;
            GridEkrana(satir);
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            sahalarıTemizle();
        }

        private void sahalarıTemizle()
        {
            txtSeciliID.Text = "0";
            txtKullaniciAdi.Text = "";
            txtAdi.Text = "";
            txtSoyadi.Text = "";
            txtGorevi.Text = "";
            txtTelefon.Text = "";
            txtMailAdres.Text = "";
            txtSuAnkiParola.Text = "";
            txtMevcutParola.Text = "";
            txtYeniParola.Text = "";
            txtYeniParolaTekrar.Text = "";
            chkKullaniciAktif.Checked = true;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!yetkiDurumu)
            {
                if (txtSuAnkiParola.Text == txtMevcutParola.Text)
                {
                    if (txtYeniParola.Text.Length > 0)
                    {
                        if (txtYeniParola.Text == txtYeniParolaTekrar.Text)
                        {
                            txtMevcutParola.Text = txtYeniParola.Text;
                        }
                        else
                        {
                            MessageBox.Show("Yeni Parolanız İle Tekrar Parolanız aynı değil! Lütfen Kontrol Ediniz!");
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Kaydetmek İçin Şifrenizi Doğru Giriniz!");
                    return;
                }
            }
            

            if (yetkiDurumu)
            {
                    if (txtYeniParola.Text.Length > 0)
                    {
                        if (txtYeniParola.Text == txtYeniParolaTekrar.Text)
                        {
                            txtMevcutParola.Text = txtYeniParola.Text;
                        }
                        else
                        {
                            MessageBox.Show("Yeni Parolan İle Tekrar Parolan aynı değil! Lütfen Kontrol Ediniz!");
                            return;
                        }
                    }
            }


            DataTable dtSonuc = new DataTable();
            dtSonuc = manager.GetDataTableFull("KULLANICI", "KULLANICI_ID="+txtSeciliID.Text.ToString(), analizConStr);
            bool kayitVar = true;
            if (dtSonuc.Rows.Count == 0)
            {
                dtSonuc.Rows.Add();
                kayitVar = false;
            }
            dtSonuc.Rows[0]["KULLANICI_ADI"] = txtKullaniciAdi.Text.ToString();
            dtSonuc.Rows[0]["ADI"] = txtAdi.Text.ToString();
            dtSonuc.Rows[0]["SOYADI"] = txtSoyadi.Text.ToString();
            dtSonuc.Rows[0]["GOREVI"] = txtGorevi.Text.ToString();
            dtSonuc.Rows[0]["TELEFONU"] = txtTelefon.Text.ToString();
            dtSonuc.Rows[0]["MAIL_ADRESI"] = txtMailAdres.Text.ToString();
            dtSonuc.Rows[0]["PAROLA"] = txtMevcutParola.Text.ToString();
            if (chkKullaniciAktif.Checked)
            {
                dtSonuc.Rows[0]["AKTIF"] = 1;
            }
            else
            {
                dtSonuc.Rows[0]["AKTIF"] = 0;
            }
            if (!kayitVar)
            {
                dtSonuc.Rows[0]["KAYDEDEN"] = Manager.KullaniciAdSoyad.ToString();
            }
            dtSonuc.Rows[0]["GUNCELLEYEN"] = Manager.KullaniciAdSoyad.ToString();

            int deger = int.Parse(txtSeciliID.Text.ToString());

            // kaydetme if koşulu içinde oluyor
            if (manager.kaydetGuncelle("KULLANICI", "KULLANICI_ID" , deger, dtSonuc, analizConStr))
            {
                dtSonuc = manager.GetDataTableFull("KULLANICI", "KULLANICI_ADI='" + txtKullaniciAdi.Text.ToString() + "'",analizConStr);
                txtKullaniciAdi.Text = dtSonuc.Rows[0]["KULLANICI_ADI"].ToString();
                //GridEkrana(0);
                MessageBox.Show("Kaydetme İşlemi Tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnKaydet.Text = "Kaydet";
            }
            else
            {
                MessageBox.Show("Kaydetme İşleminde Hata. Kayıt Gerçekleşmedi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("KULLANICITANIM", "LISTELE")))
            {
                yetkisiz();
            }
            else
            {
                yetkili();
            }
        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {
            kullaniciListele();
        }
    }
}
