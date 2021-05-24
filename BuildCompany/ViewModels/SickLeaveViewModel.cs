using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BuildCompany
{
  
    class SickLeaveViewModel : Bindable
    {
        buildcompanyContext Db;
        private SickleaveDatum selectedSickleaveData;
        public SickleaveDatum SelectedSickLeaveData
        {
            get { return selectedSickleaveData; }
            set
            {
                selectedSickleaveData = value;
                OnPropertyChanged("SelectedSickleaveData");
            }
        }

        ObservableCollection<SickleaveDatum> sickleaveDatas;
        public ObservableCollection<SickleaveDatum> SickleaveDatas
        {
            get { return sickleaveDatas; }
            set
            {
                sickleaveDatas = value;
                OnPropertyChanged("SickleaveDatas");
            }
        }

        public void DataRefresh()
        {
            Db = new buildcompanyContext();
            Db.SickleaveData.Load();
            SickleaveDatas = Db.SickleaveData.Local.ToObservableCollection();
            OnPropertyChanged("SickleaveDatas");
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
                        SickleaveDatum sickleaveData = new SickleaveDatum();
                        sickleaveData.IdSickLeaveData = 0;
                       
                        SickleaveDatas.Add(sickleaveData);
                        Db.SickleaveData.Add(sickleaveData);
                        Db.SaveChanges();
                        DataRefresh();
                        SelectedSickLeaveData = sickleaveData;
                    }
                    ));
            }

        }



        public MyCommand SaveCommand
        {

            get
            {
                return saveCommand ?? (saveCommand = new MyCommand(obj =>
                {
                    SickleaveDatum sickleaveData = obj as SickleaveDatum;
                    if (sickleaveData != null)
                    {
                        var newsickleaveData = Db.SickleaveData.Find(sickleaveData.IdSickLeaveData);
                        if (sickleaveData.IdSickLeaveData != 0)
                        {
                            Db.Employees.Load();
                            var empl = Db.Employees.Find(sickleaveData.IdEmployee);

                            if(empl != null)
                            {
                                empl.IdEmployeeStatus = 3;
                                Db.Entry(empl).State = EntityState.Modified;
                            }
                            

                            sickleaveData = newsickleaveData;
                            Db.Entry(sickleaveData).State = EntityState.Modified;
                            Db.SaveChanges();
                            DataRefresh();


                        }
                        else
                        {
                            Db.Employees.Load();
                            var empl = Db.Employees.Find(sickleaveData.IdEmployee);
                            if (empl != null)
                            {
                                empl.IdEmployeeStatus = 3;
                                Db.Entry(empl).State = EntityState.Modified;
                            }
                            Db.SickleaveData.Add(sickleaveData);

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
                        SickleaveDatum sickleaveData = obj as SickleaveDatum;
                        if (sickleaveData != null)
                        {
                            Db.SickleaveData.Load();
                            var newsickleaveData = Db.SickleaveData.Find(sickleaveData.IdSickLeaveData);
                            if (newsickleaveData != null)
                            {
                                Db.SickleaveData.Remove(sickleaveData);
                                Db.SaveChanges();
                                DataRefresh();
                            }
                            else
                            {

                                SickleaveDatas.Remove(sickleaveData);

                                DataRefresh();
                            }


                        }
                    }
                    ));
            }
        }

        public ObservableCollection<SickleaveStatus> SickleaveStatuses { get; set; }
        public IEnumerable<SickleaveStatusViewModel> SickleaveStatusViewModels { get; private set; }

        public class SickleaveStatusViewModel : Bindable
        {
            public SickleaveStatusViewModel(SickleaveStatus model)
            {
                Model = model;
                SickLeaveStatusName = Model.SickLeaveStatusName;
            }

            public string SickLeaveStatusName { get; set; }
            public SickleaveStatus Model { get; set; }
        }

        public ObservableCollection<Employee> Employees { get; set; }
        public IEnumerable<EmployeeViewModel> EmployeeViewModels { get; private set; }


        public class EmployeeViewModel : Bindable
        {
            public EmployeeViewModel(Employee model)
            {
                Model = model;
                EmployeeName = model.EmployeeLastName + " " + model.EmployeeFirstName + " " + model.EmployeePatronymic;
            }

            public string EmployeeName { get; set; }
            public Employee Model { get; set; }
        }

        public SickLeaveViewModel()
        {
            Db = new buildcompanyContext();
            
           
            try
            {
                Db.SickleaveData.Load();
                SickleaveDatas = Db.SickleaveData.Local.ToObservableCollection();

                Db.SickleaveStatuses.Load();
                SickleaveStatuses = Db.SickleaveStatuses.Local.ToObservableCollection();
                var sickleaveStatusViewModels = new List<SickleaveStatusViewModel>();
                foreach (var el in SickleaveStatuses)
                {
                    sickleaveStatusViewModels.Add(new SickleaveStatusViewModel(el));
                }
                SickleaveStatusViewModels = sickleaveStatusViewModels;


                Db.Employees.Load();
                Employees = Db.Employees.Local.ToObservableCollection();
                var employeeViewModels = new List<EmployeeViewModel>();
                foreach (var el in Employees)
                {
                    employeeViewModels.Add(new EmployeeViewModel(el));
                }
                EmployeeViewModels = employeeViewModels;
            }
            catch
            {

            }
            
        }
    }
}
