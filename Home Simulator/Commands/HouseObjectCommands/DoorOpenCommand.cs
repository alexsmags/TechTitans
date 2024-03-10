using Home_Simulator.Models.HouseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Commands.HouseObjectCommands
{
    public class DoorOpenCommand : CommandBase
    {
        private readonly Door _door;

        public DoorOpenCommand(Door door)
        {
            _door = door;
        }

        public override void Execute(object parameter)
        {
            _door.OpenDoor();
        }
    }
}
