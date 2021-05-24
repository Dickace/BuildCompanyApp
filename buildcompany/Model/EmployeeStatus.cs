using System;
using System.Collections.Generic;

#nullable disable

namespace BuildCompany
{
    public partial class EmployeeStatus
    {
        public EmployeeStatus()
        {
            Employees = new HashSet<Employee>();
        }

        public int IdEmployeeStatus { get; set; }
        public string EmployeeStatusName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
