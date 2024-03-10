using Home_Simulator.Models.HouseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Commands.HouseObjectCommands
{
    public class UnBlockWindowCommand : CommandBase
    {
        private readonly Window _window;

        public UnBlockWindowCommand(Window window)
        {
            _window = window;
        }

        public override void Execute(object parameter)
        {
            _window.UnBlockWindow();
        }
    }
}
