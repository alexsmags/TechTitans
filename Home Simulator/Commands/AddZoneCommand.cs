using Home_Simulator.Models.HouseModels;
using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Home_Simulator.Commands
{
    public class AddZoneCommand : CommandBase
    {
        private readonly SimulationViewModel _simulationViewModel;

        public AddZoneCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }

        public override void Execute(object parameter)
        {
            if (!String.IsNullOrEmpty(_simulationViewModel.NewZoneName))
            {
                bool zoneExists = _simulationViewModel.Zones.Any(zone => zone.Name.Equals(_simulationViewModel.NewZoneName, StringComparison.OrdinalIgnoreCase));

                if (!zoneExists)
                {
                    _simulationViewModel.Zones.Add(new Zone(_simulationViewModel.NewZoneName));
                    _simulationViewModel.NewZoneName = string.Empty;
                }
                else
                {
                    MessageBox.Show("This zone name already exists.");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Zone Name");
            }
        }
    }
}
