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
using Restopos.Yoklama.Web.Initializer;
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


            services.AddScoped<IPrivilegeDAL, EfPrivilegeRepository>();
            services.AddScoped<IPrivilegeService, PrivilegeManager>();
            services.AddScoped(typeof(ICreatableService<Privilege>), typeof(PrivilegeManager));
            services.AddScoped(typeof(IReadableService<Privilege>), typeof(PrivilegeManager));
            services.AddScoped(typeof(IUpdatableService<Privilege>), typeof(PrivilegeManager));
            services.AddScoped(typeof(IReadableDAL<Privilege>), typeof(EfReadableRepository<Privilege>));
            services.AddScoped(typeof(IUpdatableDAL<Privilege>), typeof(EfUpdatableRepository<Privilege>));
            services.AddScoped(typeof(ICreatableDAL<Privilege>), typeof(EfCreatableRepository<Privilege>));

            services.AddScoped<IUserDAL, EfUserRepository>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped(typeof(ICrudableService<User>), typeof(UserManager));
            services.AddScoped(typeof(ICrudableDAL<User>), typeof(EfCrudableRepository<User>));
            services.AddScoped(typeof(ICreatableDAL<User>), typeof(EfCreatableRepository<User>));
            services.AddScoped(typeof(IUpdatableDAL<User>), typeof(EfUpdatableRepository<User>));
            services.AddScoped(typeof(IRemovableDAL<User>), typeof(EfRemovableRepository<User>));
            services.AddScoped(typeof(IReadableDAL<User>), typeof(EfReadableRepository<User>));

            services.AddScoped(typeof(ICrudableService<Department>), typeof(DepartmentManager));
            services.AddScoped(typeof(ICreatableService<Department>), typeof(DepartmentManager));
            services.AddScoped(typeof(IUpdatableService<Department>), typeof(DepartmentManager));
            services.AddScoped(typeof(IRemovableService<Department>), typeof(DepartmentManager));

            services.AddScoped(typeof(ICrudableDAL<Department>), typeof(EfCrudableRepository<Department>));
            services.AddScoped(typeof(ICreatableDAL<Department>), typeof(EfCreatableRepository<Department>));
            services.AddScoped(typeof(IUpdatableDAL<Department>), typeof(EfUpdatableRepository<Department>));
            services.AddScoped(typeof(IRemovableDAL<Department>), typeof(EfRemovableRepository<Department>));
            services.AddScoped(typeof(IReadableDAL<Department>), typeof(EfReadableRepository<Department>));
            //////////
            services.AddScoped(typeof(ICrudableService<AbsenceType>), typeof(AbsenceTypeManager));
            services.AddScoped(typeof(ICreatableService<AbsenceType>), typeof(AbsenceTypeManager));
            services.AddScoped(typeof(IUpdatableService<AbsenceType>), typeof(AbsenceTypeManager));
            services.AddScoped(typeof(IRemovableService<AbsenceType>), typeof(AbsenceTypeManager));

            services.AddScoped(typeof(ICrudableDAL<AbsenceType>), typeof(EfCrudableRepository<AbsenceType>));
            services.AddScoped(typeof(ICreatableDAL<AbsenceType>), typeof(EfCreatableRepository<AbsenceType>));
            services.AddScoped(typeof(IUpdatableDAL<AbsenceType>), typeof(EfUpdatableRepository<AbsenceType>));
            services.AddScoped(typeof(IRemovableDAL<AbsenceType>), typeof(EfRemovableRepository<AbsenceType>));
            services.AddScoped(typeof(IReadableDAL<AbsenceType>), typeof(EfReadableRepository<AbsenceType>));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IPrivilegeService privilegeService)
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

            PrivilegeInitializer.SeedData(privilegeService);

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
