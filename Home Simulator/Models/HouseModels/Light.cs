using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Home_Simulator.Models
{
    public class Light : INotifyPropertyChanged
    {
        #region Fields

        private bool _on;
        private BitmapImage _lightImage;

        public event PropertyChangedEventHandler PropertyChanged;

        private bool _userHasAccess;

        public bool UserHasAccess
        {
            get { return _userHasAccess; }
            set { _userHasAccess = value; OnPropertyChanged(nameof(UserHasAccess)); }
        }


        #endregion

        #region Properties

        public bool On
        {
            get { return _on; }
            set
            {
                _on = value;
                OnPropertyChanged(nameof(On));
            }
        }

        public BitmapImage LightImage
        {
            get
            {
                return _lightImage;
            }

            set
            {
                _lightImage = value;
                OnPropertyChanged(nameof(LightImage));
            }
        }



        #endregion

        #region Constructors

        public Light()
        {
            LightImage = new BitmapImage(new Uri(@"\..\..\Images\HouseObjectIcons\lightbulb_off.png", UriKind.RelativeOrAbsolute));
            _on = false;
        }

        #endregion

        #region Public Methods

        public void SwitchOn()
        {
            On = true;
            LightImage = new BitmapImage(new Uri(@"\..\..\Images\HouseObjectIcons\lightbulb_on.png", UriKind.RelativeOrAbsolute));
        }

        public void SwitchOff()
        {
            On = false;
            LightImage = new BitmapImage(new Uri(@"\..\..\Images\HouseObjectIcons\lightbulb_off.png", UriKind.RelativeOrAbsolute));
        }

        #endregion

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
