using Home_Simulator.Models.HouseSimulationModels;
using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Commands
{
    public class DeletePeriodCommand : CommandBase
    {
        private SimulationViewModel _simulationViewModel;

        public DeletePeriodCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel; 
        }
        public override void Execute(object parameter)
        {
            var period = parameter as TemperaturePeriodModel;

            if (_simulationViewModel.SelectedZone != null && period != null)
            {
                _simulationViewModel.SelectedZone.TemperaturePeriods.Remove(period);
                _simulationViewModel.AddLogMessage($"Period '{period.PeriodName}' deleted.");
            }
        }
    }
}
