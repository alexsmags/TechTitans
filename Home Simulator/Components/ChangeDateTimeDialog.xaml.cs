using Home_Simulator.Models.HouseSimulationModels;
using Home_Simulator.ViewModels;
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
    public partial class ChangeDateTimeDialog : Window
    {
        public DateTime SelectedDateTime { get; private set; }

        public ChangeDateTimeDialog(DateTimeModel dateTimeModel)
        {
            InitializeComponent();
            datePicker.SelectedDate = DateTime.Now;
            timeTextBox.Text = DateTime.Now.ToString("HH:mm");
        }

        private void OnUpdateDateTimeClick(object sender, RoutedEventArgs e)
        {
            if (datePicker.SelectedDate is DateTime selectedDate)
            {
                string timeText = timeTextBox.Text;
                TimeSpan time;
                if (TimeSpan.TryParse(timeText, out time))
                {
                    SelectedDateTime = selectedDate.Add(time);

                    this.DialogResult = true; 
                }
                else
                {
                    MessageBox.Show("Invalid time format. Please use HH:mm format.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
