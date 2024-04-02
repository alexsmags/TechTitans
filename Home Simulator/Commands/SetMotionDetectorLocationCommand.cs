using Home_Simulator.Models.HouseModels;
using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Commands
{
    public class SetMotionDetectorLocationCommand : CommandBase
    {
        private SimulationViewModel _simulationViewModel;

        public SetMotionDetectorLocationCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }

        public override void Execute(object parameter)
        {
            var selectedRoom = parameter as Room; 

            if (selectedRoom != null)
            {

                if (!selectedRoom.HasMotionDetector)
                {
                    selectedRoom.HasMotionDetector = true;

                    _simulationViewModel.AddLogMessage($"Motion detector set in room: {selectedRoom.Name}");
                }

                else
                {
                    _simulationViewModel.AddLogMessage($"Motion detector is already set in room: {selectedRoom.Name}");
                }
            }
        }



    }
}
