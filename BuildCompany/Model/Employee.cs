using System;
using System.Collections.Generic;

#nullable disable

namespace BuildCompany
{
    public partial class Employee
    {
        public Employee()
        {
            SickleaveData = new HashSet<SickleaveDatum>();
            Teams = new HashSet<Team>();
            VacationData = new HashSet<VacationDatum>();
        }

        public int IdEmployee { get; set; }
        public int? IdTeam { get; set; }
        public int? IdEmployeeStatus { get; set; }
        public int? IdEmployeeFunction { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeePatronymic { get; set; }
        public string EmployeePassportData { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public string EmployeeEmail { get; set; }
        public int? IdLeadTeam { get; set; }

        public virtual EmpFunction IdEmployeeFunctionNavigation { get; set; }
        public virtual EmployeeStatus IdEmployeeStatusNavigation { get; set; }
        public virtual Team IdLeadTeamNavigation { get; set; }
        public virtual Team IdTeamNavigation { get; set; }
        public virtual ICollection<SickleaveDatum> SickleaveData { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<VacationDatum> VacationData { get; set; }
    }
}
