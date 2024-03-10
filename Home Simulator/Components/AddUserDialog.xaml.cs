using Home_Simulator.Models.ProfileModels;
using Home_Simulator.ViewModels;
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

namespace Home_Simulator.Components
{

    public partial class AddUserDialog : Window
    {

        public string UserName { get; set; }    
        public int UserAge { get; set; }    
        public UserType? UserType { get; set; }

        public AddUserDialog()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void OnAddUserClick(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(UserName) && UserAge >= 0 && UserType != null)
            {
                this.DialogResult = true;
            }

            else
            {
                ErrorMessage.Visibility = Visibility.Visible;
            }
        }
    }
}
