using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseModels.Services
{
    public class DoorStateService
    {
        private SimulationViewModel _simulationViewModel;

        public DoorStateService(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }

        public void CloseDoorsOnAwayModeOn()
        {
            foreach (var room in _simulationViewModel.Rooms)
            {
                foreach (Door door in room.Doors)
                {
                    if (_simulationViewModel.IsAwayModeEnabled)
                    {
                        if (door.IsOpen)
                        {
                            door.CloseDoor();
                        }
                    }
                }
            }

        }
    }
}
