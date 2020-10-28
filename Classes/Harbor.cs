using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace Hamnen.Classes
{
    class Harbor
    {
        public double SpaceLeft { get; set; }
        public ObservableCollection<Boat> DockedBoats { get; set; }
        public delegate string EventHandler(string boatId);
        public Mooring[] Moorings { get; set; } //Mooring är förtöjning på engelska men var det närmaste båtplats

        public Harbor(int size)
        {
            DockedBoats = new ObservableCollection<Boat>();
            Moorings = new Mooring[size];
            for (int i = 0; i < size; i++)
            {
                Moorings[i] = new Mooring();
            }
        }
    }
}