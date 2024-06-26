﻿using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
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
    public partial class ViewRoomsDialog : Window
    {
        private SimulationViewModel _simulationViewModel;

        public ViewRoomsDialog(SimulationViewModel simulationViewModel)
        {
            InitializeComponent();
            this.DataContext = simulationViewModel;
            roomsListBox.ItemsSource = simulationViewModel.Rooms;
        }
    }
}
