using Home_Simulator.Models.ProfileModels;
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
    public partial class UserSelectionDialog : Window
    {
        public User SelectedUser => UsersListBox.SelectedItem as User;

        public UserSelectionDialog(IEnumerable<User> users)
        {
            InitializeComponent();
            UsersListBox.ItemsSource = users;

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }


    }
}
