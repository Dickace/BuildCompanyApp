using System;
using System.Collections.Generic;

#nullable disable

namespace BuildCompany
{
    public partial class EmpFunction
    {
        public EmpFunction()
        {
            Employees = new HashSet<Employee>();
        }

        public int IdEmployeeFunction { get; set; }
        public string EmployeeFunctionName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
