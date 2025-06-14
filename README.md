![image](https://github.com/user-attachments/assets/11b61d7f-9ba6-48be-822b-6c86fe07a80a)

# 📚 MVCProjectCamp

## 📝 Tanıtım

ASP.NET MVC mimarisiyle geliştirilmiş, çok katmanlı ve modüler yapıda bir eğitim/örnek proje uygulamasıdır. Kullanıcı yönetimi, blog, mesajlaşma, bildirim, rol tabanlı yetkilendirme ve istatistiksel raporlama gibi temel işlevleri içerir.

---

## 🚀 Özellikler

- 👤 Kullanıcı kayıt, giriş ve profil yönetimi
- 📝 Blog yazısı oluşturma, düzenleme ve silme
- 💬 Mesajlaşma sistemi (gelen/giden kutusu)
- 🔔 Bildirim yönetimi
- 🏷️ Kategori yönetimi
- 🎨 Admin paneli ve dinamik dashboard
- 📈 İstatistiksel raporlar ve grafikler
- 🔒 Rol tabanlı yetkilendirme ve oturum yönetimi
- 🌐 Responsive arayüz tasarımı (Bootstrap)

---

## 🏗️ Teknik Altyapı

- **Backend:** ASP.NET MVC 5, Entity Framework, C#
- **Frontend:** Razor View Engine, Bootstrap, jQuery
- **Veritabanı:** MSSQL (Code First veya Database First desteği)
- **Katmanlar:**
  - `Entities/` : Veri modelleri
  - `DataAccess/` : Entity Framework veri erişim katmanı
  - `Business/` : İş kuralları ve servisler
  - `Presentation/` : MVC controller ve view’lar
  - `Core/` : Ortak yardımcılar ve altyapı kodları
- **Güvenlik:** Kimlik doğrulama, cookie ile oturum, rol tabanlı erişim, validasyon
- **Ekstra:**  
  - Dinamik dashboard ve istatistik sayfaları
  - Loglama ve hata yönetimi

---

## 📂 Klasör Yapısı

```
MVCProjectCamp/
├── Business/         # Servisler ve iş kuralları
├── Core/             # Ortak altyapı ve yardımcı kodlar
├── DataAccess/       # Veri erişim katmanı (EF)
├── Entities/         # Model sınıfları
├── Presentation/     # MVC controller ve view’lar
├── Content/          # Statik dosyalar (CSS, JS, img)
├── App_Start/        # Konfigürasyonlar (Route, Filter vb.)
├── Web.config        # Uygulama ayarları
└── ...
```

---

## ⚙️ Kurulum & Kullanım

1. Projeyi klonlayın veya indirin.
2. MSSQL üzerinde veritabanı bağlantı ayarlarını `Web.config`’te yapın.
3. Gerekli NuGet paketlerini yükleyin (Entity Framework, Bootstrap vb.).
4. Visual Studio ile projeyi açıp çalıştırın.

---

## 🤝 Katkı

Katkı sağlamak için projeyi forklayabilir ve pull request gönderebilirsiniz.

---

## 📄 Lisans

Bu proje MIT lisansı ile sunulmuştur.
