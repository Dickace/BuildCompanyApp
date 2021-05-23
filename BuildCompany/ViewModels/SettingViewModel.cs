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
        public string IP { get; set; }
        public string Hosts { get; set; }
        public string Login { get; set; }
        public string DatabaseName { get; set; }
        public string Passw{ get; set; }
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
