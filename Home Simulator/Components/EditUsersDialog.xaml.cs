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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Home_Simulator.Components
{
    public partial class EditUsersDialog : Window
    {
        public User SelectedUser => UsersListBox.SelectedItem as User;
        private SimulationViewModel _simulationViewModel;   

        public EditUsersDialog(SimulationViewModel simulationViewModel)
        {
            InitializeComponent();
            this.DataContext = simulationViewModel;
            UsersListBox.ItemsSource = simulationViewModel.users;
            _simulationViewModel=simulationViewModel;
        }

        private void OnOkButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void UsersListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Make sure the double click was on a ListBoxItem and not on empty space.
            var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null && item.IsSelected)
            {
                User selectedUser = UsersListBox.SelectedItem as User;
                if (selectedUser != null)
                {
                    EditUserDialog editUserDialog = new EditUserDialog(selectedUser, _simulationViewModel);
                    editUserDialog.Owner = Application.Current.MainWindow;
                    editUserDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                    var dialogResult = editUserDialog.ShowDialog();
                    if (dialogResult.HasValue && dialogResult.Value)
                    {
                        UsersListBox.Items.Refresh();
                    }
                }
            }
        }


    }
}
