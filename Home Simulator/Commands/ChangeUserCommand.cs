using Home_Simulator.Components;
using Home_Simulator.Models.ProfileModels;
using Home_Simulator.Stores;
using Home_Simulator.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Simulator.Commands
{
    public class ChangeUserCommand : CommandBase
    {
        private readonly SimulationViewModel _simulationViewModel;

        public ChangeUserCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }


        public override void Execute(object parameter)
        {
            var dialog = new UserSelectionDialog(_simulationViewModel.users);

            dialog.Owner = Application.Current.MainWindow;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            var result = dialog.ShowDialog();

            if (result == true)
            {
                _simulationViewModel.CurrentUser = dialog.SelectedUser;
            }
        }
    }
}
