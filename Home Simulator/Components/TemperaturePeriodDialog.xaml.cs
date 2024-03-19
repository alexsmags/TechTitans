using Home_Simulator.Models.HouseSimulationModels;
using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Home_Simulator.Components
{
    public partial class TemperaturePeriodDialog : Window
    {
        private SimulationViewModel _simulationViewModel;
        public TemperaturePeriodDialog(SimulationViewModel simulationViewModel)
        {
            InitializeComponent();
            UpdateTemperatureDisplay();
            _simulationViewModel = simulationViewModel;
            this.DataContext = _simulationViewModel;
        }

        private void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            string periodName = periodNameTextBox.Text;
            TimeSpan startTime;
            TimeSpan endTime;
            bool startTimeIsValid = TimeSpan.TryParse(startTimeTextBox.Text, out startTime);
            bool endTimeIsValid = TimeSpan.TryParse(endTimeTextBox.Text, out endTime);
            double desiredTemperature = temperatureSlider.Value;

            if (!startTimeIsValid || !endTimeIsValid)
            {
                MessageBox.Show("Invalid time format. Please enter times in HH:MM format.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_simulationViewModel.SelectedZone != null)
            {
                if (_simulationViewModel.SelectedZone.TemperaturePeriods.Count != 3)
                {
                    if (!DoesPeriodOverlap(startTime, endTime, _simulationViewModel.SelectedZone.TemperaturePeriods))
                    {
                        var newPeriod = new TemperaturePeriodModel
                        {
                            PeriodName = periodName,
                            StartTime = startTime,
                            EndTime = endTime,
                            DesiredTemperature = desiredTemperature
                        };

                        _simulationViewModel.SelectedZone.TemperaturePeriods.Add(newPeriod);
                        this.DialogResult = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("The new period overlaps with an existing period.", "Overlap Detected", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Cannot add more than 3 periods.", "Limit Reached", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }



        private bool DoesPeriodOverlap(TimeSpan newStartTime, TimeSpan newEndTime, ObservableCollection<TemperaturePeriodModel> existingPeriods)
        {
            foreach (var period in existingPeriods)
            {
                if ((newStartTime < period.EndTime && newStartTime >= period.StartTime) ||
                    (newEndTime > period.StartTime && newEndTime <= period.EndTime))
                {
                    return true;
                }

                if (newStartTime <= period.StartTime && newEndTime >= period.EndTime)
                {
                    return true; 
                }
            }
            return false;
        }

        private void UpdateTemperatureDisplay()
        {
            tempDisplay.Text = "Temperature: " + temperatureSlider.Value.ToString("N0") + "°C";
        }
        private void setTemperature_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateTemperatureDisplay();
        }


    }
}
