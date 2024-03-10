using Home_Simulator.Models.HouseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Commands.HouseObjectCommands
{
    public class BlockWindowCommand : CommandBase
    {
        private readonly Window _window;

        public BlockWindowCommand(Window window)
        {
            _window = window;
        }

        public override void Execute(object parameter)
        {
            _window.BlockWindow();
        }
    }
}
