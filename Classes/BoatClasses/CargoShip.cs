using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Hamnen.Classes
{
    class CargoShip : Boat
    {
        public int NumberOfContainers { get; set; }
        public CargoShip()
        {
            Id = $"L-{Utilitis.GenerateId()}";
            BoatType = "Lastfartyg";
            Weight = Utilitis.Random.Next(3000, 20000 + 1);
            MaxVelocity = Utilitis.Random.Next(1, 20 + 1) * 1.852; //Km/H
            NumberOfContainers = Utilitis.Random.Next(0, 500 + 1);
            TimeBeforeLeaving = 6;
            Size = 4;
            Other = $"Containers: {NumberOfContainers}";
        }
        public CargoShip(string id, int weight, double maxVelocity, string numberOfContainers, int timeBeforeLeaving)
        {
            Id = id;
            Weight = weight;
            MaxVelocity = maxVelocity;
            TimeBeforeLeaving = timeBeforeLeaving;
            BoatType = "Lastfartyg";
            Size = 4;
            Other = numberOfContainers;
        }
    }
}
