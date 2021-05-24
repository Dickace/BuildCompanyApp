using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BuildCompany
{

   
    class SettingViewModel : Bindable
    {
        public ICommand ChangeSettings
        {
            get; private set;
        }

        public void UpdateSetting()
        {
            var sett = Properties.Settings.Default;
            sett.IP = IP;
            sett.host = Hosts;
            sett.login = Login;
            sett.database = DatabaseName;
            sett.password = Passw;
            sett.Save();

        }
        string ip;
        string hosts;
        string login;
        string databaseName;
        string passw;
        public string IP { get { return ip; } set 
            {
             ip = value;
                OnPropertyChanged("IP");
            } }
        public string Hosts
        {
            get { return hosts; }
            set
            {
                hosts = value;
                OnPropertyChanged("Hosts");
            }
        }
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        public string DatabaseName
        {
            get { return databaseName; }
            set
            {
                databaseName = value;
                OnPropertyChanged("DatanaseName");
            }
        }
        public string Passw
        {
            get { return passw; }
            set
            {
                passw = value;
                OnPropertyChanged("Passw");
            }
        }
        public SettingViewModel()
        {
            var sett = Properties.Settings.Default;
            IP = sett.IP;
            Hosts = sett.host;
            Login = sett.login;
            DatabaseName = sett.database;
            Passw = sett.password;
            ChangeSettings = new ChangeSettings(this);
        }
    }
}
