using Home_Simulator.Components;
using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseModels.Services
{
    public class WindowStateService
    {
        private SimulationViewModel _simulationViewModel;

        public WindowStateService(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }

        public void UpdateWindowStates()
        {
            var currentDate = DateTime.ParseExact(_simulationViewModel.SimulationModel.GetCurrentDate(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            int currentMonth = currentDate.Month;

            bool isSummer = currentMonth >= 6 && currentMonth <= 8;


            foreach (var zone in _simulationViewModel.Zones)
            {
                foreach (var room in zone.Rooms)
                {
                    if (isSummer && _simulationViewModel.OutsideTemperature < room.RoomTemperature)
                    {
                        foreach (var window in room.Windows)
                        {
                            if (!window.IsBlocked)
                            {
                                window.OpenWindow();
                            }
                        }
                    }
                }
            }

        }

        public void BlockWindowsOnAwayModeOn()
        {
            foreach (var room in _simulationViewModel.Rooms)
            {
                foreach (Window window in room.Windows)
                {
                    if (_simulationViewModel.IsAwayModeEnabled)
                    {
                        if (!window.IsBlocked)
                        {
                            window.BlockWindow();
                        }
                    }
                }
            }

        }

        public void CheckDoorsAndWindows()
        {
            foreach (var room in _simulationViewModel.Rooms)
            {
                foreach (var door in room.Doors)
                {
                    if (door.IsOpen)
                    {
                        _simulationViewModel.AddLogMessage($"Alert: Door is open in {room.Name} while in Away Mode");
                    }
                }

                foreach (var window in room.Windows)
                {
                    if (window.IsOpen)
                    {
                        _simulationViewModel.AddLogMessage($"Alert: Window is open in {room.Name} while in Away Mode");
                    }
                }
            }
        }

    }
}
