using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCompany
{
    class VacationViewModel: Bindable
    {
        buildcompanyContext Db;
        private VacationDatum selectedVacationData;
        public VacationDatum SelectedVacationData
        {
            get { return selectedVacationData; }
            set
            {
                selectedVacationData = value;
                OnPropertyChanged("SelectedVacationData");
            }
        }

        ObservableCollection<VacationDatum> vacationDatas;
        public ObservableCollection<VacationDatum> VacationDatas
        {
            get { return vacationDatas; }
            set
            {
                vacationDatas = value;
                OnPropertyChanged("VacationDatas");
            }
        }

        public void DataRefresh()
        {
            Db = new buildcompanyContext();
            Db.VacationData.Load();
            VacationDatas = Db.VacationData.Local.ToObservableCollection();
            OnPropertyChanged("VacationDatas");
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
                        VacationDatum vacationData = new VacationDatum();
                        vacationData.IdVacationData = 0;
                        vacationData.IdVacationStatus = 0;
                        vacationDatas.Add(vacationData);
                        Db.VacationData.Add(vacationData);
                        Db.SaveChanges();
                        DataRefresh();
                        var nvacations = Db.VacationData.OrderBy(nvacation => nvacation.IdVacationData);
                        SelectedVacationData = nvacations.Last();
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
                    VacationDatum vacationData = obj as VacationDatum;
                    if (vacationData != null)
                    {
                        var newvacationData = Db.VacationData.Find(vacationData.IdVacationData);
                        if (vacationData.IdVacationData != 0)
                        {
                            Db.Employees.Load();
                            var empl = Db.Employees.Find(vacationData.IdEmployee);
                            if(empl != null)
                            {
                                empl.IdEmployeeStatus = 4;
                                Db.Entry(empl).State = EntityState.Modified;
                            }
                            vacationData = newvacationData;
                            Db.Entry(vacationData).State = EntityState.Modified;
                            Db.SaveChanges();
                            DataRefresh();


                        }
                        else
                        {
                            Db.Employees.Load();
                            var empl = Db.Employees.Find(vacationData.IdEmployee);
                            if (empl != null)
                            {
                                empl.IdEmployeeStatus = 4;
                                Db.Entry(empl).State = EntityState.Modified;
                            }

                            Db.VacationData.Add(vacationData);

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
                        VacationDatum vacationData = obj as VacationDatum;
                        if (vacationData != null)
                        {
                            Db.VacationData.Load();
                            var newVacationData = Db.VacationData.Find(vacationData.IdVacationData);
                            
                            if (newVacationData !=null)
                            {
                                Db.VacationData.Remove(vacationData);
                                Db.SaveChanges();
                                DataRefresh();

                             
                            }
                            else
                            {
                                VacationDatas.Remove(vacationData);
                                DataRefresh();

                            }


                        }
                    },obj=> selectedVacationData!=null));
            }
        }

        public ObservableCollection<VacationStatus> VacationStatuses { get; set; }
        public IEnumerable<VacationStatusViewModel> VacationStatusViewModels { get; private set; }

        public class VacationStatusViewModel : Bindable
        {
            public VacationStatusViewModel(VacationStatus model)
            {
                Model = model;
                VacationStatusName = Model.VacationStatusName;
            }

            public string VacationStatusName { get; set; }
            public VacationStatus Model { get; set; }
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

        public VacationViewModel()
        {
            Db = new buildcompanyContext();


            try
            {
                Db.VacationData.Load();
                VacationDatas = Db.VacationData.Local.ToObservableCollection();

                Db.VacationStatuses.Load();
                VacationStatuses = Db.VacationStatuses.Local.ToObservableCollection();
                var vacationStatusViewModels = new List<VacationStatusViewModel>();
                foreach (var el in VacationStatuses)
                {
                    vacationStatusViewModels.Add(new VacationStatusViewModel(el));
                }
                VacationStatusViewModels = vacationStatusViewModels;


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
