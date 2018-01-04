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
    public partial class AnaForm : Form
    {
        Manager manager = new Manager();
        string analizConStr = "";
        string wolVoxConStr = "";

        public AnaForm()
        {
            InitializeComponent();
            analizConStr = manager.conStrAnaliz;
            wolVoxConStr = manager.conStrWolvox;
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            Manager.YetkiEkraniAcik = 0;
            kullaniciGiris();

        }
        private void telefonDuzenle()
        {
            //Telefon numaralarının başında 0 olması, birden fazla cari bulmada sorun oluşturuyor.
            //Bu nedenle telefon numaralarının başında 0 varsa kaldırma işlemi yapıldı.
            string sorgu = " UPDATE CARI SET CEP_TEL = SUBSTRING(CEP_TEL from 2 for CHAR_LENGTH(CEP_TEL)) WHERE CEP_TEL LIKE('0%'); ";
            if (!(manager.sqlCalistir(sorgu, wolVoxConStr)))
            {
                MessageBox.Show("Sorgu Çalışmasında Hata Oluştu!");
            }
            sorgu = " UPDATE CARI SET TEL1 = SUBSTRING(TEL1 from 2 for CHAR_LENGTH(TEL1)) WHERE TEL1 LIKE('0%'); ";
            if (!(manager.sqlCalistir(sorgu, wolVoxConStr)))
            {
                MessageBox.Show("Sorgu Çalışmasında Hata Oluştu!");
            }

        }
        private void müşteriTakibiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("ANALIZ", "GIRIS")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: ANALIZ - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FrmAnalizProje analiz = new FrmAnalizProje();
            analiz.MdiParent = this;
            analiz.Text = "Müşteri Takibi";
            analiz.Show();
        }

        private void enÇokSatanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("RAPOR", "GIRIS")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: RAPOR - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Raporlar raporlar = new Raporlar();
            raporlar.MdiParent = this;
            raporlar.Show();
        }

        private void kullanıcıDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kullaniciGiris();
        }

        private void kullaniciGiris()
        {
            Giris giris = new Giris();
            //giris.MdiParent = this;
            giris.Text = "Kullanıcı Girişi";
            giris.ShowDialog();
            if (Manager.VeriTasi == null)
            {
                this.Dispose();
            }
            else
            {
                this.Text = "Aktar Takip - Aktif Kullanıcı : " + Manager.KullaniciAdSoyad;
                telefonDuzenle();
            }
            Manager.VeriTasi = null;
        }

        private void kullanıcıTanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("KULLANICITANIM", "GIRIS")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: KULLANICITANIM - Yetki: GIRIS)", "Yetki",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            KullaniciTanimlama kullaniciTanimlama = new KullaniciTanimlama();
            //kullaniciTanimlama.MdiParent = this;
            kullaniciTanimlama.Text = "Kullanıcı Tanımlama";
            kullaniciTanimlama.ShowDialog();
        }

        private void yetkilendirmeİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("YETKILENDIRME", "GIRIS")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: YETKILENDIRME - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Yetkilendirme yetkilendirme = new Yetkilendirme();
            yetkilendirme.MdiParent = this;
            yetkilendirme.Text = "Kullanıcı Tanımlama";
            yetkilendirme.Show();
        }

        private void seçimParametreleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Manager.VeriTasi = null;
            //DetayTanim modelSinifi = new DetayTanim(true);
            //modelSinifi.ShowDialog();
            //cmbModelSinifiDoldur();
            //if (Manager.VeriTasi.ToString() != "0" && Manager.VeriTasi.ToString() != "36") cmbModelSinifi.SelectedValue = Manager.VeriTasi;
            Manager.VeriTasi = null;


            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("PARAMETRE", "GIRIS")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: PARAMETRE - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Parametre parametre = new Parametre();
            parametre.MdiParent = this;
            parametre.Text = "Parametre";
            parametre.Show();
        }

        private void müşteriBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("CARIKART", "GIRIS")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: CARIKART - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Manager.CariIdTasi = null;
            CariKart cariKart = new CariKart();
            Manager.CariIdTasi = null;
            cariKart.MdiParent = this;
            cariKart.Text = "Cari Kart";
            cariKart.Show();
        }

        private void tümAçıkFormlarıKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void formlarıKüçültToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] charrx = this.MdiChildren;
            foreach (Form chform in charrx)
                chform.WindowState = FormWindowState.Minimized;
        }

        private void formalrıOrjinalBoyutaGetirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] charrx = this.MdiChildren;
            foreach (Form chform in charrx)
                chform.WindowState = FormWindowState.Normal;
        }

        private void parametreAğacıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("PARAMETREAGACI", "GIRIS")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: PARAMETREAGACI - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ParametreAgaci parametreAgaci = new ParametreAgaci();
            //parametreAgaci.MdiParent = this;
            Manager.NodTasi = 109;
            parametreAgaci.Text = "İletişim Şekli";
            parametreAgaci.Show();
        }

        private void eksikListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("EKSIKLISTESI", "GIRIS")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: EKSIKLISTESI - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            YaziciIslemleri yaziciIslemleri = new YaziciIslemleri();
            yaziciIslemleri.MdiParent = this;
            //Manager.NodTasi = 109;
            yaziciIslemleri.Text = "Eksik Listesi";
            yaziciIslemleri.Show();
        }

        private void müşteriİlişkileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("MUSTERIILISKILERI", "GIRIS")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: MUSTERIILISKILERI - Yetki: GIRIS)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            RaporlarSatis raorlarSatis = new RaporlarSatis();
            raorlarSatis.MdiParent = this;
            //Manager.NodTasi = 109;
            raorlarSatis.Text = "Müşteri İlişkileri";
            raorlarSatis.Show();
        }
    }
}
