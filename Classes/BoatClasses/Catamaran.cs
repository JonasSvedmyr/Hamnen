using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen.Classes.BoatClasses
{
    public class Catamaran :   Boat
    {
        public int AmountOfBeds { get; set; }
        public Catamaran()
        {
            Id = $"K-{Utils.GenerateId()}";
            BoatType = "Katamaran";
            Weight = Utils.Random.Next(1200, 8000 + 1);
            MaxVelocity = Utils.Random.Next(1, 12 + 1) * 1.852; //Km/H
            AmountOfBeds = Utils.Random.Next(1, 4 + 1);
            TimeBeforeLeaving = 3;
            Size = 6;
            Other = $"Antal Bäddplatser: {AmountOfBeds}";
        }
        public Catamaran(string id, int weight, double maxVelocity, string amountOfBeds, int timeBeforeLeaving, string dockedAt)
        {
            Id = id;
            Weight = weight;
            MaxVelocity = maxVelocity;
            TimeBeforeLeaving = timeBeforeLeaving;
            BoatType = "Katamaran";
            Size = 6;
            Other = amountOfBeds;
            DockedAt = dockedAt;
        }
    }
}
