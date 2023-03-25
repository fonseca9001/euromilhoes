using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Euromilhoes
{
    internal class Ticket
    {
        private List<HashSet<int>> ticketNumbers;
        private List<HashSet<int>> ticketStars;
        private int ticketSerial;
        private static int ticketIncrement = 1;
        private Random random = new Random();
        private static DateTime fillDate;

        //Constructors

        public Ticket()
        {
            ticketNumbers = new List<HashSet<int>>();
            ticketStars = new List<HashSet<int>>();
            ticketSerial = ticketIncrement;
            ticketIncrement++;
            ticketNumbers.Add(new HashSet<int>());
            ticketStars.Add(new HashSet<int>());
            GenerateRandomNumbers(); //o ticket é criado com 5 números e 2 estrelas aleatórios
        }

        public Ticket(List<HashSet<int>> ticketNumbers, List<HashSet<int>> ticketStars)
        {
            this.ticketNumbers = ticketNumbers;
            this.ticketStars = ticketStars;
            ticketSerial = ticketIncrement;
            ticketIncrement++;
        }

        //Methods

        public override string ToString()
        {
            string ticketString = "Ticket: " + ticketSerial + "\n";
            ticketString += "Numbers: ";
            foreach (HashSet<int> numbers in ticketNumbers)
            {
                foreach (int number in numbers)
                {
                    ticketString += number + " ";
                }
            }
            ticketString += "\nStars: ";
            foreach (HashSet<int> stars in ticketStars)
            {
                foreach (int star in stars)
                {
                    ticketString += star + " ";
                }
            }
            return ticketString;
        }

        public void GenerateRandomNumbers()
        {

            ticketNumbers[0].Clear();
            ticketStars[0].Clear();

            var numbers = new HashSet<int>();
            while (numbers.Count < 5)
            {
                int number = random.Next(1, 51);
                numbers.Add(number);
            }
            ticketNumbers[0].UnionWith(numbers);

            var stars = new HashSet<int>();
            while (stars.Count < 2)
            {
                int star = random.Next(1, 13);
                stars.Add(star);
            }
            ticketStars[0].UnionWith(stars);
        }

        //Gets & Sets

        public List<HashSet<int>> TicketNumbers { get => ticketNumbers; set => ticketNumbers = value; }
        public List<HashSet<int>> TicketStars { get => ticketStars; set => ticketStars = value; }
        public int TicketSerial { get => ticketSerial; set => ticketSerial = value; }
        public DateTime FillDate { get => fillDate; set => fillDate = value; }
    }
}
