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
    public partial class Yonetici_FilmDuzenle : Form
    {

        Film film = new Film();

        public Yonetici_FilmDuzenle()
        {
            InitializeComponent();
        }
      

        private void Form3_Load(object sender, EventArgs e)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; " +
  "user Id=postgres ; password=1234 ");

            string sorgu = "select * from filmlertablosu";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_film_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_film_adi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_yönetmen.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_oyuncular.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox_film_turu.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_yayın_yılı.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_degerlendirme_Puan.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txt_resim_yolu.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

            // PictureBox'a resmi yükleyin (ResimDosyaYolu sütununu kullanarak)
            string resimDosyaYolu = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            pictureBox1.Image = Image.FromFile(resimDosyaYolu);

        }


        private void btn_Ekle_Click(object sender, EventArgs e)
        { 

            // Film sınıfındaki FilmEkle metodu kullanılabilir
            film.FilmEkle(int.Parse(txt_film_id.Text), txt_film_adi.Text, txt_yönetmen.Text, txt_oyuncular.Text, comboBox_film_turu.Text, int.Parse(txt_yayın_yılı.Text), float.Parse(txt_degerlendirme_Puan.Text), txt_resim_yolu.Text);


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            film.FilmSil(int.Parse(txt_film_id.Text));
        }


        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            film.FilmGuncelle(int.Parse(txt_film_id.Text), txt_film_adi.Text, txt_yönetmen.Text, txt_oyuncular.Text, comboBox_film_turu.Text, int.Parse(txt_yayın_yılı.Text), float.Parse(txt_degerlendirme_Puan.Text), txt_resim_yolu.Text);
        }



        private string yoneticiAd;

        private void btn_geri_Click(object sender, EventArgs e)
        {
            Yonetici_Ekran Form8 = new Yonetici_Ekran(yoneticiAd);
            this.Hide();
            Form8.Show();
        }

        private void btn_bosalt_Click(object sender, EventArgs e)
        {
            // TextBox'ları ve ComboBox'ı boşalt
            txt_film_id.Text = "";
            txt_film_adi.Text = "";
            txt_yönetmen.Text = "";
            txt_oyuncular.Text = "";
            comboBox_film_turu.SelectedIndex = -1; // ComboBox'ı boşaltmak için SelectedIndex'i -1 yapabilirsiniz
            txt_yayın_yılı.Text = "";
            txt_degerlendirme_Puan.Text = "";
            txt_resim_yolu.Text = "";

            // PictureBox'tan resmi temizle
            pictureBox1.Image = null;
        }

        private void txt_film_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Listele_Click(object sender, EventArgs e)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; " +
 "user Id=postgres ; password=1234 ");

            string sorgu = "select * from filmlertablosu";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
