using Home_Simulator.Models.HouseModels;
using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Home_Simulator.Commands
{
    public class AddRoomToZoneCommand : CommandBase
    {
        private readonly SimulationViewModel _simulationViewModel;

        public AddRoomToZoneCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Room roomToAdd)
            {
                foreach(Room roomToMatch in _simulationViewModel.Rooms)
                {
                    if (roomToMatch.Equals(roomToAdd)) 
                    {
                        _simulationViewModel.SelectedZone.Rooms.Add(roomToMatch);
                        _simulationViewModel.AddLogMessage($"Room {roomToMatch.Name} added to zone {_simulationViewModel.SelectedZone.Name}");
                    }
                }

                _simulationViewModel.AvailableRooms.Remove(roomToAdd);

            }

        }
    }
}
