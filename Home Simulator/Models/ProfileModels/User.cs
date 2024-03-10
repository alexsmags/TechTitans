using Home_Simulator.Models.HouseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace Home_Simulator.Models.ProfileModels
{
    public class User : INotifyPropertyChanged
    {

        private string _name;

        private int _age;

        private UserType? _type;

        private bool _hasAccessToLights;

        private bool _hasAccessToDoors;

        private bool _hasAccessToWindows;

        private Location _currentLocation;

        private BitmapImage _profileImage;

        public event PropertyChangedEventHandler PropertyChanged;



        public BitmapImage ProfileImage
        {
            get { return _profileImage; }
            set 
            { 
                _profileImage = value;
                OnPropertyChanged(nameof(ProfileImage));
            }
        }


        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public UserType? Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged(nameof(Type));
                    AssignPermissions();
                    ProfileImage = _type.HasValue
                        ? new BitmapImage(new Uri(ProfileImageBasedOffUserType(_type.Value), UriKind.RelativeOrAbsolute))
                        : null;
                }
            }
        }

        public bool HasAccessToLights
        {
            get => _hasAccessToLights;

            set
            {
                _hasAccessToLights = value;
                OnPropertyChanged(nameof(HasAccessToLights));   
            }
        }

        public bool HasAccessToDoors
        {
            get => _hasAccessToDoors;

            set
            {
                _hasAccessToDoors = value;
                OnPropertyChanged(nameof(HasAccessToDoors));
            }
        }

        public bool HasAccessToWindows
        {
            get => _hasAccessToWindows;

            set
            {
                _hasAccessToWindows = value;
                OnPropertyChanged(nameof(HasAccessToWindows));
            }
        }

        public Location CurrentLocation
        {
            get => _currentLocation;
            
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
                PermissionBasedOffLocation();
            }
        }

        public User(string name, int age, UserType? type = null) 
        {
            Name = name;
            Age = age;
            Type = type;
        }

        private String ProfileImageBasedOffUserType(UserType type)
        {
            if (type == UserType.Child)
            {
                return @"../Images/ProfileIcons/Child.png";
            }

            if (type == UserType.Father) 
            {
                return @"../Images/ProfileIcons/Father.png";
            }

            if (type == UserType.Mother)
            {
                return @"../Images/ProfileIcons/Mother.png";
            }

            if (type == UserType.Guest)
            {
                return @"../Images/ProfileIcons/Guest.png";
            }

            if (type == UserType.Stranger)
            {
                return @"../Images/ProfileIcons/Stranger.png";
            }


            return null;
        }

        private void AssignPermissions()
        {
            HasAccessToLights = false;
            HasAccessToDoors = false;
            HasAccessToWindows = false;

            switch (_type)
            {
                case UserType.Child:
                    HasAccessToLights = true;
                    break;
                case UserType.Father:
                case UserType.Mother:
                    HasAccessToLights = true;
                    HasAccessToDoors = true;
                    HasAccessToWindows = true;
                    break;
                case UserType.Guest:
                    HasAccessToLights = true;
                    break;
                case UserType.Stranger:
                    break;
                default:
                    break;
            }
        }

        private void PermissionBasedOffLocation()
        {
            if (this.CurrentLocation?.Name.Equals("Outdoor") == true)
            {
                HasAccessToLights = false;
                HasAccessToDoors = false;
                HasAccessToWindows = false;
            }
            else
            {
                AssignPermissions();
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(propertyName, new PropertyChangedEventArgs(nameof(propertyName)));
        }
    }

}
