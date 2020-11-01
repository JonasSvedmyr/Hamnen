using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Hamnen.Classes
{
    interface IDock
    {
        public (int[], bool) FindDocking(Boat boat, ObservableCollection<Boat> Dock, Mooring[] moorings);
        public void Dock(Boat boat, ObservableCollection<Boat> FirstDock, ObservableCollection<Boat> SecondDock, Mooring[] mooringsFirstDock, Mooring[] mooringsSecondDock, string MessageFirstDock, string MessageSecondDock);
        public void RemoveFromDock(Boat boat, ObservableCollection<Boat> Dock, Mooring[] moorings);
    }
}
