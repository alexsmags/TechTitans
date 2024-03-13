using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Home_Simulator.Models.HouseModels
{
    public class Window : INotifyPropertyChanged
    {
		private bool _isOpen;

        private bool _isBlocked;

        private BitmapImage _windowImage;

        private string _windowName;

        public string WindowState
        {
            get
            {
                if (IsBlocked) return "Blocked";
                return IsOpen ? "Open" : "Closed";
            }
        }

        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                if (_isOpen != value)
                {
                    _isOpen = value;
                    OnPropertyChanged(nameof(IsOpen));
                    OnPropertyChanged(nameof(WindowState));
                }
            }
        }

        public bool IsBlocked
        {
            get => _isBlocked;
            set
            {
                if (_isBlocked != value)
                {
                    _isBlocked = value;
                    OnPropertyChanged(nameof(IsBlocked));
                    OnPropertyChanged(nameof(WindowState));
                }
            }
        }

        public BitmapImage WindowImage
        {
            get { return _windowImage; }
            set 
            { 
                _windowImage = value;
                OnPropertyChanged(nameof(WindowImage));
            }
        }

        public string WindowName
        {
            get { return _windowName; }
            set
            {
                _windowName = value;
                OnPropertyChanged(nameof(WindowName));
            }
        }


        public Window() 
        {
            _windowImage = new BitmapImage(new Uri(@"\..\..\Images\HouseObjectIcons\window_closed.png", UriKind.RelativeOrAbsolute));
            _isOpen = false;
            _isBlocked = false;
        }

        public void OpenWindow()
        {
            IsOpen = true;
            WindowImage = new BitmapImage(new Uri(@"\..\..\Images\HouseObjectIcons\window_open.png", UriKind.RelativeOrAbsolute));
        }

        public void CloseWindow()
        {
            IsOpen = false;
            WindowImage = new BitmapImage(new Uri(@"\..\..\Images\HouseObjectIcons\window_closed.png", UriKind.RelativeOrAbsolute));
        }

        public void BlockWindow()
        {
            IsBlocked = true;
            WindowImage = new BitmapImage(new Uri(@"\..\..\Images\HouseObjectIcons\blocked_icon.png", UriKind.RelativeOrAbsolute));
        }

        public void UnBlockWindow()
        {
            IsBlocked = false;

            if (_isOpen)
            {
                WindowImage = new BitmapImage(new Uri(@"\..\..\Images\HouseObjectIcons\window_open.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                WindowImage = new BitmapImage(new Uri(@"\..\..\Images\HouseObjectIcons\window_closed.png", UriKind.RelativeOrAbsolute));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
