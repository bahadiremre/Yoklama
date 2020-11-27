using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Interfaces
{
    public interface IAbsenceStatusService : ICrudableService<AbsenceStatus>
    {
        List<AbsenceStatus> GetAllByDate(DateTime startDate, DateTime endDate);
    }
}
