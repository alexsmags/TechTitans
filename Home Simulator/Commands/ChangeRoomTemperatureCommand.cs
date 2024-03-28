
using Home_Simulator.Components;
using Home_Simulator.Models.HouseModels;
using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Room = Home_Simulator.Models.HouseModels.Room;

namespace Home_Simulator.Commands
{
    public class ChangeRoomTemperatureCommand : CommandBase
    {
        private readonly SimulationViewModel _simulationViewModel;

        public ChangeRoomTemperatureCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Room room)
            {
                var dialog = new ChangeTemperatureDialog(room.RoomTemperature); 

                dialog.Owner = Application.Current.MainWindow;
                dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                var result = dialog.ShowDialog();

                if (result == true)
                {
                    room.RoomTemperature = dialog.SelectedTemperature;
                    _simulationViewModel.AddLogMessage($"{room.Name} temperature changed to {dialog.SelectedTemperature}°");
                }
            }
        }
    }
}
