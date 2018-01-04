namespace AnalizProje
{
    partial class FrmAnalizProje
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnalizProje));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCariListesi = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvCariDetay = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvAldigiUrunler = new System.Windows.Forms.DataGridView();
            this.txtCariAra = new System.Windows.Forms.TextBox();
            this.btnCariAra = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnBul = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCariGrubu = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnGorusmeler = new System.Windows.Forms.Button();
            this.txtSayi = new System.Windows.Forms.TextBox();
            this.btnCariGuncelle = new System.Windows.Forms.Button();
            this.btnCariDetyalar = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.dgvGorusmeler = new System.Windows.Forms.DataGridView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtHastaliklari = new System.Windows.Forms.TextBox();
            this.cmbCinsiyet = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.lblCariGrubu = new System.Windows.Forms.Label();
            this.txtCariGrubu = new System.Windows.Forms.TextBox();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.txtEkTelefon1 = new System.Windows.Forms.TextBox();
            this.txtFaks = new System.Windows.Forms.TextBox();
            this.txtCepTel = new System.Windows.Forms.TextBox();
            this.txtTcKimlikNo = new System.Windows.Forms.TextBox();
            this.txtVergiNo = new System.Windows.Forms.TextBox();
            this.txtVergiDairesi = new System.Windows.Forms.TextBox();
            this.cmbSektor = new System.Windows.Forms.ComboBox();
            this.txtTicariUnvani = new System.Windows.Forms.TextBox();
            this.txtCariSoyadi = new System.Windows.Forms.TextBox();
            this.txtCariAdi = new System.Windows.Forms.TextBox();
            this.txtCariKodu = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCariId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkYeniCariAc = new System.Windows.Forms.CheckBox();
            this.btnYeniCariAc = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCariListesi)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCariDetay)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAldigiUrunler)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGorusmeler)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvCariListesi);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(928, 62);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(450, 320);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dgvCariListesi
            // 
            this.dgvCariListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCariListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCariListesi.Location = new System.Drawing.Point(5, 24);
            this.dgvCariListesi.Name = "dgvCariListesi";
            this.dgvCariListesi.ReadOnly = true;
            this.dgvCariListesi.Size = new System.Drawing.Size(440, 291);
            this.dgvCariListesi.TabIndex = 0;
            this.dgvCariListesi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCariListesi_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnYeniCariAc);
            this.groupBox3.Controls.Add(this.chkYeniCariAc);
            this.groupBox3.Controls.Add(this.dgvCariDetay);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.ForeColor = System.Drawing.Color.Teal;
            this.groupBox3.Location = new System.Drawing.Point(5, 8);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox3.Size = new System.Drawing.Size(920, 201);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cari Özet (Wolvox)";
            // 
            // dgvCariDetay
            // 
            this.dgvCariDetay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCariDetay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCariDetay.Location = new System.Drawing.Point(5, 24);
            this.dgvCariDetay.Name = "dgvCariDetay";
            this.dgvCariDetay.ReadOnly = true;
            this.dgvCariDetay.Size = new System.Drawing.Size(910, 169);
            this.dgvCariDetay.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dgvAldigiUrunler);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox4.ForeColor = System.Drawing.Color.Teal;
            this.groupBox4.Location = new System.Drawing.Point(5, 219);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox4.Size = new System.Drawing.Size(920, 230);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Aldığı Ürünler (Wolvox)";
            // 
            // dgvAldigiUrunler
            // 
            this.dgvAldigiUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAldigiUrunler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAldigiUrunler.Location = new System.Drawing.Point(5, 24);
            this.dgvAldigiUrunler.Name = "dgvAldigiUrunler";
            this.dgvAldigiUrunler.ReadOnly = true;
            this.dgvAldigiUrunler.Size = new System.Drawing.Size(910, 201);
            this.dgvAldigiUrunler.TabIndex = 1;
            // 
            // txtCariAra
            // 
            this.txtCariAra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCariAra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCariAra.Location = new System.Drawing.Point(10, 25);
            this.txtCariAra.Margin = new System.Windows.Forms.Padding(5);
            this.txtCariAra.Name = "txtCariAra";
            this.txtCariAra.Size = new System.Drawing.Size(367, 26);
            this.txtCariAra.TabIndex = 0;
            this.txtCariAra.TextChanged += new System.EventHandler(this.txtCariAra_TextChanged);
            // 
            // btnCariAra
            // 
            this.btnCariAra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCariAra.Location = new System.Drawing.Point(385, 25);
            this.btnCariAra.Name = "btnCariAra";
            this.btnCariAra.Size = new System.Drawing.Size(60, 27);
            this.btnCariAra.TabIndex = 1;
            this.btnCariAra.Text = "Ara...";
            this.btnCariAra.UseVisualStyleBackColor = true;
            this.btnCariAra.Click += new System.EventHandler(this.btnCariAra_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnCariAra);
            this.groupBox1.Controls.Add(this.txtCariAra);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(928, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(450, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cari Ara (Wolvox)";
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.btnBul);
            this.groupBox8.Controls.Add(this.label1);
            this.groupBox8.Controls.Add(this.cmbCariGrubu);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox8.ForeColor = System.Drawing.Color.Teal;
            this.groupBox8.Location = new System.Drawing.Point(928, 385);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox8.Size = new System.Drawing.Size(450, 64);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Cari Filitre (Wolvox)";
            // 
            // btnBul
            // 
            this.btnBul.Location = new System.Drawing.Point(396, 22);
            this.btnBul.Name = "btnBul";
            this.btnBul.Size = new System.Drawing.Size(49, 28);
            this.btnBul.TabIndex = 3;
            this.btnBul.Text = "Bul";
            this.btnBul.UseVisualStyleBackColor = true;
            this.btnBul.Click += new System.EventHandler(this.btnBul_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cari Grubu :";
            // 
            // cmbCariGrubu
            // 
            this.cmbCariGrubu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCariGrubu.FormattingEnabled = true;
            this.cmbCariGrubu.Location = new System.Drawing.Point(120, 22);
            this.cmbCariGrubu.Name = "cmbCariGrubu";
            this.cmbCariGrubu.Size = new System.Drawing.Size(270, 28);
            this.cmbCariGrubu.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.btnGorusmeler);
            this.groupBox5.Controls.Add(this.txtSayi);
            this.groupBox5.Controls.Add(this.btnCariGuncelle);
            this.groupBox5.Controls.Add(this.btnCariDetyalar);
            this.groupBox5.Controls.Add(this.groupBox9);
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.cmbCinsiyet);
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Controls.Add(this.lblCariGrubu);
            this.groupBox5.Controls.Add(this.txtCariGrubu);
            this.groupBox5.Controls.Add(this.txtEMail);
            this.groupBox5.Controls.Add(this.txtEkTelefon1);
            this.groupBox5.Controls.Add(this.txtFaks);
            this.groupBox5.Controls.Add(this.txtCepTel);
            this.groupBox5.Controls.Add(this.txtTcKimlikNo);
            this.groupBox5.Controls.Add(this.txtVergiNo);
            this.groupBox5.Controls.Add(this.txtVergiDairesi);
            this.groupBox5.Controls.Add(this.cmbSektor);
            this.groupBox5.Controls.Add(this.txtTicariUnvani);
            this.groupBox5.Controls.Add(this.txtCariSoyadi);
            this.groupBox5.Controls.Add(this.txtCariAdi);
            this.groupBox5.Controls.Add(this.txtCariKodu);
            this.groupBox5.Controls.Add(this.label37);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtCariId);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox5.ForeColor = System.Drawing.Color.Teal;
            this.groupBox5.Location = new System.Drawing.Point(5, 452);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox5.Size = new System.Drawing.Size(1373, 305);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Cari Kart Özet";
            // 
            // btnGorusmeler
            // 
            this.btnGorusmeler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGorusmeler.Location = new System.Drawing.Point(1243, 14);
            this.btnGorusmeler.Name = "btnGorusmeler";
            this.btnGorusmeler.Size = new System.Drawing.Size(119, 40);
            this.btnGorusmeler.TabIndex = 126;
            this.btnGorusmeler.Text = "Görüşmeler";
            this.btnGorusmeler.UseVisualStyleBackColor = true;
            this.btnGorusmeler.Click += new System.EventHandler(this.btnGorusmeler_Click);
            // 
            // txtSayi
            // 
            this.txtSayi.Location = new System.Drawing.Point(763, 24);
            this.txtSayi.Name = "txtSayi";
            this.txtSayi.Size = new System.Drawing.Size(87, 26);
            this.txtSayi.TabIndex = 125;
            this.txtSayi.Text = "0";
            this.txtSayi.Visible = false;
            // 
            // btnCariGuncelle
            // 
            this.btnCariGuncelle.Location = new System.Drawing.Point(656, 23);
            this.btnCariGuncelle.Name = "btnCariGuncelle";
            this.btnCariGuncelle.Size = new System.Drawing.Size(94, 28);
            this.btnCariGuncelle.TabIndex = 124;
            this.btnCariGuncelle.Text = "Güncelle";
            this.btnCariGuncelle.UseVisualStyleBackColor = true;
            this.btnCariGuncelle.Visible = false;
            this.btnCariGuncelle.Click += new System.EventHandler(this.btnCariGuncelle_Click);
            // 
            // btnCariDetyalar
            // 
            this.btnCariDetyalar.Location = new System.Drawing.Point(261, 14);
            this.btnCariDetyalar.Name = "btnCariDetyalar";
            this.btnCariDetyalar.Size = new System.Drawing.Size(123, 40);
            this.btnCariDetyalar.TabIndex = 4;
            this.btnCariDetyalar.Text = "Cari Kart";
            this.btnCariDetyalar.UseVisualStyleBackColor = true;
            this.btnCariDetyalar.Click += new System.EventHandler(this.btnCariDetyalar_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.dgvGorusmeler);
            this.groupBox9.Location = new System.Drawing.Point(983, 53);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(385, 245);
            this.groupBox9.TabIndex = 123;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Görüşmeler";
            // 
            // dgvGorusmeler
            // 
            this.dgvGorusmeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGorusmeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGorusmeler.Location = new System.Drawing.Point(3, 22);
            this.dgvGorusmeler.Name = "dgvGorusmeler";
            this.dgvGorusmeler.ReadOnly = true;
            this.dgvGorusmeler.Size = new System.Drawing.Size(379, 220);
            this.dgvGorusmeler.TabIndex = 2;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox7.Controls.Add(this.txtAciklama);
            this.groupBox7.Location = new System.Drawing.Point(523, 187);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(454, 111);
            this.groupBox7.TabIndex = 123;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Açıklama";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAciklama.Location = new System.Drawing.Point(7, 25);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.ReadOnly = true;
            this.txtAciklama.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAciklama.Size = new System.Drawing.Size(441, 80);
            this.txtAciklama.TabIndex = 63;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox6.Controls.Add(this.txtHastaliklari);
            this.groupBox6.Location = new System.Drawing.Point(8, 187);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(509, 110);
            this.groupBox6.TabIndex = 122;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Hastalıkları";
            // 
            // txtHastaliklari
            // 
            this.txtHastaliklari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHastaliklari.Location = new System.Drawing.Point(6, 25);
            this.txtHastaliklari.Multiline = true;
            this.txtHastaliklari.Name = "txtHastaliklari";
            this.txtHastaliklari.ReadOnly = true;
            this.txtHastaliklari.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHastaliklari.Size = new System.Drawing.Size(497, 79);
            this.txtHastaliklari.TabIndex = 59;
            // 
            // cmbCinsiyet
            // 
            this.cmbCinsiyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCinsiyet.FormattingEnabled = true;
            this.cmbCinsiyet.Location = new System.Drawing.Point(835, 152);
            this.cmbCinsiyet.Name = "cmbCinsiyet";
            this.cmbCinsiyet.Size = new System.Drawing.Size(142, 28);
            this.cmbCinsiyet.TabIndex = 121;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(747, 157);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(86, 20);
            this.label28.TabIndex = 120;
            this.label28.Text = "Cinsiyeti :";
            // 
            // lblCariGrubu
            // 
            this.lblCariGrubu.AutoSize = true;
            this.lblCariGrubu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCariGrubu.ForeColor = System.Drawing.Color.Red;
            this.lblCariGrubu.Location = new System.Drawing.Point(518, 31);
            this.lblCariGrubu.Name = "lblCariGrubu";
            this.lblCariGrubu.Size = new System.Drawing.Size(24, 20);
            this.lblCariGrubu.TabIndex = 119;
            this.lblCariGrubu.Text = "...";
            // 
            // txtCariGrubu
            // 
            this.txtCariGrubu.Location = new System.Drawing.Point(414, 25);
            this.txtCariGrubu.Name = "txtCariGrubu";
            this.txtCariGrubu.Size = new System.Drawing.Size(35, 26);
            this.txtCariGrubu.TabIndex = 118;
            this.txtCariGrubu.Text = "0";
            this.txtCariGrubu.Visible = false;
            // 
            // txtEMail
            // 
            this.txtEMail.Location = new System.Drawing.Point(523, 154);
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.ReadOnly = true;
            this.txtEMail.Size = new System.Drawing.Size(182, 26);
            this.txtEMail.TabIndex = 117;
            // 
            // txtEkTelefon1
            // 
            this.txtEkTelefon1.Location = new System.Drawing.Point(835, 123);
            this.txtEkTelefon1.Name = "txtEkTelefon1";
            this.txtEkTelefon1.ReadOnly = true;
            this.txtEkTelefon1.Size = new System.Drawing.Size(142, 26);
            this.txtEkTelefon1.TabIndex = 116;
            // 
            // txtFaks
            // 
            this.txtFaks.Location = new System.Drawing.Point(835, 94);
            this.txtFaks.Name = "txtFaks";
            this.txtFaks.ReadOnly = true;
            this.txtFaks.Size = new System.Drawing.Size(142, 26);
            this.txtFaks.TabIndex = 115;
            // 
            // txtCepTel
            // 
            this.txtCepTel.Location = new System.Drawing.Point(835, 59);
            this.txtCepTel.Name = "txtCepTel";
            this.txtCepTel.ReadOnly = true;
            this.txtCepTel.Size = new System.Drawing.Size(142, 26);
            this.txtCepTel.TabIndex = 114;
            // 
            // txtTcKimlikNo
            // 
            this.txtTcKimlikNo.Location = new System.Drawing.Point(523, 123);
            this.txtTcKimlikNo.Name = "txtTcKimlikNo";
            this.txtTcKimlikNo.ReadOnly = true;
            this.txtTcKimlikNo.Size = new System.Drawing.Size(182, 26);
            this.txtTcKimlikNo.TabIndex = 113;
            // 
            // txtVergiNo
            // 
            this.txtVergiNo.Location = new System.Drawing.Point(523, 91);
            this.txtVergiNo.Name = "txtVergiNo";
            this.txtVergiNo.ReadOnly = true;
            this.txtVergiNo.Size = new System.Drawing.Size(182, 26);
            this.txtVergiNo.TabIndex = 112;
            // 
            // txtVergiDairesi
            // 
            this.txtVergiDairesi.Location = new System.Drawing.Point(523, 59);
            this.txtVergiDairesi.Name = "txtVergiDairesi";
            this.txtVergiDairesi.ReadOnly = true;
            this.txtVergiDairesi.Size = new System.Drawing.Size(182, 26);
            this.txtVergiDairesi.TabIndex = 111;
            // 
            // cmbSektor
            // 
            this.cmbSektor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSektor.FormattingEnabled = true;
            this.cmbSektor.Location = new System.Drawing.Point(123, 154);
            this.cmbSektor.Name = "cmbSektor";
            this.cmbSektor.Size = new System.Drawing.Size(261, 28);
            this.cmbSektor.TabIndex = 110;
            // 
            // txtTicariUnvani
            // 
            this.txtTicariUnvani.Location = new System.Drawing.Point(123, 123);
            this.txtTicariUnvani.Name = "txtTicariUnvani";
            this.txtTicariUnvani.ReadOnly = true;
            this.txtTicariUnvani.Size = new System.Drawing.Size(261, 26);
            this.txtTicariUnvani.TabIndex = 109;
            // 
            // txtCariSoyadi
            // 
            this.txtCariSoyadi.Location = new System.Drawing.Point(123, 91);
            this.txtCariSoyadi.Name = "txtCariSoyadi";
            this.txtCariSoyadi.ReadOnly = true;
            this.txtCariSoyadi.Size = new System.Drawing.Size(261, 26);
            this.txtCariSoyadi.TabIndex = 108;
            // 
            // txtCariAdi
            // 
            this.txtCariAdi.Location = new System.Drawing.Point(123, 59);
            this.txtCariAdi.Name = "txtCariAdi";
            this.txtCariAdi.ReadOnly = true;
            this.txtCariAdi.Size = new System.Drawing.Size(261, 26);
            this.txtCariAdi.TabIndex = 107;
            // 
            // txtCariKodu
            // 
            this.txtCariKodu.Location = new System.Drawing.Point(123, 27);
            this.txtCariKodu.Name = "txtCariKodu";
            this.txtCariKodu.ReadOnly = true;
            this.txtCariKodu.Size = new System.Drawing.Size(132, 26);
            this.txtCariKodu.TabIndex = 106;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(45, 157);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(72, 20);
            this.label37.TabIndex = 105;
            this.label37.Text = "Sektör :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(439, 157);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 20);
            this.label18.TabIndex = 104;
            this.label18.Text = "e-Mail 1 :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(713, 126);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 20);
            this.label16.TabIndex = 103;
            this.label16.Text = "Ek Telefon 1 :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(775, 96);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 20);
            this.label15.TabIndex = 102;
            this.label15.Text = "Faks :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(707, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 20);
            this.label13.TabIndex = 101;
            this.label13.Text = "Cep Telefonu :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(392, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 20);
            this.label11.TabIndex = 100;
            this.label11.Text = "T.C. Kimlik No :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(433, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 20);
            this.label10.TabIndex = 99;
            this.label10.Text = "Vergi No :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(401, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 20);
            this.label9.TabIndex = 98;
            this.label9.Text = "Vergi Dairesi :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(454, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 97;
            this.label5.Text = "Grubu :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 96;
            this.label4.Text = "Ticari Ünvanı :";
            // 
            // txtCariId
            // 
            this.txtCariId.Location = new System.Drawing.Point(8, 50);
            this.txtCariId.Name = "txtCariId";
            this.txtCariId.Size = new System.Drawing.Size(65, 26);
            this.txtCariId.TabIndex = 95;
            this.txtCariId.Text = "0";
            this.txtCariId.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 94;
            this.label3.Text = "Soyadı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 92;
            this.label2.Text = "Adı :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 20);
            this.label6.TabIndex = 91;
            this.label6.Text = "Cari Kodu :";
            // 
            // chkYeniCariAc
            // 
            this.chkYeniCariAc.AutoSize = true;
            this.chkYeniCariAc.Location = new System.Drawing.Point(179, 0);
            this.chkYeniCariAc.Name = "chkYeniCariAc";
            this.chkYeniCariAc.Size = new System.Drawing.Size(304, 24);
            this.chkYeniCariAc.TabIndex = 2;
            this.chkYeniCariAc.Text = "Seçili Fatura İçin Yeni Cari Oluştur";
            this.chkYeniCariAc.UseVisualStyleBackColor = true;
            this.chkYeniCariAc.CheckedChanged += new System.EventHandler(this.chkYeniCariAc_CheckedChanged);
            // 
            // btnYeniCariAc
            // 
            this.btnYeniCariAc.Enabled = false;
            this.btnYeniCariAc.Location = new System.Drawing.Point(480, -1);
            this.btnYeniCariAc.Name = "btnYeniCariAc";
            this.btnYeniCariAc.Size = new System.Drawing.Size(27, 24);
            this.btnYeniCariAc.TabIndex = 127;
            this.btnYeniCariAc.Text = "!";
            this.btnYeniCariAc.UseVisualStyleBackColor = true;
            // 
            // FrmAnalizProje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 761);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmAnalizProje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analiz 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAnalizProje_FormClosing);
            this.Load += new System.EventHandler(this.FrmAnalizProje_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCariListesi)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCariDetay)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAldigiUrunler)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGorusmeler)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvCariListesi;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvCariDetay;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvAldigiUrunler;
        private System.Windows.Forms.TextBox txtCariAra;
        private System.Windows.Forms.Button btnCariAra;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCariGrubu;
        private System.Windows.Forms.Button btnBul;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblCariGrubu;
        private System.Windows.Forms.TextBox txtCariGrubu;
        private System.Windows.Forms.TextBox txtEMail;
        private System.Windows.Forms.TextBox txtEkTelefon1;
        private System.Windows.Forms.TextBox txtFaks;
        private System.Windows.Forms.TextBox txtCepTel;
        private System.Windows.Forms.TextBox txtTcKimlikNo;
        private System.Windows.Forms.TextBox txtVergiNo;
        private System.Windows.Forms.TextBox txtVergiDairesi;
        private System.Windows.Forms.ComboBox cmbSektor;
        private System.Windows.Forms.TextBox txtTicariUnvani;
        private System.Windows.Forms.TextBox txtCariSoyadi;
        private System.Windows.Forms.TextBox txtCariAdi;
        private System.Windows.Forms.TextBox txtCariKodu;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCariId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCinsiyet;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtHastaliklari;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.DataGridView dgvGorusmeler;
        private System.Windows.Forms.Button btnCariDetyalar;
        private System.Windows.Forms.Button btnCariGuncelle;
        private System.Windows.Forms.TextBox txtSayi;
        private System.Windows.Forms.Button btnGorusmeler;
        private System.Windows.Forms.CheckBox chkYeniCariAc;
        private System.Windows.Forms.Button btnYeniCariAc;
    }
}

