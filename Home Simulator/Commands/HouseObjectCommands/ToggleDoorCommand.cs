using Home_Simulator.Models.HouseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Home_Simulator.Commands.HouseObjectCommands
{
    public class ToggleDoorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => parameter is Door;

        public void Execute(object parameter)
        {
            if (parameter is Door door)
            {
                if (door.IsOpen)
                {
                    door.CloseDoor();
                }
                else
                {
                    door.OpenDoor();
                }

            }
        }
    }
}
