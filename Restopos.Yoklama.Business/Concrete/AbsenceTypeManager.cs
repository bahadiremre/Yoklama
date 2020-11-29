using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Concrete
{
    public class AbsenceTypeManager : IAbsenceTypeService
    {
        private readonly ICrudableDAL<AbsenceType> crudableDAL;
        public AbsenceTypeManager(ICrudableDAL<AbsenceType> crudableDAL)
        {
            this.crudableDAL = crudableDAL;
        }

        public void Add(AbsenceType absenceType)
        {
            crudableDAL.Add(absenceType);
        }

        public List<AbsenceType> GetAll()
        {
            return crudableDAL.GetAll();
        }

        public AbsenceType GetById(int id)
        {
            return crudableDAL.GetById(id);
        }

        public void Remove(AbsenceType absenceType)
        {
            crudableDAL.Remove(absenceType);
        }

        public void Update(AbsenceType absenceType)
        {
            crudableDAL.Update(absenceType);
        }
    }
}
