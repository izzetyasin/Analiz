namespace AnalizProje
{
    partial class RaporlarSatis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaporlarSatis));
            this.grpButonlar = new System.Windows.Forms.GroupBox();
            this.btnIkıTarihArasiKar = new System.Windows.Forms.Button();
            this.btnTarihArasiMusteri = new System.Windows.Forms.Button();
            this.txtBitisTarihi = new System.Windows.Forms.MaskedTextBox();
            this.txtBaslamaTarihi = new System.Windows.Forms.MaskedTextBox();
            this.txtSiparisteAra = new System.Windows.Forms.TextBox();
            this.btnSiparisteAra = new System.Windows.Forms.Button();
            this.btnCevapsiz = new System.Windows.Forms.Button();
            this.btnGorusmeler = new System.Windows.Forms.Button();
            this.btnCariAra = new System.Windows.Forms.Button();
            this.grpSonuc = new System.Windows.Forms.GroupBox();
            this.dgvSonuc = new System.Windows.Forms.DataGridView();
            this.grpGenelToplamlar = new System.Windows.Forms.GroupBox();
            this.txtKarYuzdesi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGenelKazanc = new System.Windows.Forms.TextBox();
            this.txtSatisTutari = new System.Windows.Forms.TextBox();
            this.txtBirimSatisFiyati = new System.Windows.Forms.TextBox();
            this.txtBirimAlisFiyati = new System.Windows.Forms.TextBox();
            this.txtSiparisSayisi = new System.Windows.Forms.TextBox();
            this.txtSepetSayisi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpButonlar.SuspendLayout();
            this.grpSonuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSonuc)).BeginInit();
            this.grpGenelToplamlar.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpButonlar
            // 
            this.grpButonlar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpButonlar.Controls.Add(this.btnIkıTarihArasiKar);
            this.grpButonlar.Controls.Add(this.btnTarihArasiMusteri);
            this.grpButonlar.Controls.Add(this.txtBitisTarihi);
            this.grpButonlar.Controls.Add(this.txtBaslamaTarihi);
            this.grpButonlar.Controls.Add(this.txtSiparisteAra);
            this.grpButonlar.Controls.Add(this.btnSiparisteAra);
            this.grpButonlar.Controls.Add(this.btnCevapsiz);
            this.grpButonlar.Controls.Add(this.btnGorusmeler);
            this.grpButonlar.Controls.Add(this.btnCariAra);
            this.grpButonlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpButonlar.ForeColor = System.Drawing.Color.Teal;
            this.grpButonlar.Location = new System.Drawing.Point(14, 14);
            this.grpButonlar.Margin = new System.Windows.Forms.Padding(5);
            this.grpButonlar.Name = "grpButonlar";
            this.grpButonlar.Padding = new System.Windows.Forms.Padding(5);
            this.grpButonlar.Size = new System.Drawing.Size(279, 790);
            this.grpButonlar.TabIndex = 1;
            this.grpButonlar.TabStop = false;
            this.grpButonlar.Text = "Sorgular";
            // 
            // btnIkıTarihArasiKar
            // 
            this.btnIkıTarihArasiKar.Location = new System.Drawing.Point(8, 357);
            this.btnIkıTarihArasiKar.Name = "btnIkıTarihArasiKar";
            this.btnIkıTarihArasiKar.Size = new System.Drawing.Size(267, 53);
            this.btnIkıTarihArasiKar.TabIndex = 175;
            this.btnIkıTarihArasiKar.Text = "İki Tarih Arası Kar Analizi";
            this.btnIkıTarihArasiKar.UseVisualStyleBackColor = true;
            this.btnIkıTarihArasiKar.Visible = false;
            this.btnIkıTarihArasiKar.Click += new System.EventHandler(this.btnIkıTarihArasiKar_Click);
            // 
            // btnTarihArasiMusteri
            // 
            this.btnTarihArasiMusteri.Location = new System.Drawing.Point(8, 298);
            this.btnTarihArasiMusteri.Name = "btnTarihArasiMusteri";
            this.btnTarihArasiMusteri.Size = new System.Drawing.Size(267, 53);
            this.btnTarihArasiMusteri.TabIndex = 174;
            this.btnTarihArasiMusteri.Text = "İki Tarih Arası Müşteriler";
            this.btnTarihArasiMusteri.UseVisualStyleBackColor = true;
            this.btnTarihArasiMusteri.Click += new System.EventHandler(this.btnTarihArasiMusteri_Click);
            // 
            // txtBitisTarihi
            // 
            this.txtBitisTarihi.Location = new System.Drawing.Point(171, 267);
            this.txtBitisTarihi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBitisTarihi.Mask = "00/00/0000";
            this.txtBitisTarihi.Name = "txtBitisTarihi";
            this.txtBitisTarihi.Size = new System.Drawing.Size(104, 26);
            this.txtBitisTarihi.TabIndex = 173;
            this.txtBitisTarihi.ValidatingType = typeof(System.DateTime);
            // 
            // txtBaslamaTarihi
            // 
            this.txtBaslamaTarihi.Location = new System.Drawing.Point(8, 267);
            this.txtBaslamaTarihi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBaslamaTarihi.Mask = "00/00/0000";
            this.txtBaslamaTarihi.Name = "txtBaslamaTarihi";
            this.txtBaslamaTarihi.Size = new System.Drawing.Size(104, 26);
            this.txtBaslamaTarihi.TabIndex = 172;
            this.txtBaslamaTarihi.ValidatingType = typeof(System.DateTime);
            // 
            // txtSiparisteAra
            // 
            this.txtSiparisteAra.Location = new System.Drawing.Point(8, 27);
            this.txtSiparisteAra.Name = "txtSiparisteAra";
            this.txtSiparisteAra.Size = new System.Drawing.Size(267, 26);
            this.txtSiparisteAra.TabIndex = 171;
            // 
            // btnSiparisteAra
            // 
            this.btnSiparisteAra.Location = new System.Drawing.Point(8, 53);
            this.btnSiparisteAra.Name = "btnSiparisteAra";
            this.btnSiparisteAra.Size = new System.Drawing.Size(267, 37);
            this.btnSiparisteAra.TabIndex = 170;
            this.btnSiparisteAra.Text = "Siparişte Ara";
            this.btnSiparisteAra.UseVisualStyleBackColor = true;
            this.btnSiparisteAra.Click += new System.EventHandler(this.btnSiparisteAra_Click);
            // 
            // btnCevapsiz
            // 
            this.btnCevapsiz.Location = new System.Drawing.Point(8, 155);
            this.btnCevapsiz.Name = "btnCevapsiz";
            this.btnCevapsiz.Size = new System.Drawing.Size(267, 53);
            this.btnCevapsiz.TabIndex = 4;
            this.btnCevapsiz.Text = "Cevapsız Görüşmeler";
            this.btnCevapsiz.UseVisualStyleBackColor = true;
            this.btnCevapsiz.Click += new System.EventHandler(this.btnCevapsiz_Click);
            // 
            // btnGorusmeler
            // 
            this.btnGorusmeler.Location = new System.Drawing.Point(8, 96);
            this.btnGorusmeler.Name = "btnGorusmeler";
            this.btnGorusmeler.Size = new System.Drawing.Size(267, 53);
            this.btnGorusmeler.TabIndex = 3;
            this.btnGorusmeler.Text = "Görüşmeler";
            this.btnGorusmeler.UseVisualStyleBackColor = true;
            this.btnGorusmeler.Click += new System.EventHandler(this.btnCevapBekleyenGorusmeler_Click);
            // 
            // btnCariAra
            // 
            this.btnCariAra.Location = new System.Drawing.Point(283, 27);
            this.btnCariAra.Name = "btnCariAra";
            this.btnCariAra.Size = new System.Drawing.Size(20, 37);
            this.btnCariAra.TabIndex = 1;
            this.btnCariAra.Text = "Birim Bazlı Satış Listesi";
            this.btnCariAra.UseVisualStyleBackColor = true;
            this.btnCariAra.Visible = false;
            this.btnCariAra.Click += new System.EventHandler(this.btnCariAra_Click);
            // 
            // grpSonuc
            // 
            this.grpSonuc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSonuc.Controls.Add(this.dgvSonuc);
            this.grpSonuc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpSonuc.ForeColor = System.Drawing.Color.Teal;
            this.grpSonuc.Location = new System.Drawing.Point(297, 14);
            this.grpSonuc.Margin = new System.Windows.Forms.Padding(5);
            this.grpSonuc.Name = "grpSonuc";
            this.grpSonuc.Padding = new System.Windows.Forms.Padding(5);
            this.grpSonuc.Size = new System.Drawing.Size(1083, 699);
            this.grpSonuc.TabIndex = 4;
            this.grpSonuc.TabStop = false;
            this.grpSonuc.Text = "Sorgu Sonucu";
            // 
            // dgvSonuc
            // 
            this.dgvSonuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSonuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSonuc.Location = new System.Drawing.Point(5, 20);
            this.dgvSonuc.Name = "dgvSonuc";
            this.dgvSonuc.ReadOnly = true;
            this.dgvSonuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSonuc.Size = new System.Drawing.Size(1073, 674);
            this.dgvSonuc.TabIndex = 1;
            this.dgvSonuc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSonuc_CellDoubleClick);
            // 
            // grpGenelToplamlar
            // 
            this.grpGenelToplamlar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGenelToplamlar.Controls.Add(this.txtKarYuzdesi);
            this.grpGenelToplamlar.Controls.Add(this.label7);
            this.grpGenelToplamlar.Controls.Add(this.txtGenelKazanc);
            this.grpGenelToplamlar.Controls.Add(this.txtSatisTutari);
            this.grpGenelToplamlar.Controls.Add(this.txtBirimSatisFiyati);
            this.grpGenelToplamlar.Controls.Add(this.txtBirimAlisFiyati);
            this.grpGenelToplamlar.Controls.Add(this.txtSiparisSayisi);
            this.grpGenelToplamlar.Controls.Add(this.txtSepetSayisi);
            this.grpGenelToplamlar.Controls.Add(this.label6);
            this.grpGenelToplamlar.Controls.Add(this.label5);
            this.grpGenelToplamlar.Controls.Add(this.label4);
            this.grpGenelToplamlar.Controls.Add(this.label3);
            this.grpGenelToplamlar.Controls.Add(this.label2);
            this.grpGenelToplamlar.Controls.Add(this.label1);
            this.grpGenelToplamlar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpGenelToplamlar.ForeColor = System.Drawing.Color.Teal;
            this.grpGenelToplamlar.Location = new System.Drawing.Point(297, 723);
            this.grpGenelToplamlar.Margin = new System.Windows.Forms.Padding(5);
            this.grpGenelToplamlar.Name = "grpGenelToplamlar";
            this.grpGenelToplamlar.Padding = new System.Windows.Forms.Padding(5);
            this.grpGenelToplamlar.Size = new System.Drawing.Size(1078, 81);
            this.grpGenelToplamlar.TabIndex = 5;
            this.grpGenelToplamlar.TabStop = false;
            this.grpGenelToplamlar.Text = "Genel Toplamlar";
            // 
            // txtKarYuzdesi
            // 
            this.txtKarYuzdesi.Location = new System.Drawing.Point(754, 42);
            this.txtKarYuzdesi.Name = "txtKarYuzdesi";
            this.txtKarYuzdesi.Size = new System.Drawing.Size(50, 22);
            this.txtKarYuzdesi.TabIndex = 13;
            this.txtKarYuzdesi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(760, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Kar %";
            // 
            // txtGenelKazanc
            // 
            this.txtGenelKazanc.Location = new System.Drawing.Point(627, 42);
            this.txtGenelKazanc.Name = "txtGenelKazanc";
            this.txtGenelKazanc.Size = new System.Drawing.Size(109, 22);
            this.txtGenelKazanc.TabIndex = 11;
            this.txtGenelKazanc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSatisTutari
            // 
            this.txtSatisTutari.Location = new System.Drawing.Point(505, 42);
            this.txtSatisTutari.Name = "txtSatisTutari";
            this.txtSatisTutari.Size = new System.Drawing.Size(109, 22);
            this.txtSatisTutari.TabIndex = 10;
            this.txtSatisTutari.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBirimSatisFiyati
            // 
            this.txtBirimSatisFiyati.Location = new System.Drawing.Point(382, 42);
            this.txtBirimSatisFiyati.Name = "txtBirimSatisFiyati";
            this.txtBirimSatisFiyati.Size = new System.Drawing.Size(109, 22);
            this.txtBirimSatisFiyati.TabIndex = 9;
            this.txtBirimSatisFiyati.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBirimAlisFiyati
            // 
            this.txtBirimAlisFiyati.Location = new System.Drawing.Point(259, 42);
            this.txtBirimAlisFiyati.Name = "txtBirimAlisFiyati";
            this.txtBirimAlisFiyati.Size = new System.Drawing.Size(109, 22);
            this.txtBirimAlisFiyati.TabIndex = 8;
            this.txtBirimAlisFiyati.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSiparisSayisi
            // 
            this.txtSiparisSayisi.Location = new System.Drawing.Point(138, 42);
            this.txtSiparisSayisi.Name = "txtSiparisSayisi";
            this.txtSiparisSayisi.Size = new System.Drawing.Size(109, 22);
            this.txtSiparisSayisi.TabIndex = 7;
            this.txtSiparisSayisi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSepetSayisi
            // 
            this.txtSepetSayisi.Location = new System.Drawing.Point(11, 42);
            this.txtSepetSayisi.Name = "txtSepetSayisi";
            this.txtSepetSayisi.Size = new System.Drawing.Size(109, 22);
            this.txtSepetSayisi.TabIndex = 6;
            this.txtSepetSayisi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(633, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Genel Kazanç";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(517, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Satış Tutarı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Birim Alış Fiyatı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Birim Satış Fiyatı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sipariş Sayısı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sepet Sayısı";
            // 
            // RaporlarSatis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 809);
            this.Controls.Add(this.grpGenelToplamlar);
            this.Controls.Add(this.grpSonuc);
            this.Controls.Add(this.grpButonlar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RaporlarSatis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RaporlarSatis";
            this.Load += new System.EventHandler(this.RaporlarSatis_Load);
            this.grpButonlar.ResumeLayout(false);
            this.grpButonlar.PerformLayout();
            this.grpSonuc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSonuc)).EndInit();
            this.grpGenelToplamlar.ResumeLayout(false);
            this.grpGenelToplamlar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpButonlar;
        private System.Windows.Forms.Button btnCariAra;
        private System.Windows.Forms.GroupBox grpSonuc;
        private System.Windows.Forms.DataGridView dgvSonuc;
        private System.Windows.Forms.Button btnGorusmeler;
        private System.Windows.Forms.Button btnCevapsiz;
        private System.Windows.Forms.TextBox txtSiparisteAra;
        private System.Windows.Forms.Button btnSiparisteAra;
        private System.Windows.Forms.Button btnTarihArasiMusteri;
        private System.Windows.Forms.MaskedTextBox txtBitisTarihi;
        private System.Windows.Forms.MaskedTextBox txtBaslamaTarihi;
        private System.Windows.Forms.Button btnIkıTarihArasiKar;
        private System.Windows.Forms.GroupBox grpGenelToplamlar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSepetSayisi;
        private System.Windows.Forms.TextBox txtGenelKazanc;
        private System.Windows.Forms.TextBox txtSatisTutari;
        private System.Windows.Forms.TextBox txtBirimSatisFiyati;
        private System.Windows.Forms.TextBox txtBirimAlisFiyati;
        private System.Windows.Forms.TextBox txtSiparisSayisi;
        private System.Windows.Forms.TextBox txtKarYuzdesi;
        private System.Windows.Forms.Label label7;
    }
}