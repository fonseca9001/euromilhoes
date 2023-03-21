using System;
using System.Collections.Generic;

namespace euromilhoes
{
    public static class Ticket
    {
        public static Ticket GenerateWinningTicket()
        {
            var mainNumbers = new List<int>();
            var luckyStars = new List<int>();
            var random = new Random();

            // Generate 5 main numbers (between 1 and 50) without repeating
            while (mainNumbers.Count < 5)
            {
                var number = random.Next(1, 51);
                if (!mainNumbers.Contains(number))
                {
                    mainNumbers.Add(number);
                }
            }

            // Generate 2 lucky stars (between 1 and 12) without repeating
            while (luckyStars.Count < 2)
            {
                var number = random.Next(1, 13);
                if (!luckyStars.Contains(number))
                {
                    luckyStars.Add(number);
                }
            }

            return new Ticket(mainNumbers, luckyStars);
        }
    }

    public class Ticket
    {
        public List<int> MainNumbers { get; set; }
        public List<int> LuckyStars { get; set; }

        public Ticket(List<int> mainNumbers, List<int> luckyStars)
        {
            MainNumbers = mainNumbers;
            LuckyStars = luckyStars;
        }

        public void FillFromUserInput()
        {
            // Prompt the user for input
            Console.WriteLine("Enter 5 main numbers (between 1 and 50):");
            MainNumbers = ParseNumberListFromUserInput();
            Console.WriteLine("Enter 2 lucky stars (between 1 and 12):");
            LuckyStars = ParseNumberListFromUserInput();
        }

        private static List<int> ParseNumberListFromUserInput()
        {
            var input = Console.ReadLine();
            var numbers = new List<int>();
            foreach (var str in input.Split(' '))
            {
                if (int.TryParse(str, out var number))
                {
                    numbers.Add(number);
                }
            }
            return numbers;
        }
    }
}    