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
                    foreach (var light in room.Lights)
                    {
                        AttachLightCommandListeners(light);
                    }
                    foreach (var door in room.Doors)
                    {
                        AttachDoorCommandListeners(door);
                    }
                    foreach (var window in room.Windows)
                    {
                        AttachWindowCommandListeners(window);
                    }
                    roomList.Add(room);
                    roomNumber++;
                }
            }

            return roomList;

        }


        private void AttachLightCommandListeners(Light light)
        {
            light.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(Light.On))
                {
                    var lightInstance = sender as Light;
                    if (lightInstance != null)
                    {
                        if (lightInstance.On)
                        {
                            var command = new LightOnCommand(lightInstance);
                            command.Execute(null);
                        }
                        else
                        {
                            var command = new LightOffCommand(lightInstance);
                            command.Execute(null);
                        }
                    }
                }
            };
        }

        private void AttachDoorCommandListeners(Door door)
        {
            door.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(Door.IsOpen))
                {
                    var doorInstance = sender as Door;
                    if (doorInstance != null)
                    {
                        if (doorInstance.IsOpen)
                        {
                            var command = new DoorOpenCommand(doorInstance);
                            command.Execute(null);
                        }
                        else
                        {
                            var command = new DoorCloseCommand(doorInstance);
                            command.Execute(null);
                        }
                    }
                }
            };


        }

        private void AttachWindowCommandListeners(Window window)
        {
            window.PropertyChanged += (sender, e) =>
            {
                var windowInstance = sender as Window;
                if (windowInstance != null)
                {
                    switch (e.PropertyName)
                    {
                        case nameof(Window.IsOpen):
                            if (windowInstance.IsOpen)
                            {
                                var command = new WindowOpenCommand(windowInstance);
                                command.Execute(null);
                            }
                            else
                            {
                                var command = new WindowCloseCommand(windowInstance);
                                command.Execute(null);
                            }
                            break;

                        case nameof(Window.IsBlocked):
                            if (windowInstance.IsBlocked)
                            {
                                var command = new BlockWindowCommand(windowInstance);
                                command.Execute(null);
                            }
                            else
                            {
                                var command = new UnBlockWindowCommand(windowInstance);
                                command.Execute(null);
                            }
                            break;
                    }
                }
            };
        }

    }
}
