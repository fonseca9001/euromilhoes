using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
            return "Player: " + name + "\nNIF: " + nif + "\nSaldo: " + balance;
        }

        public void printTicketList()
        {
            for (int i = 0; i < ownedTickets.Count; i++)
            {
                Console.WriteLine(ownedTickets[i].ToString());
            }
        }
        public void importJsonTicket()
        {
            //Show all files in the folder
            string[] files = Directory.GetFiles(@".\tickets\");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
            //Choose a file
            Console.WriteLine("Choose a file to import: ");
            string fileToImport = Console.ReadLine();
            //Read the file

            string json = File.ReadAllText(@".\tickets\");
            Ticket t = JsonConvert.DeserializeObject<Ticket>(json);
            //make valid
            t.SetIsValid(true);

            ownedTickets.Add(t);   
        }
        public void exportJsonTicket()
        {
            //export a ticket to a json file
            Console.WriteLine("Choose a ticket to export: ");
            //print all tickets
            for (int i = 0; i < ownedTickets.Count; i++)
            {
                Console.WriteLine(i + " - " + ownedTickets[i].ToString());
            }
            
            int ticketToExport = Convert.ToInt32(Console.ReadLine());
            string json = JsonConvert.SerializeObject(ownedTickets[ticketToExport]);
            //name file with the ticket number and stars and date
            string fileName = ownedTickets[ticketToExport].GetTicketNumbers() + "_" + ownedTickets[ticketToExport].GetTicketStars() + "_" + DateTime.Now.ToString("dd-MM-yyyy");
            File.WriteAllText(@".\tickets\" + fileName + ".json", json);

        }
        //Gets & Sets
        public string Name { get => name; set => name = value; }
        public int Nif { get => nif; set => nif = value; }
        public decimal Balance { get => balance; set { if (value >= 0) this.balance = value; } }
        public List<Ticket> OwnedTickets { get => ownedTickets; set => ownedTickets = value; }
           
    }
}
