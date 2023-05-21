using AutoMapper;
using Ilk_MVC_Proyekt.Context;
using Ilk_MVC_Proyekt.Models.Mapping;
using Ilk_MVC_Proyekt.Services;
using Microsoft.EntityFrameworkCore;

namespace Ilk_MVC_Proyekt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ProductContext>(item => item.UseSqlServer("Server=Murad; Database=ProductDb; Trusted_Connection=True; TrustServerCertificate=True;"));

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IUserService, UserService>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Automapper());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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