using System;
using System.Collections.Generic;

#nullable disable

namespace BuildCompany
{
    public partial class TeamStatus
    {
        public TeamStatus()
        {
            Teams = new HashSet<Team>();
        }

        public int IdTeamStatus { get; set; }
        public string TeamStatusName { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
