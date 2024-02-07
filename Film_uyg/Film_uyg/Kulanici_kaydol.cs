using Npgsql;
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
    public partial class Kulanici_kaydol : Form
    {
        public Kulanici_kaydol()
        {
            InitializeComponent();
        }


        Kullaniciislemleri kullaniciislemleri = new Kullaniciislemleri();


        private void btn_kydt_Click(object sender, EventArgs e)
        {


            kullaniciislemleri.KullanıcıEkle(txt_AdSoyad.Text, txt_tc.Text, DateTime.Parse(txt_DogumTarihi.Text), comboBox_cinsiyet.Text, comboBox_uyelik_tipi.Text, txt_k_adi.Text, txt_sifre.Text);
        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            Form Form1 = new Login();
            // Aktif olan Form'u kapat
            this.Hide();
            Form1.Show();
        }
    }
}
