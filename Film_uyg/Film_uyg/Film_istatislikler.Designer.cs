namespace Film_uyg
{
    partial class Film_istatislikler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Film_istatislikler));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_en_cok_puanli = new System.Windows.Forms.Button();
            this.btn_yorum_en_cok = new System.Windows.Forms.Button();
            this.btn_en_cok_puanlanan_filmler = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_degerlendirme_Puan = new System.Windows.Forms.TextBox();
            this.txt_film_adi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_film_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_film = new System.Windows.Forms.PictureBox();
            this.btn_geri = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_film)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(857, 657);
            this.dataGridView1.TabIndex = 37;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btn_en_cok_puanli
            // 
            this.btn_en_cok_puanli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_en_cok_puanli.Location = new System.Drawing.Point(89, 537);
            this.btn_en_cok_puanli.Name = "btn_en_cok_puanli";
            this.btn_en_cok_puanli.Size = new System.Drawing.Size(270, 44);
            this.btn_en_cok_puanli.TabIndex = 45;
            this.btn_en_cok_puanli.Text = "En Yüksek Puan Alan Filmler";
            this.btn_en_cok_puanli.UseVisualStyleBackColor = true;
            this.btn_en_cok_puanli.Click += new System.EventHandler(this.btn_en_cok_puanli_Click);
            // 
            // btn_yorum_en_cok
            // 
            this.btn_yorum_en_cok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_yorum_en_cok.Location = new System.Drawing.Point(89, 475);
            this.btn_yorum_en_cok.Name = "btn_yorum_en_cok";
            this.btn_yorum_en_cok.Size = new System.Drawing.Size(270, 44);
            this.btn_yorum_en_cok.TabIndex = 46;
            this.btn_yorum_en_cok.Text = "En Çok Yorumlanan Filmler";
            this.btn_yorum_en_cok.UseVisualStyleBackColor = true;
            this.btn_yorum_en_cok.Click += new System.EventHandler(this.btn_yorum_en_cok_Click);
            // 
            // btn_en_cok_puanlanan_filmler
            // 
            this.btn_en_cok_puanlanan_filmler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_en_cok_puanlanan_filmler.Location = new System.Drawing.Point(89, 601);
            this.btn_en_cok_puanlanan_filmler.Name = "btn_en_cok_puanlanan_filmler";
            this.btn_en_cok_puanlanan_filmler.Size = new System.Drawing.Size(270, 44);
            this.btn_en_cok_puanlanan_filmler.TabIndex = 47;
            this.btn_en_cok_puanlanan_filmler.Text = "En Çok Değerlendirme Alan Filmler";
            this.btn_en_cok_puanlanan_filmler.UseVisualStyleBackColor = true;
            this.btn_en_cok_puanlanan_filmler.Click += new System.EventHandler(this.btn_en_cok_puanlanan_filmler_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txt_degerlendirme_Puan);
            this.panel1.Controls.Add(this.btn_en_cok_puanlanan_filmler);
            this.panel1.Controls.Add(this.txt_film_adi);
            this.panel1.Controls.Add(this.btn_en_cok_puanli);
            this.panel1.Controls.Add(this.btn_yorum_en_cok);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_film_id);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox_film);
            this.panel1.Location = new System.Drawing.Point(903, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 657);
            this.panel1.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(50, 417);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 23);
            this.label7.TabIndex = 42;
            this.label7.Text = "Puanı";
            // 
            // txt_degerlendirme_Puan
            // 
            this.txt_degerlendirme_Puan.BackColor = System.Drawing.Color.Black;
            this.txt_degerlendirme_Puan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_degerlendirme_Puan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_degerlendirme_Puan.ForeColor = System.Drawing.Color.White;
            this.txt_degerlendirme_Puan.Location = new System.Drawing.Point(234, 418);
            this.txt_degerlendirme_Puan.Name = "txt_degerlendirme_Puan";
            this.txt_degerlendirme_Puan.Size = new System.Drawing.Size(176, 30);
            this.txt_degerlendirme_Puan.TabIndex = 41;
            // 
            // txt_film_adi
            // 
            this.txt_film_adi.BackColor = System.Drawing.Color.Black;
            this.txt_film_adi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_film_adi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_film_adi.ForeColor = System.Drawing.Color.White;
            this.txt_film_adi.Location = new System.Drawing.Point(234, 357);
            this.txt_film_adi.Name = "txt_film_adi";
            this.txt_film_adi.Size = new System.Drawing.Size(176, 30);
            this.txt_film_adi.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(50, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 23);
            this.label2.TabIndex = 31;
            this.label2.Text = "Film Adı ";
            // 
            // txt_film_id
            // 
            this.txt_film_id.BackColor = System.Drawing.Color.Black;
            this.txt_film_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_film_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_film_id.ForeColor = System.Drawing.Color.White;
            this.txt_film_id.Location = new System.Drawing.Point(234, 312);
            this.txt_film_id.Name = "txt_film_id";
            this.txt_film_id.Size = new System.Drawing.Size(176, 30);
            this.txt_film_id.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(50, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 23);
            this.label1.TabIndex = 29;
            this.label1.Text = "Film ID";
            // 
            // pictureBox_film
            // 
            this.pictureBox_film.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox_film.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_film.Image")));
            this.pictureBox_film.Location = new System.Drawing.Point(30, 16);
            this.pictureBox_film.Name = "pictureBox_film";
            this.pictureBox_film.Size = new System.Drawing.Size(391, 278);
            this.pictureBox_film.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_film.TabIndex = 0;
            this.pictureBox_film.TabStop = false;
            // 
            // btn_geri
            // 
            this.btn_geri.BackColor = System.Drawing.Color.Navy;
            this.btn_geri.Font = new System.Drawing.Font("Snap ITC", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_geri.ForeColor = System.Drawing.Color.White;
            this.btn_geri.Location = new System.Drawing.Point(1170, 687);
            this.btn_geri.Name = "btn_geri";
            this.btn_geri.Size = new System.Drawing.Size(181, 29);
            this.btn_geri.TabIndex = 48;
            this.btn_geri.Text = "Geri";
            this.btn_geri.UseVisualStyleBackColor = false;
            this.btn_geri.Click += new System.EventHandler(this.btn_geri_Click);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(1418, 728);
            this.Controls.Add(this.btn_geri);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form6";
            this.Text = "Form6";
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_film)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_en_cok_puanli;
        private System.Windows.Forms.Button btn_yorum_en_cok;
        private System.Windows.Forms.Button btn_en_cok_puanlanan_filmler;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_degerlendirme_Puan;
        private System.Windows.Forms.TextBox txt_film_adi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_film_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_film;
        private System.Windows.Forms.Button btn_geri;
    }
}