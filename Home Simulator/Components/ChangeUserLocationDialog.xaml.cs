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
    public partial class ChangeUserLocationDialog : Window
    {
        public Models.HouseModels.Location SelectedRoom => LocationListBox.SelectedItem as Models.HouseModels.Location;

        private SimulationViewModel _simulationViewModel;

        public ChangeUserLocationDialog(SimulationViewModel simulationViewModel)
        {
            InitializeComponent();
            LocationListBox.ItemsSource = simulationViewModel.LocationService.Locations;
            _simulationViewModel = simulationViewModel;

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (_simulationViewModel.CurrentUser == null)
            {
                NoSelectionMessage.Text = "You must select a user first";
                NoSelectionMessage.Visibility = Visibility.Visible;
            }

            else
            {
                this.DialogResult = true;
            }
        }

        private void UsersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NoSelectionMessage.Visibility = Visibility.Collapsed;
        }
    }
}
