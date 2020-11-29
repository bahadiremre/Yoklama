using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restopos.Yoklama.Business.Concrete;
using Restopos.Yoklama.Business.Extensions.ServiceExt;
using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using Restopos.Yoklama.Entities.Concrete.Constants;
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
            services.AddDbContext<YoklamaDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
            {
                opt.LoginPath = "/Home/Index";
                opt.LogoutPath = "/Panel/Logout";
                opt.AccessDeniedPath = "/Panel/Index";
                opt.Cookie.HttpOnly = true;
                opt.Cookie.Name = "Rstps";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
            });

            services.AddAuthorization(conf =>
            {
                conf.AddPolicy(ConstPrivileges.ADD_DEPARTMENT, policy => policy.RequireClaim(ConstPrivileges.ADD_DEPARTMENT));
                conf.AddPolicy(ConstPrivileges.ADD_ROLE, policy => policy.RequireClaim(ConstPrivileges.ADD_ROLE));
                conf.AddPolicy(ConstPrivileges.ADD_USERS_ABSENCE, policy => policy.RequireClaim(ConstPrivileges.ADD_USERS_ABSENCE));
                conf.AddPolicy(ConstPrivileges.ADD_ABSENCETYPE, policy => policy.RequireClaim(ConstPrivileges.ADD_ABSENCETYPE));
                conf.AddPolicy(ConstPrivileges.DELETE_DEPARTMENT, policy => policy.RequireClaim(ConstPrivileges.DELETE_DEPARTMENT));
                conf.AddPolicy(ConstPrivileges.DELETE_ROLE, policy => policy.RequireClaim(ConstPrivileges.DELETE_ROLE));
                conf.AddPolicy(ConstPrivileges.DELETE_USER, policy => policy.RequireClaim(ConstPrivileges.DELETE_USER));
                conf.AddPolicy(ConstPrivileges.DELETE_USERS_ABSENCE, policy => policy.RequireClaim(ConstPrivileges.DELETE_USERS_ABSENCE));
                conf.AddPolicy(ConstPrivileges.DELETE_ABSENCETYPE, policy => policy.RequireClaim(ConstPrivileges.DELETE_ABSENCETYPE));
                conf.AddPolicy(ConstPrivileges.LIST_DEPARTMENTS, policy => policy.RequireClaim(ConstPrivileges.LIST_DEPARTMENTS));
                conf.AddPolicy(ConstPrivileges.LIST_PRIVILEGES, policy => policy.RequireClaim(ConstPrivileges.LIST_PRIVILEGES));
                conf.AddPolicy(ConstPrivileges.LIST_ROLES, policy => policy.RequireClaim(ConstPrivileges.LIST_ROLES));
                conf.AddPolicy(ConstPrivileges.LIST_USERS, policy => policy.RequireClaim(ConstPrivileges.LIST_USERS));
                conf.AddPolicy(ConstPrivileges.LIST_USERS_ABSENCES, policy => policy.RequireClaim(ConstPrivileges.LIST_USERS_ABSENCES));
                conf.AddPolicy(ConstPrivileges.LIST_ABSENCETYPES, policy => policy.RequireClaim(ConstPrivileges.LIST_ABSENCETYPES));
                conf.AddPolicy(ConstPrivileges.UPDATE_DEPARTMENT, policy => policy.RequireClaim(ConstPrivileges.UPDATE_DEPARTMENT));
                conf.AddPolicy(ConstPrivileges.UPDATE_PRIVILEGES_DESC, policy => policy.RequireClaim(ConstPrivileges.UPDATE_PRIVILEGES_DESC));
                conf.AddPolicy(ConstPrivileges.UPDATE_ROLE, policy => policy.RequireClaim(ConstPrivileges.UPDATE_ROLE));
                conf.AddPolicy(ConstPrivileges.UPDATE_USER, policy => policy.RequireClaim(ConstPrivileges.UPDATE_USER));
                conf.AddPolicy(ConstPrivileges.UPDATE_USERS_ABSENCE, policy => policy.RequireClaim(ConstPrivileges.UPDATE_USERS_ABSENCE));
                conf.AddPolicy(ConstPrivileges.UPDATE_ABSENCETYPE, policy => policy.RequireClaim(ConstPrivileges.UPDATE_ABSENCETYPE));
            });

            services.AddDependencies();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IPrivilegeService privilegeService, IRoleService roleService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/Home/StatusCodePage", "?code={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            PrivilegeInitializer.SeedData(privilegeService);
            RoleInitializer.SeedData(privilegeService, roleService);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id:int?}");
            });
        }
    }
}
