using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Interfaces
{
    public interface IAbsenceStatusDAL : ICrudableDAL<AbsenceStatus>
    {
        List<AbsenceStatus> GetByDate(DateTime startDate, DateTime endDate);
        List<AbsenceStatus> GetByDate(DateTime startDate, DateTime endDate, int userId);
        List<AbsenceStatus> GetByType(int typeId);
    }
}
