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
    public partial class ChangeTemperatureDialog : Window
    {
        public string SelectedTemperature => "Temperature: " + setTemperature.Value + "°C";

        public ChangeTemperatureDialog(string temperature)
        {
            InitializeComponent();
            UpdateTemperatureDisplay(); 

        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            bool isInt = double.TryParse(setTemperature.Value.ToString(), out double result);
            if (!string.IsNullOrWhiteSpace(setTemperature.Value.ToString()) && isInt)
            {
                this.DialogResult = true;
            }
        }

        private void UpdateTemperatureDisplay()
        {
            tempDisplay.Text = "Temperature: " + setTemperature.Value.ToString("N0") + "°C";
        }

        private void setTemperature_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateTemperatureDisplay();
        }

    }
}
