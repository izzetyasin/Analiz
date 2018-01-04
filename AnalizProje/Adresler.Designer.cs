namespace AnalizProje
{
    partial class Adresler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Adresler));
            this.txtPostaKodu = new System.Windows.Forms.TextBox();
            this.cmbUlke = new System.Windows.Forms.ComboBox();
            this.cmbIl = new System.Windows.Forms.ComboBox();
            this.cmbIlce = new System.Windows.Forms.ComboBox();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.txtCariId = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvAdresler = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAdresId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkIletisimAdresiMi = new System.Windows.Forms.CheckBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnYeni = new System.Windows.Forms.Button();
            this.chkAktif = new System.Windows.Forms.CheckBox();
            this.txtKonumLAT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKonumLNG = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBlkodu = new System.Windows.Forms.TextBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdresler)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPostaKodu
            // 
            this.txtPostaKodu.Location = new System.Drawing.Point(112, 148);
            this.txtPostaKodu.MaxLength = 5;
            this.txtPostaKodu.Name = "txtPostaKodu";
            this.txtPostaKodu.Size = new System.Drawing.Size(209, 26);
            this.txtPostaKodu.TabIndex = 105;
            // 
            // cmbUlke
            // 
            this.cmbUlke.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUlke.FormattingEnabled = true;
            this.cmbUlke.Location = new System.Drawing.Point(437, 148);
            this.cmbUlke.Name = "cmbUlke";
            this.cmbUlke.Size = new System.Drawing.Size(209, 28);
            this.cmbUlke.TabIndex = 101;
            // 
            // cmbIl
            // 
            this.cmbIl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIl.FormattingEnabled = true;
            this.cmbIl.Location = new System.Drawing.Point(112, 114);
            this.cmbIl.Name = "cmbIl";
            this.cmbIl.Size = new System.Drawing.Size(209, 28);
            this.cmbIl.TabIndex = 100;
            this.cmbIl.SelectedIndexChanged += new System.EventHandler(this.cmbIl_SelectedIndexChanged);
            // 
            // cmbIlce
            // 
            this.cmbIlce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIlce.FormattingEnabled = true;
            this.cmbIlce.Location = new System.Drawing.Point(437, 114);
            this.cmbIlce.Name = "cmbIlce";
            this.cmbIlce.Size = new System.Drawing.Size(209, 28);
            this.cmbIlce.TabIndex = 99;
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(112, 13);
            this.txtAdres.Multiline = true;
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtAdres.Size = new System.Drawing.Size(534, 95);
            this.txtAdres.TabIndex = 96;
            // 
            // txtCariId
            // 
            this.txtCariId.Location = new System.Drawing.Point(42, 45);
            this.txtCariId.Name = "txtCariId";
            this.txtCariId.Size = new System.Drawing.Size(24, 26);
            this.txtCariId.TabIndex = 95;
            this.txtCariId.Text = "0";
            this.txtCariId.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvAdresler);
            this.groupBox1.Location = new System.Drawing.Point(2, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(740, 310);
            this.groupBox1.TabIndex = 94;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adresleri";
            // 
            // dgvAdresler
            // 
            this.dgvAdresler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdresler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAdresler.Location = new System.Drawing.Point(3, 22);
            this.dgvAdresler.Name = "dgvAdresler";
            this.dgvAdresler.ReadOnly = true;
            this.dgvAdresler.Size = new System.Drawing.Size(734, 285);
            this.dgvAdresler.TabIndex = 0;
            this.dgvAdresler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdresler_CellClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 91;
            this.label10.Text = "Posta Kodu :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(382, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 20);
            this.label9.TabIndex = 90;
            this.label9.Text = "Ülke :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 20);
            this.label4.TabIndex = 86;
            this.label4.Text = "İl :";
            // 
            // txtAdresId
            // 
            this.txtAdresId.Location = new System.Drawing.Point(12, 45);
            this.txtAdresId.Name = "txtAdresId";
            this.txtAdresId.Size = new System.Drawing.Size(24, 26);
            this.txtAdresId.TabIndex = 85;
            this.txtAdresId.Text = "0";
            this.txtAdresId.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 84;
            this.label3.Text = "İlçe :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 83;
            this.label2.Text = "Açık Adres :";
            // 
            // chkIletisimAdresiMi
            // 
            this.chkIletisimAdresiMi.AutoSize = true;
            this.chkIletisimAdresiMi.Location = new System.Drawing.Point(112, 184);
            this.chkIletisimAdresiMi.Name = "chkIletisimAdresiMi";
            this.chkIletisimAdresiMi.Size = new System.Drawing.Size(126, 24);
            this.chkIletisimAdresiMi.TabIndex = 107;
            this.chkIletisimAdresiMi.Text = "İletişim Adresi";
            this.chkIletisimAdresiMi.UseVisualStyleBackColor = true;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(658, 77);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(84, 58);
            this.btnKaydet.TabIndex = 109;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnYeni
            // 
            this.btnYeni.Location = new System.Drawing.Point(658, 13);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(84, 58);
            this.btnYeni.TabIndex = 108;
            this.btnYeni.Text = "Yeni";
            this.btnYeni.UseVisualStyleBackColor = true;
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            // chkAktif
            // 
            this.chkAktif.AutoSize = true;
            this.chkAktif.Location = new System.Drawing.Point(112, 214);
            this.chkAktif.Name = "chkAktif";
            this.chkAktif.Size = new System.Drawing.Size(60, 24);
            this.chkAktif.TabIndex = 110;
            this.chkAktif.Text = "Aktif";
            this.chkAktif.UseVisualStyleBackColor = true;
            // 
            // txtKonumLAT
            // 
            this.txtKonumLAT.Location = new System.Drawing.Point(437, 182);
            this.txtKonumLAT.Name = "txtKonumLAT";
            this.txtKonumLAT.Size = new System.Drawing.Size(209, 26);
            this.txtKonumLAT.TabIndex = 112;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 111;
            this.label1.Text = "Konum LAT :";
            // 
            // txtKonumLNG
            // 
            this.txtKonumLNG.Location = new System.Drawing.Point(437, 214);
            this.txtKonumLNG.Name = "txtKonumLNG";
            this.txtKonumLNG.Size = new System.Drawing.Size(209, 26);
            this.txtKonumLNG.TabIndex = 114;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 113;
            this.label5.Text = "Konum LNG :";
            // 
            // txtBlkodu
            // 
            this.txtBlkodu.Location = new System.Drawing.Point(12, 77);
            this.txtBlkodu.Name = "txtBlkodu";
            this.txtBlkodu.Size = new System.Drawing.Size(54, 26);
            this.txtBlkodu.TabIndex = 115;
            this.txtBlkodu.Text = "0";
            this.txtBlkodu.Visible = false;
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(658, 141);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(84, 58);
            this.btnSil.TabIndex = 116;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // Adresler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 558);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.txtBlkodu);
            this.Controls.Add(this.txtKonumLNG);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtKonumLAT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkAktif);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnYeni);
            this.Controls.Add(this.chkIletisimAdresiMi);
            this.Controls.Add(this.txtPostaKodu);
            this.Controls.Add(this.cmbUlke);
            this.Controls.Add(this.cmbIl);
            this.Controls.Add(this.cmbIlce);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.txtCariId);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAdresId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.Color.Teal;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(762, 597);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(762, 597);
            this.Name = "Adresler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adresler";
            this.Load += new System.EventHandler(this.Adresler_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdresler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPostaKodu;
        private System.Windows.Forms.ComboBox cmbUlke;
        private System.Windows.Forms.ComboBox cmbIl;
        private System.Windows.Forms.ComboBox cmbIlce;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.TextBox txtCariId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvAdresler;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAdresId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkIletisimAdresiMi;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnYeni;
        private System.Windows.Forms.CheckBox chkAktif;
        private System.Windows.Forms.TextBox txtKonumLAT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKonumLNG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBlkodu;
        private System.Windows.Forms.Button btnSil;
    }
}