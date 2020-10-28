using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen.Classes
{
    public class Mooring
    {
        public bool isEmpthy { get; set; }
        public double SpaceLeft { get; set; } = 1;
        public List<string> IdOfDockedBoat { get; set; }
        public Mooring()
        {
            IdOfDockedBoat = new List<string>();
            isEmpthy = true;
        }
    }
}
