using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Home_Simulator.Models.HouseModels
{
    public class AirConditioner : INotifyPropertyChanged
    {
        private string _acName;

        private bool _isOn;

        private BitmapImage _acImage;

        private double _desiredTemperature;



        public bool IsOn
        {
            get { return _isOn; }
            set 
            {
                _isOn = value;
                OnPropertyChanged(nameof(IsOn));
            }
        }


        public string ACName
        {
            get { return _acName; }
            set 
            { 
                _acName = value;
                OnPropertyChanged(nameof(ACName));
            }
        }

        public BitmapImage ACImage
        {
            get { return _acImage; }
            set
            {
                _acImage = value;
                OnPropertyChanged(nameof(ACImage));
            }
        }

        public double DesiredTemperature
        {
            get { return _desiredTemperature; }
            set
            {
                _desiredTemperature = value;
                OnPropertyChanged(nameof(DesiredTemperature));
            }
        }


        public AirConditioner()
        {
            _acImage = new BitmapImage(new Uri(@"\..\..\Images\HouseObjectIcons\ac_off.png", UriKind.RelativeOrAbsolute));
            _isOn = false;
        }


        public void TurnOnAC()
        {
            IsOn = true;
            ACImage = new BitmapImage(new Uri(@"\..\..\Images\HouseObjectIcons\ac_on.png", UriKind.RelativeOrAbsolute));
        }

        public void TurnOffAC()
        {
            IsOn = false;
            ACImage = new BitmapImage(new Uri(@"\..\..\Images\HouseObjectIcons\ac_off.png", UriKind.RelativeOrAbsolute));
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
