using System;
using System.Text;
using System.IO;

namespace Day2Solution
{

    
    class Program
    {
        static void Main(string[] args)
        {

            string[] inputTxt = File.ReadAllLines(@"G:\My Drive\Yasamin\C#\AdventOfCode\Day2\input.txt");

            // part 1
            int depth = 0;
            int horizontal = 0;
            for (int i = 0; i < inputTxt.Length; i++)
            {

                string[] result = inputTxt[i].Split(" ");
                switch (result[0])
                {
                    case "forward":
                        {
                            horizontal += Int32.Parse(result[1]);
                            break;
                        }
                    case "up":
                        {
                            depth -= Int32.Parse(result[1]);
                            break;
                        }
                    case "down":
                        {
                            depth += Int32.Parse(result[1]);
                            break;
                        }
                }



                

            }
            Console.WriteLine("Part 1: Depth multiply by Horizontal is {0}", depth * horizontal);

            // part 2
            inputTxt = File.ReadAllLines(@"G:\My Drive\Yasamin\C#\AdventOfCode\Day2\input.txt");
            int aim = 0;
            depth = 0;
            horizontal = 0;

            for (int i = 0; i < inputTxt.Length; i++)
            {

                string[] result = inputTxt[i].Split(" ");
                switch (result[0])
                {
                    case "forward":
                        {
                            horizontal += Int32.Parse(result[1]);
                            depth += (aim * Int32.Parse(result[1]));
                            break;
                        }
                    case "up":
                        {
                            aim -= Int32.Parse(result[1]);
                            break;
                        }
                    case "down":
                        {
                            aim += Int32.Parse(result[1]);
                            break;
                        }
                }





            }
            Console.WriteLine("Part 2: Depth multiply by Horizontal is {0}", depth * horizontal);


        }
    }
}
