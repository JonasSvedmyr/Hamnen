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
                Utils.LoadHarbor(harbor);
            }
            catch (System.Exception)
            {
                var newBoats = Utils.GenerateBoats(5);
                foreach (var boat in newBoats)
                {
                    _dock.Dock(boat, harbor);
                }
            }
            LogFreeSpace();
            harbor.UpdateHarborStatistics();
            DataContext = harbor;
        }

        private void ButtonNewDay_click(object sender, RoutedEventArgs e)
        {
            NextDayButton.IsEnabled = false;
            harbor.Message = "";
            foreach (Boat boat in harbor.DockedBoats)
            {
                boat.TimeBeforeLeaving--;
            }
            List<Boat> boatsToRemove = harbor.DockedBoats.Where(b => b.TimeBeforeLeaving <= 0).ToList();
            if (boatsToRemove.Count > 0)
            {
                foreach (var boat in boatsToRemove)
                {
                    _dock.RemoveFromDock(boat, harbor);
                }
            }
            var newBoats = Utils.GenerateBoats(5);
            foreach (var boat in newBoats)
            {
                _dock.Dock(boat, harbor);
            }
            LogFreeSpace();
            harbor.UpdateHarborStatistics();
            Utils.SaveHarbor(harbor);
            NextDayButton.IsEnabled = true;
        }

        public void LogFreeSpace()
        {
            harbor.FreeSpace = "Lediga platser:";
            var freeSpace = harbor.FindFreeSpace();
            foreach (var mooring in freeSpace)
            {
                harbor.FreeSpace += $"\nPlats: {mooring}";
            }
        }
    }
}
