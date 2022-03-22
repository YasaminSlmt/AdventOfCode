using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Day7Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputTxt = File.ReadAllLines(@"G:\My Drive\Yasamin\C#\AdventOfCode\Day7\input.txt");
            
            string[] inputStr = inputTxt[0].Split(',');
            int[] input = Array.ConvertAll(inputStr, s => int.Parse(s));
            // Part 1: 
            //  Inefficient way: To conver the input string into an array and go one by one to calcualte the distances for each element and find the min

            int min = Int32.MaxValue;

            foreach(int num in Enumerable.Range(input.Min(), (input.Max() - input.Min() +1)))
            {
                int s = 0;
                s = input.Aggregate(0, (diff, y) => diff + Math.Abs(y - num) );
                min = s < min ? s : min;

            }

            Console.WriteLine("Part 1: The optimum number is at position {0}", min);

            // part 2: 
            min = Int32.MaxValue;
            foreach (int num in Enumerable.Range(input.Min(), (input.Max() - input.Min() + 1)))
            {
                int s = 0;
                s = input.Aggregate(0, (sum, y) => sum + (Math.Abs(y - num) * (Math.Abs(y - num) + 1))/2);
                min = s < min ? s : min;

            }

            Console.WriteLine("Part 1: The optimum number is at position {0}", min);


        }
    }
}
