using Home_Simulator.Models.HouseModels;
using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Commands
{
    public class RemoveRoomFromZoneCommand : CommandBase
    {
        private readonly SimulationViewModel _simulationViewModel;

        public RemoveRoomFromZoneCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Room roomToRemove)
            {
                foreach (Room roomToMatch in _simulationViewModel.Rooms)
                {
                    if (roomToMatch.Equals(roomToRemove))
                    {
                        _simulationViewModel.SelectedZone.Rooms.Remove(roomToMatch);
                        _simulationViewModel.AddLogMessage($"Room '{roomToMatch.Name}' removed from zone '{_simulationViewModel.SelectedZone.Name}'.");
                    }
                } 
                _simulationViewModel.AvailableRooms.Add(roomToRemove);


            }

        }
    }
}
