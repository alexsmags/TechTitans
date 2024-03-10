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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Home_Simulator.Views
{
    public partial class StartUpView : UserControl
    {
        public StartUpView()
        {
            InitializeComponent();
            this.Loaded += StartUpView_Loaded;
        }

        private void StartUpView_Loaded(object sender, RoutedEventArgs e)
        {
            var storyboard = this.Resources["SwingAnimation"] as Storyboard;
            storyboard.Begin();
        }

    }
}
