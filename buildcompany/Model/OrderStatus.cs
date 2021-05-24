using System;
using System.Collections.Generic;

#nullable disable

namespace BuildCompany
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int IdOrderStatus { get; set; }
        public string OrderStatusName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
