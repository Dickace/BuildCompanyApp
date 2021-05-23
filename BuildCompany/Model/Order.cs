using System;
using System.Collections.Generic;

#nullable disable

namespace BuildCompany
{
    public partial class Order
    {
        public Order()
        {
            MaterialLists = new HashSet<MaterialList>();
        }

        public int IdOrder { get; set; }
        public int IdClient { get; set; }
        public int? IdOrderStatus { get; set; }
        public int? IdTeam { get; set; }
        public int? OrderNumber { get; set; }
        public int? OrderSummary { get; set; }
        public DateTime? OrderEndingDate { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual OrderStatus IdOrderStatusNavigation { get; set; }
        public virtual Team IdTeamNavigation { get; set; }
        public virtual ICollection<MaterialList> MaterialLists { get; set; }
    }
}
