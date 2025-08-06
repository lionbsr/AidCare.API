🩺 AidCare.API (Yapay Zeka Destekli Diyabet Takip Sistemi)
Bu proje, diyabet hastalarının kan şekeri düzeylerini takip etmek, kayıt altına almak ve kullanıcıların verilerini düzenli olarak kontrol edebilmesini sağlamak amacıyla geliştirilmiş bir RESTful Web API uygulamasıdır.

💡 Özellikler
✅ Kullanıcı (hasta) kaydı, listeleme, güncelleme ve silme

✅ Kan şekeri (Blood Glucose) verisi ekleme, görüntüleme, güncelleme ve silme

✅ Aynı T.C. kimlik numarasıyla ikinci kayıt yapılamaması (benzersizlik kontrolü)

✅ Swagger arayüzü ile test imkanı

✅ Katmanlı mimari: Entities, DataAccess, Business, API

✅ PostgreSQL veritabanı kullanımı

✅ Entity Framework Core ile migration yönetimi
AidCare.API/
├── Controllers/           → API uç noktaları (User, BloodGlucose)
├── AidCare.Business/      → Servis katmanı (iş kuralları)
├── AidCare.DataAccess/    → Repository ve EF Core işlemleri
├── AidCare.Entities/      → Veri modelleri (User, BloodGlucose)
├── Migrations/            → EF Core migration dosyaları
├── Program.cs             → Uygulama yapılandırması
└── appsettings.json       → Veritabanı bağlantı ayarları
🧪 Swagger Test Paneli
Proje çalıştırıldığında Swagger otomatik olarak açılır:
📍 https://localhost:7165/swagger/index.html

Buradan:

POST /api/User ile kullanıcı ekleyebilir

POST /api/BloodGlucose ile kan şekeri verisi girebilirsin

🛠️ Kurulum ve Çalıştırma
PostgreSQL kurulu olduğundan emin olun

appsettings.json içindeki DefaultConnection alanını düzenleyin

Migration’ları çalıştırın:

bash
Kopyala
Düzenle
dotnet ef database update
Projeyi çalıştırın:

bash
Kopyala
Düzenle
dotnet run
🧠 Gelecekte Planlananlar
🔒 Kimlik doğrulama (JWT)

📈 Grafiksel veri analizi

🧬 Yapay zeka destekli öneri sistemi

👤 Geliştirici
Büşra Arslan
📍 Kocaeli Üniversitesi, Bilgisayar Mühendisliği
GitHub: @lionbsr
