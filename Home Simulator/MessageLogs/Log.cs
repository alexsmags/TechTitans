using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;


namespace Home_Simulator.MessageLogs
{
    public class Log
    {
        private static string _filePath = @"..\..\MessageLogs\SimulationLogs.txt";

        private SimulationViewModel _simulationViewModel;

        public Log(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }

        public void AddMessage(string message)
        {
            string log = $"{DateTime.Now} - {message}";
           _simulationViewModel.LogMessages.Add(log);
            using (StreamWriter sw = File.AppendText(_filePath))
            {
                sw.WriteLine(log);
            }

        }
    } 

}
