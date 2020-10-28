using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen.Classes
{
    class MotorBoat : Boat
    {
        public int HorsePower { get; set; }
        public MotorBoat()
        {
            Id = $"M-{Utilitis.GenerateId()}";
            BoatType = "Motorbåt";
            Weight = Utilitis.Random.Next(200, 3000 + 1);
            MaxVelocity = Utilitis.Random.Next(1, 60 + 1) * 1.852;
            HorsePower = Utilitis.Random.Next(10, 1000 + 1);//hk
            TimeBeforeLeaving = 3;
            Size = 1;
            Other = $"Hästkraft: {HorsePower}";
        }
        public MotorBoat(string id, int weight, double maxVelocity, string horsePower, int timeBeforeLeaving)
        {
            Id = id;
            Weight = weight;
            MaxVelocity = maxVelocity;
            TimeBeforeLeaving = timeBeforeLeaving;
            BoatType = "Motorbåt";
            Size = 1;
            Other = horsePower;
        }
    }
}
