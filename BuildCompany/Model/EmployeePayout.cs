using System;
using System.Collections.Generic;

#nullable disable

namespace BuildCompany
{
    public partial class EmployeePayout
    {
        public int IdEmployeePayout { get; set; }
        public int? IdEmployee { get; set; }
        public int? PayoutForOrders { get; set; }
        public string EmployeeCardNumber { get; set; }
        public string EmployeeTaxNumber { get; set; }
        public int? BonusesAndFines { get; set; }
        public int? TotalPayout { get; set; }
    }
}
