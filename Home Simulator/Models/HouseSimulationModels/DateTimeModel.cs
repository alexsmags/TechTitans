﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseSimulationModels
{
    public class DateTimeModel
    {
        public TimeSpan SimulationTime { get; set; }
        public DateTime SimulationDate { get; set; }
        private double _timeSpeed = 1;

        public double TimeSpeed
        {
            get => _timeSpeed;
            set => _timeSpeed = value;
        }

        public DateTimeModel()
        {
            SimulationTime = TimeSpan.Zero;
            SimulationDate = DateTime.Now;
        }

        public void IncrementTime()
        {
            TimeSpan timeIncrement = TimeSpan.FromSeconds(_timeSpeed);
            SimulationTime = SimulationTime.Add(timeIncrement);

            if (SimulationTime.TotalHours >= 24)
            {
                SimulationDate = SimulationDate.AddDays(1);
                SimulationTime = TimeSpan.Zero;
            }
        }

        public string GetCurrentTime() => SimulationTime.ToString(@"hh\:mm\:ss");

        public string GetCurrentDate() => SimulationDate.ToString("M") + ", " + SimulationDate.ToString("yyyy");
    }
}