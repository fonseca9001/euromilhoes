using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromilhoes
{
    internal class Player
    {
        private String name;
        private int nif;
        private decimal saldo;
        private List<Ticket> ownedTickets;
        private static int playerIncrement = 1;
        private Random random = new Random();

        //Constructors
        public Player()
        {
            name = "NewPlayer" + playerIncrement.ToString();
            //generate a random 9 digit number for nif
            nif = random.Next(100000000, 999999999);
            saldo = 100;
            ownedTickets = new List<Ticket>();
            playerIncrement++;
        }
        public Player(string name, int nif)
        {
            this.name = name;
            this.nif = nif;    
            this.saldo = 100;
            ownedTickets = new List<Ticket>();
        }

        public override string ToString()
        {
            return "Player: " + name + "\nNIF: " + nif + "\nSaldo: " + saldo;
        }



        //Gets & Sets
        public string Name { get => name; set => name = value; }
        public int Nif { get => nif; set => nif = value; }
        public decimal Saldo { get => saldo; set { if (value >= 0) this.saldo = value; } }
        public List<Ticket> OwnedTickets { get => ownedTickets; set => ownedTickets = value; }
        
        
    }
}
