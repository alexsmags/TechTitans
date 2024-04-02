using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Commands
{
    public class SetPoliceTimerCommand : CommandBase
    {
        private SimulationViewModel _simulationViewModel;

        public SetPoliceTimerCommand(SimulationViewModel simulationViewModel) 
        { 
            _simulationViewModel = simulationViewModel; 
        }

        public override void Execute(object parameter)
        {
            if (parameter is string timerValueString && int.TryParse(timerValueString, out int timerValue))
            {
                _simulationViewModel.PoliceTimer = timerValue;
                _simulationViewModel.AddLogMessage($"Police alert timer set to: {timerValue} seconds.");
            }
            else
            {
                _simulationViewModel.AddLogMessage("Invalid input for police timer.");
            }
        }
    }
}
