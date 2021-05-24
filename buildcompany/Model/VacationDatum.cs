using System;
using System.Collections.Generic;

#nullable disable

namespace BuildCompany
{
    public partial class VacationDatum
    {
        public int IdVacationData { get; set; }
        public int? IdVacationStatus { get; set; }
        public int? IdEmployee { get; set; }
        public DateTime? VacationStartDate { get; set; }
        public bool? PaidVacation { get; set; }
        public DateTime? VacationEndDate { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual VacationStatus IdVacationStatusNavigation { get; set; }
    }
}
