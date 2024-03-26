using Home_Simulator.Models.HouseModels;
using Home_Simulator.ViewModels;
using Home_Simulator.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Room = Home_Simulator.Models.HouseModels.Room;

namespace Home_Simulator.Commands
{
    public class ChangeUserLocationCommand : CommandBase
    {
        private readonly SimulationViewModel _simulationViewModel;

        public ChangeUserLocationCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }


        public override void Execute(object parameter)
        {
            var dialog = new ChangeUserLocationDialog(_simulationViewModel);

            dialog.Owner = Application.Current.MainWindow;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            var result = dialog.ShowDialog();

            if (result == true)
            {
                if (_simulationViewModel.CurrentUser != null)
                {
                    // store old location
                    Room oldRoom = _simulationViewModel.CurrentUser.CurrentLocation as Room;

                    // set new location
                    _simulationViewModel.CurrentUser.CurrentLocation = dialog.SelectedRoom;

                    Room currentRoom = _simulationViewModel.CurrentUser.CurrentLocation as Room;
                    if (currentRoom != null)
                    {
                        if (oldRoom != null && oldRoom != dialog.SelectedRoom)
                        {
                            oldRoom.RemoveUser(_simulationViewModel.CurrentUser);
                            currentRoom.AddUser(_simulationViewModel.CurrentUser);
                            _simulationViewModel.AddLogMessage($"User '{_simulationViewModel.CurrentUser.Name}' moved from '{oldRoom.Name}' to '{currentRoom.Name}'.");

                        }
                        else
                        {
                            currentRoom.AddUser(_simulationViewModel.CurrentUser);
                            _simulationViewModel.AddLogMessage($"User '{_simulationViewModel.CurrentUser.Name}' moved to '{currentRoom.Name}'.");
                        }

                    }
                    else
                    {
                       if (oldRoom != null) 
                       { 
                            oldRoom.RemoveUser(_simulationViewModel?.CurrentUser); 
                            _simulationViewModel.AddLogMessage($"User '{_simulationViewModel.CurrentUser.Name}' moved from '{oldRoom.Name}' to 'Outside'.");
                       }
                       else
                        {
                            _simulationViewModel.AddLogMessage($"User '{_simulationViewModel.CurrentUser.Name}' moved to 'Outside'.");
                       }    
                    }

                    _simulationViewModel.CurrentLocation = _simulationViewModel.CurrentUser.CurrentLocation;
                    _simulationViewModel.InvokeAccess();
                }        
            }
        }
    }
}
