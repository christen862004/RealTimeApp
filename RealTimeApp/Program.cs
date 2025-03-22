using Microsoft.EntityFrameworkCore;
using RealTimeApp.Hubs;
using RealTimeApp.Models;

namespace RealTimeApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            builder.Services.AddSignalR();//register all hubs

            builder.Services.AddDbContext<ShopingContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("CS"))
                ); ;
            //web service
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(url => true)
                    .AllowCredentials();
                   
                });
            });
            /* .SetIsOriginAllowed(url => {
                         if (url == "http://127.0.0.1:51141/")
                             return true;
                         return false;
                     });*/
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseCors();//add middleware cross orgininal request 

            app.UseRouting();

            app.UseAuthorization();
            
            app.MapHub<ChatHub>("/Chat");
            app.MapHub<ProductHub>("/ProductHub");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
