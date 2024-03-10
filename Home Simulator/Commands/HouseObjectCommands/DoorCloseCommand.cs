using Home_Simulator.Models.HouseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Commands.HouseObjectCommands
{
    public class DoorCloseCommand : CommandBase
    {
        private readonly Door _door;

        public DoorCloseCommand(Door door)
        {
            _door = door;
        }

        public override void Execute(object parameter)
        {
            _door.CloseDoor();
        }
    }
}
