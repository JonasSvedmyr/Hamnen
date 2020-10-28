using Hamnen.Classes;
using Hamnen.ExtensionMethods;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Hamnen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Harbor harbor;
        IDock _dock;
        public MainWindow()
        {
            InitializeComponent();
            _dock = new FirstFit();
            harbor = new Harbor(64);
            var newBoats = Utilitis.GenerateBoats(5);
            //foreach (var boat in newBoats)
            //{
            //    _dock.Dock(boat, harbor);
            //}
            Utilitis.LoadHarbor(harbor);
            int index = 0;
            foreach (Mooring mooring in harbor.Moorings)
            {
                if (!mooring.isEmpthy)
                {
                    foreach (var boatId in mooring.IdOfDockedBoat)
                    {
                        TestTextBlock.Text += $"\n{index} = {boatId[0]}";
                    }

                }
                index++;
            }
            LogHarbor();
            
        }
        void LogHarbor()
        {
            int temp = harbor.DockedBoats.Where(q => q.BoatType == "Roddbåt").Count();
            NumberOfRowBoatsTextBlock.Text = $"Antal roddbåtar: {temp}";
            temp = harbor.DockedBoats.Where(q => q.BoatType == "Motorbåt").Count();
            NumberOfMotorBoatsTextBlock.Text = $"Antal motorbåtar: {temp}";
            temp = harbor.DockedBoats.Where(q => q.BoatType == "Lastfartyg").Count();
            NumberOfCargoShipsTextBlock.Text = $"Antal lastfartyg: {temp}";
            temp = harbor.DockedBoats.Where(q => q.BoatType == "Segelbåt").Count();
            NumberOfSailboatsTextBlock.Text = $"Antal segelbåt: {temp}";
            temp = harbor.FindFreeSpace().Count();
            NumberOfSpotsLeft.Text = $"Antal platser kvar: {temp}";
            double temp2 = harbor.AvrageSpeed();
            MaxVelocityAvrageTextBlock.Text = $"Medelhastiget för alla båtar: {temp2}Km/H";

        }
        //Datagrid does not update when i press the button
        private void ButtonNewDay_click(object sender, RoutedEventArgs e)
        {
            NextDayButton.IsEnabled = false;
            foreach (Boat boat in harbor.DockedBoats)
            {
                boat.TimeBeforeLeaving--;
            }
            DataLog.Text = "";
            List<Boat> boatsToRemove = harbor.DockedBoats.Where(b => b.TimeBeforeLeaving <= 0).ToList();
            if(boatsToRemove.Count > 0)
            {
                foreach (var boat in boatsToRemove)
                {
                    if (DataLog.Text == "")
                    {
                        DataLog.Text += $"{boat.Id} har lämnat hamnen";
                    }
                    else
                    {
                        DataLog.Text += $"\n{boat.Id} har lämnat hamnen";
                    }
                    _dock.RemoveFromDock(boat, harbor);
                }
            }
            var newBoats = Utilitis.GenerateBoats(5);
            foreach (var boat in newBoats)
            {
                if (DataLog.Text == "")
                {
                    DataLog.Text += $"{boat.Id} har kommit till hamnen";
                }
                else
                {
                    DataLog.Text += $"\n{boat.Id} har har kommit till hamnen";
                }
                _dock.Dock(boat, harbor);
            }
            TestTextBlock.Text = "";
            int index = 0;
            foreach (Mooring mooring in harbor.Moorings)
            {
                if (!mooring.isEmpthy)
                {
                    foreach (var boatId in mooring.IdOfDockedBoat)
                    {
                        TestTextBlock.Text += $"\n{index} = {boatId[0]}";
                    }

                }
                index++;
            }
            LogHarbor();
            Utilitis.SaveHarbor(harbor);
            NextDayButton.IsEnabled = true;
        }
    }
}
