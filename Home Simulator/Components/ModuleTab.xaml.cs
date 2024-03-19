using Home_Simulator.Models.HouseModels;
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

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            // Find the parent ListBoxItem of the Expander
            var item = FindParent<ListBoxItem>((FrameworkElement)sender);

            // Check if the ListBoxItem is found and not already selected
            if (item != null && !item.IsSelected)
            {
                // Set the item as selected
                var listBox = FindParent<ListBox>(item);
                listBox.SelectedItem = item.DataContext;
            }
        }

        // Generic method to find a parent of a given control
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

            // Navigate up the visual tree to find the ListBoxItem
            DependencyObject parent = comboBox;
            while (parent != null && !(parent is ListBoxItem))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            // Get the ListBoxItem
            ListBoxItem listBoxItem = parent as ListBoxItem;
            if (listBoxItem == null) return;

            // Get the ListBox from the ListBoxItem
            ListBox listBox = ItemsControl.ItemsControlFromItemContainer(listBoxItem) as ListBox;
            if (listBox == null) return;

            // Set the SelectedItem of the ListBox
            listBox.SelectedItem = listBoxItem.DataContext;
        }

        private void Button_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
