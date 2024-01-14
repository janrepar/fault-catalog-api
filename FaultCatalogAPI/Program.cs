
using FaultCatalogAPI.Data;
using FaultCatalogAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace FaultCatalogAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var CorsPolicy = "_CorsPolicy";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Register services.
            builder.Services.AddScoped<IFaultService, FaultService>();
            builder.Services.AddScoped<ISuccessCriterionService, SuccessCriterionService>();
            builder.Services.AddScoped<IFaultSuccessCriterionService, FaultSuccessCriterionService>();
            // Register db context.
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: CorsPolicy, policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(CorsPolicy);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
