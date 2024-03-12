using Home_Simulator.Components;
using Home_Simulator.Models.ProfileModels;
using Home_Simulator.ProfileReader;
using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Simulator.Commands
{
    public class RemoveUserCommand : CommandBase
    {
        private readonly SimulationViewModel _simulationViewModel;

        public RemoveUserCommand(SimulationViewModel simulationViewModel)
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
                if (_simulationViewModel.CurrentUser == dialog.SelectedUser)
                {
                    _simulationViewModel.CurrentUser = null; 
                }
                    User userToRemove = dialog.SelectedUser;

                    _simulationViewModel.users.Remove(userToRemove);

                    var profileReaderService = ProfileReaderService.Instance;
                    profileReaderService.RemoveUser(userToRemove);
            }

        }
    }
}
