using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Euromilhoes
{
    internal class Player
    {
        private String name;
        private int nif;
        private decimal balance;
        private List<Ticket> ownedTickets;
        private static int playerIncrement = 1;
        private Random random = new Random();

        //Constructors
        public Player()
        {
            name = "NewPlayer" + playerIncrement.ToString();
            nif = random.Next(100000000, 999999999);
            balance = 100;
            ownedTickets = new List<Ticket>();
            playerIncrement++;
        }

        public Player(string name, int nif)
        {
            this.name = name;
            this.nif = nif;
            this.balance = 100;
            ownedTickets = new List<Ticket>();
        }

        public override string ToString()
        {
            return "Player: "
                + name
                + "\nNIF: "
                + nif
                + "\nSaldo: "
                + string.Format("{0:0.00}", balance);
        }

        public void PrintTicketList()
        {
            foreach (Ticket t in ownedTickets)
            {
                Console.WriteLine(t.ToString());
            }
        }

        //Gets & Sets
        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Nif
        {
            get => nif;
            set => nif = value;
        }
        public decimal Balance
        {
            get => balance;
            set
            {
                if (value >= 0)
                    this.balance = value;
            }
        }
        public List<Ticket> OwnedTickets
        {
            get => ownedTickets;
            set => ownedTickets = value;
        }
    }
}
