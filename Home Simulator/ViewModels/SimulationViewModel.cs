using Home_Simulator.Components;
using Home_Simulator.Models.HouseModels;
using Home_Simulator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Room = Home_Simulator.Models.HouseModels.Room;
using Home_Simulator.Commands.HouseObjectCommands;
using Home_Simulator.Models.HouseSimulationModels;
using Home_Simulator.Models.ProfileModels;
using System.Windows;
using Home_Simulator.Commands;
using Home_Simulator.Stores;

namespace Home_Simulator.ViewModels
{
    public class SimulationViewModel : ViewModelBase
    {
        #region Fields

        private string _currentTime;

        private string _currentDate;

        private bool _hasAccessToDoors;

        private bool _hasAccessToWindows;

        private double _outsideTemperature;

        private string _newZoneName;

        private DispatcherTimer _timer;

        private bool _isSimulationRunning;

        public DateTimeModel simulationModel;

        public ObservableCollection<User> users;

        private ObservableCollection<Room> _availableRooms = new ObservableCollection<Room>();

        private ObservableCollection<Zone> _zones = new ObservableCollection<Zone>();

        public ObservableCollection<Zone> Zones
        {
            get { return _zones; }
            set
            {
                if (_zones != value)
                {
                    _zones = value;
                    OnPropertyChanged(nameof(Zones));
                }
            }
        }

        public ObservableCollection<Room> AvailableRooms
        {
            get { return _availableRooms; }
            set
            {
                if (_availableRooms != value)
                {
                    _availableRooms = value;
                    OnPropertyChanged(nameof(AvailableRooms));
                }
            }
        }

        public LocationService LocationService { get; set; }

        public ObservableCollection<Room> Rooms => LocationService.Rooms;

        public OutdoorLocation OutdoorLocation => LocationService.OutdoorLocation;

        public LightPermissionManager LightPermissionManager;

        private User _currentUser;

        private Location _currentLocation;

        private Zone _selectedZone;

        #endregion

        #region Commands

        public ICommand ChangeUserCommand { get; private set; }

        public ICommand ChangeTemperatureCommand { get; private set; }

        public ICommand ChangeUserLocationCommand { get; private set; }

        public ICommand ChangeDateTimeCommand { get; private set; }

        public ICommand AddUserCommand { get; private set; }

        public ICommand RemoveUserCommand { get; private set; }

        public ICommand EditUserCommand { get; private set; }

        public ICommand EditUsersCommand { get; private set; }

        public ICommand ToggleLightCommand { get; private set; }

        public ICommand ToggleDoorCommand { get; private set; }

        public ICommand ToggleOpenCloseWindowCommand { get; private set; }

        public ICommand ToggleBlockUnblockWindowCommand { get; private set; }

        public ICommand AddRoomToZoneCommand { get; private set; }

        public ICommand AddZoneCommand { get; private set; }

        public ICommand RemoveZoneCommand { get; private set; }

        public ICommand RemoveRoomFromZoneCommand { get; private set; }

        public ICommand AddTemperaturePeriodCommand { get; private set; }

        public ICommand RemoveTemperaturePeriodCommand { get; private set; }

        public ICommand DeletePeriodCommand { get; private set; }


        #endregion

        #region Properties
        public bool CanEditUser => CurrentUser != null && users.Any();

        public double OutsideTemperature
        {
            get { return _outsideTemperature; }
            set 
            { 
                _outsideTemperature = value;
                OnPropertyChanged(nameof(OutsideTemperature));
            }
        }


        public string CurrentTime
        {
            get { return simulationModel.GetCurrentTime(); }
            set
            {
                _currentTime = simulationModel.GetCurrentTime();
                OnPropertyChanged(nameof(CurrentTime));
            }
        }

        public string CurrentDate
        {
            get { return simulationModel.GetCurrentDate(); }
            set
            {
                _currentDate = simulationModel.GetCurrentDate();
                OnPropertyChanged(nameof(CurrentDate));
            }
        }

        public double TimeSpeed
        {
            get => simulationModel.TimeSpeed;
            set
            {
                if (simulationModel.TimeSpeed != value)
                {
                    simulationModel.TimeSpeed = value;
                    OnPropertyChanged(nameof(TimeSpeed));
                }
            }
        }

