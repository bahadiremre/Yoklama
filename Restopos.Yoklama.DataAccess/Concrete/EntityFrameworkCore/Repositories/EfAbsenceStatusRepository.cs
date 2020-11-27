using Microsoft.EntityFrameworkCore;
using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAbsenceStatusRepository : IAbsenceStatusDAL
    {
        private readonly ICrudableDAL<AbsenceStatus> crudableDAL;
        public EfAbsenceStatusRepository(ICrudableDAL<AbsenceStatus> crudableDAL)
        {
            this.crudableDAL = crudableDAL;
        }

        public void Add(AbsenceStatus absenceStatus)
        {
            crudableDAL.Add(absenceStatus);
        }

        public List<AbsenceStatus> GetAll()
        {
            return crudableDAL.GetAll();
        }

        public List<AbsenceStatus> GetAllByDate(DateTime startDate, DateTime endDate)
        {
            using var context = new SqlDbContext();
            List<AbsenceStatus> absenceStatuses = context.Set<AbsenceStatus>().
                Include(x => x.AbsenceType).Include(x => x.User).
                Where(x => x.StartDate >= startDate && x.StartDate <= endDate
                || x.EndDate >= startDate && x.EndDate <= endDate
                || startDate >= x.StartDate && endDate <= x.EndDate).ToList();
            return absenceStatuses;
        }

        public List<AbsenceStatus> GetAllByDate(DateTime startDate, DateTime endDate, int userId)
        {
            using var context = new SqlDbContext();
            List<AbsenceStatus> absenceStatuses = context.Set<AbsenceStatus>().
                Include(x => x.AbsenceType).Include(x => x.User).
                Where(x => x.StartDate >= startDate && x.StartDate <= endDate
                || x.EndDate >= startDate && x.EndDate <= endDate
                || startDate >= x.StartDate && endDate <= x.EndDate
                && x.UserId == userId).ToList();
            return absenceStatuses;
        }

        public AbsenceStatus GetById(int id)
        {
            using var context = new SqlDbContext();
            return context.Set<AbsenceStatus>().Include(x => x.AbsenceType).
                Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public void Remove(AbsenceStatus absenceStatus)
        {
            crudableDAL.Remove(absenceStatus);
        }

        public void Update(AbsenceStatus absenceStatus)
        {
            crudableDAL.Update(absenceStatus);
        }
    }
}
