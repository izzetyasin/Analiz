namespace AnalizProje
{
    partial class ParametreAgaci
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParametreAgaci));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnSec = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.txtISPARENT = new System.Windows.Forms.TextBox();
            this.txtSEVIYE = new System.Windows.Forms.TextBox();
            this.txtUST_SEVIYE_ID = new System.Windows.Forms.TextBox();
            this.txtSEVIYE_ADI = new System.Windows.Forms.TextBox();
            this.txtPARAMETRE_ID = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Location = new System.Drawing.Point(4, -5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 485);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 22);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(408, 460);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // btnSec
            // 
            this.btnSec.Location = new System.Drawing.Point(7, 483);
            this.btnSec.Name = "btnSec";
            this.btnSec.Size = new System.Drawing.Size(123, 42);
            this.btnSec.TabIndex = 1;
            this.btnSec.Text = "Seç";
            this.btnSec.UseVisualStyleBackColor = true;
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Location = new System.Drawing.Point(292, 483);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(123, 42);
            this.btnIptal.TabIndex = 2;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // txtISPARENT
            // 
            this.txtISPARENT.Location = new System.Drawing.Point(141, 442);
            this.txtISPARENT.Name = "txtISPARENT";
            this.txtISPARENT.Size = new System.Drawing.Size(23, 26);
            this.txtISPARENT.TabIndex = 34;
            // 
            // txtSEVIYE
            // 
            this.txtSEVIYE.Location = new System.Drawing.Point(112, 442);
            this.txtSEVIYE.Name = "txtSEVIYE";
            this.txtSEVIYE.Size = new System.Drawing.Size(23, 26);
            this.txtSEVIYE.TabIndex = 33;
            // 
            // txtUST_SEVIYE_ID
            // 
            this.txtUST_SEVIYE_ID.Location = new System.Drawing.Point(80, 442);
            this.txtUST_SEVIYE_ID.Name = "txtUST_SEVIYE_ID";
            this.txtUST_SEVIYE_ID.Size = new System.Drawing.Size(26, 26);
            this.txtUST_SEVIYE_ID.TabIndex = 32;
            // 
            // txtSEVIYE_ADI
            // 
            this.txtSEVIYE_ADI.Location = new System.Drawing.Point(46, 442);
            this.txtSEVIYE_ADI.Name = "txtSEVIYE_ADI";
            this.txtSEVIYE_ADI.Size = new System.Drawing.Size(28, 26);
            this.txtSEVIYE_ADI.TabIndex = 31;
            // 
            // txtPARAMETRE_ID
            // 
            this.txtPARAMETRE_ID.Location = new System.Drawing.Point(15, 442);
            this.txtPARAMETRE_ID.Name = "txtPARAMETRE_ID";
            this.txtPARAMETRE_ID.Size = new System.Drawing.Size(25, 26);
            this.txtPARAMETRE_ID.TabIndex = 30;
            // 
            // ParametreAgaci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 531);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtISPARENT);
            this.Controls.Add(this.txtSEVIYE);
            this.Controls.Add(this.txtUST_SEVIYE_ID);
            this.Controls.Add(this.txtSEVIYE_ADI);
            this.Controls.Add(this.txtPARAMETRE_ID);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnSec);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.Color.Teal;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(440, 570);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(440, 570);
            this.Name = "ParametreAgaci";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametre Ağacı";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ParametreAgaci_FormClosing);
            this.Load += new System.EventHandler(this.ParametreAgaci_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnSec;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.TextBox txtISPARENT;
        private System.Windows.Forms.TextBox txtSEVIYE;
        private System.Windows.Forms.TextBox txtUST_SEVIYE_ID;
        private System.Windows.Forms.TextBox txtSEVIYE_ADI;
        private System.Windows.Forms.TextBox txtPARAMETRE_ID;
    }
}