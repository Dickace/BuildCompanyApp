using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using BuildCompany.ViewModels;

namespace BuildCompany
{
    class PayoutViewModel : Bindable

    {

        private EmployeePayout selectedPayout;

        public EmployeePayout SelectedPayout
        {
            get { return selectedPayout; }
            set
            {
              
                selectedPayout = value;
                if (selectedPayout != null)
                {
                    selectedPayout.TotalPayout = selectedPayout.PayoutForOrders + selectedPayout.BonusesAndFines;
                }
                
                OnPropertyChanged("SelectedPayout");
            }
        }
        public ObservableCollection<EmployeePayout> Payouts { get; set; }
      

        buildcompanyContext Db;
        public IEnumerable<PostPayoutModel> PostViewModels { get; private set; }

        public ObservableCollection<Employee> Employees { get; set; }
        public PayoutViewModel()
        {
            
            
            Db = new buildcompanyContext();
            try
            {
                Db.EmployeePayouts.Load();
                Payouts = Db.EmployeePayouts.Local.ToObservableCollection();
                foreach (var el in Payouts)
                {
                    el.TotalPayout = el.PayoutForOrders + el.BonusesAndFines;
                }
                Db.Employees.Load();
                Employees = Db.Employees.Local.ToObservableCollection();
                var postViewModels = new List<PostPayoutModel>();
                Db.SickleaveData.Load();
                Db.VacationData.Load();
                foreach (var el in Employees)
                {
                    if (el.IdEmployeeStatus != 1)
                    {
                        postViewModels.Add(new PostPayoutModel(el));


                    }
                    else if (el.IdEmployeeStatus == 3)
                    {

                        var s = Db.SickleaveData.Find(el.IdEmployee);
                        if (s.IdSickLeaveData != 0 && s.PaidSickLeave == true)
                        {
                            postViewModels.Add(new PostPayoutModel(el));
                        }
                    }
                    else if (el.IdEmployeeStatus == 4)
                    {
                        var s = Db.VacationData.Find(el.IdEmployee);
                        if (s.IdVacationData != 0 && s.PaidVacation == true)
                        {
                            postViewModels.Add(new PostPayoutModel(el));
                        }
                    }

                }
                PostViewModels = postViewModels;

            }
            catch
            {

            }



        }

        public class PostPayoutModel : Bindable
        {
            public PostPayoutModel(Employee model)
            {
                Model = model;
                EmployeeName = model.EmployeeLastName + " " + model.EmployeeFirstName + " " + model.EmployeePatronymic;
            }
            public string EmployeeName { get; set; }
            public Employee Model { get; set; }
        }


        private MyCommand addCommand;
        private MyCommand saveCommand;
        private MyCommand removeCommand;
        
        public MyCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new MyCommand(obj =>
                    {
                        EmployeePayout payout = new EmployeePayout();
                        payout.IdEmployeePayout = 0;

                        Payouts.Add(payout);
                        Db.EmployeePayouts.Add(payout);
                        Db.SaveChanges();
                        DataRefresh();
                        SelectedPayout = payout;
                    }));
            }
        }

        public void DataRefresh()
        {
            Db = new buildcompanyContext();
            Db.EmployeePayouts.Load();
            Payouts = Db.EmployeePayouts.Local.ToObservableCollection();
            OnPropertyChanged("Payouts");
        }
        public MyCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                    (saveCommand = new MyCommand(obj =>
                    {
                        EmployeePayout payout = obj as EmployeePayout;
                        if (payout != null)
                        {
                            
                            
                            var newpayout = Db.EmployeePayouts.Find(payout.IdEmployeePayout);
                            if (newpayout.IdEmployeePayout != 0) 
                            {

                                payout = newpayout;
                                payout.TotalPayout = payout.PayoutForOrders + payout.BonusesAndFines;
                                OnPropertyChanged("SelectedPayouts");
                                Db.Entry(payout).State = EntityState.Modified;
                                Db.SaveChanges();
                                DataRefresh();
                            }
                            else
                            {
                                payout.TotalPayout = payout.PayoutForOrders + payout.BonusesAndFines;
                                OnPropertyChanged("SelectedPayouts");
                                Db.EmployeePayouts.Add(payout);
                                Db.SaveChanges();
                                DataRefresh();
                            }
                           
                        }
                    }));
            }
        }
      
        public MyCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new MyCommand(obj =>
                    {
                        EmployeePayout payout = obj as EmployeePayout;
                        if (payout != null)
                        {
                            Db.EmployeePayouts.Load();
                            var newEmployeePayout = Db.EmployeePayouts.Find(payout.IdEmployeePayout);
                            if(newEmployeePayout != null)
                            {
                                Db.EmployeePayouts.Remove(payout);
                                Db.SaveChanges();
                                DataRefresh();
                            }
                            else
                            {
                                Payouts.Remove(payout);
                                DataRefresh();
                            }
                           
                        }
                        
                    }));
            }
        }

    }
}