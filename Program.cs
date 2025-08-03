using AidCare.Business.Abstract; // IUserService arayüzü
using AidCare.Business.Concrete; // UserManager sınıfı
using AidCare.DataAccess;
using AidCare.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore; // DbContext ve Npgsql için
using Microsoft.OpenApi.Models; // Swagger için

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // 1️⃣ Controller servislerini ekliyoruz (API uç noktaları için)
        builder.Services.AddControllers();

        // 2️⃣ Swagger/OpenAPI yapılandırması ekleniyor
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "AidCare API",
                Version = "v1"
            });
        });

        // 3️⃣ Veritabanı bağlantısını ayarlıyoruz (PostgreSQL)
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // 4️⃣ Bağımlılıkları (servisleri) projeye enjekte ediyoruz
        builder.Services.AddScoped<IUserService, UserManager>();
        builder.Services.AddScoped<IUserRepository, EfUserRepository>();

        // 5️⃣ CORS Politikası ekleniyor (Swagger üzerinden gelen istekler için önemli)
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        var app = builder.Build();

        // 6️⃣ CORS aktif ediliyor
        app.UseCors("AllowAll");

        // 7️⃣ Geliştirme ortamı için Swagger UI aktif ediliyor
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AidCare API v1");
            });
        }

        // 8️⃣ HTTPS yönlendirmesi aktif
        app.UseHttpsRedirection();

        // 9️⃣ Yetkilendirme middleware'i aktif (JWT vs. için)
        app.UseAuthorization();

        // 🔟 Controller route'larını API'ye bağlama
        app.MapControllers();

        // 🔚 Uygulamayı çalıştırma
        app.Run();
    }
}
