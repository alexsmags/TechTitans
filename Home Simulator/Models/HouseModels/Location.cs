using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseModels
{
    public abstract class Location : INotifyPropertyChanged
    {
		private string _name;

		public string Name
		{
			get { return _name; }
			set 
            {
                _name = value; 
                OnPropertyChanged(nameof(Name));
            }
		}
        private bool _isOutdoor;

        public bool IsOutdoor
        {
            get { return _isOutdoor; }
            set 
            { 
                _isOutdoor = value;
                OnPropertyChanged(nameof(IsOutdoor));
            }
        }


        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
