using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Day6Solution
{
    public class Lanternfish
    {
        public Double daysLeft { get; set; }
       

        public Lanternfish(Double day) 
        {
            daysLeft = day;
        }

        public double CalculateTotalGrandChilderern(double nDays)
        {
            double gen = 0;
            double totalGrandChilderern = 0;
            if (nDays <  daysLeft)
                    return 0;
            while ((daysLeft -nDays + (gen)*8) < 0)
            {
                totalGrandChilderern += -Math.Floor((daysLeft - nDays + gen * 8) / 7);
                gen++;
            }


            return totalGrandChilderern;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] inputTxt = File.ReadAllLines(@"G:\My Drive\Yasamin\C#\AdventOfCode\Day6\input - Test.txt");
            Double nDays = 18;

            List<string> initialDaysStr = new List<string>();
            initialDaysStr = inputTxt[0].Split(',').ToList();

            List<Lanternfish> fishes = new List<Lanternfish>();
            // to implement > should check that intial day of none of the fishes is 0
            double sum = 0.0;
            foreach(string dayStr in initialDaysStr) 
            {
                Double day = Convert.ToDouble(dayStr);
                fishes.Add(new Lanternfish(day)); // should try to rewrite using .Select()
                
                
            }
            foreach(Lanternfish fish in fishes)
                sum += fish.CalculateTotalGrandChilderern(nDays);


            //for (int i = 0; i < nDays; i++)
            //{
            //    Console.WriteLine(i);
            //    int newFishToAdd = 0;
            //    foreach (Lanternfish fish in fishes)
            //    {
            //        if (fish.days == 0)
            //        {
            //            fish.days = 7; // Set the days left to 7 instead of 6, because int he next step it will lose one. So by the end  of the day, it will still have 6 days left
            //            newFishToAdd++;
            //        }
            //        fish.days -= 1;

            //    }                 

            //    for (int j = 0; j < newFishToAdd; j++)
            //    {
            //        fishes.Add(new Lanternfish());
            //    }


            //}


            Console.WriteLine("Total number of fishes after {0} days is {1}",nDays, sum + fishes.Count);

        }
    }
}
