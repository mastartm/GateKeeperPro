using GateKeeperPro;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

string connectionString = "Server=MASTAR;Database=GateKeeperProDb;Trusted_Connection=True;TrustServerCertificate=True;";

try
{
    using (SqlConnection baglanti = new SqlConnection(connectionString))
    {
        baglanti.Open();
        Console.WriteLine("Bağlantı başarılı!\n");

        string sorgu = "SELECT Id, AdSoyad, TcNo, KartNo, TaseronId, SgkGirisiVar, IsgBelgesiVar, KartIptalMi FROM Personel";

        using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
        using (SqlDataReader okuyucu = komut.ExecuteReader())
        {
            while (okuyucu.Read())
            {
                Personel p = new Personel();
                p.Id = okuyucu.GetInt32(0);
                p.AdSoyad = okuyucu.GetString(1);
                p.TcNo = okuyucu.GetString(2);
                p.KartNo = okuyucu.GetString(3);
                p.TaseronId = okuyucu.GetInt32(4);
                p.SgkGirisiVar = okuyucu.GetBoolean(5);
                p.IsgBelgesiVar = okuyucu.GetBoolean(6);
                p.KartIptalMi = okuyucu.GetBoolean(7);

                Console.WriteLine($"{p.AdSoyad} | Evrak Tamam: {p.IsEvraklariTamam} | Kart İptal: {p.KartIptalMi}");

            }
        }
    }
    Console.WriteLine("\n--- Turnike Simülasyonu ---\n");
    TurnikeServisi servis = new TurnikeServisi(connectionString);

    Personel mehmet = new Personel { Id = 2, AdSoyad = "Mehmet Demir", KartNo = "4503", SgkGirisiVar = true, IsgBelgesiVar = false, KartIptalMi = false };
    servis.KartOkut(mehmet, "192.168.1.51");

    Personel ahmet = new Personel { Id = 1, AdSoyad = "Ahmet Yılmaz", KartNo = "4502", SgkGirisiVar = true, IsgBelgesiVar = true, KartIptalMi = false };
    servis.KartOkut(ahmet, "192.168.1.50");
    Console.WriteLine("\n--- Polymorphism Testi ---\n");

    List<Kullanici> kullanicilar = new List<Kullanici>();
    kullanicilar.Add(new Personel { AdSoyad = "Ahmet Yılmaz", KartNo = "4502", SgkGirisiVar = true, IsgBelgesiVar = true });
    kullanicilar.Add(new TaseronYetkilisi { AdSoyad = "Fatma Şahin", KartNo = "9001", YetkiSeviyesi = 2 });

    foreach (Kullanici k in kullanicilar)
    {
        Console.WriteLine(k.Bilgi());
    }
}
catch (Exception ex)
{
    Console.WriteLine("Hata: " + ex.Message);
}