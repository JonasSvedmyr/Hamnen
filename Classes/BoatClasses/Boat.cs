﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen.Classes
{
    public abstract class Boat
    {
        public string Id { get; set; }
        public string DockedAt { get; set; }
        public string BoatType { get; set; }
        public int Size { get; set; }
        public int Weight { get; set; }
        public double MaxVelocity { get; set; }
        public int TimeBeforeLeaving { get; set; }
        public string Other { get; set; }
    }
}
