using Home_Simulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Home_Simulator.ViewModels;

namespace Home_Simulator.Commands.HouseObjectCommands
{
    public class ToggleLightCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly SimulationViewModel _simulationViewModel;

        public ToggleLightCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }

        public bool CanExecute(object parameter) => parameter is Light;

        public void Execute(object parameter)
        {
            if (parameter is Light light)
            {
                if (light.On)
                {
                    light.SwitchOff();
                    _simulationViewModel.AddLogMessage($"Light switched off");
                }
                else
                {
                    light.SwitchOn();
                    _simulationViewModel.AddLogMessage($"Light switched on");
                }
                
            }
        }
    }

}
