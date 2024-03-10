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
    public class ChangeTemperatureCommand : CommandBase
    {
        private readonly SimulationViewModel _simulationViewModel;

        public ChangeTemperatureCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }


        public override void Execute(object parameter)
        {
            var dialog = new ChangeTemperatureDialog(_simulationViewModel.OutsideTemperature);

            dialog.Owner = Application.Current.MainWindow;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            var result = dialog.ShowDialog();

            if (result == true)
            {
                _simulationViewModel.OutsideTemperature = dialog.SelectedTemperature;
            }
        }
    }
}

