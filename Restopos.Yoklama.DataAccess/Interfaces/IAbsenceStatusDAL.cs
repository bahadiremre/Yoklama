using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Interfaces
{
    public interface IAbsenceStatusDAL : ICrudableDAL<AbsenceStatus>
    {
        List<AbsenceStatus> GetAllByDate(DateTime startDate, DateTime endDate);
    }
}
