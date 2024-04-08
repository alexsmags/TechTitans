using Home_Simulator.Models.HouseModels;
using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Home_Simulator.Commands.HouseObjectCommands
{
    public class ToggleDoorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly SimulationViewModel _simulationViewModel;

        public ToggleDoorCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }
        public bool CanExecute(object parameter) => parameter is Door;

        public void Execute(object parameter)
        {
            if (parameter is Door door)
            {
                if (door.IsOpen)
                {
                    door.CloseDoor();
                    _simulationViewModel.AddLogMessage($"Door {door.DoorName} closed");
                }
                else
                {
                    door.OpenDoor();
                    if (_simulationViewModel.IsAwayModeEnabled == true)
                    {
                        _simulationViewModel.AddLogMessage($"WARNING NOTIFICATION: Door {door.DoorName} opened when in away mode");
                    } else
                    {
                        _simulationViewModel.AddLogMessage($"Door {door.DoorName} opened");
                    }

                }

            }
        }
    }
}
