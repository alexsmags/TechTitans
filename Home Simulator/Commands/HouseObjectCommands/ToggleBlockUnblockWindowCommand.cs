using Home_Simulator.Models.HouseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Home_Simulator.Commands.HouseObjectCommands
{
    public class ToggleBlockUnblockWindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => parameter is Window;

        public void Execute(object parameter)
        {
            if (parameter is Window window)
            {
                if(window.IsBlocked) 
                {
                    window.UnBlockWindow();
                }
                else
                {
                    window.BlockWindow();
                }
            }
        }
    }
}