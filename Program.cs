using bibliotech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace bibliotech
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BibliotechDb>(opt => opt.UseSqlite("Data Source=bibliotech.db"));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Ajoute des outils pour documenter l'API avec Swagger (exploration et g�n�ration de documentation).
            builder.Services.AddEndpointsApiExplorer();
            // D�finir une documentation pour l'API (titre, version, description, contact, etc.).
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "BibliotechAPI",
                    Version = "v1",
                    Description = "Une API pour g�rer des commandes",
                    Contact = new OpenApiContact
                    {
                        Name = "Legroupe",
                        Email = "legroupejla@example.com",
                        Url = new Uri("https://cheerful-travesseiro-ea025c.netlify.app/")
                    }
                });

                c.EnableAnnotations();
            });

            var app = builder.Build();
            // Construire l'application avec les services configur�s.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BibliotechAPI V1");
                    c.RoutePrefix = "swagger";
                });
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
