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
    public partial class Giris : Form
    {
        Manager manager = new Manager();
        public Giris()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            DataTable sonuc = new DataTable();

            string sqlSorgu = "SELECT COUNT(KULLANICI_ID), KULLANICI_ID , ADI, SOYADI , AKTIF FROM KULLANICI WHERE "+
                "KULLANICI_ADI='"+txtKullaniciAdi.Text.ToString()+"' AND PAROLA='"+txtParola.Text.ToString()+ "' GROUP BY KULLANICI_ID,ADI,SOYADI, AKTIF";
            sonuc = manager.BasitSorguDT(sqlSorgu,manager.conStrAnaliz);

            if (sonuc !=null && sonuc.Rows.Count>0 && sonuc.Rows[0]["COUNT"].ToString().Equals("1") && sonuc.Rows[0]["AKTIF"].ToString().Equals("1"))
            {
                Manager.KullaniciID = sonuc.Rows[0]["KULLANICI_ID"];//.ToString();
                Manager.KullaniciAdSoyad = sonuc.Rows[0]["ADI"].ToString() + " " + sonuc.Rows[0]["SOYADI"].ToString();
                Manager.VeriTasi = "Giriş Onaylandı";
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Parola Hatalı", "Hatalı Girişi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Dispose();
        }

        private void Giris_FormClosing(object sender, FormClosingEventArgs e)
        {
                this.Dispose();
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }
    }
}
