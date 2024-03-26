
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
using System.Globalization;
using Home_Simulator.Models.HouseModels.Services;
using Home_Simulator.MessageLogs;

namespace Home_Simulator.ViewModels
{
    public class SimulationViewModel : ViewModelBase
    {
        #region Fields

        private  Log _log;

        private ObservableCollection<string> _logMessages = new ObservableCollection<string>();

        private double _outsideTemperature;

        private string _newZoneName;

        private DispatcherTimer _timer;

        private bool _isSimulationRunning;

        private DateTimeModel _simulationModel;

        public ObservableCollection<User> users;

        private ObservableCollection<Room> _availableRooms = new ObservableCollection<Room>();

        private ObservableCollection<Zone> _zones = new ObservableCollection<Zone>();

        public LocationService LocationService { get; set; }

        public ObservableCollection<Room> Rooms => LocationService.Rooms;

        public OutdoorLocation OutdoorLocation => LocationService.OutdoorLocation;

        public LightPermissionManager LightPermissionManager;

        private User _currentUser;

        private Location _currentLocation;

        private Zone _selectedZone;

        private WindowStateService _windowStateService;

        private OutsideTemperatureService _outsideTemperatureService;

        private ZoneRoomTemperatureService _zoneRoomTemperatureService;

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
        
        public ICommand LoadCSVTemperatureCommand { get; private set; }


        #endregion

        #region Properties

        public ObservableCollection<string> LogMessages
        {
            get { return _logMessages; }
            set
            {
                _logMessages = value;
                OnPropertyChanged(nameof(LogMessages));
            }
        }

        public bool CanEditUser => CurrentUser != null && users.Any();

        public List<(DateTime dateTime, double temperature)> OutsideTemperatureData { get; set; }

        public double OutsideTemperature
        {
            get { return _outsideTemperature; }
            set
            {   
                _outsideTemperature = value;
                OnPropertyChanged(nameof(OutsideTemperature));

            }
        }

        public bool IsSimulationRunning
        {
            get => _isSimulationRunning;
            set
            {
                if (_isSimulationRunning != value)
                {
                    bool previousValue = _isSimulationRunning;
                    _isSimulationRunning = value;
                    OnPropertyChanged(nameof(IsSimulationRunning));

                    if (_isSimulationRunning)
                    {
                        _timer.Start();
                        _log.AddMessage("Simulation started");
                    }
                    else
                    {
                        _timer.Stop();
                        if (previousValue)
                        {
                            _log.AddMessage("Simulation stopped");
                        }
                    }
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
                    var previousUser = _currentUser;
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
                _zoneRoomTemperatureService.AdjustRoomTemperature(this);
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

        public DateTimeModel SimulationModel
        {
            get { return _simulationModel; }
            set 
            { 
                _simulationModel = value;
                OnPropertyChanged(nameof(SimulationModel)); 
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

        public void AddLogMessage(string message)
        {
            _log.AddMessage(message);
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
            _log = Log.Instance(this);
            users = new ObservableCollection<User>();
            LocationService = new LocationService();
            SimulationModel = new DateTimeModel();
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
            LoadCSVTemperatureCommand = new LoadCSVTemperatureCommand(this);
            ToggleLightCommand = new ToggleLightCommand(this);
            ToggleDoorCommand = new ToggleDoorCommand(this);
            ToggleOpenCloseWindowCommand = new ToggleOpenCloseWindowCommand(this);
            ToggleBlockUnblockWindowCommand = new ToggleBlockUnblockWindowCommand(this);

            _windowStateService = new WindowStateService();
            _outsideTemperatureService = new OutsideTemperatureService();
            _zoneRoomTemperatureService = new ZoneRoomTemperatureService();


          

            
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += (sender, e) =>
            {
                SimulationModel.IncrementTime();
            };

            SimulationModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(DateTimeModel.SimulationDate))
                {
                    _outsideTemperatureService.UpdateOutsideTemperature(this);
                    _zoneRoomTemperatureService.AdjustRoomTemperature(this);
                }

                if (e.PropertyName == nameof(DateTimeModel.SimulationTime))
                {
                    _zoneRoomTemperatureService.UpdateRoomTemperatures(this);
                    _windowStateService.UpdateWindowStates(this);
                }
            };

        }

        public void InvokeCurentUserPropertyChanged() => OnPropertyChanged(nameof(CurrentUser));

        public void InvokeAccess()
        {
            OnPropertyChanged(nameof(HasAccessToDoors));
            OnPropertyChanged(nameof(HasAccessToWindows));
        }

        #endregion


    }
}
