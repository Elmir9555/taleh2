using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendLahiye.Context;
using BackendLahiye.UniteOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BackendLahiye
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(_configuration["ConnectionStrings:Mssql"]);
            });

            services.AddScoped<IUow, Uow>();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Defaultareas",
                    pattern: "{area:exists}/{controller=Product}/{action=ProductList}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
