using System;
using System.Collections.Generic;

#nullable disable

namespace BuildCompany
{
    public partial class SickleaveStatus
    {
        public SickleaveStatus()
        {
            SickleaveData = new HashSet<SickleaveDatum>();
        }

        public int IdSickLeaveStatus { get; set; }
        public string SickLeaveStatusName { get; set; }

        public virtual ICollection<SickleaveDatum> SickleaveData { get; set; }
    }
}
