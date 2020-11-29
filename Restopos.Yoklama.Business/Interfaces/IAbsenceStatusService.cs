using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Interfaces
{
    public interface IAbsenceStatusService : ICrudableService<AbsenceStatus>
    {
        List<AbsenceStatus> GetByDate(DateTime startDate, DateTime endDate);
        List<AbsenceStatus> GetByDate(DateTime startDate, DateTime endDate, int userId);
        List<AbsenceStatus> GetByType(int typeId);
    }
}
