using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseSimulationModels
{
    public class TemperaturePeriodModel
    {
        public string PeriodName { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public double DesiredTemperature { get; set; }
    }
}
