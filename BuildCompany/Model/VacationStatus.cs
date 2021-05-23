using System;
using System.Collections.Generic;

#nullable disable

namespace BuildCompany
{
    public partial class VacationStatus
    {
        public VacationStatus()
        {
            VacationData = new HashSet<VacationDatum>();
        }

        public int IdVacationStatus { get; set; }
        public string VacationStatusName { get; set; }

        public virtual ICollection<VacationDatum> VacationData { get; set; }
    }
}
