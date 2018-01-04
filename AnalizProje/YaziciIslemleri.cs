using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Drawing.Printing;


namespace AnalizProje
{
    public partial class YaziciIslemleri : Form
    {

        public YaziciIslemleri()
        {
            InitializeComponent();
        }

        private void btnSayfaAyarlari_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void btnBaskiOnIzleme_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            DialogResult pdr = printDialog1.ShowDialog();
            if (pdr == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            

            //Graphics g = panel1.CreateGraphics();
            //Font LableFont = new Font("Arial", 10);
            //Font CodeFont = new Font("Free 3 of 9", 30);
            //string code = "*1234";
            //float LabelWidth = g.MeasureString(code, LableFont).Width; float CodeWidth = g.MeasureString(code, CodeFont).Width;
            //g.DrawString(code, CodeFont, Brushes.Black, 1, 1);
            //Brushes.Black PointF((CodeWidth-LabelWidth) / 3, 30));



            ////Yazı fontumu ve çizgi çizmek için fırçamı ve kalem nesnemi oluşturdum
            //Font myFont = new Font("Calibri", 11);
            //SolidBrush sbrush = new SolidBrush(Color.Black);
            //Pen myPen = new Pen(Color.Black);

            ////Bu kısımda sipariş formu yazısını ve çizgileri yazdırıyorum
            //e.Graphics.DrawString(DateTime.Now.ToString("dd.MM.yyyy")+ " TARİHLİ EKSİK LİSTESİ", myFont, sbrush, 100, 80);


            //myFont = new Font("Calibri", 12, FontStyle.Regular);
            //e.Graphics.DrawString("Ürün Adı", myFont, sbrush, 100, 120);
            //e.Graphics.DrawString("Miktarı", myFont, sbrush, 420, 120);
            //e.Graphics.DrawString("Birimi", myFont, sbrush, 620, 120);

            //e.Graphics.DrawLine(myPen, 100, 140, 750, 140);

            //int y = 150;

            //StringFormat myStringFormat = new StringFormat();
            //myStringFormat.Alignment = StringAlignment.Far;

            //decimal gTotal = 0;

            //foreach (ListViewItem lvi in listView1.Items)
            //{
            //    //e.Graphics.DrawString(lvi.Text, myFont, sbrush, 120, y);
            //    e.Graphics.DrawString(lvi.SubItems[0].Text, myFont, sbrush, 100, y);
            //    e.Graphics.DrawString(lvi.SubItems[1].Text, myFont, sbrush, 420, y);
            //    e.Graphics.DrawString(lvi.SubItems[2].Text, myFont, sbrush, 620, y);
            //    //e.Graphics.DrawString(lvi.SubItems[1].Text, myFont, sbrush, 220, y, myStringFormat);
            //    //decimal bFiyat = Convert.ToDecimal(lvi.SubItems[2].Text);
            //    //decimal fiyat = Convert.ToDecimal(lvi.SubItems[1].Text) * Convert.ToDecimal(lvi.SubItems[2].Text);
            //    //gTotal += fiyat;
            //    //e.Graphics.DrawString(bFiyat.ToString("c"), myFont, sbrush, 530, y, myStringFormat);
            //    //e.Graphics.DrawString(fiyat.ToString("c"), myFont, sbrush, 700, y, myStringFormat);

            //    y += 25;

            //}

            //e.Graphics.DrawLine(myPen, 100, y, 750, y);
            //e.Graphics.DrawString(gTotal.ToString("c"), myFont, sbrush, 700, y + 10, myStringFormat);

        }

        void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void YaziciIslemleri_Load(object sender, EventArgs e)
        {

        }


        private void btnBarkodBas_Click(object sender, EventArgs e)
        {
             //PortOpen_USB(0); // Start Job 
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


            //yazdir.PrintPage += delegate (object sender1, PrintPageEventArgs s)
            //{
            //    s.Graphics.DrawString("HOŞ GELDİNİZ!", new Font("Arial", 8), new SolidBrush(Color.Black), new RectangleF(1, 5, 120, 0));
            //    s.Graphics.DrawString("----------------", new Font("Arial", 8), new SolidBrush(Color.Black), new RectangleF(1, 15, 120, 0));
            //    s.Graphics.DrawString("SIRA NUMARANIZ 1", new Font("Arial", 8), new SolidBrush(Color.Black), new RectangleF(1, 25, 120, 0));
            //};
            //try
            //{
            //    yazdir.DefaultPageSettings.PaperSize = new PaperSize("Barkod",100,50);
            //   // yazdir.PrinterSettings.PrinterName = "ZDesigner TLP 2844";
            //    yazdir.Print();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Yazdırma Sırasında Bir Sorun Oluştu.", ex);
            //}

            //printDocument1.Print();
        }

    }
}
