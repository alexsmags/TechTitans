using Home_Simulator.Models.HouseModels;
using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Commands
{
    public class RemoveMotionDetectorLocationCommand : CommandBase
    {
        private SimulationViewModel _simulationViewModel;

        public RemoveMotionDetectorLocationCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Room room)
            {
                if (room.HasMotionDetector)
                {
                    room.HasMotionDetector = false; 
                    _simulationViewModel.AddLogMessage($"Motion detector removed from room: {room.Name}.");
                }
                else
                {
                    _simulationViewModel.AddLogMessage($"Room: {room.Name} already had no motion detector.");
                }
            }
        }

    }
}
