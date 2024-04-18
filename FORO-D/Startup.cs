using FORO_D.Data;
using FORO_D.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FORO_D
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            #region Tipo de DB Provider a usar
            try
            {
                _dbInMemory = Configuration.GetValue<bool>("DbInMem");
            }
            catch
            {
                _dbInMemory = true;
            }
            #endregion


        }

        public IConfiguration Configuration { get; }

        public bool _dbInMemory = false;

        public void ConfigureServices(IServiceCollection services)
        {
            #region Tipo de DB provider a usar
            if (_dbInMemory)
            {
                services.AddDbContext<ForoContext>(options => options.UseInMemoryDatabase("ForoDB"));
            }
            else
            {
                services.AddDbContext<ForoContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ForoCS"))
                );
            }
            #endregion

            services.AddScoped<PrecargaDatos>();

            #region Identity
            services.AddIdentity<Usuario, Rol>().AddEntityFrameworkStores<ForoContext>();

            services.Configure<IdentityOptions>(
                opciones =>
                {
                    opciones.Password.RequiredLength = 8;
                }
                );
            #endregion
           
            services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
                opciones =>
                {
                    opciones.LoginPath = "/Account/IniciarSesion";
                    opciones.AccessDeniedPath = "/Account/AccesoDenegado";
                });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ForoContext foroContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var contexto = serviceScope.ServiceProvider.GetRequiredService<ForoContext>();

                if (!_dbInMemory)
            {
                foroContext.Database.Migrate();

            }
                serviceScope.ServiceProvider.GetService<PrecargaDatos>().TraerInformacionDeData();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            }
            );
        }
    }
}
