using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace NumericSeries
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

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

            
            app.MapGet("/", context =>
            {
                context.Response.Redirect("/series/natural/0");
                return System.Threading.Tasks.Task.CompletedTask;
            });

            // ruta principal
            app.MapControllerRoute(
                name: "series",
                pattern: "series/{serie}/{n:int}",
                defaults: new { controller = "Series", action = "Index" });

            // ruta default
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}