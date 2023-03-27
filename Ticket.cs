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
        private HashSet<int> ticketNumbers { get; set; }
        private HashSet<int> ticketStars { get; set; }
        private Tuple<HashSet<int>, HashSet<int>> ticketBets { get; set; }
        private int ticketSerial;
        private static int ticketIncrement = 1;
        private Random random = new Random();

        //Constructors

        public Ticket()
        {
            ticketNumbers = new HashSet<int>();
            ticketStars = new HashSet<int>();
            ticketBets = Tuple.Create(ticketNumbers, ticketStars);
            ticketSerial = ticketIncrement++;
        }

        public Ticket(Tuple <HashSet<int>, HashSet<int>> ticketBets)
        {
            this.ticketBets = ticketBets;
            ticketSerial = ticketIncrement++;
        }


        //fazer get do tuple
        public int TicketSerial { get => ticketSerial; set => ticketSerial = value; }

        //Methods

        public override string ToString()
        {
            string ticketString = "Ticket: " + ticketSerial + "\n";
            ticketString += "Numbers: ";
            foreach (int number in ticketNumbers)
            {
                ticketString += number + " ";
            }
            ticketString += "\nStars: ";
            foreach (int star in ticketStars)
            {
                ticketString += star + " ";
            }
            return ticketString;
        }
    }
}
