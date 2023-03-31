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
        private HashSet<int> ticketNumbers;
        private HashSet<int> ticketStars;
        private int ticketSerial;
        private static int ticketIncrement = 1;
        private Random random = new Random();

        //Constructors

        public Ticket()
        {
            HashSet<int> ticketnumbers = new HashSet<int>() { 10, 20, 30, 40, 50 };
            HashSet<int> ticketStars = new HashSet<int>() { 4, 8 };
            ticketSerial = ticketIncrement;
            ticketIncrement++;
        }
        //Note that I've added `()` after `HashSet<int>` to instantiate the HashSet object and used curly braces to enclose the integer values inside.

        public Ticket(HashSet<int> ticketNumbers, HashSet<int> ticketStars)
        {
            this.ticketNumbers = ticketNumbers;
            this.ticketStars = ticketStars;
            ticketSerial = ticketIncrement;
            ticketIncrement++;
        }



        public override string ToString()
        {
            string ticketString = "Ticket nº: " + ticketSerial + "\n";
            ticketString += "Numbers: ";
            foreach (int num in ticketNumbers)
            {
                ticketString += num + " ";
            }
            ticketString += "\nStars: ";
            foreach (int star in ticketStars)
            {
                ticketString += star + " ";
            }
            ticketString += "\n";

            return ticketString;
        }
    }
}
