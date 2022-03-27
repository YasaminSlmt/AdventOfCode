using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Day8Solution
{
    public class Digit
    {
        public string[] Strs { get; set; }

        public bool ExistInAnotherStr(string StringToCheck)
        {
            
            return false;
        }
    }
    
    
    
    class Program
    {
        static void Main(string[] args)
        {
            string[] letters = { "a", "b", "c", "d", "e", "f", "g" };
            IDictionary<int, int> digits = new Dictionary<int, int>() {
                {0,6 },
                {1,2 },
                {2,5 },
                {3,5 },
                {4,4 },
                {5,5 },
                {6,6 },
                {7,3 },
                {8,7 },
                {9,6 }, 
            };

            string[] inputTxt = File.ReadAllLines(@"G:\My Drive\Yasamin\C#\AdventOfCode\Day8\input.txt");

            int counter = 0;
            int sum = 0;

            // Part 1

            for (int line = 0; line < inputTxt.Length; line++)
            {
                string[] str = inputTxt[line].Split('|', StringSplitOptions.None);
                string[] lineOutput = str[1].Split(' ', StringSplitOptions.None);
                foreach(string output in lineOutput)
                {
                    if ((output.Length == digits[1]) || (output.Length == digits[4]) || (output.Length == digits[7]) || (output.Length == digits[8]))
                        counter++;
                }
            }


            Console.WriteLine("Number of output digits with unique signals is {0}", counter);


            // Part 2
           
            // Decoding numbers
            for (int line = 0; line < inputTxt.Length; line++)
            {
                string[] str = inputTxt[line].Split('|', StringSplitOptions.None);
                string[] lineOutput = str[1].Trim().Split(' ', StringSplitOptions.None);
                string[] lineInput = str[0].Trim().Split(' ', StringSplitOptions.None);

                IDictionary<int, string> lineDigits = new Dictionary<int, string>() {
                {0,"" },
                {1,"" },
                {2,"" },
                {3,"" },
                {4,"" },
                {5,"" },
                {6,"" },
                {7,"" },
                {8,"" },
                {9,"" },
            };
                // Find 1, 4, 7, and 8 based on the strings length
                lineDigits[1] = Array.Find(lineInput, element => element.Length == 2);
                lineDigits[4] = Array.Find(lineInput, element => element.Length == 4);
                lineDigits[7] = Array.Find(lineInput, element => element.Length == 3);
                lineDigits[8] = Array.Find(lineInput, element => element.Length == 7);

                // Find 3: The only 5 element number which has all the letters of 1
                var possibleStrs = lineInput.Where(str => lineDigits[1].All(c => str.Contains(c))).ToArray();
                lineDigits[3] = Array.Find(possibleStrs, element => element.Length == 5);

                // Find 9: The only 6 element number which has all the letters of 4
                possibleStrs = lineInput.Where(str => lineDigits[4].All(c => str.Contains(c))).ToArray();
                lineDigits[9] = Array.Find(possibleStrs, element => element.Length == 6);

                // Find 5: The only 5 element number where all of its element exist in 9 
                possibleStrs = lineInput.Where(str => str.All(c => lineDigits[9].Contains(c))).ToArray();
                lineDigits[5] = Array.Find(possibleStrs, element => element.Length == 5 && !element.Equals(lineDigits[3]));
                
                // Find 2: The only 5 element that is left
                lineDigits[2] = Array.Find(lineInput, element => (element.Length == 5 && !element.Equals(lineDigits[3]) && !element.Equals(lineDigits[5])));

                // Find 6: The only 6 element number left which has all the letters of 5
                possibleStrs = lineInput.Where(str => lineDigits[5].All(c => str.Contains(c))).ToArray();
                lineDigits[6] = Array.Find(possibleStrs, element => element.Length == 6 && !element.Equals(lineDigits[9]));

                // Find 0: The only 6 element that is left
                lineDigits[0] = Array.Find(lineInput, element => element.Length == 6 && !element.Equals(lineDigits[6]) && !element.Equals(lineDigits[9]));


                // Decoding the outputs
                string outputNum = "";
                foreach (string output in lineOutput)
                {
                    possibleStrs = lineDigits.Values.Where(str => str.All(c => output.Contains(c))).ToArray();
                    var tmp = Array.Find(possibleStrs, element => element.Length == output.Length);

                    outputNum += Convert.ToString(lineDigits.FirstOrDefault(x => x.Value == tmp).Key);



                }

                sum += Convert.ToInt32(outputNum);

            }

            Console.WriteLine("Part 2 answer is {0}", sum);


            

        }

    }
}
