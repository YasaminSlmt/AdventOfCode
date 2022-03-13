using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Day3Solution
{

    public class Number
    {
        public bool check = false;
        public int value;

        public Number(int value)
        {
            this.value = value;
        }

        public void CheckVal(int num)
        {
            this.check = (num == this.value ? true : this.check);
        }
    }

    public class Card
    {
        public bool isRowTrue {get; set;}
        public bool isColTrue { get; set; }
        public int winRound { get; set; }
        public int cardID { get; set; }
        public int lastDraw { get; set; }
        public Number[,] numbers = new Number[5,5];

        

        public Card(int cardID, string[] numStr)
        {
            isRowTrue = false;
            isColTrue = false;
            winRound = 0;
            lastDraw = 0;

            this.cardID = cardID;
            for (int row = 0; row < 5; row++)
            {
                string[] line = numStr[row].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < 5; col++)
                {
                    numbers[row, col] = new Number(Convert.ToInt32(line[col]));   
                }
            }
        }

        public void CheckNums(int darwNum)
        {
            foreach(Number num in numbers)
            {
                num.CheckVal(darwNum);
            }
        }

        public void CheckScore(int round, int num)
        {
            // check rows
            for (int row = 0; row < 5; row++)
            {
                Number[] rowToCheck = Enumerable.Range(0, numbers.GetLength(1))
                                    .Select(x => numbers[row, x])
                                    .ToArray();
                bool value = Array.TrueForAll(rowToCheck, element => element.check == true);
                if (value)
                {
                    isRowTrue = true;
                    break;
                }


            }
            // check columns
            for (int col = 0; col < 5; col++)
            {
                Number[] colToCheck = Enumerable.Range(0, numbers.GetLength(0))
                    .Select(x => numbers[x, col])
                    .ToArray();
                bool value = Array.TrueForAll(colToCheck, element => element.check == true);
                if (value)
                {
                    isColTrue = true;
                    break;
                }
            }

            if (isRowTrue || isColTrue)
            {
                winRound = round;
                lastDraw = num;
            }

        }
    }


        class Program
    {
        static void Main(string[] args)
        {

            string[] inputTxt = File.ReadAllLines(@"G:\My Drive\Yasamin\C#\AdventOfCode\Day4\input - Copy.txt");

            string[] inputNumsStr = inputTxt[0].Split(",");
            int[] inputNums = inputNumsStr.Select(int.Parse).ToArray();

            var nCards = inputTxt.Where(line => line == "").Count();

            var cards = new List<Card>();
            string[] cardStr;

            for (int i = 0; i < (nCards); i++)
            {
                cardStr = inputTxt[(i*6+2)..(i*6 + 2 + 5)];
                cards.Add(new Card (i, cardStr));
            }
            int cardNum = 0;
            foreach (Card card in cards)
            {
               int round = 0; 
               foreach(int num in inputNums)
                {
                    round++;
                    card.CheckNums(num);
                    card.CheckScore(round, num);
                    if (card.winRound != 0)
                        break;
                    
                }
                cardNum++;
            }

            Card winningCard = cards.Aggregate((min, x) => x.winRound < min.winRound ? x : min);
            int s = 0;
            foreach (Number num in winningCard.numbers)
                 s+=(num.check == false ? num.value : 0);


            Console.WriteLine("Final score is {0}", s*winningCard.lastDraw);








        }
    }
}
