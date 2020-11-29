using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Concrete
{
    public class AbsenceStatusManager : IAbsenceStatusService
    {
        private readonly IAbsenceStatusDAL absenceStatusDAL;
        public AbsenceStatusManager(IAbsenceStatusDAL absenceStatusDAL)
        {
            this.absenceStatusDAL = absenceStatusDAL;
        }

        public void Add(AbsenceStatus absenceStatus)
        {
            absenceStatusDAL.Add(absenceStatus);
        }

        public List<AbsenceStatus> GetAll()
        {
            return absenceStatusDAL.GetAll();
        }

        public List<AbsenceStatus> GetByDate(DateTime startDate, DateTime endDate)
        {
            return absenceStatusDAL.GetByDate(startDate, endDate);
        }

        public List<AbsenceStatus> GetByDate(DateTime startDate, DateTime endDate, int userId)
        {
            return absenceStatusDAL.GetByDate(startDate, endDate, userId);
        }

        public AbsenceStatus GetById(int id)
        {
            return absenceStatusDAL.GetById(id);
        }

        public List<AbsenceStatus> GetByType(int typeId)
        {
            return absenceStatusDAL.GetByType(typeId);
        }

        public void Remove(AbsenceStatus absenceStatus)
        {
            absenceStatusDAL.Remove(absenceStatus);
        }

        public void Update(AbsenceStatus absenceStatus)
        {
            absenceStatusDAL.Update(absenceStatus);
        }
    }
}
