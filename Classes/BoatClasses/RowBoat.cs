using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen.Classes
{
    public class RowBoat : Boat
    {
        public int MaxAmountOfPeople { get; set; }
        public RowBoat()
        {
            Id = $"R-{(Utils.GenerateId())}";
            BoatType = "Roddbåt";
            Weight = Utils.Random.Next(100, 300 + 1);
            MaxVelocity = Utils.Random.Next(1, 3 + 1) * 1.852;
            MaxAmountOfPeople = Utils.Random.Next(1, 6 + 1);
            TimeBeforeLeaving = 1;
            Size = 0.5F;
            Other = $"Max antal pers: {MaxAmountOfPeople}";
        }
        public RowBoat(string id, int weight, double maxVelocity, string maxAmountOfPeople, int timeBeforeLeaving, string dockedAt)
        {
            Id = id;
            Weight = weight;
            MaxVelocity = maxVelocity;
            TimeBeforeLeaving = timeBeforeLeaving;
            BoatType = "Roddbåt";
            Size = 0.5F;
            Other = maxAmountOfPeople;
            DockedAt = dockedAt;
        }
    }
}
