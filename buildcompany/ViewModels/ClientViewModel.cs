using BuildCompany.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace BuildCompany
{
    class ClientViewModel : Bindable, INotifyPropertyChanged
    {



        buildcompanyContext Db;

        private MyCommand addClientWindow;
        private MyCommand editClient;
        private MyCommand deleteClient;

        ObservableCollection<Client> clients;

        public MyCommand AddClientWindow
        {
            get
            {
                return addClientWindow ??
                    (addClientWindow = new MyCommand(obj =>
                    {
                        ClientWindow clientWindow = new ClientWindow(new Client());
                        if (clientWindow.ShowDialog() == true)
                        {
                            Client newclient = clientWindow.Client;
                            Db.Clients.Add(newclient);
                            Db.SaveChanges();
                        }
                        
                    }));
            }
        }

        public MyCommand EditClient
        {
            get
            {
                return editClient ??
                    (editClient = new MyCommand((selectedItem) =>
                    {
                        if (selectedItem == null) return;
                        Client client = selectedItem as Client;
                        Client vm = new Client()
                        {
                            IdClient = client.IdClient,
                            ClientLastName = client.ClientLastName,
                            ClientFirstName = client.ClientFirstName,
                            ClientAdress = client.ClientAdress,
                            ClientDescription = client.ClientDescription,
                            ClientPatronymic = client.ClientPatronymic,

                        };
                        ClientWindow clientWindow = new ClientWindow(vm);
                        if (clientWindow.ShowDialog() == true)
                        {
                            client = Db.Clients.Find(clientWindow.Client.IdClient);
                            if (clientWindow.Client != null)
                            {
                                client.ClientFirstName = clientWindow.Client.ClientFirstName;
                                client.ClientLastName = clientWindow.Client.ClientLastName;
                                client.ClientPatronymic = clientWindow.Client.ClientPatronymic;
                                client.ClientAdress = clientWindow.Client.ClientAdress;
                                client.ClientDescription = clientWindow.Client.ClientDescription;
                                Db.Entry(client).State = EntityState.Modified;
                                
                                Db.SaveChanges();
                                

                            }
                        }

                    }));
            }
        }
        public MyCommand DeleteClient
        {
            get
            {
                return deleteClient ??
                    (deleteClient = new MyCommand((selectedItem) =>
                    {
                        if (selectedItem == null) return;
                        Client client = selectedItem as Client;

                        Db.Clients.Remove(client);
                        
                       
                        Db.SaveChanges();
                    }));
            }
        }

        public ObservableCollection<Client> Clients { get { return clients; }
            set
            {
                clients = value;
                OnPropertyChanged("Clients");
            } }


        public ClientViewModel()
        {
            Db = new buildcompanyContext();
            try
            {
                Db.Clients.Load();
                Clients = Db.Clients.Local.ToObservableCollection();

            }
            catch
            {

            }

        }




    }
}