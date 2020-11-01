using Hamnen.Classes;
using Hamnen.ExtensionMethods;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace Hamnen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public HarborViewModel harbor { get; set; }
        IDock _dock;

        public MainWindow()
        {
            InitializeComponent();
            _dock = new FirstFit();
            harbor = new HarborViewModel(64);
            try
            {
                Utils.LoadHarbor(harbor.DockedBoatsFirstDock, harbor.DockedBoatsSecondDock, harbor.MooringsFirstDock, harbor.MooringsSecondDock);
            }
            catch (System.Exception)
            {
                var newBoats = Utils.GenerateBoats(5);
                foreach (var boat in newBoats)
                {
                    _dock.Dock(boat, harbor.DockedBoatsFirstDock, harbor.DockedBoatsSecondDock, harbor.MooringsFirstDock, harbor.MooringsSecondDock, harbor.MessageFirstDock, harbor.MessageSecondDock);
                }
            }
            harbor.UpdateHarborStatistics();
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
