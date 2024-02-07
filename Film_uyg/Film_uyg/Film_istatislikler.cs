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
    public partial class Film_istatislikler : Form
    {
        public Film_istatislikler()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; " +
          "user Id=postgres ; password=1234 ");


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            


            // Satırın tıklanan hücresinin indeksini kontrol et
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Hücre içeriğini al
                txt_film_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value?.ToString();
                txt_film_adi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value?.ToString();
                //txt_yönetmen.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value?.ToString();
                //txt_oyuncular.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value?.ToString();
                //txt_film_turu.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value?.ToString();
                //txt_yayın_yılı.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value?.ToString();
                txt_degerlendirme_Puan.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value?.ToString();
                // PictureBox'a resmi yükleyin (ResimDosyaYolu sütununu kullanarak)
                string resimDosyaYolu = dataGridView1.Rows[e.RowIndex].Cells[8].Value?.ToString();


                if (!string.IsNullOrEmpty(resimDosyaYolu))
                {
                    pictureBox_film.Image = Image.FromFile(resimDosyaYolu);
                }
                else
                {
                    // ResimDosyaYolu boşsa, PictureBox'i temizle
                    pictureBox_film.Image = null;
                }
            }


        }

        private void Form6_Load(object sender, EventArgs e)
        {
            //string sorgu = "select filmid,ad,degerlendirmepuani,yonetmen,oyuncular,tur,yayinyili,resimdosyayolu from filmlertablosu";
            //NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
        }

        private void btn_en_cok_puanli_Click(object sender, EventArgs e)
        {
            try
            {
                // En yüksek puan alan filmleri getir
                string sorgu = "SELECT filmid,ad,degerlendirmepuani,yonetmen,oyuncular,tur,yayinyili,yayinyili,resimdosyayolu from filmlertablosu ORDER BY filmlertablosu.degerlendirmepuani DESC";

                using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
                {
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds.Tables.Count > 0)
                        {
                            // DataGridView temizle
                            dataGridView1.DataSource = null;

                            // DataGridView'e DataSet'i bağla
                            dataGridView1.DataSource = ds.Tables[0];
                        }
                        else
                        {
                            MessageBox.Show("Veri bulunamadı.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }



        private void btn_yorum_en_cok_Click(object sender, EventArgs e)
        {

            try
            {
                // Her filmin yorum sayısını içeren sorgu
                string yorumSorgu = "SELECT filmid, COUNT(*) as yorum_sayisi FROM yorumlartablosu GROUP BY filmid";

                // Her filmin adı, yazarı ve yorum sayısını içeren sorgu
                string sorgu = "SELECT f.filmid, f.ad , COALESCE(y.yorum_sayisi, 0) as yorum_sayisi,f.yonetmen, f.oyuncular, f.tur, f.yayinyili, f.degerlendirmepuani,f.resimdosyayolu " +
                               "FROM filmlertablosu f " +
                               "LEFT JOIN (" + yorumSorgu + ") y ON f.filmid = y.filmid " +
                               "ORDER BY yorum_sayisi DESC";

                using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
                {
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds.Tables.Count > 0)
                        {
                            // DataGridView temizle
                            dataGridView1.DataSource = null;

                            // DataGridView'e DataSet'i bağla
                            dataGridView1.DataSource = ds.Tables[0];

                            // İlk sütundaki film adına göre gruplayarak her filmin yanına yorum sayısını ekleyin
                            var grupluSonuc = ds.Tables[0].AsEnumerable()
                                .GroupBy(row => row.Field<string>("ad"))
                                .Select(grp => new
                                {
                                    FilmAdi = grp.Key,
                                    YorumSayisi = grp.Sum(row => row.Field<int>("yorum_sayisi"))
                                });

                           
                        }
                        else
                        {
                            MessageBox.Show("Veri bulunamadı.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }


        }

        private void btn_en_cok_puanlanan_filmler_Click(object sender, EventArgs e)
        {
            try
            {
                // Her filmin yorum sayısını içeren sorgu
                string degerlendirmeSorgu = "SELECT filmid, COUNT(*) as degerlendirme_sayisi FROM degerlendirmetablosu GROUP BY filmid";

                // Her filmin adı, yazarı ve yorum sayısını içeren sorgu
                string sorgu = "SELECT f.filmid, f.ad , COALESCE(y.degerlendirme_sayisi, 0) as degerlendirme_sayisi,f.yonetmen, f.oyuncular, f.tur, f.yayinyili, f.degerlendirmepuani,resimdosyayolu " +
                               "FROM filmlertablosu f " +
                               "LEFT JOIN (" + degerlendirmeSorgu + ") y ON f.filmid = y.filmid " +
                               "ORDER BY degerlendirme_sayisi DESC";

                using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
                {
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds.Tables.Count > 0)
                        {
                            // DataGridView temizle
                            dataGridView1.DataSource = null;

                            // DataGridView'e DataSet'i bağla
                            dataGridView1.DataSource = ds.Tables[0];

                            // İlk sütundaki film adına göre gruplayarak her filmin yanına yorum sayısını ekleyin
                            var grupluSonuc = ds.Tables[0].AsEnumerable()
                                .GroupBy(row => row.Field<string>("ad"))
                                .Select(grp => new
                                {
                                    FilmAdi = grp.Key,
                                    YorumSayisi = grp.Sum(row => row.Field<int>("degerlendirme_sayisi"))
                                });


                        }
                        else
                        {
                            MessageBox.Show("Veri bulunamadı.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private int kullaniciId;

        private void btn_geri_Click(object sender, EventArgs e)
        {
            AnaEkran Form5 = new AnaEkran(kullaniciId);  // Burada kullaniciId'yi geçirin
                                                   // Aktif olan Form5'i kapat
            this.Hide();
            Form5.Show();
        }
    }
}
