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
#pragma warning disable CS8632 // Аннотацию для ссылочных типов, допускающих значения NULL, следует использовать в коде только в контексте аннотаций "#nullable".
        public string? SickLeaveNumber { get; set; }
#pragma warning restore CS8632 // Аннотацию для ссылочных типов, допускающих значения NULL, следует использовать в коде только в контексте аннотаций "#nullable".
        public DateTime? SickLeaveEndDate { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual SickleaveStatus IdSickLeaveDataStatusNavigation { get; set; }
    }
}
