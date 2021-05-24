using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#nullable disable

namespace BuildCompany
{
    public partial class Team
    {
        

        public Team()
        {
            EmployeeIdLeadTeamNavigations = new HashSet<Employee>();
            EmployeeIdTeamNavigations = new HashSet<Employee>();
            Orders = new HashSet<Order>();
        }

        public int IdTeam
        {
            get;
            set;
        }
        public int? IdEmployee
        {
            get;
            set;
        }
        public int? IdTeamStatus
        {
            get;
            set;
        }
        public int? TeamNumber
        {
            get;
            set;
        }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual TeamStatus IdTeamStatusNavigation { get; set; }
        public virtual ICollection<Employee> EmployeeIdLeadTeamNavigations { get; set; }
        public virtual ICollection<Employee> EmployeeIdTeamNavigations { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    
    }
}
