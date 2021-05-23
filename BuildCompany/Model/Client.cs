using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#nullable disable

namespace BuildCompany
{
    public partial class Client : INotifyPropertyChanged
    {
        

        public Client()
        {
            Orders = new HashSet<Order>();
        }

        private int idClient;
        private string clientLastName;
        private string clientFirstName;
        private string clientPatronymic;
        private string clientAdress;
        private string clientDescription;

        public int IdClient
        {
            get { return idClient; }
            set
            {
                idClient = value;
                OnPropertyChanged("IdClient");
            }
        }
        public string ClientLastName
        {
            get { return clientLastName; }
            set
            {
                clientLastName = value;
                OnPropertyChanged("ClientLastName");
            }
        }
        public string ClientFirstName
        {
            get { return clientFirstName; }
            set
            {
                clientFirstName = value;
                OnPropertyChanged("ClientFirstName");
            }
        }
        public string ClientPatronymic
        {
            get { return clientPatronymic; }
            set
            {
                clientPatronymic = value;
                OnPropertyChanged("ClientPatronymic");
            }
        }
        public string ClientAdress
        {
            get { return clientAdress; }
            set
            {
                clientAdress = value;
                OnPropertyChanged("ClientAdress");
            }
        }
        public string ClientDescription
        {
            get { return clientDescription; }
            set
            {
                clientDescription = value;
                OnPropertyChanged("ClientDescription");
            }
        }

        public virtual ICollection<Order> Orders { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
