using Home_Simulator.Commands;
using Home_Simulator.Stores;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Home_Simulator.ViewModels
{
    public class StartUpViewModel : ViewModelBase
    {
        public ICommand LoadHouseLayoutStartCommand { get; }

        public StartUpViewModel(NavigationStore navigationStore)
        {
            LoadHouseLayoutStartCommand = new LoadHouseLayoutStartCommand(navigationStore);
        }


    }
}
