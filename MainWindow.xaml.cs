using Hamnen.Classes;
using Hamnen.ExtensionMethods;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;

namespace Hamnen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public HarborViewModel harbor { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            harbor = new HarborViewModel(64);
            harbor.Load(); //laddar upp alla sparade båtar eller skapar 5 nya om det inte finns några
            DataContext = harbor;
        }

        private void ButtonNewDay_click(object sender, RoutedEventArgs e)
        {
            NextDayButton.IsEnabled = false;
                harbor.NextDay();
            NextDayButton.IsEnabled = true;
        }
    }
}
