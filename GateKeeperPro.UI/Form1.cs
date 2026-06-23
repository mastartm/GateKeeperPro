using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GateKeeperPro;
using Microsoft.Data.SqlClient;

namespace GateKeeperPro.UI
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=MASTAR;Database=GateKeeperProDb;Trusted_Connection=True;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TaseronlariYukle();
            PersonelleriYukle();
            PersonelleriTurnikeComboYukle();
        }

        private void PersonelleriTurnikeComboYukle()
        {
            cmbPersonelTurnike.Items.Clear();

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            using (SqlCommand komut = new SqlCommand("SELECT Id, AdSoyad, TcNo, KartNo, TaseronId, SgkGirisiVar, IsgBelgesiVar, KartIptalMi FROM Personel", baglanti))
            {
                baglanti.Open();
                using (SqlDataReader okuyucu = komut.ExecuteReader())
                {
                    while (okuyucu.Read())
                    {
                        Personel p = new Personel
                        {
                            Id = okuyucu.GetInt32(0),
                            AdSoyad = okuyucu.GetString(1),
                            TcNo = okuyucu.GetString(2),
                            KartNo = okuyucu.GetString(3),
                            TaseronId = okuyucu.GetInt32(4),
                            SgkGirisiVar = okuyucu.GetBoolean(5),
                            IsgBelgesiVar = okuyucu.GetBoolean(6),
                            KartIptalMi = okuyucu.GetBoolean(7)
                        };
                        cmbPersonelTurnike.Items.Add(p);
                    }
                }
            }

            cmbPersonelTurnike.DisplayMember = "AdSoyad";
        }

        private void TaseronlariYukle()
        {
            cmbTaseron.Items.Clear();

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            using (SqlCommand komut = new SqlCommand("SELECT Id, FirmaAdi FROM Taseron", baglanti))
            {
                baglanti.Open();
                using (SqlDataReader okuyucu = komut.ExecuteReader())
                {
                    while (okuyucu.Read())
                    {
                        int id = okuyucu.GetInt32(0);
                        string firmaAdi = okuyucu.GetString(1);
                        cmbTaseron.Items.Add(new TaseronItem { Id = id, FirmaAdi = firmaAdi });
                    }
                }
            }

            cmbTaseron.DisplayMember = "FirmaAdi";
        }

        private void PersonelleriYukle()
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            using (SqlCommand komut = new SqlCommand("SELECT AdSoyad, TcNo, SgkGirisiVar, IsgBelgesiVar FROM Personel", baglanti))
            {
                baglanti.Open();
                using (SqlDataReader okuyucu = komut.ExecuteReader())
                {
                    dgvPersonel.Rows.Clear();
                    dgvPersonel.Columns.Clear();
                    dgvPersonel.Columns.Add("AdSoyad", "Ad Soyad");
                    dgvPersonel.Columns.Add("TcNo", "TC No");
                    dgvPersonel.Columns.Add("Sgk", "SGK");
                    dgvPersonel.Columns.Add("Isg", "ÝSG");

                    while (okuyucu.Read())
                    {
                        dgvPersonel.Rows.Add(
                            okuyucu.GetString(0),
                            okuyucu.GetString(1),
                            okuyucu.GetBoolean(2),
                            okuyucu.GetBoolean(3)
                        );
                    }
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text) || string.IsNullOrWhiteSpace(txtTcNo.Text))
            {
                MessageBox.Show("Ad Soyad ve TC No boþ olamaz!");
                return;
            }

            if (cmbTaseron.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir taþeron seçin!");
                return;
            }

            TaseronItem secilenTaseron = (TaseronItem)cmbTaseron.SelectedItem;

            Personel yeniPersonel = new Personel
            {
                AdSoyad = txtAdSoyad.Text,
                TcNo = txtTcNo.Text,
                TaseronId = secilenTaseron.Id,
                SgkGirisiVar = chkSgk.Checked,
                IsgBelgesiVar = chkIsg.Checked,
                KartIptalMi = false
            };

            string sorgu = @"INSERT INTO Personel (AdSoyad, TcNo, KartNo, TaseronId, SgkGirisiVar, IsgBelgesiVar, KartIptalMi)
                              VALUES (@AdSoyad, @TcNo, @KartNo, @TaseronId, @SgkGirisiVar, @IsgBelgesiVar, @KartIptalMi)";

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
            {
                komut.Parameters.AddWithValue("@AdSoyad", yeniPersonel.AdSoyad);
                komut.Parameters.AddWithValue("@TcNo", yeniPersonel.TcNo);
                komut.Parameters.AddWithValue("@KartNo", "0000");
                komut.Parameters.AddWithValue("@TaseronId", yeniPersonel.TaseronId);
                komut.Parameters.AddWithValue("@SgkGirisiVar", yeniPersonel.SgkGirisiVar);
                komut.Parameters.AddWithValue("@IsgBelgesiVar", yeniPersonel.IsgBelgesiVar);
                komut.Parameters.AddWithValue("@KartIptalMi", yeniPersonel.KartIptalMi);

                baglanti.Open();
                komut.ExecuteNonQuery();
            }

            MessageBox.Show("Personel kaydedildi!");

            txtAdSoyad.Clear();
            txtTcNo.Clear();
            chkSgk.Checked = false;
            chkIsg.Checked = false;

            PersonelleriYukle();
        }

        private void btnKartOkut_Click(object sender, EventArgs e)
        {
            if (cmbPersonelTurnike.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir personel seçin!");
                return;
            }

            Personel secilenPersonel = (Personel)cmbPersonelTurnike.SelectedItem;
            string ip = txtIpAdresi.Text;

            TurnikeServisi servis = new TurnikeServisi(connectionString);
            TurnikeLog sonuc = servis.KartOkut(secilenPersonel, ip);

            if (sonuc.GecisOnaylandiMi)
            {
                pnlSonuc.BackColor = Color.LightGreen;
                lblSonuc.Text = "GEÇÝÞ ONAYLANDI";
            }
            else
            {
                pnlSonuc.BackColor = Color.LightCoral;
                lblSonuc.Text = $"GEÇÝÞ REDDEDÝLDÝ: {sonuc.RedNedeni}";
            }

            string logSatiri = $"[{sonuc.Tarih:HH:mm:ss}] {secilenPersonel.AdSoyad} -> {(sonuc.GecisOnaylandiMi ? "ONAYLANDI" : "REDDEDÝLDÝ")}";
            lstLoglar.Items.Insert(0, logSatiri);
        }

        private void btnBugunGirisler_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM vw_GecisDetaylari";
            RaporGoster(sorgu);
        }

        private void btnReddedilenler_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM vw_RedEdilenGirisler";
            RaporGoster(sorgu);
        }

        private void btnFirmaRapor_Click(object sender, EventArgs e)
        {
            string sorgu = "EXEC sp_FirmaBazliGirisSayisi @Tarih = @p1";

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
            {
                komut.Parameters.AddWithValue("@p1", DateTime.Today);
                baglanti.Open();

                using (SqlDataReader okuyucu = komut.ExecuteReader())
                {
                    DataTable tablo = new DataTable();
                    tablo.Load(okuyucu);
                    dgvRapor.DataSource = tablo;
                }
            }
        }

        private void RaporGoster(string sorgu)
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
            {
                baglanti.Open();

                using (SqlDataReader okuyucu = komut.ExecuteReader())
                {
                    DataTable tablo = new DataTable();
                    tablo.Load(okuyucu);
                    dgvRapor.DataSource = tablo;
                }
            }
        }
    }

    public class TaseronItem
    {
        public int Id { get; set; }
        public string FirmaAdi { get; set; }

        public override string ToString()
        {
            return FirmaAdi;
        }
    }
}