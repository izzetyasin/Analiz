namespace AnalizProje
{
    partial class Yetkilendirme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Yetkilendirme));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvKullanicilar = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvUygulamalar = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvYetkiler = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtYetkiId = new System.Windows.Forms.TextBox();
            this.txtKullaniciID = new System.Windows.Forms.TextBox();
            this.lblYetki = new System.Windows.Forms.Label();
            this.lblUygulama = new System.Windows.Forms.Label();
            this.btnYetkiSil = new System.Windows.Forms.Button();
            this.btnYetkiver = new System.Windows.Forms.Button();
            this.lblYetkiBaslik = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvUygulamaVeYetkiler = new System.Windows.Forms.DataGridView();
            this.lblKullanici = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUygulamalar)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYetkiler)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUygulamaVeYetkiler)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvKullanicilar);
            this.groupBox1.Location = new System.Drawing.Point(7, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 236);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kullanıcılar";
            // 
            // dgvKullanicilar
            // 
            this.dgvKullanicilar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKullanicilar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKullanicilar.Location = new System.Drawing.Point(3, 22);
            this.dgvKullanicilar.Name = "dgvKullanicilar";
            this.dgvKullanicilar.ReadOnly = true;
            this.dgvKullanicilar.Size = new System.Drawing.Size(514, 211);
            this.dgvKullanicilar.TabIndex = 19;
            this.dgvKullanicilar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKullanicilar_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dgvUygulamalar);
            this.groupBox2.Location = new System.Drawing.Point(10, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 291);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Uygulamalar";
            // 
            // dgvUygulamalar
            // 
            this.dgvUygulamalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUygulamalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUygulamalar.Location = new System.Drawing.Point(3, 22);
            this.dgvUygulamalar.Name = "dgvUygulamalar";
            this.dgvUygulamalar.ReadOnly = true;
            this.dgvUygulamalar.Size = new System.Drawing.Size(281, 266);
            this.dgvUygulamalar.TabIndex = 19;
            this.dgvUygulamalar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUygulamalar_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.dgvYetkiler);
            this.groupBox3.Location = new System.Drawing.Point(303, 242);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(224, 292);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Uygulama Yetkileri";
            // 
            // dgvYetkiler
            // 
            this.dgvYetkiler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYetkiler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvYetkiler.Location = new System.Drawing.Point(3, 22);
            this.dgvYetkiler.Name = "dgvYetkiler";
            this.dgvYetkiler.ReadOnly = true;
            this.dgvYetkiler.Size = new System.Drawing.Size(218, 267);
            this.dgvYetkiler.TabIndex = 19;
            this.dgvYetkiler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvYetkiler_CellClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.txtYetkiId);
            this.groupBox4.Controls.Add(this.txtKullaniciID);
            this.groupBox4.Controls.Add(this.lblYetki);
            this.groupBox4.Controls.Add(this.lblUygulama);
            this.groupBox4.Controls.Add(this.btnYetkiSil);
            this.groupBox4.Controls.Add(this.btnYetkiver);
            this.groupBox4.Controls.Add(this.lblYetkiBaslik);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.lblKullanici);
            this.groupBox4.Location = new System.Drawing.Point(533, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(332, 532);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Kullanıcı Yetkileri";
            // 
            // txtYetkiId
            // 
            this.txtYetkiId.Location = new System.Drawing.Point(226, 54);
            this.txtYetkiId.Name = "txtYetkiId";
            this.txtYetkiId.Size = new System.Drawing.Size(100, 26);
            this.txtYetkiId.TabIndex = 31;
            this.txtYetkiId.Visible = false;
            // 
            // txtKullaniciID
            // 
            this.txtKullaniciID.Location = new System.Drawing.Point(226, 22);
            this.txtKullaniciID.Name = "txtKullaniciID";
            this.txtKullaniciID.Size = new System.Drawing.Size(100, 26);
            this.txtKullaniciID.TabIndex = 30;
            this.txtKullaniciID.Visible = false;
            // 
            // lblYetki
            // 
            this.lblYetki.AutoSize = true;
            this.lblYetki.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYetki.Location = new System.Drawing.Point(110, 114);
            this.lblYetki.Name = "lblYetki";
            this.lblYetki.Size = new System.Drawing.Size(24, 20);
            this.lblYetki.TabIndex = 29;
            this.lblYetki.Text = "...";
            // 
            // lblUygulama
            // 
            this.lblUygulama.AutoSize = true;
            this.lblUygulama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUygulama.Location = new System.Drawing.Point(110, 75);
            this.lblUygulama.Name = "lblUygulama";
            this.lblUygulama.Size = new System.Drawing.Size(24, 20);
            this.lblUygulama.TabIndex = 28;
            this.lblUygulama.Text = "...";
            // 
            // btnYetkiSil
            // 
            this.btnYetkiSil.Location = new System.Drawing.Point(212, 186);
            this.btnYetkiSil.Name = "btnYetkiSil";
            this.btnYetkiSil.Size = new System.Drawing.Size(111, 37);
            this.btnYetkiSil.TabIndex = 27;
            this.btnYetkiSil.Text = "Yetki Sil";
            this.btnYetkiSil.UseVisualStyleBackColor = true;
            this.btnYetkiSil.Click += new System.EventHandler(this.btnYetkiSil_Click);
            // 
            // btnYetkiver
            // 
            this.btnYetkiver.Location = new System.Drawing.Point(10, 186);
            this.btnYetkiver.Name = "btnYetkiver";
            this.btnYetkiver.Size = new System.Drawing.Size(111, 37);
            this.btnYetkiver.TabIndex = 26;
            this.btnYetkiver.Text = "Yetki Ver";
            this.btnYetkiver.UseVisualStyleBackColor = true;
            this.btnYetkiver.Click += new System.EventHandler(this.btnYetkiver_Click);
            // 
            // lblYetkiBaslik
            // 
            this.lblYetkiBaslik.AutoSize = true;
            this.lblYetkiBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYetkiBaslik.Location = new System.Drawing.Point(44, 114);
            this.lblYetkiBaslik.Name = "lblYetkiBaslik";
            this.lblYetkiBaslik.Size = new System.Drawing.Size(60, 20);
            this.lblYetkiBaslik.TabIndex = 25;
            this.lblYetkiBaslik.Text = "Yetki :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(6, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Uygulama :";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.dgvUygulamaVeYetkiler);
            this.groupBox5.Location = new System.Drawing.Point(6, 241);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(320, 291);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Kullanıcı Uygulama ve Yetkileri";
            // 
            // dgvUygulamaVeYetkiler
            // 
            this.dgvUygulamaVeYetkiler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUygulamaVeYetkiler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUygulamaVeYetkiler.Location = new System.Drawing.Point(3, 22);
            this.dgvUygulamaVeYetkiler.Name = "dgvUygulamaVeYetkiler";
            this.dgvUygulamaVeYetkiler.ReadOnly = true;
            this.dgvUygulamaVeYetkiler.Size = new System.Drawing.Size(314, 266);
            this.dgvUygulamaVeYetkiler.TabIndex = 19;
            // 
            // lblKullanici
            // 
            this.lblKullanici.AutoSize = true;
            this.lblKullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullanici.ForeColor = System.Drawing.Color.Red;
            this.lblKullanici.Location = new System.Drawing.Point(6, 33);
            this.lblKullanici.Name = "lblKullanici";
            this.lblKullanici.Size = new System.Drawing.Size(80, 20);
            this.lblKullanici.TabIndex = 0;
            this.lblKullanici.Text = "Kullanıcı:";
            // 
            // Yetkilendirme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 543);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.Color.Teal;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Yetkilendirme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yetkilendirme";
            this.Load += new System.EventHandler(this.Yetkilendirme_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUygulamalar)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYetkiler)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUygulamaVeYetkiler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvKullanicilar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvUygulamalar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvYetkiler;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblKullanici;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvUygulamaVeYetkiler;
        private System.Windows.Forms.Label lblYetki;
        private System.Windows.Forms.Label lblUygulama;
        private System.Windows.Forms.Button btnYetkiSil;
        private System.Windows.Forms.Button btnYetkiver;
        private System.Windows.Forms.Label lblYetkiBaslik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYetkiId;
        private System.Windows.Forms.TextBox txtKullaniciID;
    }
}