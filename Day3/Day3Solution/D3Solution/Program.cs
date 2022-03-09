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

            // part 1
            int[,] mat = new int[inputTxt.Length, inputTxt[0].Length];
            int[] repeatNum = new int[inputTxt[0].Length];


            for (int iLine = 0; iLine < inputTxt.Length; iLine++)
            {
                char[] separateLine = inputTxt[iLine].ToCharArray();
                for (int num = 0; num < separateLine.Length; num++)
                {
                    mat[iLine, num] = (int)Char.GetNumericValue(separateLine[num]);
                    if (mat[iLine, num] == 1)
                    {
                        repeatNum[num] += 1;
                    }
                    else
                    {
                        repeatNum[num] -= 1;
                    }
                }


            }

            //calcuate gamma and epsilon (convert from binary to decimal)
            int gamma = 0;
            int epsilon = 0;
            for (int i = inputTxt[0].Length; i-- > 0;)
            {
                if (repeatNum[i] > 0)
                {
                    // Most repeated digit is 1
                    gamma += (int)Math.Pow(2, (inputTxt[0].Length - i - 1));

                }
                else
                {
                    // Most repeated digit is 0
                    epsilon += (int)Math.Pow(2, (inputTxt[0].Length - i - 1));

                }

            }

            Console.WriteLine(epsilon * gamma);



        }
    }
}
