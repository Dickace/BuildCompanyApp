using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace BuildCompany
{

    class OrderViewModel : Bindable
    {
        buildcompanyContext Db;

        private Order selectedOrder;

        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }
        private ObservableCollection<Order> orders;
        public ObservableCollection<Order> Orders {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged("Orders");
            }
        }

        public void DataRefresh()
        {
            Db = new buildcompanyContext();
            Db.Orders.Load();
            Orders = Db.Orders.Local.ToObservableCollection();
            OnPropertyChanged("Orders");

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
                        Order order = new Order();
                        
                        var client = Db.Clients.First();
                        order.IdOrderStatus = 0;
                        order.IdClient = client.IdClient;
                        Orders.Add(order);
                        Db.Orders.Add(order);
                        Db.SaveChanges();
                        DataRefresh();
                        SelectedOrder = order;
                        var norders = Db.Orders.OrderBy(norder => norder.IdOrder);
                        SelectedOrder = norders.Last();
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
                    Order order = obj as Order;
                    if (order != null)
                    {
                        var neworder = Db.Orders.Find(order.IdOrder);
                        if (neworder.IdOrder != 0)
                        {
                            var Team = Db.Teams.Find(order.IdTeam);
                            if (Team != null)
                            {
                                if (Team.IdTeamStatus == 0 || Team.IdTeamStatus == 2)
                                {
                                    Team.IdTeamStatus = 1;
                                }
                                if (order.IdOrderStatus == 1)
                                {
                                    Team.IdTeamStatus = 0;
                                    order.IdTeam = null;
                                }
                                Db.Entry(Team).State = EntityState.Modified;
                            }
                            order = neworder;
                                Db.Entry(order).State = EntityState.Modified;
                               
                                Db.SaveChanges();
                                DataRefresh();
                           
                           
                        }
                        else
                        {
                            Db.Orders.Add(order);
                            
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
                        Order order = obj as Order;
                        if (order != null)
                        {
                            Db.Orders.Load();
                            var neworder = Db.Orders.Find(order.IdOrder);
                            if (neworder != null)
                            {
                                Db.Orders.Remove(order);
                                Db.SaveChanges();
                                DataRefresh();
                            }
                            else
                            {
                                
                                Orders.Remove(order);
                                DataRefresh();

                            }
                            
                       
                        }
                    }));
            }
        }
        public ObservableCollection<Client> Clients { get; set; }
        public IEnumerable<PostClientModel> ClientViewModels { get; private set; }


        public class PostClientModel : Bindable
        {
            public PostClientModel(Client model)
            {
                Model = model;
                ClientName = model.ClientLastName + " " + model.ClientFirstName + " " + model.ClientPatronymic;
            }

            public string ClientName { get; set; }
            public Client Model { get; set; }
        }

        public ObservableCollection<OrderStatus> OrderStatuses { get; set; }
        public IEnumerable<OrderStatusViewModel> OrderStatusViewModels { get; private set; }

        public class OrderStatusViewModel : Bindable
        {
            public OrderStatusViewModel(OrderStatus model)
            {
                Model = model;
                OrderStatusName = Model.OrderStatusName;
            }

           public string OrderStatusName { get; set; }
           public OrderStatus Model { get; set; }
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

        public OrderViewModel()
        {
            
            Db = new buildcompanyContext();
            try
            {
                Db.Orders.Load();
                Orders = Db.Orders.Local.ToObservableCollection();


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

                Db.OrderStatuses.Load();
                OrderStatuses = Db.OrderStatuses.Local.ToObservableCollection();
                var orderStatusViewModels = new List<OrderStatusViewModel>();
                foreach (var el in OrderStatuses)
                {
                    orderStatusViewModels.Add(new OrderStatusViewModel(el));
                }
                OrderStatusViewModels = orderStatusViewModels;


                Db.Clients.Load();
                Clients = Db.Clients.Local.ToObservableCollection();
                var clientViewModels = new List<PostClientModel>();
                foreach (var el in Clients)
                {

                    clientViewModels.Add(new PostClientModel(el));
                }
                ClientViewModels = clientViewModels;
            } 
            catch
            {

            }
            

        }


    }  
}