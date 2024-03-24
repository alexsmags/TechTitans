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

        private double _insideTemperature;
        private double _outsideTemperature;

        private bool ShouldOperate(double outsideTemperature, double insideTemperature, DateTime currentDate)
        {
            return IsSummer(currentDate) && outsideTemperature < insideTemperature;
        }

        private static bool IsSummer(DateTime date)
        {
            return date.Month >= 6 && date.Month <= 8;
        }


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

        public double InsideTemperature
        {
            get { return _insideTemperature; }
            set
            {
                _insideTemperature = value;
                OnPropertyChanged(nameof(InsideTemperature));
                AdjustACBasedOnTemperature();
            }
        }

        public double OutsideTemperature
        {
            get { return _outsideTemperature; }
            set
            {
                _outsideTemperature = value;
                OnPropertyChanged(nameof(OutsideTemperature));
                AdjustACBasedOnTemperature();
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

        private void AdjustACBasedOnTemperature()
        {
            if (IsOn && OutsideTemperature < InsideTemperature)
            {
                TurnOffAC();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
