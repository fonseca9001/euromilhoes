using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Euromilhoes
{
    internal class Ticket
    {
        private HashSet<int> ticketNumbers;
        private HashSet<int> ticketStars;
        private int ticketSerial;
        private static int ticketIncrement = 1;

        private bool isValid;
        private Random random = new Random();

        //Constructors

        public Ticket()
        {
            HashSet<int> ticketnumbers = new HashSet<int>() { 10, 20, 30, 40, 50 };
            HashSet<int> ticketStars = new HashSet<int>() { 4, 8 };
            ticketSerial = ticketIncrement;
            isValid = true;
            ticketIncrement++;
        }

        public Ticket(HashSet<int> ticketNumbers, HashSet<int> ticketStars)
        {
            this.ticketNumbers = ticketNumbers;
            this.ticketStars = ticketStars;
            this.isValid = true;
            this.ticketSerial = ticketIncrement;
            ticketIncrement++;
        }

        public override string ToString()
        {
            string ticketString = "Ticket nº: ";
            if (ticketSerial != null)
            {
                ticketString += ticketSerial;
            }
            ticketString += "\nNumbers: ";
            if (ticketNumbers != null)
            {
                foreach (int num in ticketNumbers)
                {
                    ticketString += num + " ";
                }
            }
            ticketString += "\nStars: ";
            if (ticketStars != null)
            {
                foreach (int star in ticketStars)
                {
                    ticketString += star + " ";
                }
            }
            ticketString += "\n";

            return ticketString;
        }

        public HashSet<int> GetTicketNumbers()
        {
            return this.ticketNumbers;
        }

        public HashSet<int> GetTicketStars()
        {
            return this.ticketStars;
        }

        public int GetTicketSerial()
        {
            return this.ticketSerial;
        }

        public bool GetIsValid()
        {
            return this.isValid;
        }

        public void SetTicketNumbers(HashSet<int> ticketNumbers)
        {
            this.ticketNumbers = ticketNumbers;
        }

        public void SetTicketStars(HashSet<int> ticketStars)
        {
            this.ticketStars = ticketStars;
        }

        public void SetTicketSerial(int ticketSerial)
        {
            this.ticketSerial = ticketSerial;
        }

        public void SetIsValid(bool isValid)
        {
            this.isValid = isValid;
        }
    }
}
