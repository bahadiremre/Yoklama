using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Concrete
{
    public class AbsenceStatusManager : ICrudableService<AbsenceStatus>
    {
        private readonly ICrudableDAL<AbsenceStatus> crudableDAL;
        public AbsenceStatusManager(ICrudableDAL<AbsenceStatus> crudableDAL)
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

        public AbsenceStatus GetById(int id)
        {
            return crudableDAL.GetById(id);
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
