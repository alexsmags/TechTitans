﻿using Home_Simulator.Components;
using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Globalization;

namespace Home_Simulator.Commands
{
    public class ChangeTemperatureCommand : CommandBase
    {
        private readonly SimulationViewModel _simulationViewModel;

        public ChangeTemperatureCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }


        public override void Execute(object parameter)
        {
            /** var dialog = new ChangeTemperatureDialog(_simulationViewModel.OutsideTemperature);

             dialog.Owner = Application.Current.MainWindow;
             dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
             var result = dialog.ShowDialog();

             if (result == true)
             {
                 _simulationViewModel.OutsideTemperature = dialog.SelectedTemperature;
             }**/

            // Open file dialog to select CSV file
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Title = "Select Temperature CSV File";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Read CSV file
                    var lines = File.ReadAllLines(openFileDialog.FileName);

                    // Parse temperature data
                    var temperatureData = new List<(DateTime dateTime, double temperature)>();

                    foreach (var line in lines.Skip(1)) // Skip header
                    {
                        var parts = line.Split(',');

                        if (parts.Length >= 3)
                        {
                            var date = DateTime.ParseExact(parts[0] + parts[1], "yyyy-MM-ddHH:mm", CultureInfo.InvariantCulture);
                            var temperature = double.Parse(parts[2], CultureInfo.InvariantCulture);
                            temperatureData.Add((date, temperature));
                        }
                    }

                    // Update simulation view model with temperature data
                    _simulationViewModel.OutsideTemperatureData = temperatureData;

                    MessageBox.Show("Temperature data loaded successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading temperature data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

