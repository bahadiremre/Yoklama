using Microsoft.Extensions.DependencyInjection;
using Restopos.Yoklama.Business.Concrete;
using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Extensions.ServiceExt
{
    public static class Dependencies
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICrudableDAL<>), typeof(EfCrudableRepository<>));
            services.AddScoped(typeof(IMultipleAddableDAL<>), typeof(EfMultipleAddableRepository<>));
            services.AddScoped(typeof(IMultipleRemovableDAL<>), typeof(EfMultipleRemovableRepository<>));
            services.AddScoped(typeof(ICreatableDAL<>), typeof(EfCreatableRepository<>));
            services.AddScoped(typeof(IUpdatableDAL<>), typeof(EfUpdatableRepository<>));
            services.AddScoped(typeof(IRemovableDAL<>), typeof(EfRemovableRepository<>));
            services.AddScoped(typeof(IReadableDAL<>), typeof(EfReadableRepository<>));

            services.AddScoped<IPrivilegeDAL, EfPrivilegeRepository>();
            services.AddScoped<IPrivilegeService, PrivilegeManager>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDAL, EfUserRepository>();

            services.AddScoped(typeof(IDepartmentService), typeof(DepartmentManager));
            services.AddScoped(typeof(IAbsenceTypeService), typeof(AbsenceTypeManager));

            services.AddScoped(typeof(IRoleService), typeof(RoleManager));
            services.AddScoped(typeof(IRoleDAL), typeof(EfRoleRepository));

            services.AddScoped(typeof(IRolePrivilegeService), typeof(RolePrivilegeManager));
            services.AddScoped(typeof(IRolePrivilegeDAL), typeof(EfRolePrivilegeRepository));

            services.AddScoped(typeof(IUserRoleService), typeof(UserRoleManager));
            services.AddScoped(typeof(IUserRoleDAL), typeof(EfUserRoleRepository));

            services.AddScoped(typeof(IAbsenceStatusService), typeof(AbsenceStatusManager));
            services.AddScoped(typeof(IAbsenceStatusDAL), typeof(EfAbsenceStatusRepository));
        }
    }
}
