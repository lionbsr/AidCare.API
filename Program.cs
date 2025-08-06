using AidCare.Business.Abstract; // IUserService, IBloodGlucoseService
using AidCare.Business.Concrete; // UserManager, BloodGlucoseManager
using AidCare.DataAccess;
using AidCare.DataAccess.Abstract;
using AidCare.DataAccess.Concrete.EntityFramework;
using AidCare.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "AidCare API",
                Version = "v1"
            });
        });

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // 🔹 Dependency Injection
        builder.Services.AddScoped<IUserService, UserManager>();
        builder.Services.AddScoped<IUserRepository, EfUserRepository>();

        builder.Services.AddScoped<IBloodGlucoseService, BloodGlucoseManager>();
        builder.Services.AddScoped<IBloodGlucoseRepository, EfBloodGlucoseRepository>();

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

        app.UseCors("AllowAll");

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AidCare API v1");
            });
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
