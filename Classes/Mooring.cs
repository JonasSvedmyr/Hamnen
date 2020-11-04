using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen.Classes
{
    public class Mooring
    {
        public bool isEmpthy { get; set; }
        public int SpaceLeft { get; set; } = 2;
        public List<string> IdOfDockedBoat { get; set; }
        public Mooring()
        {
            IdOfDockedBoat = new List<string>();
            isEmpthy = true;
        }
    }
}
