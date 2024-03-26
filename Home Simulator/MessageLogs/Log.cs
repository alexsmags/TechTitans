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
        private static Log instance = null;
        private static readonly object padlock = new object();
        private static string _filePath = @"..\..\MessageLogs\SimulationLogs.txt";
        private SimulationViewModel _simulationViewModel;


        public static Log Instance(SimulationViewModel simulationViewModel)
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Log(simulationViewModel);
                }
                return instance;
            }
        }   

        private  Log(SimulationViewModel simulationViewModel)
        {
            _simulationViewModel = simulationViewModel;
        }

        public void AddMessage(string message)
        {
            string log;
            if (_simulationViewModel.CurrentUser == null)
            {
                log = $"{DateTime.Now} - {message}";
            }
            else
            {
                log = $"{DateTime.Now} - {_simulationViewModel.CurrentUser.Name} : {message}";
            }
           _simulationViewModel.LogMessages.Insert(0, log);
            using (StreamWriter sw = File.AppendText(_filePath))
            {
                sw.WriteLine(log);
            }

        }
    } 

}
