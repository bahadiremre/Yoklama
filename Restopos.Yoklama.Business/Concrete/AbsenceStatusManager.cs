﻿using Restopos.Yoklama.Business.Interfaces;
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

        public List<AbsenceStatus> GetAllByDate(DateTime startDate, DateTime endDate)
        {
            return absenceStatusDAL.GetAllByDate(startDate, endDate);
        }

        public AbsenceStatus GetById(int id)
        {
            return absenceStatusDAL.GetById(id);
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
