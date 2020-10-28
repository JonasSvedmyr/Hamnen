using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen.Classes.BoatClasses
{
    class Catamaran :   Boat
    {
        public int AmountOfBeds { get; set; }
        public Catamaran()
        {
            Id = $"K-{Utilitis.GenerateId()}";
            BoatType = "Katamaran";
            Weight = Utilitis.Random.Next(1200, 8000 + 1);
            MaxVelocity = Utilitis.Random.Next(1, 12 + 1) * 1.852; //Km/H
            AmountOfBeds = Utilitis.Random.Next(1, 4 + 1);
            TimeBeforeLeaving = 3;
            Size = 3;
            Other = $"Antal Bäddplatser: {AmountOfBeds}";
        }
        public Catamaran(string id, int weight, double maxVelocity, string amountOfBeds, int timeBeforeLeaving)
        {
            Id = id;
            Weight = weight;
            MaxVelocity = maxVelocity;
            TimeBeforeLeaving = timeBeforeLeaving;
            BoatType = "Katamaran";
            Size = 3;
            Other = amountOfBeds;
        }
    }
}
