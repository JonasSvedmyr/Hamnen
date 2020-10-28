using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen.Classes
{
    interface IDock
    {
        public int[] FindDocking(Harbor harbor, Boat boat);
        public void Dock(Boat boat, Harbor harbor);
        public void RemoveFromDock(Boat boat, Harbor harbor);
    }
}
