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
    public partial class Kisiler : Form
    {
        Manager manager = new Manager();
        DataTable kisiler = new DataTable();
        string analizConStr = "";
        string wolVoxConStr = "";

        public Kisiler()
        {
            InitializeComponent();
            analizConStr = manager.conStrAnaliz;
            wolVoxConStr = manager.conStrWolvox;
        }

        private void Kisiler_Load(object sender, EventArgs e)
        {
            txtCariId.Text = Manager.CariIdTasi.ToString();
            kisileriYukle();
        }
        public void kisileriYukle()
        {
            string sql = "SELECT * FROM CARI_KISILER WHERE CARI_ID=" + Manager.CariIdTasi.ToString();

            kisiler = manager.BasitSorguDT(sql, analizConStr);
            dgvKisiler.DataSource = kisiler;

            dgvKisiler.Columns["CARI_KISILER_ID"].Visible = false;
            dgvKisiler.Columns["CARI_ID"].Visible = false;
            dgvKisiler.Columns["KAYIT_TARIHI"].Visible = false;
            dgvKisiler.Columns["KAYDEDEN"].Visible = false;
            dgvKisiler.Columns["GUNCELLEME_TARIHI"].Visible = false;
            dgvKisiler.Columns["GUNCELLEYEN"].Visible = false;

            dgvKisiler.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            if (!(manager.YetkiSorgula("KISILER", "YENIKAYIT")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: KISILER - Yetki: YENIKAYIT)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtCariKisilerId.Text = "0";
            txtAdi.Text = "";
            txtSoyadi.Text = "";
            txtTelefon1.Text = "";
            txtTelefon2.Text = "";
            txtDahili.Text = "";
            txtEMail.Text = "";
            txtAciklama.Text = "";
            txtGorevi.Text = "";
            txtYetkisi.Text = "";
            chkAktif.Checked = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("KISILER", "KAYDET")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: KISILER - Yetki: KAYDET)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtCariId.Text.ToString() == "" || txtCariKisilerId.Text.ToString().Trim() == "")
            {
                return;
            }

            DataTable dtSonuc = new DataTable();
            dtSonuc = manager.GetDataTableFull("CARI_KISILER", "CARI_KISILER_ID=" + txtCariKisilerId.Text.ToString(), analizConStr);
            bool kayitVar = true;
            if (dtSonuc.Rows.Count == 0)
            {
                dtSonuc.Rows.Add();
                kayitVar = false;
            }
            dtSonuc.Rows[0]["CARI_ID"] = txtCariId.Text.ToString();
            dtSonuc.Rows[0]["ADI"] = txtAdi.Text.ToString();
            dtSonuc.Rows[0]["SOYADI"] = txtSoyadi.Text.ToString();
            dtSonuc.Rows[0]["TELEFON1"] = txtTelefon1.Text.ToString();
            dtSonuc.Rows[0]["TELEFON2"] = txtTelefon2.Text.ToString();
            dtSonuc.Rows[0]["DAHILI_TELEFONU"] = txtDahili.Text.ToString();
            dtSonuc.Rows[0]["EMAIL"] = txtEMail.Text.ToString();
            dtSonuc.Rows[0]["ACIKLAMA"] = txtAciklama.Text.ToString();
            dtSonuc.Rows[0]["GOREVI"] = txtGorevi.Text.ToString();
            dtSonuc.Rows[0]["YETKISI"] = txtYetkisi.Text.ToString();
            dtSonuc.Rows[0]["AKTIF"] = chkAktif.Checked;

            if (!kayitVar)
            {
                dtSonuc.Rows[0]["KAYDEDEN"] = Manager.KullaniciAdSoyad.ToString();
            }
            dtSonuc.Rows[0]["GUNCELLEYEN"] = Manager.KullaniciAdSoyad.ToString();

            int deger = int.Parse(txtCariKisilerId.Text.ToString());

            // kaydetme if koşulu içinde oluyor
            if (manager.kaydetGuncelle("CARI_KISILER", "CARI_KISILER_ID", deger, dtSonuc, analizConStr))
            {
                kisileriYukle();
                MessageBox.Show("Kaydetme İşlemi Tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kaydetme İşleminde Hata. Kayıt Gerçekleşmedi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void dgvKisiler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKisiler.CurrentRow.Cells["CARI_KISILER_ID"].Value.ToString() == "")
            {
                return;
            }
            txtCariKisilerId.Text = dgvKisiler.CurrentRow.Cells["CARI_KISILER_ID"].Value.ToString();
            txtAdi.Text = dgvKisiler.CurrentRow.Cells["ADI"].Value.ToString();
            txtSoyadi.Text = dgvKisiler.CurrentRow.Cells["SOYADI"].Value.ToString();
            txtTelefon1.Text = dgvKisiler.CurrentRow.Cells["TELEFON1"].Value.ToString();
            txtTelefon2.Text = dgvKisiler.CurrentRow.Cells["TELEFON2"].Value.ToString();
            txtDahili.Text = dgvKisiler.CurrentRow.Cells["DAHILI_TELEFONU"].Value.ToString();
            txtEMail.Text = dgvKisiler.CurrentRow.Cells["EMAIL"].Value.ToString();
            txtAciklama.Text = dgvKisiler.CurrentRow.Cells["ACIKLAMA"].Value.ToString();
            txtGorevi.Text = dgvKisiler.CurrentRow.Cells["GOREVI"].Value.ToString();
            txtYetkisi.Text = dgvKisiler.CurrentRow.Cells["YETKISI"].Value.ToString();
            chkAktif.Checked = false;
            if (dgvKisiler.CurrentRow.Cells["AKTIF"].Value.ToString() == "1") chkAktif.Checked = true;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //Yetki Sorgulama
            if (!(manager.YetkiSorgula("KISILER", "SIL")))
            {
                MessageBox.Show("Yetkiniz Yok! (Uygulama: KISILER - Yetki: SIL)", "Yetki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((dgvKisiler.Rows.Count > 0))
            {
                if (MessageBox.Show("Kaydı Silmek İstiyor Musunuz?", "Uyarı...", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    manager.Sil("CARI_ADRES", "CARI_ADRES_ID=" + txtCariKisilerId.Text.ToString(), analizConStr);
                    kisileriYukle();
                }
            }
        }
    }
}
