using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCompany.ViewModels
{
    class MainViewModel: Bindable
    {
        public MainViewModel()
        {
            CurrentViewModel = wellComeViewModel;
            NavCommand = new MyICommand<string>(OnNav);
        }

        //Here add new viewModel for main windows
        private TeamViewModel teamViewModel = new TeamViewModel();

        private OrderViewModel orderViewModel = new OrderViewModel();

        private ClientViewModel clientViewModel = new ClientViewModel();

        private EmployeeViewModel employeeViewModel = new EmployeeViewModel();

        private PayoutViewModel payoutViewModel = new PayoutViewModel();

        private SettingViewModel settingViewModel = new SettingViewModel();

        private SickLeaveViewModel sickLeaveViewModel = new SickLeaveViewModel();

        private MaterialListViewModel materialListViewModel = new MaterialListViewModel();

        private VacationViewModel vacationViewModel = new VacationViewModel();

        private WellComeViewModel wellComeViewModel = new WellComeViewModel();

        private Bindable _CurrentViewModel;

        public Bindable CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public MyICommand<string> NavCommand { get; private set; }


        //Here add new command for changing viewModel for main windows by buttons
        private void OnNav(string destination)
        {

            switch (destination)
            {
                case "orders":
                    CurrentViewModel = orderViewModel;
                    break;
                case "employees":
                    CurrentViewModel = employeeViewModel;
                    break;
                case "teams":
                    CurrentViewModel = teamViewModel;
                    break;
                case "clients":
                    CurrentViewModel = clientViewModel;
                    break;
                case "payouts":
                    CurrentViewModel = payoutViewModel;
                    break;
                case "sickleave":
                    CurrentViewModel = sickLeaveViewModel;
                    break;
                case "materials":
                    CurrentViewModel = materialListViewModel;
                    break;
                case "setting":
                    CurrentViewModel = settingViewModel;
                    break;
                case "vacation":
                    CurrentViewModel = vacationViewModel;
                    break;
                default:
                    CurrentViewModel = wellComeViewModel;
                    break;
            }
        }
    }
}
