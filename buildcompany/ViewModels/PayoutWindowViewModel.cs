using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCompany.ViewModels
{
    class PayoutWindowViewModel
    {


        public int? IdEpmoyee { get; set; }
        public string EmployeeName { get; set; }
        public int? PayoutForOrdres { get; set; }
        public string EmployeeCardNumber { get; set; }
        public string EmployeeTaxNumber { get; set; }
        public int? BonusesAndFines { get; set; }
        public int? TotalPayout { get; set; }

        public List<object> Employees { get; set; }

        buildcompanyContext Db;
        public PayoutWindowViewModel(EmployeePayout payout)
        {
            Db = new buildcompanyContext();
            Db.Employees.Load();
            Employees = new List<object>();
            var Empls = Db.Employees.Select(u => u.EmployeeLastName + " " + u.EmployeeFirstName +" "+ u.EmployeePatronymic );
            foreach (var el in Empls)
            {
                Employees.Add(el);
            }
            if (!payout.IdEmployee.HasValue)
            {

            }

            var dbdata = Db.Employees.Find(payout.IdEmployee);
            EmployeeName = dbdata.EmployeeLastName + " " + dbdata.EmployeeFirstName + " " + dbdata.EmployeePatronymic;
            PayoutForOrdres = payout.PayoutForOrders;
            EmployeeCardNumber = payout.EmployeeCardNumber;
            EmployeeCardNumber = payout.EmployeeCardNumber;
            BonusesAndFines = payout.BonusesAndFines;
            TotalPayout = payout.PayoutForOrders + payout.BonusesAndFines;

            IdEpmoyee = payout.IdEmployee;

        }

    }
}
