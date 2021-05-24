using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BuildCompany.View
{
    /// <summary>
    /// Interaction logic for TeamWindow.xaml
    /// </summary>
    /// 
    

    public partial class TeamWindow : Window
    {
       
        public Team Team { get; private set; }
        public TeamWindow(Team t)
        {
            InitializeComponent();
            Team = t;
            DataContext = Team;
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
