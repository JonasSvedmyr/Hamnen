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
        IDock _dock;
        #region Props
        public double SpaceLeft { get; set; }
        public int BoatsRejected
        {
            get
            {
                return Utils.BoatsRejected;
            }
            set
            {
                Utils.BoatsRejected = value;
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
        public string MessageFirstDock { 
            get 
            {
                return Utils.MessegeFirstDock;
            }
            set 
            {
                Utils.MessegeFirstDock = value;
                NotifyPropertyChanged();
            } 
        }


        public string MessageSecondDock
        {
            get
            {
                return Utils.MessegeSecondDock;
            }
            set
            {
                Utils.MessegeSecondDock = value;
                NotifyPropertyChanged();
            }
        }
        private string _freeSpaceFirstDock;
        public string FreeSpaceFirstDock
        {
            get
            {
                return _freeSpaceFirstDock;
            }
            set
            {
                _freeSpaceFirstDock = value;
                NotifyPropertyChanged();
            }
        }
        private string _freeSpaceSecondDock;
        public string FreeSpaceSecondDock
        {
            get
            {
                return _freeSpaceSecondDock;
            }
            set
            {
                _freeSpaceSecondDock = value;
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
        #endregion
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ObservableCollection<Boat> DockedBoatsFirstDock { get; set; }
        public ObservableCollection<Boat> DockedBoatsSecondDock { get; set; }
        public Mooring[] MooringsFirstDock { get; set; } //Mooring är förtöjning på engelska men var det närmaste båtplats
        public Mooring[] MooringsSecondDock { get; set; } //Mooring är förtöjning på engelska men var det närmaste båtplats

        public HarborViewModel(int size)
        {
            _dock = new FirstFit();
            size /= 2;
            DockedBoatsFirstDock = new ObservableCollection<Boat>();
            DockedBoatsSecondDock = new ObservableCollection<Boat>();
            MooringsFirstDock = new Mooring[size];
            for (int i = 0; i < size; i++)
            {
                MooringsFirstDock[i] = new Mooring();
            }
            MooringsSecondDock = new Mooring[size];
            for (int i = 0; i < size; i++)
            {
                MooringsSecondDock[i] = new Mooring();
            }
            DockedBoatsFirstDock.CollectionChanged += DockedBoatsFirstDock_CollectionChanged;
            DockedBoatsSecondDock.CollectionChanged += DockedBoatsSecondDock_CollectionChanged;
        }

        #region Events
        public void LogFreeSpace()
        {
            FreeSpaceFirstDock = "Lediga platser:";
            var freeSpace = MooringsFirstDock.FindFreeSpace();
            foreach (var mooring in freeSpace)
            {
                FreeSpaceFirstDock += $"\nPlats: {mooring}";
            }
            FreeSpaceSecondDock = "Lediga platser:";
            freeSpace = MooringsSecondDock.FindFreeSpace();
            foreach (var mooring in freeSpace)
            {
                FreeSpaceSecondDock += $"\nPlats: {mooring}";
            }
        }
        private void DockedBoatsFirstDock_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if (MessageFirstDock == "")
                    {
                        MessageFirstDock += $"En båt har kommit till hamnen";
                    }
                    else
                    {
                        MessageFirstDock += $"\nEn båt har kommit till hamnen";
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    if (MessageFirstDock == "")
                    {
                        MessageFirstDock += $"\nEn båt har lämnat hamnen";
                    }
                    else
                    {
                        MessageFirstDock += $"\nEn båt har lämnat hamnen";
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
        private void DockedBoatsSecondDock_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if (MessageSecondDock == "")
                    {
                        MessageSecondDock += $"En båt har kommit till hamnen";
                    }
                    else
                    {
                        MessageSecondDock += $"\nEn båt har kommit till hamnen";
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    if (MessageSecondDock == "")
                    {
                        MessageSecondDock += $"\nEn båt har lämnat hamnen";
                    }
                    else
                    {
                        MessageSecondDock += $"\nEn båt har lämnat hamnen";
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

        #endregion

        public void NextDay()
        {
            MessageFirstDock = "";
            MessageSecondDock = "";
            foreach (Boat boat in DockedBoatsFirstDock)
            {
                boat.TimeBeforeLeaving--;
            }
            List<Boat> boatsToRemove = DockedBoatsFirstDock.Where(b => b.TimeBeforeLeaving <= 0).ToList();
            if (boatsToRemove.Count > 0)
            {
                foreach (var boat in boatsToRemove)
                {
                    _dock.RemoveFromDock(boat, DockedBoatsFirstDock, MooringsFirstDock);
                }
            }
            foreach (Boat boat in DockedBoatsSecondDock)
            {
                boat.TimeBeforeLeaving--;
            }
            boatsToRemove = DockedBoatsSecondDock.Where(b => b.TimeBeforeLeaving <= 0).ToList();
            if (boatsToRemove.Count > 0)
            {
                foreach (var boat in boatsToRemove)
                {
                    _dock.RemoveFromDock(boat, DockedBoatsSecondDock, MooringsSecondDock);
                }
            }
            var newBoats = Utils.GenerateBoats(5);
            foreach (var boat in newBoats)
            {
                _dock.Dock(boat, DockedBoatsFirstDock, DockedBoatsSecondDock, MooringsFirstDock, MooringsSecondDock, MessageFirstDock, MessageSecondDock);
                NotifyPropertyChanged(nameof(MessageFirstDock));
                NotifyPropertyChanged(nameof(MessageSecondDock));
                NotifyPropertyChanged(nameof(BoatsRejected));
            }
            Utils.SaveHarbor(DockedBoatsFirstDock, DockedBoatsSecondDock, MooringsFirstDock, MooringsSecondDock);
            LogFreeSpace();
            UpdateHarborStatistics();
        }
        /// <summary>
        /// A method to update all statistics of the harbor
        /// </summary>
        #region Statistics
        public void UpdateHarborStatistics() 
        {
            int temp = DockedBoatsFirstDock.Where(q => q.BoatType == "Roddbåt").Count();
            int temp2 = DockedBoatsSecondDock.Where(q => q.BoatType == "Roddbåt").Count();
            AmountOfRowBoats = temp + temp2;
            temp = DockedBoatsFirstDock.Where(q => q.BoatType == "Motorbåt").Count();
            temp2 = DockedBoatsSecondDock.Where(q => q.BoatType == "Motorbåt").Count();
            AmountOfMotorBoats = temp + temp2;
            temp = DockedBoatsFirstDock.Where(q => q.BoatType == "Lastfartyg").Count();
            temp2 = DockedBoatsSecondDock.Where(q => q.BoatType == "Lastfartyg").Count();
            AmountOfCargoShips = temp + temp2;
            temp = DockedBoatsFirstDock.Where(q => q.BoatType == "Segelbåt").Count();
            temp2 = DockedBoatsSecondDock.Where(q => q.BoatType == "Segelbåt").Count();
            AmountOfSailBoats = temp + temp2;
            temp = DockedBoatsFirstDock.Where(q => q.BoatType == "Katamaran").Count();
            temp2 = DockedBoatsSecondDock.Where(q => q.BoatType == "Katamaran").Count();
            AmountOfCatamarans = temp + temp2;
            temp = MooringsFirstDock.FindFreeSpace().Count;
            temp2 = MooringsSecondDock.FindFreeSpace().Count;
            MooringsLeft = temp + temp2;
            double temp3 = DockedBoatsFirstDock.AvrageSpeed();
            double temp4 = DockedBoatsSecondDock.AvrageSpeed();
            AvrageSpeed = temp3 + temp4;
        }
        #endregion
    }
}