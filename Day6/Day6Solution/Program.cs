using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Day6Solution
{
    public class Lanternfish
    {
        public int days { get; set; }
        public Lanternfish()
        {
            days = 8;
        }

        public Lanternfish(int day)
        {
            days = day;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] inputTxt = File.ReadAllLines(@"G:\My Drive\Yasamin\C#\AdventOfCode\Day6\input - Test.txt");
            int nDays = 256;

            List<string> initialDays = new List<string>();
            initialDays = inputTxt[0].Split(',').ToList();

            List<Lanternfish> fishes = new List<Lanternfish>();
            // to implement > should check that intial day of none of the fishes is 0
            foreach(string day in initialDays)
                fishes.Add(new Lanternfish(Convert.ToInt32(day))); // should try to rewrite using .Select()

            for (int i = 0; i < nDays; i++)
            {
                Console.WriteLine(i);
                int newFishToAdd = 0;
                foreach (Lanternfish fish in fishes)
                {
                    if (fish.days == 0)
                    {
                        fish.days = 7; // Set the days left to 7 instead of 6, because int he next step it will lose one. So by the end  of the day, it will still have 6 days left
                        newFishToAdd++;
                    }
                    fish.days -= 1;

                }                 

                for (int j = 0; j < newFishToAdd; j++)
                {
                    fishes.Add(new Lanternfish());
                }


            }

            
            Console.WriteLine("Total number of fishes after {0} days is {1}",nDays, fishes.Count);

        }
    }
}
