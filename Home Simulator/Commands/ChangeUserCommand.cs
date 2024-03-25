using Home_Simulator.Components;
using Home_Simulator.MessageLogs;
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
                var previousUser = _simulationViewModel.CurrentUser;
                _simulationViewModel.CurrentUser = dialog.SelectedUser;

                if (dialog.SelectedUser != null)
                {
                    if (previousUser != null)
                    {
                        _simulationViewModel.AddLogMessage($"User changed from {previousUser.Name} to {dialog.SelectedUser.Name}");
                    }
                    else
                    {
                        _simulationViewModel.AddLogMessage($"User set to {dialog.SelectedUser.Name}");

                    }
                }

            }
        }
    }
}
