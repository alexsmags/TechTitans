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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Home_Simulator.Components
{
    public partial class ModuleTab : UserControl
    {
        private bool _isChecked = false;

        public ModuleTab()
        {
            InitializeComponent();
        }

        private void btnToggle_Click(object sender, RoutedEventArgs e)
        {
            _isChecked = !_isChecked;

            chkBackyard.IsChecked = _isChecked;
            chkGarage.IsChecked = _isChecked;
            chkMain.IsChecked = _isChecked;

            btnToggle.Content = _isChecked ? "None" : "All";
        }
    }
}
