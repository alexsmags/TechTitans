using Home_Simulator.Models.HouseModels;
using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Commands
{
    public class RemoveZoneCommand : CommandBase
    {
        private readonly SimulationViewModel _simulationViewModel;

        public RemoveZoneCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Zone zone)
            {
                var roomSet = new HashSet<Room>(_simulationViewModel.Rooms);

                foreach (Room room in zone.Rooms)
                {
                    if (roomSet.Contains(room))
                    {
                        _simulationViewModel.AvailableRooms.Add(room);
                    }
                }

                _simulationViewModel.Zones.Remove(zone);
            }
        }
    }
}
