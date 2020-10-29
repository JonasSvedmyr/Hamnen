using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.Xml;
using System.Text;

namespace Hamnen.Classes
{
    class FirstFit : IDock
    {
        public int[] FindDocking(HarborViewModel harbor, Boat boat)
        {
            int[] dockAt;
            if (boat.Size < 1)
            {
                dockAt = new int[1];
            }
            else
            {
                dockAt = new int[(int)boat.Size];
            }
            int index = 0;
            int indexToDockAt = 0;
            double flagIfSpotfound = 0;
            if (boat is RowBoat)
            {
                List<Boat> TempListOfRowBoats = harbor.DockedBoats.Where(b => b.Id.StartsWith("R")).ToList();
                if (TempListOfRowBoats.Count % 2 != 0)
                {
                    var list = harbor.Moorings.Where(q => q.SpaceLeft > 0 && q.SpaceLeft < 1).ToList();
                    string id = list[0].IdOfDockedBoat[0];
                    for (int i = 0; i < harbor.Moorings.Length; i++)
                    {
                        foreach (var boatId in harbor.Moorings[i].IdOfDockedBoat)
                        {
                            if (id == boatId)
                            {
                                dockAt[0] = i;
                                return dockAt;
                            }
                        }
                    }
                }
            }
            foreach (var morring in harbor.Moorings)
            {
                if (flagIfSpotfound == boat.Size)
                {
                    break;
                }
                if (morring.isEmpthy)
                {
                    dockAt[index] = indexToDockAt;
                    index++;
                    flagIfSpotfound++;
                    if (boat.Size <= 1)
                    {
                        flagIfSpotfound = boat.Size;
                        break;
                    }
                }
                else
                {
                    index = 0;
                    flagIfSpotfound = 0;
                }
                indexToDockAt++;
            }

            if (flagIfSpotfound != boat.Size)
            {
                throw new Exception();
            }
            return dockAt;
        }

        public void Dock(Boat boat, HarborViewModel harbor)
        {
            try
            {
                int[] dockAt = FindDocking(harbor, boat);
                for (int i = 0; i < dockAt.Length; i++)
                {
                    harbor.Moorings[dockAt[i]].IdOfDockedBoat.Add(boat.Id);
                    harbor.Moorings[dockAt[i]].isEmpthy = false;
                    harbor.Moorings[dockAt[i]].SpaceLeft -= boat.Size;

                }
                if (dockAt.Length == 1)
                {
                    boat.DockedAt = dockAt[0].ToString();
                }
                else
                {
                    boat.DockedAt = $"{dockAt[0]}-{dockAt[dockAt.Length - 1]}";
                }
                harbor.DockedBoats.Add(boat);
            }
            catch
            {
                harbor.BoatsRejected++;
                if (harbor.Message == "")
                {
                    harbor.Message += $"En båt har blivit avisad för att den inte fick plats";
                }
                else
                {
                    harbor.Message += $"\nEn båt har blivit avisad för att den inte fick plats";
                }
            }
        }

        public void RemoveFromDock(Boat boat, HarborViewModel harbor)
        {
            var tempList = new List<string>();
            for (int i = 0; i < harbor.Moorings.Length; i++)
            {
                foreach (var boat2 in harbor.Moorings[i].IdOfDockedBoat)
                {
                    if (boat2 == boat.Id)
                    {
                        harbor.Moorings[i].isEmpthy = true;
                        harbor.Moorings[i].SpaceLeft += boat.Size; //Not the best way
                        tempList.Add(boat2);
                        harbor.DockedBoats.Remove(boat);
                    }

                }
                if (tempList.Count > 0)
                {
                    foreach (var boatId in tempList)
                    {
                        harbor.Moorings[i].IdOfDockedBoat.Remove(boatId);
                    }
                }
            }
        }
    }
}
