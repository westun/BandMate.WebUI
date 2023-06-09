using BandMate.Domain.Core;
using BandMate.Domain.Persistence;
using BandMate.MusicCatalog.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BandMate.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(connectionString));
            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddDbContext<BandMateContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IArtistRepository, SpotifyArtistRepository>();


            builder.Services.AddTransient<SpotifySettings>(f =>
            {
                return new SpotifySettings
                {
                    ClientId = builder.Configuration.GetValue<string>("Spotify:ClientId"),
                    ClientSecret = builder.Configuration.GetValue<string>("Spotify:ClientSecret"),
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}