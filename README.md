# MovieApp - Film Yönetim Sistemi 🎬

## 🎯 Proje Amacı

MovieApp, film severler ve sinema endüstrisi için kapsamlı bir film yönetim sistemi backend API'sidir. Bu proje, filmleri, oyuncuları, yönetmenleri, türleri ve kullanıcı yorumlarını yönetmeyi amaçlayan modern bir web API çözümüdür.

### Temel Özellikler:
- ✅ Film katalog yönetimi
- ✅ Oyuncu ve yönetmen profil yönetimi
- ✅ Film türü sınıflandırması
- ✅ Kullanıcı yorum ve değerlendirme sistemi
- ✅ En popüler filmler sıralaması
- ✅ Film-oyuncu ilişki yönetimi
- ✅ Kullanıcı profil yönetimi

## 🤔 Neden Bu Proje?

Modern sinema endüstrisinde film bilgilerinin merkezi bir sistemde yönetilmesi kritik önem taşımaktadır. Bu proje şu ihtiyaçları karşılamak için geliştirilmiştir:

- **Merkezi Film Veritabanı**: Tüm film bilgilerinin tek bir yerde toplanması
- **Kullanıcı Etkileşimi**: İzleyicilerin film deneyimlerini paylaşabilmesi
- **Veri Bütünlüğü**: İlişkisel veritabanı yapısı ile tutarlı veri yönetimi
- **Ölçeklenebilir Mimari**: Clean Architecture ile sürdürülebilir kod yapısı
- **Modern API**: RESTful tasarım prensipleriyle uyumlu endpoints

## 🛠️ Kullanılan Teknolojiler

### Backend Framework & Dil
- **ASP.NET Core 8.0** - Modern web API framework
- **C# 12** - Primary programming language

### Mimari Desenler
- **Clean Architecture** - Katmanlı mimari yapısı
- **CQRS (Command Query Responsibility Segregation)** - Komut ve sorgu ayrımı
- **Mediator Pattern** - Request/Response yönetimi
- **Repository Pattern** - Veri erişim katmanı soyutlaması

### Kütüphaneler & Paketler
```xml
<!-- Ana Framework Paketleri -->
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.13" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.13" />
<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="8.0.x" />

<!-- CQRS & Mediator -->
<PackageReference Include="MediatR" Version="11.0.0" />
<PackageReference Include="MediatR.Extensions.Microsoft.DependencyInjection" Version="11.0.0" />

<!-- Object Mapping -->
<PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.0" />

<!-- API Documentation -->
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2" />
```

### Veritabanı
- **PostgreSQL** - Ana veritabanı sistemi
- **Entity Framework Core** - ORM (Object-Relational Mapping)

### Proje Yapısı
```
MovieApp/
├── MovieApp.Api/                 # Web API katmanı
├── MovieApp.Application/         # İş mantığı katmanı
├── MovieApp.Domain/              # Domain modelleri
└── MovieApp.Infrastructure/      # Veri erişim katmanı
```

## 📦 Kurulum

### Ön Koşullar
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL 12+](https://www.postgresql.org/download/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) veya [VS Code](https://code.visualstudio.com/)

### 1. Projeyi Klonlayın
```bash
git clone https://github.com/zehrakbulut/movieapp.git
cd movieapp
```

### 2. Veritabanı Yapılandırması
`MovieApp.Api/appsettings.json` dosyasında PostgreSQL connection string'ini güncelleyin:
```json
{
  "ConnectionStrings": {
    "DefaultConnection" : "Host=localhost; Port=5432; Database=MovieAppDb; Username=postgres; Password=123456aA*"
  }
}
```

### 3. Paket Yükleme
```bash
dotnet restore
```

### 4. Veritabanı Migration
```bash
# Migration oluşturma
dotnet ef migrations add InitialMigration -p MovieApp.Infrastructure -s MovieApp.Api

# Veritabanını güncelleme
dotnet ef database update -p MovieApp.Infrastructure -s MovieApp.Api
```

### 5. Projeyi Çalıştırma
```bash
cd MovieApp.Api
dotnet run
```

API şu adreste erişilebilir olacak: `https://localhost:7188` veya `http://localhost:5274`

### 6. API Dokümantasyonu
Swagger UI: `https://localhost:7188/swagger`

## 🚀 API Endpoints

### 🎬 Film Yönetimi
```http
GET    /api/movies              # Tüm filmleri listele
GET    /api/movies/{id}         # Belirli film detayı
GET    /api/movies/top-movie    # En popüler filmler
POST   /api/movies              # Yeni film ekle
PUT    /api/movies/{id}         # Film güncelle
DELETE /api/movies              # Film sil
```

### 👤 Oyuncu Yönetimi
```http
GET    /api/actors              # Tüm oyuncuları listele
GET    /api/actors/{id}         # Belirli oyuncu detayı
POST   /api/actors              # Yeni oyuncu ekle
PUT    /api/actors/{id}         # Oyuncu güncelle
DELETE /api/actors              # Oyuncu sil
```

### 🎭 Yönetmen Yönetimi
```http
GET    /api/directors           # Tüm yönetmenleri listele
GET    /api/directors/{id}      # Belirli yönetmen detayı
POST   /api/directors           # Yeni yönetmen ekle
PUT    /api/directors/{id}      # Yönetmen güncelle
DELETE /api/directors           # Yönetmen sil
```

### 🎪 Tür Yönetimi
```http
GET    /api/genres              # Tüm türleri listele
GET    /api/genres/{id}         # Belirli tür detayı
POST   /api/genres              # Yeni tür ekle
PUT    /api/genres/{id}         # Tür güncelle
DELETE /api/genres              # Tür sil
```

### ⭐ Değerlendirme Yönetimi
```http
GET    /api/reviews             # Tüm yorumları listele
GET    /api/reviews/{id}        # Belirli yorum detayı
GET    /api/reviews/users/{userId}/reviews # Kullanıcı yorumları
POST   /api/reviews             # Yeni yorum ekle
PUT    /api/reviews/{id}        # Yorum güncelle
DELETE /api/reviews             # Yorum sil
```

### 👥 Kullanıcı Yönetimi
```http
GET    /api/users               # Tüm kullanıcıları listele
GET    /api/users/{id}          # Belirli kullanıcı detayı
POST   /api/users               # Yeni kullanıcı ekle
PUT    /api/users/{id}          # Kullanıcı güncelle
DELETE /api/users               # Kullanıcı sil
```

## 🏗️ Deployment

### Docker ile Deployment
```dockerfile
# Dockerfile örneği
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "MovieApp.Api.dll"]
```

**Happy Coding! 🚀**

ZEHRA AKBULUT ♡♡♡
