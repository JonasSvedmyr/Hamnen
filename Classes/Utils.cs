using Hamnen.Classes.BoatClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace Hamnen.Classes
{
    static class Utils
    {
        public static Random Random = new Random();

        public static int BoatsRejected;
        public static string MessegeFirstDock;
        public static string MessegeSecondDock;
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
        public static void SaveHarbor(ObservableCollection<Boat> firstDock, ObservableCollection<Boat> secondDock, Mooring[] mooringsFirstDock, Mooring[] mooringsSecondDock)
        {
            using (StreamWriter sr = new StreamWriter("DockedBoats.Txt"))
            {
                foreach (var boat in firstDock)
                {
                    sr.WriteLine($"{boat.Id};{boat.BoatType};{boat.DockedAt};{boat.MaxVelocity};{boat.Other};{boat.TimeBeforeLeaving};{boat.Weight};");
                }
            }
            using (StreamWriter sr = new StreamWriter("Moorings.Txt"))
            {
                string temp;
                for (int i = 0; i < mooringsFirstDock.Length; i++)
                {
                    if (!mooringsFirstDock[i].isEmpthy)
                    {

                        temp = "";
                        foreach (var boatId in mooringsFirstDock[i].IdOfDockedBoat)
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
                        sr.WriteLine($"{i};{temp};{mooringsFirstDock[i].SpaceLeft}");
                    }
                }
            }
            using (StreamWriter sr = new StreamWriter("DockedBoats2.Txt"))
            {
                foreach (var boat in secondDock)
                {
                    sr.WriteLine($"{boat.Id};{boat.BoatType};{boat.DockedAt};{boat.MaxVelocity};{boat.Other};{boat.TimeBeforeLeaving};{boat.Weight};");
                }
            }
            using (StreamWriter sr = new StreamWriter("Moorings2.Txt"))
            {
                string temp;
                for (int i = 0; i < mooringsSecondDock.Length; i++)
                {
                    if (!mooringsSecondDock[i].isEmpthy)
                    {

                        temp = "";
                        foreach (var boatId in mooringsSecondDock[i].IdOfDockedBoat)
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
                        sr.WriteLine($"{i};{temp};{mooringsSecondDock[i].SpaceLeft}");
                    }
                }
            }
        }
        public static void LoadHarbor(ObservableCollection<Boat> firstDock, ObservableCollection<Boat> secondDock, Mooring[] mooringsFirstDock, Mooring[] mooringsSecondDock)
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
                            boat = new MotorBoat(temp[0], int.Parse(temp[6]), double.Parse(temp[3]),temp[4], int.Parse(temp[5]), temp[2]);
                            break;
                        case "Roddbåt":
                            boat = new RowBoat(temp[0], int.Parse(temp[6]), double.Parse(temp[3]),temp[4], int.Parse(temp[5]), temp[2]);

                            break;
                        case "Lastfartyg":
                            boat = new CargoShip(temp[0], int.Parse(temp[6]), double.Parse(temp[3]), temp[4], int.Parse(temp[5]), temp[2]);

                            break;
                        case "Segelbåt":
                            boat = new Sailboat(temp[0], int.Parse(temp[6]), double.Parse(temp[3]), temp[4], int.Parse(temp[5]), temp[2]);

                            break;
                        case "Katamaran":
                            boat = new Catamaran(temp[0], int.Parse(temp[6]), double.Parse(temp[3]), temp[4], int.Parse(temp[5]), temp[2]);
                            break;
                        default:
                            break;
                    }
                    firstDock.Add(boat);
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
                    mooringsFirstDock[MooringId].SpaceLeft = int.Parse(temp[2]);
                    mooringsFirstDock[MooringId].isEmpthy = false;
                    temp2 = temp[1].Split(",");
                    for (int i = 0; i < temp2.Length; i++)
                    {
                        mooringsFirstDock[MooringId].IdOfDockedBoat.Add(temp2[i]);
                    }
                }
            }

            using (StreamReader sr = new StreamReader("DockedBoats2.Txt"))
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
                            boat = new MotorBoat(temp[0], int.Parse(temp[6]), double.Parse(temp[3]), temp[4], int.Parse(temp[5]), temp[2]);
                            break;
                        case "Roddbåt":
                            boat = new RowBoat(temp[0], int.Parse(temp[6]), double.Parse(temp[3]), temp[4], int.Parse(temp[5]), temp[2]);

                            break;
                        case "Lastfartyg":
                            boat = new CargoShip(temp[0], int.Parse(temp[6]), double.Parse(temp[3]), temp[4], int.Parse(temp[5]), temp[2]);

                            break;
                        case "Segelbåt":
                            boat = new Sailboat(temp[0], int.Parse(temp[6]), double.Parse(temp[3]), temp[4], int.Parse(temp[5]), temp[2]);

                            break;
                        case "Katamaran":
                            boat = new Catamaran(temp[0], int.Parse(temp[6]), double.Parse(temp[3]), temp[4], int.Parse(temp[5]), temp[2]);
                            break;
                        default:
                            break;
                    }
                    secondDock.Add(boat);
                }
            }
            using (StreamReader sr = new StreamReader("Moorings2.Txt"))
            {
                string line;
                string[] temp;
                string[] temp2;
                int MooringId;
                while ((line = sr.ReadLine()) != null)
                {
                    temp = line.Split(";");
                    MooringId = int.Parse(temp[0]);
                    mooringsSecondDock[MooringId].SpaceLeft = int.Parse(temp[2]);
                    mooringsSecondDock[MooringId].isEmpthy = false;
                    temp2 = temp[1].Split(",");
                    for (int i = 0; i < temp2.Length; i++)
                    {
                        mooringsSecondDock[MooringId].IdOfDockedBoat.Add(temp2[i]);
                    }
                }
            }
        }
        public static List<Boat> GenerateBoats(int numberToGenerate, ObservableCollection<Boat> DockedBoatsFirstDock, ObservableCollection<Boat> DockedBoatsSecondDock)
        {
            int randomNumber;
            List<Boat> boats = new List<Boat>();
            Boat boat = new RowBoat();
            for (int i = 0; i < numberToGenerate;)
            {
                randomNumber = Random.Next(0, 5);
                switch (randomNumber)
                {
                    case 0:
                        boat=new RowBoat();
                        break;
                    case 1:
                        boat=new MotorBoat();
                        break;
                    case 2:
                        boat =new Sailboat();
                        break;
                    case 3:
                        boat = new CargoShip();
                        break;
                    case 4:
                        boat = new Catamaran();
                        break;
                    default:
                        break;
                }
                if(!HasDuplicate(boat, DockedBoatsFirstDock))
                {
                    if (!HasDuplicate(boat, DockedBoatsSecondDock))
                    {
                        boats.Add(boat);
                        i++;
                    }
                }

            }
            return boats;
        }

        static public bool HasDuplicate(Boat boat, ObservableCollection<Boat> dock)
        {
            foreach (var boat2 in dock)
            {
                if(boat.Id == boat2.Id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
