using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Concrete
{
    public class DepartmentManager : ICrudableService<Department>
    {
        private readonly ICrudableDAL<Department> crudableDAL;
        public DepartmentManager(ICrudableDAL<Department> crudableDAL)
        {
            this.crudableDAL = crudableDAL;
        }

        public void Add(Department department)
        {
            crudableDAL.Add(department);
        }

        public List<Department> GetAll()
        {
            return crudableDAL.GetAll();
        }

        public Department GetById(int id)
        {
            return crudableDAL.GetById(id);
        }

        public void Remove(Department department)
        {
            crudableDAL.Remove(department);
        }

        public void Update(Department department)
        {
            crudableDAL.Update(department);
        }
    }
}
