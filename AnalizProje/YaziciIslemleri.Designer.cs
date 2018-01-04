namespace AnalizProje
{
    partial class YaziciIslemleri
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Roka Tohumu",
            "10",
            "Adet"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Buğday Çimi Suyu",
            "10",
            "gr"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YaziciIslemleri));
            this.listView1 = new System.Windows.Forms.ListView();
            this.urunAdi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.miktari = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.birimi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSayfaAyarlari = new System.Windows.Forms.Button();
            this.btnYazdir = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btnBaskiOnIzleme = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.btnBarkodBas = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.urunAdi,
            this.miktari,
            this.birimi});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listView1.Location = new System.Drawing.Point(14, 15);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(817, 236);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // urunAdi
            // 
            this.urunAdi.Text = "Ürün Adı";
            this.urunAdi.Width = 533;
            // 
            // miktari
            // 
            this.miktari.Text = "Miktarı";
            this.miktari.Width = 113;
            // 
            // birimi
            // 
            this.birimi.Text = "Birimi";
            this.birimi.Width = 91;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(853, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "<<";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(904, 15);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1072, 15);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 28);
            this.button3.TabIndex = 4;
            this.button3.Text = ">>";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1021, 15);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(45, 28);
            this.button4.TabIndex = 3;
            this.button4.Text = ">";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(970, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = ".../...";
            // 
            // btnSayfaAyarlari
            // 
            this.btnSayfaAyarlari.Location = new System.Drawing.Point(853, 81);
            this.btnSayfaAyarlari.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSayfaAyarlari.Name = "btnSayfaAyarlari";
            this.btnSayfaAyarlari.Size = new System.Drawing.Size(96, 28);
            this.btnSayfaAyarlari.TabIndex = 6;
            this.btnSayfaAyarlari.Text = "Sayfa Ayarları";
            this.btnSayfaAyarlari.UseVisualStyleBackColor = true;
            this.btnSayfaAyarlari.Click += new System.EventHandler(this.btnSayfaAyarlari_Click);
            // 
            // btnYazdir
            // 
            this.btnYazdir.Location = new System.Drawing.Point(853, 117);
            this.btnYazdir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new System.Drawing.Size(96, 28);
            this.btnYazdir.TabIndex = 7;
            this.btnYazdir.Text = "Yazdır";
            this.btnYazdir.UseVisualStyleBackColor = true;
            this.btnYazdir.Click += new System.EventHandler(this.btnYazdir_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1021, 117);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(96, 28);
            this.button7.TabIndex = 9;
            this.button7.Text = "Çıkış";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // btnBaskiOnIzleme
            // 
            this.btnBaskiOnIzleme.Location = new System.Drawing.Point(1021, 81);
            this.btnBaskiOnIzleme.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBaskiOnIzleme.Name = "btnBaskiOnIzleme";
            this.btnBaskiOnIzleme.Size = new System.Drawing.Size(96, 28);
            this.btnBaskiOnIzleme.TabIndex = 8;
            this.btnBaskiOnIzleme.Text = "Baskı Ön İzleme";
            this.btnBaskiOnIzleme.UseVisualStyleBackColor = true;
            this.btnBaskiOnIzleme.Click += new System.EventHandler(this.btnBaskiOnIzleme_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.printDocument1;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Text = "Baskı önizleme";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // btnBarkodBas
            // 
            this.btnBarkodBas.Location = new System.Drawing.Point(853, 285);
            this.btnBarkodBas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBarkodBas.Name = "btnBarkodBas";
            this.btnBarkodBas.Size = new System.Drawing.Size(96, 28);
            this.btnBarkodBas.TabIndex = 10;
            this.btnBarkodBas.Text = "Yazdır";
            this.btnBarkodBas.UseVisualStyleBackColor = true;
            this.btnBarkodBas.Click += new System.EventHandler(this.btnBarkodBas_Click);
            // 
            // panel1
            // 
            this.panel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel1.Location = new System.Drawing.Point(853, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 100);
            this.panel1.TabIndex = 11;
            // 
            // YaziciIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 708);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBarkodBas);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btnBaskiOnIzleme);
            this.Controls.Add(this.btnYazdir);
            this.Controls.Add(this.btnSayfaAyarlari);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "YaziciIslemleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YaziciIslemleri";
            this.Load += new System.EventHandler(this.YaziciIslemleri_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader urunAdi;
        private System.Windows.Forms.ColumnHeader miktari;
        private System.Windows.Forms.ColumnHeader birimi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSayfaAyarlari;
        private System.Windows.Forms.Button btnYazdir;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnBaskiOnIzleme;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button btnBarkodBas;
        private System.Windows.Forms.Panel panel1;
    }
}