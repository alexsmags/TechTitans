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
    public class ChangeDateTimeCommand : CommandBase
    {
        private readonly SimulationViewModel _simulationViewModel;

        public ChangeDateTimeCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }


        public override void Execute(object parameter)
        {
            var dialog = new ChangeDateTimeDialog(_simulationViewModel.simulationModel);

            dialog.Owner = Application.Current.MainWindow;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            var result = dialog.ShowDialog();

            if (result == true)
            {
                _simulationViewModel.simulationModel.SimulationDate = dialog.SelectedDateTime.Date;
                _simulationViewModel.simulationModel.SimulationTime = dialog.SelectedDateTime.TimeOfDay;

                // Update the View's Date/Time properties
                _simulationViewModel.CurrentDate = dialog.SelectedDateTime.TimeOfDay.ToString();
                _simulationViewModel.CurrentTime = dialog.SelectedDateTime.TimeOfDay.ToString();
            }
        }
    }
}
