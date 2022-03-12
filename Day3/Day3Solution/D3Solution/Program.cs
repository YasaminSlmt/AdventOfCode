using System;
using System.Text;
using System.Linq;
using System.IO;

namespace Day3Solution
{


    class Program
    {
        static void Main(string[] args)
        {

            string[] inputTxt = File.ReadAllLines(@"G:\My Drive\Yasamin\C#\AdventOfCode\Day3\input.txt");


            int gamma =0,epsilon = 0;
            
           
            int length = inputTxt[0].Length;

            for (int dig = 0 ; dig < length; dig ++)
            {
                //if (inputTxt.Aggregate(0, (s, line) => s + Convert.ToInt32(line[length - 1 - dig])) > inputTxt.Length / 2)
                if (inputTxt.Aggregate(0, (s, line) => s + (int)Char.GetNumericValue(line[length - (dig + 1)])) > inputTxt.Length / 2)
                {
                    gamma |= 1 << dig;
                }
                else
                    epsilon |= 1 << dig;


            }

            Console.WriteLine(gamma* epsilon);


            // Part 2
            string[] txtTemp = inputTxt;
            int idx = 0;
            while (txtTemp.Length > 1)
            {
                if (txtTemp.Aggregate(0, (s, line) => s + (int)Char.GetNumericValue(line[idx])) >= txtTemp.Length / 2.0)
                {
                    txtTemp = txtTemp.Where((line) => line[idx] == '1').ToArray();
                    
                }
                else
                {
                    txtTemp = txtTemp.Where((line) => line[idx] == '0').ToArray();
                }
                Console.WriteLine(txtTemp);
                Console.WriteLine((txtTemp.Aggregate(0, (s, line) => s + (int)Char.GetNumericValue(line[idx]))));
                
                idx += 1;
            }

            string[] ox = txtTemp;
            Console.WriteLine(ox[0]);

            txtTemp = inputTxt;

            idx = 0;
            while (txtTemp.Length > 1)
            {
                if (txtTemp.Aggregate(0, (s, line) => s + (int)Char.GetNumericValue(line[idx])) >= txtTemp.Length / 2.0)
                {
                    txtTemp = txtTemp.Where((line) => line[idx] == '0').ToArray();
                }
                else
                {
                    txtTemp = txtTemp.Where((line) => line[idx] == '1').ToArray();
                }
                idx += 1;
            }


            string[] co2 = txtTemp;


            Console.WriteLine(Convert.ToInt32(ox[0],2) * Convert.ToInt32(co2[0], 2));



        }
    }
}
