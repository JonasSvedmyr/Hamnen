using Hamnen.Classes.BoatClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hamnen.Classes
{
    static class Utilitis
    {
        public static Random Random = new Random();
        public static string GenerateId()
        {
            string idString = "";
            for (int i = 0; i < 3; i++)
            {
                int a = Random.Next(0, 26);
                char ch = (char)('a' + a);
                idString += ch;
            }
            return idString.ToUpper();
        }
        public static void SaveHarbor(Harbor harbor)
        {
            using (StreamWriter sr = new StreamWriter("DockedBoats.Txt"))
            {
                foreach (var boat in harbor.DockedBoats)
                {
                    sr.WriteLine($"{boat.Id};{boat.BoatType};{boat.DockedAt};{boat.MaxVelocity};{boat.Other};{boat.TimeBeforeLeaving};{boat.Weight};");
                }
            }
            using (StreamWriter sr = new StreamWriter("Moorings.Txt"))
            {
                string temp;
                for (int i = 0; i < harbor.Moorings.Length; i++)
                {
                    if (!harbor.Moorings[i].isEmpthy)
                    {

                        temp = "";
                        foreach (var boatId in harbor.Moorings[i].IdOfDockedBoat)
                        {
                            if (temp == "")
                            {
                                temp += $"{boatId}";
                            }
                            else
                            {
                                temp += $",{boatId}";
                            }
                        }
                        sr.WriteLine($"{i};{temp};{harbor.Moorings[i].SpaceLeft}");
                    }
                }
            }
        }
        public static void LoadHarbor(Harbor harbor)
        {
            using (StreamReader sr = new StreamReader("DockedBoats.Txt"))
            {
                string[] temp;
                string line;
                Boat boat = new RowBoat();
                while ((line = sr.ReadLine()) != null)
                {
                    temp = line.Split(";");
                    switch (temp[1])
                    {
                        case "Motorbåt":
                            boat = new MotorBoat(temp[0], int.Parse(temp[6]), double.Parse(temp[3]),temp[4], int.Parse(temp[5]));
                            break;
                        case "Roddbåt":
                            boat = new RowBoat(temp[0], int.Parse(temp[6]), double.Parse(temp[3]),temp[4], int.Parse(temp[5]));

                            break;
                        case "Lastfartyg":
                            boat = new CargoShip(temp[0], int.Parse(temp[6]), double.Parse(temp[3]), temp[4], int.Parse(temp[5]));

                            break;
                        case "Segelbåt":
                            boat = new Sailboat(temp[0], int.Parse(temp[6]), double.Parse(temp[3]), temp[4], int.Parse(temp[5]));

                            break;
                        case "Katamaran":
                            boat = new Catamaran(temp[0], int.Parse(temp[6]), double.Parse(temp[3]), temp[4], int.Parse(temp[5]));
                            break;
                        default:
                            break;
                    }
                    harbor.DockedBoats.Add(boat);
                }
            }
            using (StreamReader sr = new StreamReader("Moorings.Txt"))
            {
                string line;
                string[] temp;
                string[] temp2;
                int MooringId;
                while ((line = sr.ReadLine()) != null)
                {
                    temp = line.Split(";");
                    MooringId = int.Parse(temp[0]);
                    harbor.Moorings[MooringId].SpaceLeft = double.Parse(temp[2]);
                    harbor.Moorings[MooringId].isEmpthy = false;
                    temp2 = temp[1].Split(",");
                    for (int i = 0; i < temp2.Length; i++)
                    {
                        harbor.Moorings[MooringId].IdOfDockedBoat.Add(temp2[i]);
                    }
                }
            }
        }
        public static List<Boat> GenerateBoats(int numberToGenerate)
        {
            int randomNumber;
            List<Boat> boats = new List<Boat>();
            for (int i = 0; i < numberToGenerate; i++)
            {
                randomNumber = Random.Next(0, 4);
                switch (randomNumber)
                {
                    case 0:
                        boats.Add(new RowBoat());
                        break;
                    case 1:
                        boats.Add(new MotorBoat());
                        break;
                    case 2:
                        boats.Add(new Sailboat());
                        break;
                    case 3:
                        boats.Add(new CargoShip());
                        break;
                    default:
                        break;
                }
            }
            return boats;
        }
        public static string BoatArrives(string boatId)
        {
            return $"{boatId} har kommit till hamnen";
        }
        public static string BoatLeaves(string boatId)
        {
            return $"{boatId} har lämnat hamnen";
        }
        public static string BoatRejected(string boatId)
        {
            return $"{boatId} fick inte plats i hamnen";
        }
    }

}
