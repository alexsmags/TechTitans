using Home_Simulator.Models.HouseModels;
using Home_Simulator.Models;
using Home_Simulator.ProfileReader;
using Home_Simulator.Stores;
using Home_Simulator.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_Simulator.Commands.HouseObjectCommands;
using System.Collections.ObjectModel;

namespace Home_Simulator.Commands
{
    public class LoadHouseLayoutStartCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public LoadHouseLayoutStartCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string fileContent = File.ReadAllText(openFileDialog.FileName);

                ObservableCollection<Room> roomList = LoadFile(fileContent);
                SimulationViewModel simulationViewModel = new SimulationViewModel();
                simulationViewModel.LocationService.AddRooms(roomList);
                simulationViewModel.LocationService.Rooms = roomList;
                
                ObservableCollection <Room> availableRooms = new ObservableCollection<Room>(roomList);

                simulationViewModel.AvailableRooms = availableRooms;
                simulationViewModel.LightPermissionManager.UpdateLightPermissionsForAllUsers(simulationViewModel.Rooms, simulationViewModel.CurrentUser);

                var profileReaderService = ProfileReaderService.Instance;
                simulationViewModel.users = profileReaderService.LoadUsers();

                _navigationStore.CurrentViewModel = simulationViewModel;
            }
        }

        public ObservableCollection<Room> LoadFile(string filePath)
        {
            ObservableCollection<Room> roomList = new ObservableCollection<Room>(); 
            HouseBuilder builder = new HouseBuilder();
            HouseService houseService = new HouseService(builder);

            House house = houseService.CreateHouseFromTextFile(filePath);
            if (house != null)
            {
                int roomNumber = 1;
                foreach (var room in house.Rooms)
                {
                    roomList.Add(room);
                    roomNumber++;
                }
            }

            return roomList;

        }

    }
}
