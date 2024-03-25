using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_Simulator.ViewModels;
using System.Globalization;
using System.Windows;
using System.IO;

namespace Home_Simulator.Commands
{
    public class LoadCSVTemperatureCommand : CommandBase
    {
        private readonly SimulationViewModel _simulationViewModel;

        public LoadCSVTemperatureCommand(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }

        public override void Execute(object parameter)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Title = "Select Temperature CSV File";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    var lines = File.ReadAllLines(openFileDialog.FileName);

                    var temperatureData = new List<(DateTime dateTime, double temperature)>();

                    foreach (var line in lines.Skip(1))
                    {
                        var parts = line.Split('\t');
                        var parts2 = parts[0].Split(',');
                        try
                        {
                            if (parts2.Length >= 3)
                            {
                                var dateAndTime = parts2[0] + " " + parts2[1];
                                var date = DateTime.ParseExact(dateAndTime, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
                                var temperature = double.Parse(parts2[2], CultureInfo.InvariantCulture);
                                temperatureData.Add((date, temperature));
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error parsing line: {line}");
                            Console.WriteLine($"Error message: {ex.Message}");
                        }
                    }

                    _simulationViewModel.OutsideTemperatureData = temperatureData;
                    _simulationViewModel.SimulationModel.SimulationDate = _simulationViewModel.SimulationModel.SimulationDate;
                    _simulationViewModel.AddLogMessage("Temperature data loaded successfully.");


                    MessageBox.Show("Temperature data loaded successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading temperature data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    _simulationViewModel.AddLogMessage($"Error loading temperature data: {ex.Message}");
                }
            }
        }

    }
}
