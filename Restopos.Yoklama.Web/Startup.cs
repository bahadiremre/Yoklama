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

            //AddControllersWithViews kismina kadar olan alani refactor et
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
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/Home/StatusCodePage", "?code={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            PrivilegeInitializer.SeedData(privilegeService);
            UserRoleInitializer.SeedData(privilegeService, userService, roleService);

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
