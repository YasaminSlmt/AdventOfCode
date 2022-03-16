using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Day5Solution
{

    public class Line
    {
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }

        public Line()
        {
            x1 = 0;
            x2 = 0;
            y1 = 0;
            y2 = 0;
        }

    }
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public int value { get; set; }

        public Point(int X, int Y)
        {
            x = X;
            y = Y;
            value = 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            string[] inputTxt = File.ReadAllLines(@"G:\My Drive\Yasamin\C#\AdventOfCode\Day5\input - Test.txt");


            int[,] board = new int[999, 999]; // Should be modified so that the board size is more dynamic and based on the maximum x and t detected in the input
            Line[] lines = new Line[inputTxt.Length];
            string[] splitStrs = new string[] { ",", "-> " };

            int lineCount = 0;

            foreach (Line line in lines)
            {
                string[] splitLine = inputTxt[lineCount].Split(splitStrs, StringSplitOptions.None);
                line.x1 = Convert.ToInt32(splitLine[0]);
                line.y1 = Convert.ToInt32(splitLine[1]);
                line.x2 = Convert.ToInt32(splitLine[2]);
                line.y1 = Convert.ToInt32(splitLine[3]);

                lineCount++;

                if ((line.x1 == line.x2))
                {
                    Enumerable.Range(Math.Min(line.y1, line.y2), Math.Max(line.y1, line.y2))
                                   .Select(y => board[y, line.x1]++)
                                   .ToArray();
                }
                else if((line.y1 == line.y2))
                {
                    Enumerable.Range(Math.Min(line.x1, line.x2), Math.Max(line.x1, line.x2))
                                                .Select(x => board[line.y1, x]++)
                                                .ToArray();

                }


            }
            
            

            











        }
    }
}
