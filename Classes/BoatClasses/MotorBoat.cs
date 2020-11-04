using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen.Classes
{
    public class MotorBoat : Boat
    {
        public int HorsePower { get; set; }
        public MotorBoat()
        {
            Id = $"M-{Utils.GenerateId()}";
            BoatType = "Motorbåt";
            Weight = Utils.Random.Next(200, 3000 + 1);
            MaxVelocity = Utils.Random.Next(1, 60 + 1) * 1.852;
            HorsePower = Utils.Random.Next(10, 1000 + 1);//hk
            TimeBeforeLeaving = 3;
            Size = 2;
            Other = $"Hästkraft: {HorsePower}";
        }
        public MotorBoat(string id, int weight, double maxVelocity, string horsePower, int timeBeforeLeaving, string dockedAt)
        {
            Id = id;
            Weight = weight;
            MaxVelocity = maxVelocity;
            TimeBeforeLeaving = timeBeforeLeaving;
            BoatType = "Motorbåt";
            Size = 1;
            Other = horsePower;
            DockedAt = dockedAt;
        }
    }
}
