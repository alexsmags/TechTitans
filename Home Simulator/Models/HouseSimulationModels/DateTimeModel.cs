using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Home_Simulator.Models.HouseSimulationModels
{
    public class DateTimeModel : INotifyPropertyChanged
    {
        #region Fields

        private TimeSpan _simulationTime;

        private DateTime _simulationDate;

        private string _formattedSimulationDate;

        private double _timeSpeed = 1;

        #endregion

        #region Properties

        public TimeSpan SimulationTime
        {
            get { return _simulationTime; }
            set
            {
                _simulationTime = value;
                OnPropertyChanged(nameof(SimulationTime));
            }
        }

        public DateTime SimulationDate
        {
            get { return _simulationDate; }
            set
            {
                _simulationDate = value;
                OnPropertyChanged(nameof(SimulationDate));
                OnPropertyChanged(nameof(FormattedSimulationDate));
            }
        }

        public string FormattedSimulationDate
        {
            get { return SimulationDate.ToString("yyyy/MM/dd"); }
        }

        public double TimeSpeed
        {
            get => _timeSpeed;
            set => _timeSpeed = value;
        }

        #endregion

        public DateTimeModel()
        {
            SimulationTime = TimeSpan.Zero;
            SimulationDate = DateTime.Now;
        }

        #region Public Methods

        public void IncrementTime()
        {
            TimeSpan timeIncrement = TimeSpan.FromSeconds(_timeSpeed * 20);
            SimulationTime = SimulationTime.Add(timeIncrement);

            if (SimulationTime.TotalHours >= 24)
            {
                SimulationDate = SimulationDate.AddDays(1);
                SimulationTime = TimeSpan.Zero;
            }
        }

        public string GetCurrentTime() => SimulationTime.ToString(@"hh\:mm\:ss"); 

        public string GetCurrentDate() => SimulationDate.ToString("yyyy-MM-dd");

        #endregion

        #region Property Changed

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

    }
}
