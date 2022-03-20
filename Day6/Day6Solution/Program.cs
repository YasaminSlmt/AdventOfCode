using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Day6Solution
{
    public class Lanternfish
    {
        public double initialDay { get; set; }
        public double daysLeft { get; set; }
       

        public Lanternfish(Double day) 
        {
            initialDay = day;
            daysLeft = day;
        }

        

    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] inputTxt = File.ReadAllLines(@"C:\Users\Administrator\Desktop\C#\AdventOfCode\Day6\input.txt");
            Double nDays = 256;

            List<string> initialDaysStr = new List<string>();
            initialDaysStr = inputTxt[0].Split(',').ToList();

            // to implement > should check that intial day of none of the fishes is 0
            ulong sum = 0;
            // Find fishes with same intial state
            var uniquDaysLeft = initialDaysStr
                .GroupBy(str => str)
                .ToDictionary(grp => grp.Key, grp => grp.ToList());

            List<string> uniqueInitialDays = uniquDaysLeft.Keys.ToList();

            foreach (string dayStr in uniqueInitialDays)
            {
                ulong s = 0;
                int dayInt = Convert.ToInt32(dayStr);
                // get the total number of fishes with initial state of dayStr
                ulong nFish = Convert.ToUInt64(initialDaysStr.Where(str => Equals(str,dayStr)).Count());
                // Create a dictionary to track the changes
                IDictionary<int, int> fishDays = new Dictionary<int, int>();
                fishDays.Add(0, 0);
                fishDays.Add(1, 0); 
                fishDays.Add(2, 0);
                fishDays.Add(3, 0);
                fishDays.Add(4, 0);
                fishDays.Add(5, 0);
                fishDays.Add(6, 0);
                fishDays.Add(7, 0);
                fishDays.Add(8, 0);

                fishDays[dayInt] = 1;


                for (int i = 1; i <= nDays; i++)
                {

                    int toBeAdded = fishDays[0];
                    for (int j = 0; j< 8; j++)
                    {
                        
                        fishDays[j] = fishDays[j + 1];                   

                    }

                    fishDays[6] += toBeAdded;
                    fishDays[8] = toBeAdded;

                }
                for (int i = 0; i <= 8; i++)
                {
                    s += Convert.ToUInt64(fishDays[i]);
                }






                ////////
                //double day = Convert.ToDouble(dayStr);
                //fishes.Add(new Lanternfish(day)); // should try to rewrite using .Select()

                //for (int i = 0; i < nDays; i++)
                //{
                //    Console.WriteLine( i);
                //    int newFishToAdd = 0;
                //    foreach (Lanternfish fish in fishes)
                //    {
                //        if (fish.daysLeft == 0)
                //        {
                //            fish.daysLeft = 7; // Set the days left to 7 instead of 6, because int he next step it will lose one. So by the end  of the day, it will still have 6 days left
                //            newFishToAdd++;
                //        }
                //        fish.daysLeft -= 1;

                //    }

                //    for (int j = 0; j < newFishToAdd; j++)
                //    {
                //        fishes.Add(new Lanternfish(8));
                //    }


                //}

                sum += (s)* nFish;

            }
             Console.WriteLine("Total number of fishes after {0} days is {1}",nDays, sum);

        }
    }
}
