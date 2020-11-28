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
    public class EfAbsenceStatusRepository : IAbsenceStatusDAL,ICrudableDAL<AbsenceStatus> 
    {
        private readonly ICrudableDAL<AbsenceStatus> crudableDAL;
        private readonly YoklamaDbContext db;
        public EfAbsenceStatusRepository(ICrudableDAL<AbsenceStatus> crudableDAL, YoklamaDbContext db)
        {
            this.crudableDAL = crudableDAL;
            this.db = db;
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
            List<AbsenceStatus> absenceStatuses = db.Set<AbsenceStatus>().
                Include(x => x.AbsenceType).Include(x => x.User).
                Where(x => x.StartDate >= startDate && x.StartDate <= endDate
                || x.EndDate >= startDate && x.EndDate <= endDate
                || startDate >= x.StartDate && endDate <= x.EndDate).ToList();
            return absenceStatuses;
        }

        public List<AbsenceStatus> GetAllByDate(DateTime startDate, DateTime endDate, int userId)
        {
            List<AbsenceStatus> absenceStatuses = db.Set<AbsenceStatus>().
                Include(x => x.AbsenceType).Include(x => x.User).
                Where(x => x.StartDate >= startDate && x.StartDate <= endDate
                || x.EndDate >= startDate && x.EndDate <= endDate
                || startDate >= x.StartDate && endDate <= x.EndDate
                && x.UserId == userId).ToList();
            return absenceStatuses;
        }

        public AbsenceStatus GetById(int id)
        {
            
            return db.Set<AbsenceStatus>().Include(x => x.AbsenceType).
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
