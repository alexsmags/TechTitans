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
    public class AddUserCommand : CommandBase
    {
        private readonly SimulationViewModel _simulationViewModel;

        public AddUserCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }


        public override void Execute(object parameter)
        {
            var dialog = new AddUserDialog();

            dialog.Owner = Application.Current.MainWindow;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            var result = dialog.ShowDialog();

            if (result == true)
            {
                string userName = dialog.UserName;
                int userAge = dialog.UserAge;
                UserType userType = (UserType) dialog.UserType;

                _simulationViewModel.users.Add(new User(userName, userAge, userType));

                var profileReaderService = ProfileReaderService.Instance;
                profileReaderService.AddUser(new User(userName, userAge, userType));
            }

        }
    }
}
