﻿using Restopos.Yoklama.Web.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Models
{
    public class AbsenceStatusesByDateViewModel
    {
        public List<AbsenceStatusViewModel> absenceStatuses { get; set; }
        [DateTimeLessThan("SearchingEndDate")]
        public DateTime SearchingStartDate { get; set; }
        public DateTime SearchingEndDate { get; set; }
    }
}
