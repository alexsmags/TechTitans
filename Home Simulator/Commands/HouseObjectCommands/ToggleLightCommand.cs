using Home_Simulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Home_Simulator.Commands.HouseObjectCommands
{
    public class ToggleLightCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => parameter is Light;

        public void Execute(object parameter)
        {
            if (parameter is Light light)
            {
                if (light.On)
                {
                    light.SwitchOff();
                }
                else
                {
                    light.SwitchOn();
                }
                
            }
        }
    }

}
