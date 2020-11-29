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
            List<Privilege> privilegesHardCoded = privilegeService.GetAllConstPrivileges();
            List<Privilege> privilegesOnDB = privilegeService.GetAll();

            foreach (var priv in privilegesHardCoded)
            {
                if (!IsHardCodedPrivInDB(priv,privilegesOnDB))
                {
                    privilegeService.Add(priv);
                }
            }
        }

        private static bool IsHardCodedPrivInDB(Privilege privilege, List<Privilege> privilegesOnDB)
        {
            foreach (var item in privilegesOnDB)
            {
                if (item.Name == privilege.Name)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
