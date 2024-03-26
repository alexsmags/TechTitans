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
        public void UpdateWindowStates(SimulationViewModel _simulationViewModel)
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
    }
}
