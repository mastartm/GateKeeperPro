-- ============================================
-- GateKeeper-Pro Veritabanı Şeması
-- ============================================

CREATE DATABASE GateKeeperProDb;
GO

USE GateKeeperProDb;
GO

-- ============================================
-- TABLOLAR
-- ============================================

CREATE TABLE Taseron (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirmaAdi NVARCHAR(100) NOT NULL,
    SozlesmeNo NVARCHAR(50) NULL
);
GO

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
GO

CREATE TABLE TurnikeLog (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PersonelId INT NOT NULL,
    Tarih DATETIME NOT NULL DEFAULT GETDATE(),
    IpAdresi NVARCHAR(15) NOT NULL,
    GecisOnaylandiMi BIT NOT NULL,
    RedNedeni NVARCHAR(200) NULL,
    CONSTRAINT FK_TurnikeLog_Personel FOREIGN KEY (PersonelId) REFERENCES Personel(Id)
);
GO

-- ============================================
-- ÖRNEK VERİ (isteğe bağlı, test amaçlı)
-- ============================================

INSERT INTO Taseron (FirmaAdi, SozlesmeNo) VALUES
('ABC İnşaat', 'SZ-2026-001'),
('XYZ Elektrik', 'SZ-2026-002');
GO

INSERT INTO Personel (AdSoyad, TcNo, KartNo, TaseronId, SgkGirisiVar, IsgBelgesiVar, KartIptalMi) VALUES
('Ahmet Yılmaz', '12345678901', '4502', 1, 1, 1, 0),
('Mehmet Demir', '98765432109', '4503', 1, 1, 0, 0),
('Ayşe Kara', '11122233344', '4504', 2, 1, 1, 0);
GO

INSERT INTO TurnikeLog (PersonelId, IpAdresi, GecisOnaylandiMi, RedNedeni) VALUES
(1, '192.168.1.50', 1, NULL),
(2, '192.168.1.51', 0, 'İSG Evrağı Eksik'),
(3, '192.168.1.52', 1, NULL);
GO

-- ============================================
-- RAPORLAMA: VIEW'LER
-- ============================================

-- Tüm geçiş kayıtlarının detaylı listesi
CREATE VIEW vw_GecisDetaylari AS
SELECT
    p.AdSoyad,
    t.FirmaAdi,
    l.Tarih,
    l.IpAdresi,
    l.GecisOnaylandiMi,
    l.RedNedeni
FROM TurnikeLog l
JOIN Personel p ON l.PersonelId = p.Id
JOIN Taseron t ON p.TaseronId = t.Id;
GO

-- Evrakı eksik olduğu halde girmeye çalışanlar
CREATE VIEW vw_RedEdilenGirisler AS
SELECT
    p.AdSoyad,
    t.FirmaAdi,
    l.Tarih,
    l.RedNedeni
FROM TurnikeLog l
JOIN Personel p ON l.PersonelId = p.Id
JOIN Taseron t ON p.TaseronId = t.Id
WHERE l.GecisOnaylandiMi = 0;
GO

-- ============================================
-- RAPORLAMA: STORED PROCEDURE
-- ============================================

-- Belirli bir tarihte hangi firmadan kaç kişi giriş yaptı
CREATE PROCEDURE sp_FirmaBazliGirisSayisi
    @Tarih DATE
AS
BEGIN
    SELECT
        t.FirmaAdi,
        COUNT(*) AS GirisSayisi
    FROM TurnikeLog l
    JOIN Personel p ON l.PersonelId = p.Id
    JOIN Taseron t ON p.TaseronId = t.Id
    WHERE CAST(l.Tarih AS DATE) = @Tarih
      AND l.GecisOnaylandiMi = 1
    GROUP BY t.FirmaAdi;
END
GO

-- ============================================
-- TEST SORGULARI (örnek kullanım)
-- ============================================

-- SELECT * FROM vw_GecisDetaylari;
-- SELECT * FROM vw_RedEdilenGirisler;
-- EXEC sp_FirmaBazliGirisSayisi @Tarih = '2026-06-23';
