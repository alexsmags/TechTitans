using Home_Simulator.Models.HouseModels;
using Home_Simulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        public ModuleTab()
        {
            InitializeComponent();
            UpdateTemperatureDisplay();
            UpdateHeaterTemperatureDisplay();
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            var item = FindParent<ListBoxItem>((FrameworkElement)sender);

            if (item != null && !item.IsSelected)
            {
                var listBox = FindParent<ListBox>(item);
                listBox.SelectedItem = item.DataContext;
            }
        }

        public static T FindParent<T>(FrameworkElement child) where T : FrameworkElement
        {
            FrameworkElement parent = child;

            while (parent != null)
            {
                if (parent is T correctlyTyped)
                {
                    return correctlyTyped;
                }

                parent = VisualTreeHelper.GetParent(parent) as FrameworkElement;
            }

            return null;
        }

        private void ComboBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox == null) return;

            DependencyObject parent = comboBox;
            while (parent != null && !(parent is ListBoxItem))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            ListBoxItem listBoxItem = parent as ListBoxItem;
            if (listBoxItem == null) return;

            ListBox listBox = ItemsControl.ItemsControlFromItemContainer(listBoxItem) as ListBox;
            if (listBox == null) return;

            listBox.SelectedItem = listBoxItem.DataContext;
        }

        private void UpdateTemperatureDisplay()
        {
            if (tempDisplay == null) { return; }

            tempDisplay.Text = "Temperature: " + setTemperature.Value.ToString("N0") + "°C";
        }

        private void setTemperature_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateTemperatureDisplay();
        }

        private void UpdateHeaterTemperatureDisplay()
        {
            if (heatingTempDisplay == null) { return; }

            heatingTempDisplay.Text = "Temperature: " + setHeatingTemperature.Value.ToString("N0") + "°C";
        }

        private void setHeaterTemperature_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateHeaterTemperatureDisplay();
        }
    }
}
