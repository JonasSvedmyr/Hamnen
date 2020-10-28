using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace Hamnen.Classes
{
    public class HarborViewModel: System.ComponentModel.INotifyPropertyChanged
    {
        public double SpaceLeft { get; set; }
        private string _message;
        public string Message { 
            get 
            {
                return _message;
            }
            set 
            {
                _message = value;
            } 
        }
        public ObservableCollection<Boat> DockedBoats { get; set; }
        public delegate string EventHandler(string boatId);
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void DockedBoats_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Message = "hej";
        }
    }
}