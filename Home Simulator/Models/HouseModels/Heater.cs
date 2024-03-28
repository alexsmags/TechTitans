using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Home_Simulator.Models.HouseModels
{
    public class Heater : INotifyPropertyChanged
    {
        private string _heaterName;

        private bool _isOn;

        private BitmapImage _heaterImage;

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


        public string HeaterName
        {
            get { return _heaterName; }
            set
            {
                _heaterName = value;
                OnPropertyChanged(nameof(HeaterName));
            }
        }

        public BitmapImage HeaterImage
        {
            get { return _heaterImage; }
            set
            {
                _heaterImage = value;
                OnPropertyChanged(nameof(HeaterImage));
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


        public Heater()
        {
            _heaterImage = new BitmapImage(new Uri(@"\..\..\Images\HouseObjectIcons\heater_off.png", UriKind.RelativeOrAbsolute));
            _isOn = false;
        }


        public void TurnOnHeater()
        {
            IsOn = true;
            HeaterImage = new BitmapImage(new Uri(@"\..\..\Images\HouseObjectIcons\heater_on.png", UriKind.RelativeOrAbsolute));
        }

        public void TurnOffHeater()
        {
            IsOn = false;
            HeaterImage = new BitmapImage(new Uri(@"\..\..\Images\HouseObjectIcons\heater_off.png", UriKind.RelativeOrAbsolute));
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
