using Home_Simulator.Models.HouseModels;
using Home_Simulator.ViewModels;
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

        private readonly SimulationViewModel _simulationViewModel;

        public ToggleBlockUnblockWindowCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }
        public bool CanExecute(object parameter) => parameter is Window;

        public void Execute(object parameter)
        {
            if (parameter is Window window)
            {
                if(window.IsBlocked) 
                {
                    window.UnBlockWindow();
                    _simulationViewModel.AddLogMessage($"Window unblocked");
                }
                else
                {
                    window.BlockWindow();
                    _simulationViewModel.AddLogMessage($"Window blocked");
                }
            }
        }
    }
}