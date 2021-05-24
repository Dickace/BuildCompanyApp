using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System;

namespace BuildCompany
{
    class EmployeeViewModel : Bindable
    {

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }

        buildcompanyContext Db { get; set; }

        public ObservableCollection<Employee> Employees { get; set; }


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
                        Employee employee = new Employee();
                        employee.IdEmployeeStatus = 0;
                        Employees.Add(employee);
                        Db.Employees.Add(employee);
                        Db.SaveChanges();
                        DataRefresh();
                        SelectedEmployee = employee;
                    }
                    ));
            }

        }

        public void DataRefresh()
        {
            Db = new buildcompanyContext();
            Db.Employees.Load();
            Employees = Db.Employees.Local.ToObservableCollection();
            OnPropertyChanged("Employees");
        }

        public MyCommand SaveCommand
        {

            get
            {
                return saveCommand ?? (saveCommand = new MyCommand(obj =>
                {
                    Employee employee = obj as Employee;
                    if (employee != null)
                    {
                        var newemployee = Db.Employees.Find(employee.IdEmployee);
                        if (newemployee.IdEmployee != 0)
                        {
                            
                            employee = newemployee;
                            Db.Entry(employee).State = EntityState.Modified;
                            Db.SaveChanges();
                        }
                        else
                        {
                            Db.Employees.Add(employee);

                            Db.SaveChanges();
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
                        Employee employee = obj as Employee;
                        if (employee != null)
                        {
                            Db.Employees.Load();
                            var newemployee = Db.Employees.Find(employee.IdEmployee);
                            if (newemployee != null)
                            {
                                Db.Employees.Remove(employee);
                                Db.SaveChanges();
                                DataRefresh();
                            }
                            else
                            {

                                Employees.Remove(employee);
                                DataRefresh();

                            }


                        }
                    }));
            }
        }


        public ObservableCollection<EmployeeStatus> EmployeeStatuses { get; set; }
        public IEnumerable<EmployeeStatusViewModel> EmployeeStatusViewModels { get; private set; }

        public class EmployeeStatusViewModel : Bindable
        {
            public EmployeeStatusViewModel(EmployeeStatus model)
            {
                Model = model;
                EmployeeStatusName = Model.EmployeeStatusName;
            }

            public string EmployeeStatusName { get; set; }
            public EmployeeStatus Model { get; set; }
        }
        public ObservableCollection<EmpFunction> EmployeeFunctions { get; set; }
        public IEnumerable<EmployeeFunctionViewModel> EmployeeFunctionViewModels { get; private set; }

        public class EmployeeFunctionViewModel : Bindable
        {
            public EmployeeFunctionViewModel(EmpFunction model)
            {
                Model = model;
                EmployeeFunctionName = Model.EmployeeFunctionName;
            }

            public string EmployeeFunctionName { get; set; }
            public EmpFunction Model { get; set; }
        }

        public ObservableCollection<Team> Teams { get; set; }
        public IEnumerable<TeamViewModel> TeamViewModels { get; private set; }

        public class TeamViewModel : Bindable
        {
            public TeamViewModel(Team model)
            {
                Model = model;
                TeamNumber = Model.TeamNumber;
            }

            public int? TeamNumber { get; set; }
            public Team Model { get; set; }
        }

        public EmployeeViewModel()
        {
           
            Db = new buildcompanyContext();
            try
            {
                Db.Employees.Load();
                Employees = Db.Employees.Local.ToObservableCollection();

                Db.EmployeeStatuses.Load();
                EmployeeStatuses = Db.EmployeeStatuses.Local.ToObservableCollection();
                var orderStatusViewModels = new List<EmployeeStatusViewModel>();
                foreach (var el in EmployeeStatuses)
                {
                    orderStatusViewModels.Add(new EmployeeStatusViewModel(el));
                }
                EmployeeStatusViewModels = orderStatusViewModels;

                Db.EmpFunctions.Load();
                EmployeeFunctions = Db.EmpFunctions.Local.ToObservableCollection();
                var employeeFunctionViewModels = new List<EmployeeFunctionViewModel>();
                foreach (var el in EmployeeFunctions)
                {
                    employeeFunctionViewModels.Add(new EmployeeFunctionViewModel(el));
                }
                EmployeeFunctionViewModels = employeeFunctionViewModels;

                Db.Teams.Load();
                Teams = Db.Teams.Local.ToObservableCollection();
                var teamViewModels = new List<TeamViewModel>();
                foreach (var el in Teams)
                {

                    if (el.IdTeamStatus != 3)
                    {
                        teamViewModels.Add(new TeamViewModel(el));
                    }
                }
                TeamViewModels = teamViewModels;

            }
            catch
            {

            }


        }




    }
}