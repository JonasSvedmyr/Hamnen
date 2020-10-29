using Hamnen.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace Hamnen.Classes
{
    public class HarborViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public double SpaceLeft { get; set; }
        public int _boatsRejected;
        public int BoatsRejected
        {
            get
            {
                return _boatsRejected;
            }
            set
            {
                _boatsRejected = value;
                NotifyPropertyChanged();
            }
        }
        public int _mooringsLeft;
        public int MooringsLeft
        {
            get
            {
                return _mooringsLeft;
            }
            set
            {
                _mooringsLeft = value;
                NotifyPropertyChanged();
            }
        }
        private string _message;
        public string Message { 
            get 
            {
                return _message;
            }
            set 
            {
                _message = value;
                NotifyPropertyChanged();
            } 
        }
        private string _freeSpace;
        public string FreeSpace
        {
            get
            {
                return _freeSpace;
            }
            set
            {
                _freeSpace = value;
                NotifyPropertyChanged();
            }
        }
        private int _amountOfRowBoats;
        public int AmountOfRowBoats
        {
            get
            {
                return _amountOfRowBoats;
            }
            set
            {
                _amountOfRowBoats = value;
                NotifyPropertyChanged();
            }
        }
        private int _amountOfMotorBoats;
        public int AmountOfMotorBoats
        {
            get
            {
                return _amountOfMotorBoats;
            }
            set
            {
                _amountOfMotorBoats = value;
                NotifyPropertyChanged();
            }
        }
        private int _amountOfSailBoats;
        public int AmountOfSailBoats
        {
            get
            {
                return _amountOfSailBoats;
            }
            set
            {
                _amountOfSailBoats = value;
                NotifyPropertyChanged();
            }
        }
        private int _amountOfCargoShips;
        public int AmountOfCargoShips
        {
            get
            {
                return _amountOfCargoShips;
            }
            set
            {
                _amountOfCargoShips = value;
                NotifyPropertyChanged();
            }
        }
        private int _amountOfCatamarans;
        public int AmountOfCatamarans
        {
            get
            {
                return _amountOfCatamarans;
            }
            set
            {
                _amountOfCatamarans = value;
                NotifyPropertyChanged();
            }
        }
        private double _avrageSpeed;
        public double AvrageSpeed
        {
            get
            {
                return _avrageSpeed;
            }
            set
            {
                _avrageSpeed = value;
                NotifyPropertyChanged();
            }
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ObservableCollection<Boat> DockedBoats { get; set; }
        public Mooring[] Moorings { get; set; } //Mooring är förtöjning på engelska men var det närmaste båtplats

        public HarborViewModel(int size)
        {
            DockedBoats = new ObservableCollection<Boat>();
            Moorings = new Mooring[size];
            for (int i = 0; i < size; i++)
            {
                Moorings[i] = new Mooring();
            }
            DockedBoats.CollectionChanged += DockedBoats_CollectionChanged;
        }


        private void DockedBoats_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if (Message == "")
                    {
                        Message += $"En båt har kommit till hamnen";
                    }
                    else
                    {
                        Message += $"\nEn båt har kommit till hamnen";
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    if (Message == "")
                    {
                        Message += $"\nEn båt har lämnat hamnen";
                    }
                    else
                    {
                        Message += $"\nEn båt har lämnat hamnen";
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }
        public void UpdateHarborStatistics() //används inte just nu
        {
            int temp = DockedBoats.Where(q => q.BoatType == "Roddbåt").Count();
            AmountOfRowBoats = temp;
            temp = DockedBoats.Where(q => q.BoatType == "Motorbåt").Count();
            AmountOfMotorBoats = temp;
            temp = DockedBoats.Where(q => q.BoatType == "Lastfartyg").Count();
            AmountOfCargoShips = temp;
            temp = DockedBoats.Where(q => q.BoatType == "Segelbåt").Count();
            AmountOfSailBoats = temp;
            temp = DockedBoats.Where(q => q.BoatType == "Katamaran").Count();
            AmountOfCatamarans = temp;
            temp = Moorings.FindFreeSpace().Count;
            MooringsLeft = temp;
            double temp2 = DockedBoats.AvrageSpeed();
            AvrageSpeed = temp2;
        }
    }
}