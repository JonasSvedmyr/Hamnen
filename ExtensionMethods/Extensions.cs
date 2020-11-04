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
        public static List<int> FindFreeSpace(this Mooring[] moorings)
        {
            List<int> moornings = new List<int>();

            for (int i = 0; i < moorings.Length; i++)
            {
                if (moorings[i].isEmpthy)
                {
                    moornings.Add(i);
                }
            }
            return moornings;
        }
        public static double AvrageSpeed(this ObservableCollection<Boat> DockedBoats)
        {
            double sum = 0;
            foreach (var boat in DockedBoats)
            {
                sum += boat.MaxVelocity;
            }
            sum = Math.Round(sum / DockedBoats.Count, 5);
            if(Double.IsNaN(sum))
            {
                return 0;
            }
            else
            return sum;
        }
    }
}
