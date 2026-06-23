using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace GateKeeperPro
{
    public class TurnikeServisi
    {
        private string connectionString;

        public TurnikeServisi(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public TurnikeLog KartOkut(Personel personel, string ipAdresi)
        {
            TurnikeLog log = new TurnikeLog();
            log.Personel = personel;
            log.IpAdresi = ipAdresi;
            log.Tarih = DateTime.Now;

            if (personel.KartIptalMi)
            {
                log.GecisOnaylandiMi = false;
                log.RedNedeni = "Kart İptal Edilmiş";
            }
            else if (!personel.IsEvraklariTamam)
            {
                log.GecisOnaylandiMi = false;
                log.RedNedeni = "Evrak Eksik (SGK/İSG)";
            }
            else
            {
                log.GecisOnaylandiMi = true;
                log.RedNedeni = null;
            }

            string durum = log.GecisOnaylandiMi ? "GEÇİŞ ONAYLANDI" : $"GEÇİŞ REDDEDİLDİ (Neden: {log.RedNedeni})";
            Console.WriteLine($"[{log.Tarih:yyyy-MM-dd HH:mm:ss}] [IP: {log.IpAdresi}] Kart No: {personel.KartNo} -> {durum} (İşçi: {personel.AdSoyad})");

            KaydetVeritabanina(log);

            return log;
        }

        private void KaydetVeritabanina(TurnikeLog log)
        {
            string sorgu = @"INSERT INTO TurnikeLog (PersonelId, Tarih, IpAdresi, GecisOnaylandiMi, RedNedeni)
                              VALUES (@PersonelId, @Tarih, @IpAdresi, @GecisOnaylandiMi, @RedNedeni)";

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
            {
                komut.Parameters.AddWithValue("@PersonelId", log.Personel.Id);
                komut.Parameters.AddWithValue("@Tarih", log.Tarih);
                komut.Parameters.AddWithValue("@IpAdresi", log.IpAdresi);
                komut.Parameters.AddWithValue("@GecisOnaylandiMi", log.GecisOnaylandiMi);
                komut.Parameters.AddWithValue("@RedNedeni", log.RedNedeni ?? (object)DBNull.Value);

                baglanti.Open();
                komut.ExecuteNonQuery();
            }
        }
    }
}