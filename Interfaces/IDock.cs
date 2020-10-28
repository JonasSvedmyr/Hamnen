using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen.Classes
{
    interface IDock
    {
        public int[] FindDocking(HarborViewModel harbor, Boat boat);
        public void Dock(Boat boat, HarborViewModel harbor);
        public void RemoveFromDock(Boat boat, HarborViewModel harbor);
    }
}
