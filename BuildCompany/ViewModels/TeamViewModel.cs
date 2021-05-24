using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BuildCompany.View;

namespace BuildCompany
{
   
    class TeamViewModel : Bindable
    {
        buildcompanyContext Db;

        private MyCommand addCommand;
        private MyCommand saveCommand;
        private MyCommand removeCommand;
        private MyCommand showActiveCommand;
        private MyCommand showNoneActiveCommand;

        ObservableCollection<Team> teams;
        public ObservableCollection<Team> Teams { get { return teams; } 
            set
            {
                teams = value;
                OnPropertyChanged("Teams");
            }
        }

        public MyCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new MyCommand(obj =>
                    {
                        Team team = new Team();
                        team.IdTeam = 0;

                        Teams.Add(team);
                        Db.Teams.Add(team);
                        Db.SaveChanges();
                        DataRefresh();
                        SelectedTeam = team;
                    }
                    ));
            }

        }

        public MyCommand ShowActiveCommand
        {
            get
            {
                return showActiveCommand ??
                    (showActiveCommand = new MyCommand(obj =>
                    {
                        Db.Teams.Load();
                        Teams = new ObservableCollection<Team>();
                        var teams = Db.Teams.Local.ToObservableCollection();
                        foreach (var el in teams)
                        {
                            if (el.IdTeamStatus == 1)
                            {
                                Teams.Add(el);
                            }
                            
                        }
                        OnPropertyChanged("Teams");
                    }
                    ));
            }

        }
        public MyCommand ShowNoneActiveCommand
        {
            get
            {
                return showNoneActiveCommand ??
                    (showNoneActiveCommand = new MyCommand(obj =>
                    {
                        Db.Teams.Load();
                        Teams = new ObservableCollection<Team>();
                        var teams = Db.Teams.Local.ToObservableCollection();
                        foreach (var el in teams)
                        {
                            if (el.IdTeamStatus != 1)
                            {
                                Teams.Add(el);
                            }

                        }
                        OnPropertyChanged("Teams");
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
                    Team team = obj as Team;
                    if (team != null)
                    {
                        var newTeam = Db.Teams.Find(team.IdTeam);
                        if (team.IdTeam != 0)
                        {


                            team = newTeam;
                            Db.Entry(team).State = EntityState.Modified;
                            Db.SaveChanges();
                            DataRefresh();


                        }
                        else
                        {

                            Db.Teams.Add(team);

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
                        Team team = obj as Team;
                        if (team != null)
                        {
                            Db.Teams.Load();
                            var newTeam = Db.Teams.Find(team.IdTeam);
                            if (newTeam!=null)
                            {
                                if(newTeam != null)
                                {
                                    Db.Teams.Remove(team);
                                    Db.SaveChanges();
                                    DataRefresh();
                                }
                                
                            }
                            else
                            {

                                Teams.Remove(team);

                                DataRefresh();
                            }


                        }
                    }));
            }
        }
        Team selectedTeam;
        public Team SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                selectedTeam = value;
                OnPropertyChanged("SelectedTeam");
            }
        }
        public void DataRefresh()
        {
            Db = new buildcompanyContext();
            Db.Teams.Load();
            Teams = Db.Teams.Local.ToObservableCollection();
            OnPropertyChanged("Teams");
        }

        public ObservableCollection<TeamStatus> TeamStatuses { get; set; }

        public IEnumerable<TeamStatusViewModel> TeamStatusViewModels { get; set; }
        public class TeamStatusViewModel : Bindable
        {
            public TeamStatusViewModel(TeamStatus model)
            {
                Model = model;
                TeamStatusName = model.TeamStatusName;
            }

            public string TeamStatusName { get; set; }
            public TeamStatus Model { get; set; }
        }

        public ObservableCollection<Employee> Employees { get; set; }

        public IEnumerable<EmployeeViewModel> EmployeeViewModels { get; set; }
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

        public TeamViewModel()
        {
            Db = new buildcompanyContext();
            try
            {
                Db.Teams.Load();
                Teams = new ObservableCollection<Team>();
                var teams = Db.Teams.Local.ToObservableCollection();
                foreach(var el in teams)
                {
                    Teams.Add(el);
                }



                Db.Employees.Load();
                Employees = Db.Employees.Local.ToObservableCollection();
                var employeeViewModels = new List<EmployeeViewModel>();
                foreach (var el in Employees)
                {
                    employeeViewModels.Add(new EmployeeViewModel(el));
                }
                EmployeeViewModels = employeeViewModels;

                Db.TeamStatuses.Load();
                TeamStatuses = Db.TeamStatuses.Local.ToObservableCollection();
                var teamStatusViewModels = new List<TeamStatusViewModel>();
                foreach (var el in TeamStatuses)
                {
                    teamStatusViewModels.Add(new TeamStatusViewModel(el));
                }
                TeamStatusViewModels = teamStatusViewModels;
            }
            catch
            {
                
            }
         



        }
    }
}