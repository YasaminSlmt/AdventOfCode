using System;
using System.Text;
using System.IO;

namespace Day1Solution
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] inputTxt = File.ReadAllLines(@"G:\My Drive\Yasamin\C#\AdventOfCode\Day1\input.txt");
            int depth = 0;

            int[] inputNumber = new int[inputTxt.Length];
            // Part 1
            for (int i = 0; i < inputTxt.Length; i++)
            {
                inputNumber[i] = Int32.Parse(inputTxt[i]);
                if (i != 0)
                {
                    if (inputNumber[i] > inputNumber[i - 1])
                        depth += 1;
                }
            }

            Console.WriteLine("Single depth increase is: {0}",depth);

            //Part 2
            
            int sum3 = 0;
            for (int i = 0; i < inputTxt.Length - 2; i++)
            {
                
                if (i != 0)
                {
                    if ((inputNumber[i] + inputNumber[i+1] + inputNumber[i+2]) > (inputNumber[i - 1] + inputNumber[i] + inputNumber[i + 1]))
                        sum3 += 1;
                }
            }

            Console.WriteLine("three-measurement window sum increase is: {0}", sum3);



        }
    }
}
