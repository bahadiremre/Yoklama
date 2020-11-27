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
            services.AddScoped(typeof(ICrudableDAL<Department>), typeof(EfCrudableRepository<Department>));
            services.AddScoped(typeof(ICreatableDAL<Department>), typeof(EfCreatableRepository<Department>));
            services.AddScoped(typeof(IUpdatableDAL<Department>), typeof(EfUpdatableRepository<Department>));
            services.AddScoped(typeof(IRemovableDAL<Department>), typeof(EfRemovableRepository<Department>));
            services.AddScoped(typeof(IReadableDAL<Department>), typeof(EfReadableRepository<Department>));

            services.AddScoped(typeof(ICrudableService<AbsenceType>), typeof(AbsenceTypeManager));
            services.AddScoped(typeof(ICrudableDAL<AbsenceType>), typeof(EfCrudableRepository<AbsenceType>));
            services.AddScoped(typeof(ICreatableDAL<AbsenceType>), typeof(EfCreatableRepository<AbsenceType>));
            services.AddScoped(typeof(IUpdatableDAL<AbsenceType>), typeof(EfUpdatableRepository<AbsenceType>));
            services.AddScoped(typeof(IRemovableDAL<AbsenceType>), typeof(EfRemovableRepository<AbsenceType>));
            services.AddScoped(typeof(IReadableDAL<AbsenceType>), typeof(EfReadableRepository<AbsenceType>));

            services.AddScoped(typeof(IRoleService), typeof(RoleManager));
            services.AddScoped(typeof(IRoleDAL), typeof(EfRoleRepository));
            services.AddScoped(typeof(ICrudableDAL<Role>), typeof(EfCrudableRepository<Role>));
            services.AddScoped(typeof(ICreatableDAL<Role>), typeof(EfCreatableRepository<Role>));
            services.AddScoped(typeof(IUpdatableDAL<Role>), typeof(EfUpdatableRepository<Role>));
            services.AddScoped(typeof(IRemovableDAL<Role>), typeof(EfRemovableRepository<Role>));
            services.AddScoped(typeof(IReadableDAL<Role>), typeof(EfReadableRepository<Role>));

            services.AddScoped(typeof(IRolePrivilegeService), typeof(RolePrivilegeManager));
            services.AddScoped(typeof(ICrudableService<RolePrivilege>), typeof(RolePrivilegeManager));
            services.AddScoped(typeof(IRolePrivilegeDAL), typeof(EfRolePrivilegeRepository));
            services.AddScoped(typeof(ICrudableDAL<RolePrivilege>), typeof(EfCrudableRepository<RolePrivilege>));
            services.AddScoped(typeof(IMultipleAddableDAL<RolePrivilege>), typeof(EfMultipleAddableRepository<RolePrivilege>));
            services.AddScoped(typeof(IMultipleRemovableDAL<RolePrivilege>), typeof(EfMultipleRemovableRepository<RolePrivilege>));
            services.AddScoped(typeof(ICreatableDAL<RolePrivilege>), typeof(EfCreatableRepository<RolePrivilege>));
            services.AddScoped(typeof(IUpdatableDAL<RolePrivilege>), typeof(EfUpdatableRepository<RolePrivilege>));
            services.AddScoped(typeof(IRemovableDAL<RolePrivilege>), typeof(EfRemovableRepository<RolePrivilege>));
            services.AddScoped(typeof(IReadableDAL<RolePrivilege>), typeof(EfReadableRepository<RolePrivilege>));

            services.AddScoped(typeof(IUserRoleService), typeof(UserRoleManager));
            services.AddScoped(typeof(ICrudableService<UserRole>), typeof(UserRoleManager));
            services.AddScoped(typeof(IUserRoleDAL), typeof(EfUserRoleRepository));
            services.AddScoped(typeof(ICrudableDAL<UserRole>), typeof(EfCrudableRepository<UserRole>));
            services.AddScoped(typeof(IMultipleAddableDAL<UserRole>), typeof(EfMultipleAddableRepository<UserRole>));
            services.AddScoped(typeof(IMultipleRemovableDAL<UserRole>), typeof(EfMultipleRemovableRepository<UserRole>));
            services.AddScoped(typeof(ICreatableDAL<UserRole>), typeof(EfCreatableRepository<UserRole>));
            services.AddScoped(typeof(IUpdatableDAL<UserRole>), typeof(EfUpdatableRepository<UserRole>));
            services.AddScoped(typeof(IRemovableDAL<UserRole>), typeof(EfRemovableRepository<UserRole>));
            services.AddScoped(typeof(IReadableDAL<UserRole>), typeof(EfReadableRepository<UserRole>));

            services.AddScoped(typeof(IAbsenceStatusService), typeof(AbsenceStatusManager));
            services.AddScoped(typeof(ICrudableService<AbsenceStatus>), typeof(AbsenceStatusManager));
            services.AddScoped(typeof(IAbsenceStatusDAL), typeof(EfAbsenceStatusRepository));
            services.AddScoped(typeof(ICrudableDAL<AbsenceStatus>), typeof(EfCrudableRepository<AbsenceStatus>));
            services.AddScoped(typeof(ICreatableDAL<AbsenceStatus>), typeof(EfCreatableRepository<AbsenceStatus>));
            services.AddScoped(typeof(IUpdatableDAL<AbsenceStatus>), typeof(EfUpdatableRepository<AbsenceStatus>));
            services.AddScoped(typeof(IRemovableDAL<AbsenceStatus>), typeof(EfRemovableRepository<AbsenceStatus>));
            services.AddScoped(typeof(IReadableDAL<AbsenceStatus>), typeof(EfReadableRepository<AbsenceStatus>));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env, IPrivilegeService privilegeService,
            IUserService userService, IRoleService roleService)
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
            UserRoleInitializer.SeedData(privilegeService, userService, roleService);

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
