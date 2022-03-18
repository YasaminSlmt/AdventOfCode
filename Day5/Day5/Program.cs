﻿using System;
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

        public Line(int X1, int Y1, int X2, int Y2)
        {
            x1 = X1;
            x2 = X2;

            y1 = Y1;
            y2 = Y2;
        }

    }
    //public class Point
    //{
    //    public int x { get; set; }
    //    public int y { get; set; }
    //    public int value { get; set; }

    //    public Point(int X, int Y)
    //    {
    //        x = X;
    //        y = Y;
    //        value = 0;
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {

            string[] inputTxt = File.ReadAllLines(@"G:\My Drive\Yasamin\C#\AdventOfCode\Day5\input.txt");
            int nLines = inputTxt.Count();

            int[,] board = new int[1000, 1000]; // Should be modified so that the board size is more dynamic and based on the maximum x and t detected in the input
            var lines = new List<Line>();
            string[] splitStrs = new string[] { ",", "-> " };

            int lineCount = 0;

            for (int i = 0; i < nLines; i++)
            {
                string[] splitLine = inputTxt[lineCount].Split(splitStrs, StringSplitOptions.None);
                int x1 = Convert.ToInt32(splitLine[0]);
                int y1 = Convert.ToInt32(splitLine[1]);
                int x2 = Convert.ToInt32(splitLine[2]);
                int y2 = Convert.ToInt32(splitLine[3]);

                lines.Add(new Line(x1, y1, x2, y2));
                lineCount++;
            }

            foreach (Line line in lines)
            {


                if ((line.x1 == line.x2))
                {
                    // Horizontal line
                    int nPoints = Math.Max(line.y1, line.y2) - Math.Min(line.y1, line.y2) + 1;
                    int startY = Math.Min(line.y1, line.y2);

                    Enumerable.Range(startY, nPoints)
                                   .Select(y => board[y, line.x1]++)
                                   .ToArray();
                }
                else if((line.y1 == line.y2))
                {

                    // Vertical line
                    int nPoints = Math.Max(line.x1, line.x2) - Math.Min(line.x1, line.x2) + 1;
                    int startX = Math.Min(line.x1, line.x2);
                    
                    Enumerable.Range(startX, nPoints)
                                              .Select(x => board[line.y1, x]++)
                                              .ToArray();
                }
                
           
                else
                {
                    // Diagonal line
                    int nPoints = (Math.Abs(line.x1 - line.x2) + 1);
                    int startX = line.x1;
                    int startY = line.y1;
                    int xMove = (line.x1 > line.x2 ? -1 : 1);
                    int yMove = (line.y1 > line.y2 ? -1 : 1);

                    Enumerable.Range(0, nPoints)
                            .Select(move => board[startY + move*yMove, startX + move*xMove]++)
                             .ToArray();
                }


            }
            

            int sum = 0;

            for (int i = 0; i < board.GetLength(1); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    sum += (board[i,j] > 1 ? 1 : 0);
                }
            }

            Console.WriteLine("Sum is {0}", sum);

















        }
    }
}
