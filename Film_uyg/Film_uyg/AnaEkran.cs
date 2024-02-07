using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Film_uyg
{
    public partial class AnaEkran : Form
    {
        private int kullaniciId;

        List<Film> filmListesi = new List<Film>();





        //  Kullanici kullanici = new Kullanici() ;

        prememiumKullanıcı PrememiumKullanıcı = new prememiumKullanıcı();
        
        standart Standart  = new standart();

        public AnaEkran(int kullaniciId)
        {
            InitializeComponent();
            this.kullaniciId = kullaniciId;

            notifyIcon1.Icon = SystemIcons.Information; // Bilgi simgesi
            notifyIcon1.ShowBalloonTip(2000, "Yeni Filmler Eklendi Filmler Bölümüne git \n", "Titanic ,Örümcek Adam ,Kurtlar Vadisi..... ", ToolTipIcon.Info);


        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; " +
    "user Id=postgres ; password=1234 ");

        private void Form5_Load(object sender, EventArgs e)
        {

            string sorgu = "select * from filmlertablosu";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            PrememiumKullanıcı.Fiyat();
            Standart.Fiyat();

            //MessageBox.Show("prmeium " + PrememiumKullanıcı.Filmfiyat.ToString() );
            //MessageBox.Show("standart " + Standart.Filmfiyat.ToString());

            int kullaniciId = this.kullaniciId;

            // Kullanıcı adını, soyadını ve üyelik tipini al
            string sqlSorgusu = "SELECT adsoyad, uyeliktipi FROM kullanicitablosu WHERE kullaniciid = @kullaniciId";

            using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
            {
                using (NpgsqlCommand komut = new NpgsqlCommand(sqlSorgusu, baglanti))
                {
                    komut.Parameters.AddWithValue("@kullaniciId", kullaniciId);

                    try
                    {
                        baglanti.Open();
                        NpgsqlDataReader reader = komut.ExecuteReader();

                        if (reader.Read())
                        {
                            string adSoyad = reader["adsoyad"].ToString();
                            string uyelikTipi = reader["uyeliktipi"].ToString();

                            label_ad_soyad.Text = adSoyad;
                            label_uyelik.Text = uyelikTipi;

                            baglanti.Close();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı bilgileri bulunamadı.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_film_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_film_adi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_yönetmen.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_oyuncular.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_film_turu.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_yayın_yılı.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_degerlendirme_Puan.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            // PictureBox'a resmi yükleyin (ResimDosyaYolu sütununu kullanarak)
            string resimDosyaYolu = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            
            pictureBox_film.Image = Image.FromFile(resimDosyaYolu);

        }

        private bool panel_yorumlar_gorVisible = false;
        private void btn_yorum_gor_Click(object sender, EventArgs e)
        {
           

            label_y_ad.Text = txt_film_adi.Text;

            listBoxYorumlar.DataSource = null;
            listBoxYorumlar.Items.Clear(); // ListBox'ı temizle

            listBoxYorumlar.Width = 400;
            listBoxYorumlar.Height = 530;

            panel_yorumlar_gor.Width = 430;
            panel_yorumlar_gor.Height = 550;

           

            int filmId;

            if (int.TryParse(txt_film_id.Text, out filmId))
            {
                tabControl2.SelectedTab = tabPage_yorumlar;
                // Film ID'sine bağlı tüm yorumları al
                string yorumlar = GetYorumlar(filmId);

                // Elde edilen yorumları TextBox üzerinde göster
                textBox_yorumlar.Text = yorumlar;
            }
            else
            {
                MessageBox.Show("Geçerli bir film ID giriniz.");
            }
        }

        private string GetYorumlar(int filmId)
        {
            StringBuilder yorumlar = new StringBuilder();

            string sqlSorgusu = @"
        SELECT y.yorum, k.adsoyad
        FROM yorumlartablosu y
        INNER JOIN kullanicitablosu k ON y.kullaniciid = k.kullaniciid
        WHERE y.filmid = @filmId";

            using (NpgsqlConnection baglanti2 = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
            {
                using (NpgsqlCommand komut = new NpgsqlCommand(sqlSorgusu, baglanti2))
                {
                    komut.Parameters.AddWithValue("@filmId", filmId);

                    try
                    {
                        baglanti2.Open();

                        using (NpgsqlDataReader okuyucu = komut.ExecuteReader())
                        {
                            while (okuyucu.Read())
                            {
                                // Yorumları ve kullanıcı adlarını TextBox üzerine ekleyin
                                yorumlar.AppendLine($"{okuyucu["adsoyad"]} - {okuyucu["yorum"]}");
                            }
                        }
                        baglanti2.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }

            return yorumlar.ToString();
        }

        private bool panel2_yorumYapVisible = true;

        private void btn_yorum_yaz_Click(object sender, EventArgs e)
        {
           


            if (panel2_yorumYapVisible)
            {
                panel2_yorumYap.Visible = false;
            }
            else
            {
                panel2_yorumYap.Visible = true;
            }

            panel2_yorumYapVisible = !panel2_yorumYapVisible;
            




        }

        private void btn_yorum_kydt_Click(object sender, EventArgs e)
        {
            // panel2_yorumYap'i gizle
            panel2_yorumYap.Visible = false;


            // Form1'den getirilen kullanıcı ID
            int kullaniciId = this.kullaniciId;

            // Film ID'yi txt_film_id TextBox'ından al
            string yorummetni = txt_yorum_yaz.Text;

            if (int.TryParse(txt_film_id.Text, out int filmId))
            {
                // kullanici işlemleri sınıfından consractırı cağiriyoruz 
                kullaniciislemleri.yorumyaz(kullaniciId, filmId,yorummetni);
            }
            else
            {
                // txt_film_id.Text bir tamsayıya dönüştürülemedi.
                MessageBox.Show("Geçerli bir film ID giriniz.");
            }




        }

        private void btn_puan_kydt_Click(object sender, EventArgs e)
        {

            // panel2_yorumYap'i gizle
            panel3.Visible = false;

            // Form1'den getirilen kullanıcı ID
            int kullaniciId = this.kullaniciId;

            // Film ID'yi txt_film_id TextBox'ından al
            string Puan = comboBox_puanGir.Text;

            if (int.TryParse(txt_film_id.Text, out int filmId))
            {
                // kullanici işlemleri sınıfından consractırı cağiriyoruz 
                kullaniciislemleri.PuanVER(kullaniciId, filmId, Puan);
            }
            else
            {
                // txt_film_id.Text bir tamsayıya dönüştürülemedi.
                MessageBox.Show("Geçerli bir film ID giriniz.");
            }

            
            
        }

       

        private void panel_yorumlar_gor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_bnm_filmler_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage_izleme;
           // dataGridView2.Visible = true;


            // Form1'den getirilen kullanıcı ID
            int kullaniciId = this.kullaniciId;

            // Begenilen filmler tablosundaki verileri getiren sorgu
            string sqlSorgusu = @"
        SELECT f.filmid, f.ad, f.yonetmen, f.oyuncular, f.tur, f.yayinyili, f.degerlendirmepuani , f.resimdosyayolu
        FROM izlemetablosu b
        INNER JOIN filmlertablosu f ON b.filmid = f.filmid
        WHERE b.kullaniciid = @kullaniciId";

            using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
            {
                using (NpgsqlCommand komut = new NpgsqlCommand(sqlSorgusu, baglanti))
                {
                    komut.Parameters.AddWithValue("@kullaniciId", kullaniciId);

                    try
                    {
                        baglanti.Open();

                        // Verileri DataGridView'e yükleyin
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(komut))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView2.DataSource = dt;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }


        }

        private void btn_filmlerim_ekle_Click(object sender, EventArgs e)
        {
            // Form1'den getirilen kullanıcı ID
            int kullaniciId = this.kullaniciId;

            // Film ID'yi txt_film_id TextBox'ından al
            if (int.TryParse(txt_film_id.Text, out int filmId))
            {
                // kullanici işlemleri sınıfından consractırı cağiriyoruz 
                kullaniciislemleri.İzlemeListesineEkle(kullaniciId, filmId);
            }
            else
            {
                // txt_film_id.Text bir tamsayıya dönüştürülemedi.
                MessageBox.Show("Geçerli bir film ID giriniz.");
            }
        }

//    degerlendirme ortalama alma 
//    update filmlertablosu
//set degerlendirmepuani = coalesce((
//    select avg(puan)
//    from degerlendirmetablosu
//    where degerlendirmetablosu.filmid = filmlertablosu.filmid
//), 0);   ctrl +k+ c / k



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Satırın tıklanan hücresinin indeksini kontrol et
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                // Hücre içeriğini al
                txt_film_id.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value?.ToString();
                txt_film_adi.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value?.ToString();
                txt_yönetmen.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value?.ToString();
                txt_oyuncular.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value?.ToString();
                txt_film_turu.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value?.ToString();
                txt_yayın_yılı.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value?.ToString();
                txt_degerlendirme_Puan.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value?.ToString();
                // PictureBox'a resmi yükleyin (ResimDosyaYolu sütununu kullanarak)
                string resimDosyaYolu = dataGridView2.Rows[e.RowIndex].Cells[7].Value?.ToString();

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

        private void btn_Ara_Click(object sender, EventArgs e)
        {
            // Kullanıcının girdiği arama terimini al
            string aramaTerimi = txt_ara.Text.Trim();

            // SQL sorgusunu oluştur
            string sqlSorgusu = "SELECT * FROM filmlertablosu WHERE " +
                                "ad ILIKE @aramaTerimi OR " +
                                "yonetmen ILIKE @aramaTerimi OR " +
                                "tur ILIKE @aramaTerimi";

            // Sorguyu çalıştır ve sonuçları listele
            using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
            {
                using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(sqlSorgusu, baglanti))
                {
                    // Parametreyi ekleyerek SQL enjeksiyonunu önle
                    da.SelectCommand.Parameters.AddWithValue("@aramaTerimi", $"%{aramaTerimi}%");

                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }

        private void btn_film_listemden_ciksr_Click(object sender, EventArgs e)
        {
            // Form1'den getirilen kullanıcı ID
            int kullaniciId = this.kullaniciId;

            

            if (int.TryParse(txt_film_id.Text, out int filmId))
            {
                // kullanici işlemleri sınıfından consractırı cağiriyoruz 
                kullaniciislemleri.İzlemeListesineCıkar(kullaniciId, filmId);
            }
            else
            {
                // txt_film_id.Text bir tamsayıya dönüştürülemedi.
                MessageBox.Show("Geçerli bir film ID giriniz.");
            }




        }

        private void btn_tum_filmler_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from filmlertablosu";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btn_degerlendirme_Click(object sender, EventArgs e)
        {
           

            listBoxYorumlar.DataSource = null;
            listBoxYorumlar.Items.Clear(); // ListBox'ı temizle

            listBoxYorumlar.Width = 270;
            listBoxYorumlar.Height = 440;

            panel_yorumlar_gor.Width = 300;
            panel_yorumlar_gor.Height = 450;

          

            // TextBox'tan film ID'sini al
            int filmId;
            if (int.TryParse(txt_film_id.Text, out filmId))
            {
                tabControl2.SelectedTab = tabPage_degerledirme;

                label_d_ad.Text = txt_film_adi.Text;
                // Veritabanından kullanıcı adı, soyadı ve değerlendirmeleri çek
                string sorgu = "SELECT kullanicitablosu.adsoyad, degerlendirmetablosu.Puan, degerlendirmetablosu.filmid FROM kullanicitablosu INNER JOIN degerlendirmetablosu ON kullanicitablosu.kullaniciid = degerlendirmetablosu.kullaniciid WHERE degerlendirmetablosu.filmid = @filmId";

                using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
                {
                    using (NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@filmId", filmId);

                        try
                        {
                            baglanti.Open();
                            using (NpgsqlDataReader reader = komut.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string adsoyad = reader["adsoyad"].ToString();
                                    string puan = reader["Puan"].ToString();
                                    

                                    // ListBox'a ekleyerek göster
                                    listBoxYorumlar.Items.Add($"{adsoyad}:  puan: {puan}");
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
            else
            {
                MessageBox.Show("Geçerli bir film ID giriniz.");
            }

        }

        private void btn_film_istatislikleri_Click(object sender, EventArgs e)
        {
            Film_istatislikler Form6 = new Film_istatislikler();
            Form6.Show();

        }

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            Form Form1 = new Login();
            // Aktif olan Form5'i kapat
            this.Hide();
            Form1.Show();
        }
        private bool panel_kullanıcı_hesapVisible = false;
        private void btn_hesap_bilgileri_Click(object sender, EventArgs e)
        {

            if (panel_kullanıcı_hesapVisible)
            {
                panel_kullanıcı_hesap.Visible = false;
            }
            else
            {
                panel_kullanıcı_hesap.Visible = true;
            }

            // Bayrağı tersine çevir
            panel_kullanıcı_hesapVisible = !panel_kullanıcı_hesapVisible;



            int kullaniciId = this.kullaniciId;

            // Kullanıcı adını, soyadını ve üyelik tipini al
            string sqlSorgusu2 = "SELECT adsoyad,tc,dogumtarihi,cinsiyet,uyeliktipi FROM kullanicitablosu WHERE kullaniciid = @kullaniciId";

            using (NpgsqlConnection baglanti2 = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
            {
                using (NpgsqlCommand komut = new NpgsqlCommand(sqlSorgusu2, baglanti2))
                {
                    komut.Parameters.AddWithValue("@kullaniciId", kullaniciId);

                    try
                    {
                        baglanti2.Open();
                        NpgsqlDataReader reader = komut.ExecuteReader();

                        if (reader.Read())
                        {
                            string ad_Soyad = reader["adsoyad"].ToString();
                            string Tc = reader["tc"].ToString();
                            string Dogumtarihi = reader["dogumtarihi"].ToString();
                            string Cinsiyet = reader["cinsiyet"].ToString();
                            string uyelik_Tipi = reader["uyeliktipi"].ToString();
                            

                            txt_AdSoyad.Text = ad_Soyad;
                            txt_tc.Text = Tc;
                            txt_DogumTarihi.Text = Dogumtarihi;
                            comboBox_cinsiyet.Text = Cinsiyet;
                            comboBox_uyelik_tipi.Text = uyelik_Tipi;
                            
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı bilgileri bulunamadı.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        Kullaniciislemleri kullaniciislemleri = new Kullaniciislemleri();

        private void btn_hesap_Guncelle_Click(object sender, EventArgs e)
        {
            int kullaniciId = this.kullaniciId;


             PrememiumKullanıcı.Fiyat();
            Standart.Fiyat();

            kullaniciislemleri.KullanıcıGuncelle(kullaniciId, txt_AdSoyad.Text, txt_tc.Text, DateTime.Parse(txt_DogumTarihi.Text), comboBox_cinsiyet.Text, comboBox_uyelik_tipi.Text);


        }

        private void btn_hesap_sil_Click(object sender, EventArgs e)
        {
            int kullaniciId = this.kullaniciId;

            kullaniciislemleri.KullanıcıSil(kullaniciId);

            Form Form1 = new Login();
            // Aktif olan Form5'i kapat
            this.Hide();
            Form1.Show();
        }

        private bool panel3_Puan_verVisible = true;


        private void btn_puan_ver_Click(object sender, EventArgs e)
        {
            int kullaniciId = this.kullaniciId;

            PrememiumKullanıcı.PuanVER(kullaniciId);


            // Kullanıcı adını, soyadını ve üyelik tipini al
            string sqlSorgusu = "SELECT uyeliktipi FROM kullanicitablosu WHERE kullaniciid = @kullaniciId";

            using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
            {
                using (NpgsqlCommand komut = new NpgsqlCommand(sqlSorgusu, baglanti))
                {
                    komut.Parameters.AddWithValue("@kullaniciId", kullaniciId);

                    try
                    {
                        baglanti.Open();
                        NpgsqlDataReader reader = komut.ExecuteReader();

                        if (reader.Read())
                        {
                           
                            string uyelikTipi = reader["uyeliktipi"].ToString();

                            if (string.Equals(uyelikTipi.Trim(), "Premium", StringComparison.OrdinalIgnoreCase))
                            {
                                if (panel3_Puan_verVisible)
                                {
                                    panel3.Visible = false;
                                }
                                else
                                {
                                    panel3.Visible = true;
                                }

                                panel3_Puan_verVisible = !panel3_Puan_verVisible;
                            }
                            else
                            {
                                panel3.Visible = false;
                                MessageBox.Show("Premium kullanıcı değilsiniz Puan veremesiniz \n Puanlamak İsterseniz Premium pakete Geçebilirsiniz \n\n \nStandart  Aylık Fiyat : 100 TL \n Premium  Aylık Fiyat : %25 İndirimli : 75 TL \n");
                                 
                                
                            }

                            baglanti.Close();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı bilgileri bulunamadı.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }


            

        }

       
       

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }


        private void btn_detay_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage__detay;

            lbl_f_ad.Text = txt_film_adi.Text;

            // txt_filmid'den film ID'sini al
            if (int.TryParse(txt_film_id.Text, out int filmId))
            {
                // TextBox'ları temizle
                txtDetayBilgi.Clear();

                // TextBox'a film bilgilerini ekle
                txtDetayBilgi.AppendText($"Film Adı : {txt_film_adi.Text}{Environment.NewLine}");
                txtDetayBilgi.AppendText($"Yönetmen : {txt_yönetmen.Text}{Environment.NewLine}");
                txtDetayBilgi.AppendText($"Oyuncular : {txt_oyuncular.Text}{Environment.NewLine}");
                txtDetayBilgi.AppendText($"Tür : {txt_film_turu.Text}{Environment.NewLine}");
                txtDetayBilgi.AppendText($"Yayın Yılı : {txt_yayın_yılı.Text}{Environment.NewLine}");
                txtDetayBilgi.AppendText($"Puan : {txt_degerlendirme_Puan.Text}{Environment.NewLine}");

                // Film_detay_tablosu'ndan verileri çek
                string detaySorgu = "SELECT film_icerigi FROM film_detay_tablosu WHERE filmid = @filmId";
                using (NpgsqlCommand detayKomut = new NpgsqlCommand(detaySorgu, baglanti))
                {
                    detayKomut.Parameters.AddWithValue("@filmId", filmId);
                    baglanti.Open();
                    NpgsqlDataReader detayReader = detayKomut.ExecuteReader();

                    if (detayReader.Read())
                    {
                        // film_detay_tablosu'ndan verileri al
                        string detayBilgi = detayReader["film_icerigi"].ToString();
                        // TextBox'a film detayını ekle
                        txtDetayBilgi.AppendText($"Film Detayı: {detayBilgi}");
                    }

                    baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("Geçerli bir film ID giriniz.");
            }

        }

        private void btn_begen_Click(object sender, EventArgs e)
        {
            // Form1'den getirilen kullanıcı ID
            int kullaniciId = this.kullaniciId;

            // Film ID'yi txt_film_id TextBox'ından al
            if (int.TryParse(txt_film_id.Text, out int filmId))
            {
                // kullanici işlemleri sınıfından consractırı cağiriyoruz 
                kullaniciislemleri.BegenmeListesineEkle(kullaniciId, filmId);
            }
            else
            {
                // txt_film_id.Text bir tamsayıya dönüştürülemedi.
                MessageBox.Show("Geçerli bir film ID giriniz.");
            }

        }

        private void btn_begenMe_Click(object sender, EventArgs e)
        {
            // Form1'den getirilen kullanıcı ID
            int kullaniciId = this.kullaniciId;

            // Film ID'yi txt_film_id TextBox'ından al
            if (int.TryParse(txt_film_id.Text, out int filmId))
            {
                // kullanici işlemleri sınıfından consractırı cağiriyoruz 
                kullaniciislemleri.BegenmeListesiCıkar(kullaniciId, filmId);
            }
            else
            {
                // txt_film_id.Text bir tamsayıya dönüştürülemedi.
                MessageBox.Show("Geçerli bir film ID giriniz.");
            }

        }

        private void btn_bgndgim_filmler_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage_begen;
         //   dataGridView3.Visible = true;


            // Form1'den getirilen kullanıcı ID
            int kullaniciId = this.kullaniciId;

            // Begenilen filmler tablosundaki verileri getiren sorgu
            string sqlSorgusu = @"
        SELECT f.filmid, f.ad, f.yonetmen, f.oyuncular, f.tur, f.yayinyili, f.degerlendirmepuani , f.resimdosyayolu
        FROM begenilenfilmlertablosu b
        INNER JOIN filmlertablosu f ON b.filmid = f.filmid
        WHERE b.kullaniciid = @kullaniciId";

            using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
            {
                using (NpgsqlCommand komut = new NpgsqlCommand(sqlSorgusu, baglanti))
                {
                    komut.Parameters.AddWithValue("@kullaniciId", kullaniciId);

                    try
                    {
                        baglanti.Open();

                        // Verileri DataGridView'e yükleyin
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(komut))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView3.DataSource = dt;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_izle_Click(object sender, EventArgs e)
        {

            // txt_filmid'den film ID'sini al
            if (int.TryParse(txt_film_id.Text, out int filmId))
            {
                // film_detay_tablosu'ndan video linkini çek
                string videoSorgu = "SELECT film_video FROM film_detay_tablosu WHERE filmid = @filmId";
                using (NpgsqlCommand videoKomut = new NpgsqlCommand(videoSorgu, baglanti))
                {
                    videoKomut.Parameters.AddWithValue("@filmId", filmId);
                    baglanti.Open();
                    object videoLinkObj = videoKomut.ExecuteScalar();

                    if (videoLinkObj != null)
                    {
                        // YouTube video linkini buraya ekleyin
                        string videoLink = videoLinkObj.ToString();

                        // YouTube video linkini varsayılan web tarayıcısında aç
                        Process.Start(videoLink);
                    }
                    else
                    {
                        MessageBox.Show("Film için video linki bulunamadı.");
                    }

                    baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("Geçerli bir film ID giriniz.");
            }


           
        }

        private void btn_detayKapat_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage_gorsel;
        }

        private void btn_yorum_kapat_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage_gorsel;
        }

        private void btn_degerlendirmeKapat_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage_gorsel;
        }

        private void btn_izledim_Click(object sender, EventArgs e)
        {

            // Form1'den getirilen kullanıcı ID
            int kullaniciId = this.kullaniciId;

            // Formdan film ID'yi txt_film_id TextBox'ından al
            int filmId;

            if (int.TryParse(txt_film_id.Text, out filmId))
            {
                // Beğenilen filmler tablosundan belirli bir kaydı sil
                string silmeSorgusu = "DELETE FROM izlemetablosu WHERE kullaniciid = @kullaniciId AND filmid = @filmId";

                using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
                {
                    using (NpgsqlCommand kontrolKomut = new NpgsqlCommand("SELECT COUNT(*) FROM izlemetablosu WHERE kullaniciid = @kullaniciId AND filmid = @filmId", baglanti))
                    {
                        kontrolKomut.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                        kontrolKomut.Parameters.AddWithValue("@filmId", filmId);

                        baglanti.Open();

                        object result = kontrolKomut.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            int kayitSayisi = Convert.ToInt32(result);

                            if (kayitSayisi > 0)
                            {
                                // Film beğenilen filmler listesinden çıkarıldı
                                using (NpgsqlCommand komut = new NpgsqlCommand(silmeSorgusu, baglanti))
                                {
                                    komut.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                                    komut.Parameters.AddWithValue("@filmId", filmId);

                                    try
                                    {
                                        komut.ExecuteNonQuery();
                                        MessageBox.Show("Film İzleme  Listesinden çıkarıldı.");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Bu film zaten İzleme  Listesinde Yok.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Kontrol sorgusundan beklenmeyen bir değer döndü.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Geçerli bir film ID giriniz.");
            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
