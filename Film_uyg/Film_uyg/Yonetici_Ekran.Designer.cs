namespace Film_uyg
{
    partial class Yonetici_Ekran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Yonetici_Ekran));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_kullanici = new System.Windows.Forms.Button();
            this.btn_filmler = new System.Windows.Forms.Button();
            this.label_yonetici_ad = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_degerlendirmee = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(68, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(705, 441);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btn_kullanici
            // 
            this.btn_kullanici.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_kullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kullanici.ForeColor = System.Drawing.Color.Red;
            this.btn_kullanici.Location = new System.Drawing.Point(76, 193);
            this.btn_kullanici.Name = "btn_kullanici";
            this.btn_kullanici.Size = new System.Drawing.Size(199, 85);
            this.btn_kullanici.TabIndex = 3;
            this.btn_kullanici.Text = "Kullanıcılar";
            this.btn_kullanici.UseVisualStyleBackColor = false;
            this.btn_kullanici.Click += new System.EventHandler(this.btn_kullanici_Click_1);
            // 
            // btn_filmler
            // 
            this.btn_filmler.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_filmler.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_filmler.ForeColor = System.Drawing.Color.Red;
            this.btn_filmler.Location = new System.Drawing.Point(574, 193);
            this.btn_filmler.Name = "btn_filmler";
            this.btn_filmler.Size = new System.Drawing.Size(199, 85);
            this.btn_filmler.TabIndex = 4;
            this.btn_filmler.Text = "Filmler";
            this.btn_filmler.UseVisualStyleBackColor = false;
            this.btn_filmler.Click += new System.EventHandler(this.btn_filmler_Click_1);
            // 
            // label_yonetici_ad
            // 
            this.label_yonetici_ad.AutoSize = true;
            this.label_yonetici_ad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label_yonetici_ad.Font = new System.Drawing.Font("Algerian", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_yonetici_ad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label_yonetici_ad.Location = new System.Drawing.Point(281, 77);
            this.label_yonetici_ad.Name = "label_yonetici_ad";
            this.label_yonetici_ad.Size = new System.Drawing.Size(271, 31);
            this.label_yonetici_ad.TabIndex = 5;
            this.label_yonetici_ad.Text = "Mehmet Şirin AKIN";
            this.label_yonetici_ad.Click += new System.EventHandler(this.label_yonetici_ad_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Blue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(68, 494);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "Çıkış";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_degerlendirmee
            // 
            this.btn_degerlendirmee.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_degerlendirmee.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_degerlendirmee.ForeColor = System.Drawing.Color.Red;
            this.btn_degerlendirmee.Location = new System.Drawing.Point(296, 391);
            this.btn_degerlendirmee.Name = "btn_degerlendirmee";
            this.btn_degerlendirmee.Size = new System.Drawing.Size(256, 85);
            this.btn_degerlendirmee.TabIndex = 7;
            this.btn_degerlendirmee.Text = "Deperlendirmeler";
            this.btn_degerlendirmee.UseVisualStyleBackColor = false;
            this.btn_degerlendirmee.Click += new System.EventHandler(this.btn_degerlendirmee_Click);
            // 
            // Yonetici_Ekran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(847, 545);
            this.Controls.Add(this.btn_degerlendirmee);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_yonetici_ad);
            this.Controls.Add(this.btn_filmler);
            this.Controls.Add(this.btn_kullanici);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Yonetici_Ekran";
            this.Text = "Form8";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_kullanici;
        private System.Windows.Forms.Button btn_filmler;
        private System.Windows.Forms.Label label_yonetici_ad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_degerlendirmee;
    }
}