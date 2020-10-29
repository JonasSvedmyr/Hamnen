using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen.Classes
{
    public class Sailboat : Boat
    {
        public int BoatLenght { get; set; }
        public Sailboat()
        {
            Id = $"S-{Utils.GenerateId()}";
            BoatType = "Segelbåt";
            Weight = Utils.Random.Next(800, 6000 + 1);
            MaxVelocity = Utils.Random.Next(1, 12 + 1) * 1.852;
            BoatLenght = Utils.Random.Next(10, 60 + 1);//Fot
            TimeBeforeLeaving = 4;
            Size = 2;
            Other = $"Båtlängd: {BoatLenght} m";
        }
        public Sailboat(string id, int weight, double maxVelocity, string boatLenght, int timeBeforeLeaving, string dockedAt)
        {
            Id = id;
            Weight = weight;
            MaxVelocity = maxVelocity;
            TimeBeforeLeaving = timeBeforeLeaving;
            BoatType = "Segelbåt";
            Size = 2;
            Other = boatLenght;
            DockedAt = dockedAt;
        }
    }
}
