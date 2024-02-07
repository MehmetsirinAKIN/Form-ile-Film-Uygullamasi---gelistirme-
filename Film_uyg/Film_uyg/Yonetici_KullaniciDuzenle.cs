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
    public partial class Yonetici_KullaniciDuzenle : Form
    {


        public Yonetici_KullaniciDuzenle()
        {
            InitializeComponent();



        }



       

        private void Form2_Load(object sender, EventArgs e)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; " +
 "user Id=postgres ; password=1234 ");
            baglanti.Open();
            string sorgu = "select * from KullaniciTablosu";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btn_kullanici_listele_Click(object sender, EventArgs e)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; " +
   "user Id=postgres ; password=1234 ");

            string sorgu = "select * from KullaniciTablosu";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; " +
   "user Id=postgres ; password=1234 ");

            baglanti.Open();

            DialogResult karar1 = new DialogResult();
            karar1 = MessageBox.Show(" Kullanıcı Eklemeyi Onaylıyormusunuz ? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (karar1 == DialogResult.Yes)
            {
                MessageBox.Show("Kullanıcı Ekleme Başarılı", "bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                NpgsqlCommand komut1 = new NpgsqlCommand("insert into kullanicitablosu (kullaniciid,adsoyad,tc,dogumtarihi,cinsiyet,uyeliktipi) values(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
                komut1.Parameters.AddWithValue("@p1", int.Parse(txt_Kulanici_id.Text));
                komut1.Parameters.AddWithValue("@p2", txt_AdSoyad.Text);
                komut1.Parameters.AddWithValue("@p3", txt_tc.Text);
                komut1.Parameters.AddWithValue("@p4", DateTime.Parse(txt_DogumTarihi.Text));
                komut1.Parameters.AddWithValue("@p5", comboBox_cinsiyet.Text);
                komut1.Parameters.AddWithValue("@p6", comboBox_uyelik_tipi.Text);

                komut1.ExecuteNonQuery();
            }

        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {


            DialogResult karar1 = new DialogResult();
            karar1 = MessageBox.Show("Kullanıcıyı Silme Onaylıyor musunuz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            if (karar1 == DialogResult.Yes)
            {
                using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres; password=1234"))
                {
                    baglanti.Open();
                    using (NpgsqlTransaction transaction = baglanti.BeginTransaction())
                    {
                        try
                        {
                            NpgsqlCommand kullaniciAd_sifreSilKomutu = new NpgsqlCommand("DELETE FROM kullaniciadisifre WHERE kullaniciid = @p1", baglanti, transaction);
                            kullaniciAd_sifreSilKomutu.Parameters.AddWithValue("@p1", int.Parse(txt_Kulanici_id.Text));
                            kullaniciAd_sifreSilKomutu.ExecuteNonQuery();


                            // Bağımlı tablodan kayıtları sil (örneğin: degerlendirmetablosu)
                            NpgsqlCommand degerlendirmeSilKomutu = new NpgsqlCommand("DELETE FROM degerlendirmetablosu WHERE kullaniciid = @p1", baglanti, transaction);
                            degerlendirmeSilKomutu.Parameters.AddWithValue("@p1", int.Parse(txt_Kulanici_id.Text));
                            degerlendirmeSilKomutu.ExecuteNonQuery();

                            // Bağımlı tablodan kayıtları sil (örneğin: yorumlartablosu)
                            NpgsqlCommand yorumSilKomutu = new NpgsqlCommand("DELETE FROM yorumlartablosu WHERE kullaniciid = @p1", baglanti, transaction);
                            yorumSilKomutu.Parameters.AddWithValue("@p1", int.Parse(txt_Kulanici_id.Text));
                            yorumSilKomutu.ExecuteNonQuery();

                            // Ana tablodaki kaydı sil (örneğin: kullanicitablosu)
                            NpgsqlCommand kullaniciSilKomutu = new NpgsqlCommand("DELETE FROM kullanicitablosu WHERE kullaniciid = @p1", baglanti, transaction);
                            kullaniciSilKomutu.Parameters.AddWithValue("@p1", int.Parse(txt_Kulanici_id.Text));
                            kullaniciSilKomutu.ExecuteNonQuery();


                            NpgsqlCommand begenilenFilmSilKomutu = new NpgsqlCommand("DELETE FROM begenilenfilmlertablosu WHERE kullaniciid = @p1", baglanti, transaction);
                            begenilenFilmSilKomutu.Parameters.AddWithValue("@p1", int.Parse(txt_Kulanici_id.Text));
                            begenilenFilmSilKomutu.ExecuteNonQuery();


                            transaction.Commit();
                            MessageBox.Show("Kullanıcı Silme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Silme İptal Edildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; " +
   "user Id=postgres ; password=1234 ");

            baglanti.Open();

            DialogResult karar = new DialogResult();
            karar = MessageBox.Show(" Kullanıcı Güncelemeyi Onaylıyormusunuz ? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (karar == DialogResult.Yes)
            {
                MessageBox.Show("Kullanıcı Güncelleme Başarılı", "bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
NpgsqlCommand komut3 = new NpgsqlCommand("update kullanicitablosu set adsoyad=@p2,tc=@p3,dogumtarihi=@p4,cinsiyet=@p5,uyeliktipi=@p6 where kullaniciid=@p1", baglanti);

                komut3.Parameters.AddWithValue("@p1", int.Parse(txt_Kulanici_id.Text));
                komut3.Parameters.AddWithValue("@p2", txt_AdSoyad.Text);
                komut3.Parameters.AddWithValue("@p3", txt_tc.Text);
                komut3.Parameters.AddWithValue("@p4", DateTime.Parse(txt_DogumTarihi.Text));
                komut3.Parameters.AddWithValue("@p5", comboBox_cinsiyet.Text);
                komut3.Parameters.AddWithValue("@p6", comboBox_uyelik_tipi.Text);

                komut3.ExecuteNonQuery();

            }

            if (karar == DialogResult.No)
            {

                MessageBox.Show(" Kullanıcı Günceleme iptal edildi", "bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // MessageBox.Show("Ders Güncelleme Başarılı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Yonetici_FilmDuzenle Form3 = new Yonetici_FilmDuzenle();
            Form3.Show();
        }

        private string yoneticiAd;

        private void btn_geri_Click(object sender, EventArgs e)
        {
            Yonetici_Ekran Form8 = new Yonetici_Ekran(yoneticiAd);
            this.Hide();
            Form8.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Kulanici_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_AdSoyad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_tc.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_DogumTarihi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox_cinsiyet.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox_uyelik_tipi.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            
        }

        private void btn_bosalt_Click(object sender, EventArgs e)
        {
            // TextBox'ları ve ComboBox'ı boşalt
            txt_Kulanici_id.Text = "";
            txt_AdSoyad.Text = "";
            txt_tc.Text = "";
            txt_DogumTarihi.Text = "";
            comboBox_cinsiyet.SelectedIndex = -1; // ComboBox'ı boşaltmak için SelectedIndex'i -1 yapabilirsiniz
            comboBox_uyelik_tipi.SelectedIndex = -1;

        }
    }
}
