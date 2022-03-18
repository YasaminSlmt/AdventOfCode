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

        public Line(int X1, int Y1, int X2, int Y2)
        {
            x1 = X1;
            x2 = X2;

            y1 = Y1;
            y2 = Y2;
        }
        public bool IsVertical()
        {
            if (x1 == x2)
                return true;
            return false;
        }
        public bool IsHorizontal()
        {
            if (y1 == y2)
                return true;
            return false;
        }

        public void MovePoints(int[,] board)
        {
            int nPoints = 0, startX = 0, startY = 0, xMove = 0, yMove = 0;
            if (IsVertical())
            {
                // Horizontal line
                nPoints = Math.Max(y1, y2) - Math.Min(y1, y2) + 1;
                startX = x1;
                startY = Math.Min(y1, y2);
                xMove = 0;
                yMove = 1;

            }
            else if (IsHorizontal())
            {
                // Vertical line
                nPoints = Math.Max(x1, x2) - Math.Min(x1, x2) + 1;
                startX = Math.Min(x1, x2);
                startY = y1;
                xMove = 1;
                yMove = 0;
            }
            else
            {
                // Diagonal line
                nPoints = (Math.Abs(x1 - x2) + 1);
                startX = x1;
                startY = y1;
                xMove = (x1 > x2 ? -1 : 1);
                yMove = (y1 > y2 ? -1 : 1);

            }

            Move(nPoints, startX, startY, xMove, yMove, board);

        }
        private void Move(int nPoints, int startX, int startY, int xMove, int yMove, int[,] board)
        {
            Enumerable.Range(0, nPoints)
                        .Select(point => board[startY + point * yMove, startX + point * xMove]++)
                        .ToArray();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] inputTxt = File.ReadAllLines(@"G:\My Drive\Yasamin\C#\AdventOfCode\Day5\input - Test.txt");
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
                line.MovePoints(board);
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
