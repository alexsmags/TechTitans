using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Home_Simulator.Models.HouseModels
{
    public class Door : INotifyPropertyChanged
    {
        private string _doorName;

        private bool _isOpen;

        private BitmapImage _doorImage;


        public string DoorName
        {
            get { return _doorName; }
            set
            {
                _doorName = value;
                OnPropertyChanged(nameof(DoorName));
            }
        }

        public bool IsOpen
        {
            get { return _isOpen; }
            set
            {
                _isOpen = value;
                OnPropertyChanged(nameof(IsOpen));
            }
        }

        public BitmapImage DoorImage
        {
            get { return _doorImage; }
            set
            {
                _doorImage = value;
                OnPropertyChanged(nameof(DoorImage));
            }
        }


        public Door()
        {
            _doorImage = new BitmapImage(new Uri(@"\..\..\Images\HouseObjectIcons\door_closed.png", UriKind.RelativeOrAbsolute));
            _isOpen = false;
        }


        public void OpenDoor()
        {
            IsOpen = true;
            DoorImage = new BitmapImage(new Uri(@"\..\..\Images\HouseObjectIcons\door_open.png", UriKind.RelativeOrAbsolute));
        }

        public void CloseDoor()
        {
            IsOpen = false;
            DoorImage = new BitmapImage(new Uri(@"\..\..\Images\HouseObjectIcons\door_closed.png", UriKind.RelativeOrAbsolute));
        }



        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
