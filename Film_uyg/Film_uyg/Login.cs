using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Film_uyg
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();


        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; " +
          "user Id=postgres ; password=1234 ");

       // private string yoneticiAd;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            Film_istatislikler Form6 = new Film_istatislikler();
            Form6.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Film_istatislikler Form6 = new Film_istatislikler();
            Form6.Show();
        }

        private void btn_kaydol_Click(object sender, EventArgs e)
        {
            Kulanici_kaydol Form7 = new Kulanici_kaydol();
            this.Hide();
            Form7.Show();
        }

        private void btn_kullanici_giris_Click(object sender, EventArgs e)
        {

            // Kullanıcının girdiği kullanıcı adı ve şifreyi al

            string kullaniciAdi = txt_k_adi.Text;
            string sifre = txt_sifre.Text;

            // Kullanıcı adı ve şifre kontrolü için SQL sorgusu
            string sqlSorgusu = "SELECT kullaniciid FROM kullaniciadisifre WHERE kullanici_adi = @kullaniciAdi AND sifre = @sifre";

            using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
            {
                using (NpgsqlCommand komut = new NpgsqlCommand(sqlSorgusu, baglanti))
                {
                    // Parametreleri ekleyerek SQL enjeksiyonunu önle 
                    komut.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    komut.Parameters.AddWithValue("@sifre", sifre);

                    try
                    {
                        baglanti.Open();

                        // NpgsqlDataReader ile sorgudan veri okuma
                        using (NpgsqlDataReader okuyucu = komut.ExecuteReader())
                        {
                            // Okuyucu veri okuyabiliyorsa, giriş başarılı
                            if (okuyucu.Read())
                            {
                                MessageBox.Show("Giriş başarılı!");

                                // Kullanıcı ID'yi al
                                int kullaniciId = okuyucu.GetInt32(okuyucu.GetOrdinal("kullaniciid"));

                                // Form5'i oluştur ve kullanıcı ID'yi ileterek göster
                                AnaEkran form5 = new AnaEkran(kullaniciId);
                                form5.Show();

                                // Şu anki formu gizle veya kapat
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }


        }

        private void btn_yonetici_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txt_k_adi.Text;
            string sifre = txt_sifre.Text;
            string yoneticiAd = ""; // Yönetici adını saklamak için bir değişken

            // Önceden belirlenmiş kullanıcı adı ve şifreleri tanımla
            string mehmetKullaniciAdi = "mehmet";
            string mehmetSifre = "123";

            string iremKullaniciAdi = "irem";
            string iremSifre = "irem35";

            // Kullanıcı adı ve şifreyi kontrol et
            if ((kullaniciAdi == mehmetKullaniciAdi && sifre == mehmetSifre) ||
                (kullaniciAdi == iremKullaniciAdi && sifre == iremSifre))
            {
                MessageBox.Show("Giriş başarılı!");

                // İlgili kullanıcıya göre yönetici adını belirle
                yoneticiAd = (kullaniciAdi == mehmetKullaniciAdi) ? "Mehmet Şİrin AKIN" : "İrem KARADAĞ";

                // Giriş başarılıysa, Form8'i aç ve yönetici adını gönder
                Yonetici_Ekran Form8 = new Yonetici_Ekran(yoneticiAd);
                this.Hide();
                Form8.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
            }
        }
    }
}
