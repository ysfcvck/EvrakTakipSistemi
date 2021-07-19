using EvrakTakipSistemi.CustomValidations;
using EvrakTakipSistemi.Models.Authentication;
using EvrakTakipSistemi.Models.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EvrakTakipSistemi
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddSession();
            services.AddDbContext<AppDbContext>(_ => _.UseSqlServer(Configuration["ConnectionStrings:SqlServerConnectionString"]));
            services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromHours(10));//******

            services.AddIdentity<AppUser, AppRole>(_ =>
            {
                _.Password.RequiredLength = 5; //En az kaç karakterli olmasý gerektiðini belirtiyoruz.
                _.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunluluðunu kaldýrýyoruz.
                _.Password.RequireLowercase = false; //Küçük harf zorunluluðunu kaldýrýyoruz.
                _.Password.RequireUppercase = false; //Büyük harf zorunluluðunu kaldýrýyoruz.
                _.Password.RequireDigit = false; //0-9 arasý sayýsal karakter zorunluluðunu kaldýrýyoruz.
                _.User.RequireUniqueEmail = true; //Email adreslerini tekilleþtiriyoruz.
                _.User.AllowedUserNameCharacters = "abcçdefghiýjklmnoöpqrsþtuüvwxyzABCÇDEFGHIÝJKLMNOÖPQRSÞTUÜVWXYZ0123456789-._@+"; //Kullanýcý adýnda geçerli olan karakterleri belirtiyoruz.
            }).AddPasswordValidator<CustomPasswordValidation>()
              .AddUserValidator<CustomUserValidation>()
              .AddErrorDescriber<CustomIdentityErrorDescriber>().AddEntityFrameworkStores<AppDbContext>()
              .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(_ =>
            {
                _.LoginPath = new PathString("/User/Login");
                _.Cookie = new CookieBuilder
                {
                    Name = "IdentityCookie", //Oluþturulacak Cookie'yi isimlendiriyoruz.
                    HttpOnly = false, //Kötü niyetli insanlarýn client-side tarafýndan Cookie'ye eriþmesini engelliyoruz.
                    //Expiration = TimeSpan.FromMinutes(2), //Oluþturulacak Cookie'nin vadesini belirliyoruz.
                    SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin gönderilmemesini belirtiyoruz.
                    SecurePolicy = CookieSecurePolicy.Always //HTTPS üzerinden eriþilebilir yapýyoruz.
                };
                _.SlidingExpiration = true; //Expiration süresinin yarýsý kadar süre zarfýnda istekte bulunulursa eðer geri kalan yarýsýný tekrar sýfýrlayarak ilk ayarlanan süreyi tazeleyecektir.
                _.ExpireTimeSpan = TimeSpan.FromMinutes(30); //CookieBuilder nesnesinde tanýmlanan Expiration deðerinin varsayýlan deðerlerle ezilme ihtimaline karþýn tekrardan Cookie vadesi burada da belirtiliyor.
                _.AccessDeniedPath = new PathString("/Authority/Page"); //Yetkisi olmayan kullanýcýlar yönlendiriliyor.
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseRouting();

            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Login}/{id?}");
            });
        }
    }
}
