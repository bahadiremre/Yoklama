using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Initializer
{
    public static class PrivilegeInitializer
    {
        public static void SeedData(IPrivilegeService privilegeService)
        {
            List<Privilege> privileges = privilegeService.GetAllConstPrivileges();

            foreach (var priv in privileges)
            {
                if (privilegeService.GetByName(priv.Name) == null)
                {
                    privilegeService.Add(priv);
                }
            }
        }
    }
}
