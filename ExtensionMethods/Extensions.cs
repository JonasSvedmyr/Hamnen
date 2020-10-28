using Hamnen.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Hamnen.ExtensionMethods
{
    static class Extensions
    {
        public static List<int> FindFreeSpace(this HarborViewModel harbor)
        {
            List<int> moornings = new List<int>();

            for (int i = 0; i < harbor.Moorings.Length; i++)
            {
                if (harbor.Moorings[i].isEmpthy)
                {
                    moornings.Add(i);
                }
            }
            return moornings;
        }
        public static double AvrageSpeed(this HarborViewModel harbor)
        {
            double sum = 0;
            foreach (var boat in harbor.DockedBoats)
            {
                sum += boat.MaxVelocity;
            }
            return sum / harbor.DockedBoats.Count;
        }
        public static ObservableCollection<Boat> ToObservabelCollection(this List<Boat> boats)
        {
            ObservableCollection<Boat> tempList = new ObservableCollection<Boat>();
            foreach (var boat in boats)
            {
                tempList.Add(boat);
            }
            return tempList;
        }
    }
    
}
