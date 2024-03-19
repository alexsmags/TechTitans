using Home_Simulator.Models.HouseSimulationModels;
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
    public partial class RemoveTemperaturePeriodDialog : Window
    {
        private SimulationViewModel _viewModel;

        public RemoveTemperaturePeriodDialog(SimulationViewModel viewModel, IEnumerable<TemperaturePeriodModel> periods)
        {
            InitializeComponent();
            _viewModel = viewModel; // Store the ViewModel
            lstPeriods.ItemsSource = periods; // Bind the ListBox directly to the periods collection
            this.DataContext = viewModel; // Set the DataContext to the ViewModel
        }

    }
}
