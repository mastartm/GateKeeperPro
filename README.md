# GateKeeper-Pro — Şantiye Personel, Evrak ve Turnike Yönetim Sistemi

C# (WinForms) ve SQL Server ile geliştirilmiş, şantiye/saha ortamlarında personel evrak takibi, turnike geçiş simülasyonu ve muhasebe raporlaması için tasarlanmış bir masaüstü uygulaması.

🎥 **Demo videosu:** https://youtu.be/-pxKJYcPHq8

---

## Bu proje neden yapıldı

Bu proje, bir İK/Sistem Sorumlusu pozisyonu ilanında yer alan teknik gereksinimlere (network ve turnike sistemi yönetimi, OOP, SQL sorgulama/raporlama, evrak takibi) somut bir karşılık olarak tasarlandı. Amaç, ilandaki maddeleri gerçek, çalışan bir uygulama ile göstermekti.

---

## Özellikler

- **Personel & Taşeron Yönetimi** — personel kaydı, hangi taşerona ait olduğu, SGK/İSG evrak durumu
- **Turnike Simülasyonu** — kart okutma simülasyonu; evrak durumuna göre otomatik geçiş onayı/reddi, IP adresli log kaydı
- **Raporlama** — SQL View ve Stored Procedure ile gün/firma bazlı raporlama

---

## Mimari

```
Evrak yönetimi (Personel, Taşeron)  ─┐
                                      ├──> SQL Server ──> Raporlama (View / Stored Procedure)
Turnike & network (TurnikeLog)      ─┘
```

WinForms arayüzü, üç modülü tek bir pencerede `TabControl` ile sunar: **Personel Yönetimi | Turnike Simülasyonu | Raporlama**.

---

## Kullanılan teknolojiler

- **C# / .NET 8** — Windows Forms
- **SQL Server** — ilişkisel veritabanı, View, Stored Procedure
- **ADO.NET (Microsoft.Data.SqlClient)** — parametreli sorgular (SQL Injection korumalı)

---

## OOP prensipleri

| Prensip | Projedeki karşılığı |
|---|---|
| **Encapsulation** | `Personel.IsEvraklariTamam` — SGK ve İSG verilerinden otomatik hesaplanan, dışarıdan elle değiştirilemeyen property |
| **Inheritance** | `Personel : Kullanici`, `TaseronYetkilisi : Kullanici` — ortak alanlar (`AdSoyad`, `TcNo`, `KartNo`) temel sınıfta tutulur |
| **Polymorphism** | `Kullanici.Bilgi()` metodu `virtual`, her alt sınıf kendi `override`'ını sağlar |
| **Abstraction** | `TurnikeServisi.KartOkut()` — kart iptali, evrak kontrolü ve log oluşturma mantığının tamamı tek bir metod arkasında gizlenir |

---

## Veritabanı şeması

3 tablo, FK ilişkili: `Taseron` (1) → (N) `Personel` (1) → (N) `TurnikeLog`

```sql
CREATE TABLE Taseron (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirmaAdi NVARCHAR(100) NOT NULL,
    SozlesmeNo NVARCHAR(50) NULL
);

CREATE TABLE Personel (
    Id INT PRIMARY KEY IDENTITY(1,1),
    AdSoyad NVARCHAR(100) NOT NULL,
    TcNo NVARCHAR(11) NOT NULL,
    KartNo NVARCHAR(20) NOT NULL,
    TaseronId INT NOT NULL,
    SgkGirisiVar BIT NOT NULL DEFAULT 0,
    IsgBelgesiVar BIT NOT NULL DEFAULT 0,
    KartIptalMi BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Personel_Taseron FOREIGN KEY (TaseronId) REFERENCES Taseron(Id)
);

CREATE TABLE TurnikeLog (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PersonelId INT NOT NULL,
    Tarih DATETIME NOT NULL DEFAULT GETDATE(),
    IpAdresi NVARCHAR(15) NOT NULL,
    GecisOnaylandiMi BIT NOT NULL,
    RedNedeni NVARCHAR(200) NULL,
    CONSTRAINT FK_TurnikeLog_Personel FOREIGN KEY (PersonelId) REFERENCES Personel(Id)
);
```

Raporlama için 2 view + 1 stored procedure (`vw_GecisDetaylari`, `vw_RedEdilenGirisler`, `sp_FirmaBazliGirisSayisi`) — tam script `database/schema.sql` dosyasında.

---

## Nasıl çalışır (akış özeti)

1. **Personel Yönetimi** sekmesinde personel kaydı oluşturulur — taşeron seçilir, SGK/İSG durumu işaretlenir.
2. **Turnike Simülasyonu** sekmesinde bir personel ve simüle edilen turnikenin IP'si seçilip "Kart Okut" denir.
   - `TurnikeServisi.KartOkut()` kart iptali ve evrak durumunu kontrol eder.
   - Sonuç ekranda (yeşil/kırmızı panel) ve veritabanında (`TurnikeLog` tablosu) eş zamanlı tutulur.
3. **Raporlama** sekmesinde, View ve Stored Procedure çağrılarıyla gün/firma bazlı özet raporlar alınır.

---

## Kurulum

1. SQL Server'da `database/schema.sql` dosyasını çalıştırarak veritabanını oluştur.
2. `GateKeeperPro.sln` dosyasını Visual Studio ile aç.
3. `GateKeeperPro.UI` projesindeki `Form1.cs` içinde `connectionString` değişkenini kendi SQL Server sunucu adına göre güncelle.
4. `GateKeeperPro.UI` projesini başlangıç (Startup) projesi yap, F5 ile çalıştır.

---

## Proje yapısı

```
GateKeeperPro/              -> sınıf kütüphanesi (Kullanici, Personel, Taseron, TurnikeLog, TurnikeServisi)
GateKeeperPro.UI/           -> WinForms arayüzü
database/schema.sql         -> tablolar, view'ler, stored procedure
```
