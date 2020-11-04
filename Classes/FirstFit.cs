using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.Xml;
using System.Text;

namespace Hamnen.Classes
{
    class FirstFit : IDock
    {
        public (int[], bool) FindDocking(Boat boat, ObservableCollection<Boat> dock, Mooring[] moorings)
        {
            int[] dockAt;
            bool success = false;
            int arraySize = boat.Size / 2;
            if (boat.Size <= 2)
            {
                dockAt = new int[1];
            }
            else
            {
                dockAt = new int[arraySize];
            }
            int index = 0;
            int indexToDockAt = 0;
            double flagIfSpotfound = 0;
            if (boat is RowBoat)
            {
                List<Boat> TempListOfRowBoats = dock.Where(b => b.Id.StartsWith("R")).ToList();
                if (TempListOfRowBoats.Count % 2 != 0)
                {
                    var list = moorings.Where(q => q.SpaceLeft == 1).ToList();
                    string id = list[0].IdOfDockedBoat[0];
                    for (int i = 0; i < moorings.Length; i++)
                    {
                        foreach (var boatId in moorings[i].IdOfDockedBoat)
                        {
                            if (id == boatId)
                            {
                                dockAt[0] = i;
                                success = true;
                                return (dockAt, success);
                            }
                        }
                    }
                }
            }
            foreach (var morring in moorings)
            {
                if (flagIfSpotfound == boat.Size)
                {
                    break;
                }
                if (morring.isEmpthy)
                {
                    dockAt[index] = indexToDockAt;
                    index++;
                    flagIfSpotfound+=2;
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
                success = false;
                return (dockAt, success);
            }
            success = true;
            return (dockAt, success);
        }

        public void Dock(Boat boat, ObservableCollection<Boat> firstDock, ObservableCollection<Boat> secondDock, Mooring[] mooringsFirstDock, Mooring[] mooringsSecondDock, string messageFirstDock, string MessageSecondDock)
        {

            (int[] dockAt, bool Succsess) = FindDocking(boat, firstDock, mooringsFirstDock);
            if (Succsess)
            {
                for (int i = 0; i < dockAt.Length; i++)
                {
                    mooringsFirstDock[dockAt[i]].IdOfDockedBoat.Add(boat.Id);
                    mooringsFirstDock[dockAt[i]].isEmpthy = false;
                    mooringsFirstDock[dockAt[i]].SpaceLeft -= boat.Size;

                }
                if (dockAt.Length == 1)
                {
                    boat.DockedAt = dockAt[0].ToString();
                }
                else
                {
                    boat.DockedAt = $"{dockAt[0]}-{dockAt[dockAt.Length - 1]}";
                }
                firstDock.Add(boat);
            }
            else
            {
                (dockAt, Succsess) = FindDocking(boat, secondDock, mooringsSecondDock);
                if (Succsess)
                {
                    for (int i = 0; i < dockAt.Length; i++)
                    {
                        mooringsSecondDock[dockAt[i]].IdOfDockedBoat.Add(boat.Id);
                        mooringsSecondDock[dockAt[i]].isEmpthy = false;
                        mooringsSecondDock[dockAt[i]].SpaceLeft -= boat.Size;

                    }
                    if (dockAt.Length == 1)
                    {
                        boat.DockedAt = dockAt[0].ToString();
                    }
                    else
                    {
                        boat.DockedAt = $"{dockAt[0]}-{dockAt[dockAt.Length - 1]}";
                    }
                    secondDock.Add(boat);
                }
                else
                {
                    Utils.BoatsRejected++;
                    if (Utils.MessegeSecondDock == "")
                    {
                        Utils.MessegeSecondDock += $"En båt har blivit avisad för att den inte fick plats";
                    }
                    else
                    {
                        Utils.MessegeSecondDock += $"\nEn båt har blivit avisad för att den inte fick plats";
                    }
                }
            }

        }

        public void RemoveFromDock(Boat boat, ObservableCollection<Boat> dock, Mooring[] moorings)
        {
            var tempList = new List<string>();
            for (int i = 0; i < moorings.Length; i++)
            {
                foreach (var boat2 in moorings[i].IdOfDockedBoat)
                {
                    if (boat is RowBoat)
                    {
                        if (moorings[i].IdOfDockedBoat.Count == 1)
                        {
                            moorings[i].isEmpthy = true;
                        }
                        moorings[i].SpaceLeft += boat.Size;
                        tempList.Add(boat2);
                        dock.Remove(boat);
                    }
                    else
                    {
                        moorings[i].isEmpthy = true;
                        tempList.Add(boat2);
                        dock.Remove(boat);
                        moorings[i].SpaceLeft += boat.Size;
                    }

                }
                if (tempList.Count > 0)
                {
                    foreach (var boatId in tempList)
                    {
                        moorings[i].IdOfDockedBoat.Remove(boatId);
                    }
                }
            }
        }
    }
}
