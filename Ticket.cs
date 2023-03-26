using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Euromilhoes
{
    internal class Ticket
    {
        private List<Tuple<HashSet<int>, HashSet<int>>> ticketNums;
        private int ticketSerial;
        private static int ticketIncrement = 1;
        private Random random = new Random();

        //Constructors

        public Ticket()
        {
            this.ticketNums = new List<Tuple<HashSet<int>, HashSet<int>>>();
            this.ticketSerial = ticketIncrement;
            this.ticketIncrement++;
        }

        public Ticket(List<Tuple<HashSet<int>, HashSet<int>>> ticketNums)
        {
            this.ticketNums = ticketNums;
            this.ticketSerial = ticketIncrement;
            this.ticketIncrement++;
        }

        //Gets & Sets

        //fazer get do tuple
        public int TicketSerial { get => ticketSerial; set => ticketSerial = value; }

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
    }
}
