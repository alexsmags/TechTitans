using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_Simulator.Models;

namespace Home_Simulator.Commands.HouseObjectCommands
{
    public class LightOnCommand : CommandBase
    {
        private readonly Light _light;

        public LightOnCommand(Light light)
        {
            _light = light;
        }

        public override void Execute(object parameter)
        {
            _light.SwitchOn();
        }
    }
}
