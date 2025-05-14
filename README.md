# ADO.NET Customer Projesi

Bu proje, C# ve ADO.NET kullanılarak geliştirilmiş bir müşteri yönetim sistemidir. Proje içerisinde SQL Server veritabanı bağlantısı kurulmuş ve veriler `Customer` ve `City` tabloları üzerinden yönetilmektedir.

## 📁 Proje Özellikleri

- SQL Server ile bağlantı (ADO.NET)
- `Customer` ve `City` tablolarından veri çekme
- Windows Forms arayüzü
- FormMap üzerinden formlar arası geçiş

## 🧱 Kullanılan Teknolojiler

- C#
- ADO.NET
- Windows Forms
- SQL Server

## 🧭 Formlar

- **CustomerForm:** Müşteri listeleme ve ekleme işlemleri.
- **CityForm:** Şehirleri görüntüleme.
- **FormMap:** Formlar arası yönlendirme ve geçiş kontrolü.

## 🔧 Kurulum

1. SQL Server’da `CustomerDB` adında bir veritabanı oluşturun.
2. Tabloları oluşturun ve örnek veriler ekleyin.
3. Projeyi Visual Studio ile açın.
4. `app.config` dosyasından bağlantı cümlesini (`ConnectionString`) düzenleyin.
5. Uygulamayı çalıştırın