        public bool IsSimulationRunning
        {
            get => _isSimulationRunning;
            set
            {
                if (_isSimulationRunning != value)
                {
                    _isSimulationRunning = value;
                    OnPropertyChanged(nameof(IsSimulationRunning));

                    if (_isSimulationRunning)
                        _timer.Start();
                    else
                        _timer.Stop();
                }
            }
        }

        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                if (_currentUser != value)
                {
                    _currentUser = value;
                    CurrentLocation = _currentUser?.CurrentLocation;

                    OnPropertyChanged(nameof(CurrentUser));
                    OnPropertyChanged(nameof(CanEditUser));
                    OnPropertyChanged(nameof(HasAccessToDoors));
                    OnPropertyChanged(nameof(HasAccessToWindows));
                    LightPermissionManager.UpdateLightPermissionsForAllUsers(Rooms, CurrentUser);
                }
            }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set 
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
                LightPermissionManager.UpdateLightPermissionsForAllUsers(Rooms, CurrentUser);

            }
        }


        public bool HasAccessToDoors
        {
            get { return _currentUser?.HasAccessToDoors ?? false; }
            set
            {
                if (_currentUser != null)
                {
                    _currentUser.HasAccessToDoors = value;
                }
                OnPropertyChanged(nameof(HasAccessToDoors));
            }
        }

        public bool HasAccessToWindows
        {
            get { return _currentUser?.HasAccessToWindows ?? false; }
            set
            {
                if (_currentUser != null)
                {
                    _currentUser.HasAccessToWindows = value;
                }
                OnPropertyChanged(nameof(HasAccessToWindows));
            }
        }

        public Zone SelectedZone
        {
            get { return _selectedZone; }
            set
            {
                if (_selectedZone != value)
                {
                    _selectedZone = value;
                    OnPropertyChanged(nameof(SelectedZone));
                    OnPropertyChanged(nameof(SelectedZone.Rooms));
                }
            }
        }

        public string NewZoneName
        {
            get { return _newZoneName; }
            set
            {
                _newZoneName = value;
                OnPropertyChanged(nameof(NewZoneName));
            }
        }


        #endregion

        #region Constructors

        public SimulationViewModel()
        {
            InitializeSimulation();
        }

        #endregion

        #region Initializers

        private void InitializeSimulation()
        {
            users = new ObservableCollection<User>();
            LocationService = new LocationService();
            simulationModel = new DateTimeModel();
            LightPermissionManager = new LightPermissionManager();
            ChangeUserCommand = new ChangeUserCommand(this);
            ChangeTemperatureCommand = new ChangeTemperatureCommand(this);
            ChangeUserLocationCommand = new ChangeUserLocationCommand(this);
            ChangeDateTimeCommand = new ChangeDateTimeCommand(this);
            AddUserCommand = new AddUserCommand(this);
            RemoveUserCommand = new RemoveUserCommand(this);
            EditUsersCommand = new EditUsersCommand(this);
            AddRoomToZoneCommand = new AddRoomToZoneCommand(this);
            RemoveRoomFromZoneCommand = new RemoveRoomFromZoneCommand(this);
            AddZoneCommand = new AddZoneCommand(this);
            RemoveZoneCommand = new RemoveZoneCommand(this);
            AddTemperaturePeriodCommand = new AddTemperaturePeriodCommand(this);
            RemoveTemperaturePeriodCommand = new RemoveTemperaturePeriodCommand(this);
            DeletePeriodCommand = new DeletePeriodCommand(this);

            ToggleLightCommand = new ToggleLightCommand();
            ToggleDoorCommand = new ToggleDoorCommand();
            ToggleOpenCloseWindowCommand = new ToggleOpenCloseWindowCommand();
            ToggleBlockUnblockWindowCommand = new ToggleBlockUnblockWindowCommand();


            OutsideTemperature = 15;

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += (sender, e) =>
            {
                simulationModel.IncrementTime();
                OnPropertyChanged(nameof(CurrentTime));
                OnPropertyChanged(nameof(CurrentDate));
                UpdateRoomTemperatures();
            };

        }

        public void InvokeCurentUserPropertyChanged () => OnPropertyChanged(nameof(CurrentUser));

        // This will be encapsulated later on, most likely using Observer Design Pattern. 
        private void UpdateRoomTemperatures()
        {
            foreach (var zone in Zones)
            {
                var currentTime = simulationModel.SimulationTime;
                foreach (var period in zone.TemperaturePeriods)
                {
                    if (currentTime >= period.StartTime && currentTime < period.EndTime)
                    {
                        foreach (var room in zone.Rooms)
                        {
                            room.RoomTemperature = period.DesiredTemperature;
                        }
                        break; 
                    }
                }
            }
        }

        public void InvokeAccess()
        {
            OnPropertyChanged(nameof(HasAccessToDoors));
            OnPropertyChanged(nameof(HasAccessToWindows));
        }

        #endregion

        #region Private Methods

        #endregion

    }
}
