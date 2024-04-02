
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
using System.ComponentModel;

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

        private bool _isShhEnabled = false;

        private bool _isAwayModeEnabled = false;

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

        private DoorStateService _doorStateService;

        private OutsideTemperatureService _outsideTemperatureService;

        private ZoneRoomTemperatureService _zoneRoomTemperatureService;

        private AirConditionerService _airConditionerService;

        private HeatingService _heatingService;

        private MotionDetectionService _motionDetectionService;

        private TemperatureMonitorService _temperatureMonitorService;

        private int _policeTimer;

        private bool _isPoliceTimerActive = false;

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

        public ICommand ToggleAcCommand { get; private set; }

        public ICommand ToggleHeaterCommand { get; private set; }

        public ICommand ChangeRoomTemperatureCommand { get; private set; }

        public ICommand ViewRoomsCommand { get; private set; }

        public ICommand SetMotionDetectorLocationCommand { get; private set; }

        public ICommand SetPoliceTimerCommand { get; private set; }

        public ICommand RemoveMotionDetectorLocationCommand { get; private set; }

        public ICommand TogglePoliceTimerCommand { get; private set; }


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

        public AirConditioner AirConditioner {get; set;}

        public Heater Heater { get; set; }

        public List<(DateTime dateTime, double temperature)> OutsideTemperatureData { get; set; }

        public double OutsideTemperature
        {
            get { return _outsideTemperature; }
            set
            {
                double oldTemperature = _outsideTemperature;
                _outsideTemperature = value;
                OnPropertyChanged(nameof(OutsideTemperature));
                _temperatureMonitorService.CheckOutsideTemperatureChanges(value);
                _airConditionerService.UpdateAirConditionerState();

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

        public bool IsShhEnabled
        {
            get => _isShhEnabled;
            set
            {
                if (_isShhEnabled != value)
                {
                    _isShhEnabled = value;
                    OnPropertyChanged(nameof(IsShhEnabled));

                    if (_isShhEnabled)
                    {
                        _log.AddMessage("SHH Enabled");
                    }
                    else
                    {
                        _log.AddMessage("SHH Disabled");
                    }
                }
            }
        }

        public bool IsAwayModeEnabled
        {
            get => _isAwayModeEnabled;
            set
            {
                if (_isAwayModeEnabled != value)
                {
                    _isAwayModeEnabled = value;
                    OnPropertyChanged(nameof(IsAwayModeEnabled));
                    _windowStateService.BlockWindowsOnAwayModeOn();
                    _doorStateService.CloseDoorsOnAwayModeOn();

                    if (_isAwayModeEnabled)
                    {
                        _windowStateService.CheckDoorsAndWindows();
                        _log.AddMessage("Away Mode turned On");
                    }
                    else
                    {
                        _log.AddMessage("Away Mode turned Off");
                    }
                }
            }
        }

        public bool IsPoliceTimerActive
        {
            get => _isPoliceTimerActive;
            set
            {
                _isPoliceTimerActive = value;
                OnPropertyChanged(nameof(IsPoliceTimerActive));
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
                _zoneRoomTemperatureService.AdjustRoomTemperature();
                LightPermissionManager.UpdateLightPermissionsForAllUsers(Rooms, CurrentUser);


                Room currentRoom = value as Room;
                if (currentRoom != null && currentRoom.HasMotionDetector)
                {
                    _motionDetectionService.DetectMotion(currentRoom);
                }

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

        public int PoliceTimer
        {
            get => _policeTimer;
            set
            {
                _policeTimer = value;
                OnPropertyChanged(nameof(PoliceTimer));
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
            ToggleAcCommand = new ToggleAcCommand(this);
            ToggleHeaterCommand = new ToggleHeaterCommand(this);
            ChangeRoomTemperatureCommand = new ChangeRoomTemperatureCommand(this);
            ViewRoomsCommand = new ViewRoomsCommand(this);
            SetMotionDetectorLocationCommand = new SetMotionDetectorLocationCommand(this);
            RemoveMotionDetectorLocationCommand = new RemoveMotionDetectorLocationCommand(this);
            SetPoliceTimerCommand = new SetPoliceTimerCommand(this);
            TogglePoliceTimerCommand = new TogglePoliceTimerCommand(this);  
            _motionDetectionService = new MotionDetectionService(this);

            _windowStateService = new WindowStateService(this);
            _doorStateService = new DoorStateService(this);
            _outsideTemperatureService = new OutsideTemperatureService(this);
            _zoneRoomTemperatureService = new ZoneRoomTemperatureService(this, AirConditioner);
            _airConditionerService = new AirConditionerService(this);
            _heatingService = new HeatingService(this);
            _temperatureMonitorService = new TemperatureMonitorService(this);


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
                if (IsShhEnabled)
                {
                    if (e.PropertyName == nameof(DateTimeModel.SimulationDate))
                    {
                        _zoneRoomTemperatureService.AdjustRoomTemperature();
                        _airConditionerService.UpdateAirConditionerState();
                        _heatingService.UpdateRoomTemperatures();
                    }

                    if (e.PropertyName == nameof(DateTimeModel.SimulationTime))
                    {
                        _zoneRoomTemperatureService.UpdateRoomTemperatures();
                        _airConditionerService.UpdateRoomTemperatures(this);
                        _heatingService.UpdateRoomTemperatures();

                        if (!IsAwayModeEnabled)
                        {
                            _windowStateService.UpdateWindowStates();
                        }
                    }
                }

                else
                {
                    if (e.PropertyName == nameof(DateTimeModel.SimulationDate))
                    {
                        _outsideTemperatureService.UpdateOutsideTemperature();
                    }
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

        public void Room_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Room.RoomTemperature) && sender is Room room)
            {
                double newTemperature = room.RoomTemperature;
                // Now, invoke the temperature monitoring logic
                _temperatureMonitorService.CheckTemperatureChanges(room, newTemperature);
            }
        }

    }
}
