using Home_Simulator.Models.ProfileModels;
using Home_Simulator.ProfileReader;
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
    public partial class EditUserDialog : Window
    {
        public User CurrentUser { get; set; }

        private SimulationViewModel _simulationViewModel;

        public EditUserDialog(User user, SimulationViewModel simulationViewModel)
        {
            InitializeComponent();
            CurrentUser = user;
            _simulationViewModel = simulationViewModel;
            this.DataContext = this; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            CurrentUser.Name = NameTextBox.Text;
            CurrentUser.Age = int.Parse(AgeTextBox.Text); 
            CurrentUser.Type = (UserType)UserTypeComboBox.SelectedItem;

            if (_simulationViewModel.CurrentUser == CurrentUser)
            {
                _simulationViewModel.InvokeCurentUserPropertyChanged();
                _simulationViewModel.InvokeAccess();
                _simulationViewModel.LightPermissionManager.UpdateLightPermissionsForAllUsers(_simulationViewModel.Rooms, _simulationViewModel.CurrentUser);
            }
            ProfileReaderService.SaveUsers(_simulationViewModel.users);
        }
    }
}
