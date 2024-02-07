using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Film_uyg
{
    public partial class Yonetici_Ekran : Form
    {
        private string yoneticiAd;
        public Yonetici_Ekran(string yoneticiAd)
        {
            InitializeComponent();
            
            this.yoneticiAd = yoneticiAd;
            label_yonetici_ad.Text = "" + yoneticiAd;
        }

        private void btn_kullanici_Click(object sender, EventArgs e)
        {
            Yonetici_KullaniciDuzenle Form2 = new Yonetici_KullaniciDuzenle();
            this.Hide();
            Form2.Show();
        }

        

        private void btn_kullanici_Click_1(object sender, EventArgs e)
        {
            Yonetici_KullaniciDuzenle Form2 = new Yonetici_KullaniciDuzenle();
            this.Hide();
            Form2.Show();
        }

        private void btn_filmler_Click_1(object sender, EventArgs e)
        {
            Yonetici_FilmDuzenle Form3 = new Yonetici_FilmDuzenle();
            this.Hide();
            Form3.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label_yonetici_ad_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // çikiş işlemi
            Form Form1 = new Login();
            // Aktif olan Form8'i kapat
            this.Hide();
            Form1.Show();
        }

        private void btn_degerlendirmee_Click(object sender, EventArgs e)
        {
            Yonetici_DegerlendirmeDuzenle Form4 = new Yonetici_DegerlendirmeDuzenle();
            this.Hide();
            Form4.Show();
        }

    }

}
