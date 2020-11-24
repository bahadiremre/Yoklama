using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restopos.Yoklama.Business.Concrete;
using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
            {
                opt.LoginPath = "/Home/Index";
                opt.LogoutPath = "/Panel/Logout";
                opt.Cookie.HttpOnly = true;
                opt.Cookie.Name = "Rstps";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
            });

            services.AddScoped<IUserDAL, EfUserRepository>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped(typeof(ICrudableService<User>), typeof(UserManager));
            services.AddScoped(typeof(ICrudableService<Department>), typeof(DepartmentManager));
            services.AddScoped(typeof(ICrudableDAL<User>), typeof(EfCrudableRepository<User>));
            services.AddScoped(typeof(ICrudableDAL<Department>), typeof(EfCrudableRepository<Department>));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
