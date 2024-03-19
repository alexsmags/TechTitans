using Home_Simulator.Components;
using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Simulator.Commands
{
    public class RemoveTemperaturePeriodCommand : CommandBase
    {
        private readonly SimulationViewModel _simulationViewModel;

        public RemoveTemperaturePeriodCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }

        public override void Execute(object parameter)
        {
            if (_simulationViewModel.SelectedZone != null)
            {
                var dialog = new RemoveTemperaturePeriodDialog(_simulationViewModel, _simulationViewModel.SelectedZone.TemperaturePeriods);
                dialog.Owner = Application.Current.MainWindow;
                dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                dialog.ShowDialog();
            }
        }
    }
}
