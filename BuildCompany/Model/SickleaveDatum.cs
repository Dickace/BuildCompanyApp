using System;
using System.Collections.Generic;

#nullable disable

namespace BuildCompany
{
    public partial class SickleaveDatum
    {
        public int IdSickLeaveData { get; set; }
        public int? IdSickLeaveDataStatus { get; set; }
        public int? IdEmployee { get; set; }
        public DateTime? SickLeaveStartDate { get; set; }
        public bool? PaidSickLeave { get; set; }
        public string? SickLeaveNumber { get; set; }
        public DateTime? SickLeaveEndDate { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual SickleaveStatus IdSickLeaveDataStatusNavigation { get; set; }
    }
}
