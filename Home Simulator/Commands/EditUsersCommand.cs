using Home_Simulator.Components;
using Home_Simulator.Models.ProfileModels;
using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Simulator.Commands
{
    public class EditUsersCommand : CommandBase
    {
        private SimulationViewModel _simulationViewModel { get; set; }  

        public EditUsersCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel; 
        }


        public override void Execute(object parameter)
        {
            var dialog = new EditUsersDialog(_simulationViewModel);

            dialog.Owner = Application.Current.MainWindow;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            var result = dialog.ShowDialog();
            _simulationViewModel.AddLogMessage($"User '{_simulationViewModel.CurrentUser.Name}' edited.");

        }
    }
}
