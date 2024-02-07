namespace Film_uyg
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_yonetici = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_kaydol = new System.Windows.Forms.Button();
            this.btn_kullanici_giris = new System.Windows.Forms.Button();
            this.txt_sifre = new System.Windows.Forms.TextBox();
            this.txt_k_adi = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(43, 201);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1201, 486);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Ravie", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(94, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(865, 107);
            this.label1.TabIndex = 35;
            this.label1.Text = "Film Zamanı... ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btn_yonetici);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_kaydol);
            this.panel1.Controls.Add(this.btn_kullanici_giris);
            this.panel1.Controls.Add(this.txt_sifre);
            this.panel1.Controls.Add(this.txt_k_adi);
            this.panel1.Location = new System.Drawing.Point(965, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 165);
            this.panel1.TabIndex = 38;
            // 
            // btn_yonetici
            // 
            this.btn_yonetici.Location = new System.Drawing.Point(15, 121);
            this.btn_yonetici.Name = "btn_yonetici";
            this.btn_yonetici.Size = new System.Drawing.Size(118, 23);
            this.btn_yonetici.TabIndex = 6;
            this.btn_yonetici.Text = "Yönetici Giriş";
            this.btn_yonetici.UseVisualStyleBackColor = true;
            this.btn_yonetici.Click += new System.EventHandler(this.btn_yonetici_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(23, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Şifre Gir : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(23, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kullanıcı adı gir";
            // 
            // btn_kaydol
            // 
            this.btn_kaydol.Location = new System.Drawing.Point(252, 121);
            this.btn_kaydol.Name = "btn_kaydol";
            this.btn_kaydol.Size = new System.Drawing.Size(75, 23);
            this.btn_kaydol.TabIndex = 3;
            this.btn_kaydol.Text = "Kaydol";
            this.btn_kaydol.UseVisualStyleBackColor = true;
            this.btn_kaydol.Click += new System.EventHandler(this.btn_kaydol_Click);
            // 
            // btn_kullanici_giris
            // 
            this.btn_kullanici_giris.Location = new System.Drawing.Point(167, 121);
            this.btn_kullanici_giris.Name = "btn_kullanici_giris";
            this.btn_kullanici_giris.Size = new System.Drawing.Size(75, 23);
            this.btn_kullanici_giris.TabIndex = 2;
            this.btn_kullanici_giris.Text = "Giriş";
            this.btn_kullanici_giris.UseVisualStyleBackColor = true;
            this.btn_kullanici_giris.Click += new System.EventHandler(this.btn_kullanici_giris_Click);
            // 
            // txt_sifre
            // 
            this.txt_sifre.Location = new System.Drawing.Point(167, 68);
            this.txt_sifre.Name = "txt_sifre";
            this.txt_sifre.Size = new System.Drawing.Size(160, 22);
            this.txt_sifre.TabIndex = 1;
            // 
            // txt_k_adi
            // 
            this.txt_k_adi.Location = new System.Drawing.Point(167, 26);
            this.txt_k_adi.Name = "txt_k_adi";
            this.txt_k_adi.Size = new System.Drawing.Size(160, 22);
            this.txt_k_adi.TabIndex = 0;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1339, 711);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_kullanici_giris;
        private System.Windows.Forms.TextBox txt_sifre;
        private System.Windows.Forms.TextBox txt_k_adi;
        private System.Windows.Forms.Button btn_kaydol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_yonetici;
    }
}

