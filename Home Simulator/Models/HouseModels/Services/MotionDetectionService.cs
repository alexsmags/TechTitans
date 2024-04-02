using Home_Simulator.Models.HouseSimulationModels;
using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Home_Simulator.Models.HouseModels.Services
{
    public class MotionDetectionService
    {
        private readonly SimulationViewModel _viewModel;
        private Dictionary<Room, int> _roomCountdowns = new Dictionary<Room, int>();

        public MotionDetectionService(SimulationViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.SimulationModel.PropertyChanged += HandleSimulationTimeChanged;
        }

        private void HandleSimulationTimeChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(DateTimeModel.SimulationTime) || !_viewModel.IsAwayModeEnabled) return;

            var roomsToNotify = new List<Room>();

            foreach (var roomEntry in _roomCountdowns.ToList())
            {
                if (--_roomCountdowns[roomEntry.Key] <= 0)
                {
                    roomsToNotify.Add(roomEntry.Key);
                }
            }

            foreach (var room in roomsToNotify)
            {
                NotifyPolice(room);
                _roomCountdowns.Remove(room);
            }
        }

        public void DetectMotion(Room room)
        {
            if (!_viewModel.IsAwayModeEnabled || !_viewModel.IsSimulationRunning || room == null) return;

            room.IsMotionDetected = true;

            if (_viewModel.IsPoliceTimerActive && !_roomCountdowns.ContainsKey(room))
            {
                _roomCountdowns[room] = _viewModel.PoliceTimer;
                _viewModel.AddLogMessage($"Motion detected in {room.Name}. Notifying police in {_viewModel.PoliceTimer} seconds.");
            }
            else
            {
                _viewModel.AddLogMessage($"Motion detected in {room.Name}. Police timer is disabled.");
            }
        }

        private void NotifyPolice(Room room)
        {
            _viewModel.AddLogMessage($"Police notified due to motion detection in {room.Name}.");
            room.IsMotionDetected = false; 
        }
    }
}
