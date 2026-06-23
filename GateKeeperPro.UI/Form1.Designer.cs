namespace GateKeeperPro.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPersonel = new TabPage();
            dgvPersonel = new DataGridView();
            btnKaydet = new Button();
            label12 = new Label();
            chkIsg = new CheckBox();
            label4 = new Label();
            chkSgk = new CheckBox();
            label3 = new Label();
            cmbTaseron = new ComboBox();
            txtTcNo = new TextBox();
            label2 = new Label();
            txtAdSoyad = new TextBox();
            label1 = new Label();
            tabTurnike = new TabPage();
            lstLoglar = new ListBox();
            pnlSonuc = new Panel();
            lblSonuc = new Label();
            btnKartOkut = new Button();
            txtIpAdresi = new TextBox();
            label6 = new Label();
            cmbPersonelTurnike = new ComboBox();
            label5 = new Label();
            tabRaporlama = new TabPage();
            dgvRapor = new DataGridView();
            btnFirmaRapor = new Button();
            btnReddedilenler = new Button();
            btnBugunGirisler = new Button();
            tabControl1.SuspendLayout();
            tabPersonel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPersonel).BeginInit();
            tabTurnike.SuspendLayout();
            pnlSonuc.SuspendLayout();
            tabRaporlama.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRapor).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPersonel);
            tabControl1.Controls.Add(tabTurnike);
            tabControl1.Controls.Add(tabRaporlama);
            tabControl1.Location = new Point(72, 30);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(673, 377);
            tabControl1.TabIndex = 0;
            // 
            // tabPersonel
            // 
            tabPersonel.Controls.Add(dgvPersonel);
            tabPersonel.Controls.Add(btnKaydet);
            tabPersonel.Controls.Add(label12);
            tabPersonel.Controls.Add(chkIsg);
            tabPersonel.Controls.Add(label4);
            tabPersonel.Controls.Add(chkSgk);
            tabPersonel.Controls.Add(label3);
            tabPersonel.Controls.Add(cmbTaseron);
            tabPersonel.Controls.Add(txtTcNo);
            tabPersonel.Controls.Add(label2);
            tabPersonel.Controls.Add(txtAdSoyad);
            tabPersonel.Controls.Add(label1);
            tabPersonel.Location = new Point(4, 24);
            tabPersonel.Name = "tabPersonel";
            tabPersonel.Padding = new Padding(3);
            tabPersonel.Size = new Size(665, 349);
            tabPersonel.TabIndex = 0;
            tabPersonel.Text = "Personel Yönetimi";
            tabPersonel.UseVisualStyleBackColor = true;
            // 
            // dgvPersonel
            // 
            dgvPersonel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersonel.Location = new Point(254, 16);
            dgvPersonel.Name = "dgvPersonel";
            dgvPersonel.Size = new Size(390, 314);
            dgvPersonel.TabIndex = 11;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(31, 190);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(133, 23);
            btnKaydet.TabIndex = 10;
            btnKaydet.Text = "KAYDET";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(17, 151);
            label12.Name = "label12";
            label12.Size = new Size(27, 15);
            label12.TabIndex = 9;
            label12.Text = "İSG:";
            // 
            // chkIsg
            // 
            chkIsg.AutoSize = true;
            chkIsg.Location = new Point(105, 151);
            chkIsg.Name = "chkIsg";
            chkIsg.Size = new Size(86, 19);
            chkIsg.TabIndex = 8;
            chkIsg.Text = "İSG Mevcut";
            chkIsg.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 126);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 7;
            label4.Text = "SGK:";
            // 
            // chkSgk
            // 
            chkSgk.AutoSize = true;
            chkSgk.Location = new Point(105, 126);
            chkSgk.Name = "chkSgk";
            chkSgk.Size = new Size(90, 19);
            chkSgk.TabIndex = 6;
            chkSgk.Text = "SGK Mevcut";
            chkSgk.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 94);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 5;
            label3.Text = "Taşeron:";
            // 
            // cmbTaseron
            // 
            cmbTaseron.FormattingEnabled = true;
            cmbTaseron.Location = new Point(105, 91);
            cmbTaseron.Name = "cmbTaseron";
            cmbTaseron.Size = new Size(121, 23);
            cmbTaseron.TabIndex = 4;
            // 
            // txtTcNo
            // 
            txtTcNo.Location = new Point(105, 53);
            txtTcNo.Name = "txtTcNo";
            txtTcNo.Size = new Size(121, 23);
            txtTcNo.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 61);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 2;
            label2.Text = "TC Kimlik No:";
            // 
            // txtAdSoyad
            // 
            txtAdSoyad.Location = new Point(105, 13);
            txtAdSoyad.Name = "txtAdSoyad";
            txtAdSoyad.Size = new Size(121, 23);
            txtAdSoyad.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 16);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "Ad Soyad:";
            // 
            // tabTurnike
            // 
            tabTurnike.Controls.Add(lstLoglar);
            tabTurnike.Controls.Add(pnlSonuc);
            tabTurnike.Controls.Add(btnKartOkut);
            tabTurnike.Controls.Add(txtIpAdresi);
            tabTurnike.Controls.Add(label6);
            tabTurnike.Controls.Add(cmbPersonelTurnike);
            tabTurnike.Controls.Add(label5);
            tabTurnike.Location = new Point(4, 24);
            tabTurnike.Name = "tabTurnike";
            tabTurnike.Padding = new Padding(3);
            tabTurnike.Size = new Size(665, 349);
            tabTurnike.TabIndex = 1;
            tabTurnike.Text = "Turnike Simulasyonu";
            tabTurnike.UseVisualStyleBackColor = true;
            // 
            // lstLoglar
            // 
            lstLoglar.FormattingEnabled = true;
            lstLoglar.ItemHeight = 15;
            lstLoglar.Location = new Point(36, 218);
            lstLoglar.Name = "lstLoglar";
            lstLoglar.Size = new Size(497, 94);
            lstLoglar.TabIndex = 6;
            // 
            // pnlSonuc
            // 
            pnlSonuc.Controls.Add(lblSonuc);
            pnlSonuc.Location = new Point(33, 133);
            pnlSonuc.Name = "pnlSonuc";
            pnlSonuc.Size = new Size(500, 63);
            pnlSonuc.TabIndex = 5;
            // 
            // lblSonuc
            // 
            lblSonuc.AutoSize = true;
            lblSonuc.Location = new Point(26, 15);
            lblSonuc.Name = "lblSonuc";
            lblSonuc.Size = new Size(0, 15);
            lblSonuc.TabIndex = 0;
            // 
            // btnKartOkut
            // 
            btnKartOkut.Location = new Point(33, 90);
            btnKartOkut.Name = "btnKartOkut";
            btnKartOkut.RightToLeft = RightToLeft.Yes;
            btnKartOkut.Size = new Size(172, 23);
            btnKartOkut.TabIndex = 4;
            btnKartOkut.Text = "Kart Okut";
            btnKartOkut.UseVisualStyleBackColor = true;
            btnKartOkut.Click += btnKartOkut_Click;
            // 
            // txtIpAdresi
            // 
            txtIpAdresi.Location = new Point(85, 44);
            txtIpAdresi.Name = "txtIpAdresi";
            txtIpAdresi.Size = new Size(120, 23);
            txtIpAdresi.TabIndex = 3;
            txtIpAdresi.Text = "192.168.1.50";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 51);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 2;
            label6.Text = "IP Adresi:";
            // 
            // cmbPersonelTurnike
            // 
            cmbPersonelTurnike.FormattingEnabled = true;
            cmbPersonelTurnike.Location = new Point(84, 15);
            cmbPersonelTurnike.Name = "cmbPersonelTurnike";
            cmbPersonelTurnike.Size = new Size(121, 23);
            cmbPersonelTurnike.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 18);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 0;
            label5.Text = "Personel:";
            // 
            // tabRaporlama
            // 
            tabRaporlama.Controls.Add(dgvRapor);
            tabRaporlama.Controls.Add(btnFirmaRapor);
            tabRaporlama.Controls.Add(btnReddedilenler);
            tabRaporlama.Controls.Add(btnBugunGirisler);
            tabRaporlama.Location = new Point(4, 24);
            tabRaporlama.Name = "tabRaporlama";
            tabRaporlama.Padding = new Padding(3);
            tabRaporlama.Size = new Size(665, 349);
            tabRaporlama.TabIndex = 2;
            tabRaporlama.Text = "Raporlama";
            tabRaporlama.UseVisualStyleBackColor = true;
            // 
            // dgvRapor
            // 
            dgvRapor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRapor.Location = new Point(6, 123);
            dgvRapor.Name = "dgvRapor";
            dgvRapor.Size = new Size(641, 150);
            dgvRapor.TabIndex = 3;
            // 
            // btnFirmaRapor
            // 
            btnFirmaRapor.Location = new Point(407, 50);
            btnFirmaRapor.Name = "btnFirmaRapor";
            btnFirmaRapor.Size = new Size(141, 23);
            btnFirmaRapor.TabIndex = 2;
            btnFirmaRapor.Text = "Firma Bazlı Raporlar";
            btnFirmaRapor.UseVisualStyleBackColor = true;
            btnFirmaRapor.Click += btnFirmaRapor_Click;
            // 
            // btnReddedilenler
            // 
            btnReddedilenler.Location = new Point(260, 50);
            btnReddedilenler.Name = "btnReddedilenler";
            btnReddedilenler.Size = new Size(141, 23);
            btnReddedilenler.TabIndex = 1;
            btnReddedilenler.Text = "Reddedilenler";
            btnReddedilenler.UseVisualStyleBackColor = true;
            btnReddedilenler.Click += btnReddedilenler_Click;
            // 
            // btnBugunGirisler
            // 
            btnBugunGirisler.Location = new Point(113, 50);
            btnBugunGirisler.Name = "btnBugunGirisler";
            btnBugunGirisler.Size = new Size(141, 23);
            btnBugunGirisler.TabIndex = 0;
            btnBugunGirisler.Text = "Bugünün Girişleri";
            btnBugunGirisler.UseVisualStyleBackColor = true;
            btnBugunGirisler.Click += btnBugunGirisler_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPersonel.ResumeLayout(false);
            tabPersonel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPersonel).EndInit();
            tabTurnike.ResumeLayout(false);
            tabTurnike.PerformLayout();
            pnlSonuc.ResumeLayout(false);
            pnlSonuc.PerformLayout();
            tabRaporlama.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRapor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPersonel;
        private TabPage tabTurnike;
        private TabPage tabRaporlama;
        private TextBox txtAdSoyad;
        private Label label1;
        private Label label12;
        private CheckBox chkIsg;
        private Label label4;
        private CheckBox chkSgk;
        private Label label3;
        private ComboBox cmbTaseron;
        private TextBox txtTcNo;
        private Label label2;
        private DataGridView dgvPersonel;
        private Button btnKaydet;
        private ComboBox cmbPersonelTurnike;
        private Label label5;
        private TextBox txtIpAdresi;
        private Label label6;
        private Panel pnlSonuc;
        private Label lblSonuc;
        private Button btnKartOkut;
        private ListBox lstLoglar;
        private Button btnFirmaRapor;
        private Button btnReddedilenler;
        private Button btnBugunGirisler;
        private DataGridView dgvRapor;
    }
}
