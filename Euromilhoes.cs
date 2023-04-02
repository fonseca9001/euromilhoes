using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace Euromilhoes
{
    internal class Euromilhoes
    {

        private List<Player> theBigPlayerList;
        private decimal prize;
        private int numApostas;
        //private bool maxApostas = false;
        private DateTime initDate = DateTime.Now.Date;


        internal List<Player> TheBigPlayerList { get => theBigPlayerList; set => theBigPlayerList = value; }
        public decimal Prize { get => prize; set => prize = value; }
        public int NumApostas { get => numApostas; set => numApostas = value; }
        public DateTime InitDate { get => initDate; set => initDate = value; }
        //public bool MaxApostas { get => maxApostas; set => maxApostas = value; }


        public Euromilhoes()
        {
            this.theBigPlayerList = new List<Player>();
            this.prize = 0;
            this.numApostas = 0;
        }

        //Ticket Stuff

        public void TicketWriter(Ticket t) // "TicketWriter" should start with a capital letter
        {
            if (!Directory.Exists("./tickets"))
            {
                Directory.CreateDirectory("./tickets");
            }
            string ticketFileName = $"./tickets/{t.GetTicketSerial()}.txt"; // variable name should match the one used below
            using (StreamWriter writer = new StreamWriter(ticketFileName))
            {
                writer.WriteLine(string.Join(",", t.GetTicketNumbers())); // "t.nums" should be replaced with "t.GetTicketNumbers()"
                writer.WriteLine(string.Join(",", t.GetTicketStars())); // "t.stars" should be replaced with "t.GetTicketStars()"
            }
        }

        public void TicketReader(Ticket t) // "TicketReader" should start with a capital letter
        {
            //list tickets in directory
            Console.WriteLine("Boletins disponiveis: \n");
            string[] tickets = Directory.GetFiles("./tickets");
            foreach (string ticket in tickets)
            {
                Console.WriteLine(ticket);
            }
            Console.WriteLine("Introduza o número de serie do boletim: \n");
            string ticketFileName = $"./tickets/{Console.ReadLine()}.txt";
            using (StreamReader reader = new StreamReader(ticketFileName))
            {
                string line = reader.ReadLine();
                string[] nums = line.Split(',');
                HashSet<int> ticketNums = new HashSet<int>();
                foreach (string num in nums)
                {
                    ticketNums.Add(int.Parse(num));
                }
                t.SetTicketNumbers(ticketNums);
                line = reader.ReadLine();
                string[] stars = line.Split(',');
                HashSet<int> ticketStars = new HashSet<int>();
                foreach (string star in stars)
                {
                    ticketStars.Add(int.Parse(star));
                }
                t.SetTicketStars(ticketStars);
            }

        }
        public void randomTicket(Ticket t) // "RandomTicket" should start with a capital letter
        {
            HashSet<int> nums = new HashSet<int>();
            HashSet<int> stars = new HashSet<int>();
            Random random = new Random();
            while (nums.Count < 5) // fixed the loop to ensure that there are always 5 numbers in the set
            {
                int num = random.Next(1, 51);
                nums.Add(num);
            }
            while (stars.Count < 2) // fixed the loop to ensure that there are always 2 stars in the set
            {
                int star = random.Next(1, 13);
                stars.Add(star);
            }
            t.SetTicketNumbers(nums);
            t.SetTicketStars(stars);

            TicketWriter(t); // fixed the method name to match the corrected name above
        }


        private void fillTicket(Ticket t)
        {
            HashSet<int> nums = new HashSet<int>();
            HashSet<int> stars = new HashSet<int>();
            Console.WriteLine("Introduza os números do boletim: \n");
            AddToList(5, nums);
            Console.WriteLine("Introduza as estrelas do boletim: \n");
            AddToList(2, stars);
            t.SetTicketNumbers(nums);
            t.SetTicketStars(stars);

            TicketWriter(t);

            // Write nums and stars to file create folder if it doesn't exist

        }


        private void AddToList(int length, HashSet<int> list)
        {
            int minValue = 1;
            int maxValue = length == 5 ? 50 : 12;

            for (int i = 1; i <= length; i++)
            {
                Console.Write("Enter a number: ");
                int input = int.Parse(Console.ReadLine());

                if (input >= minValue && input <= maxValue && !list.Contains(input))
                {
                    list.Add(input);
                }
                else
                {
                    Console.WriteLine("Wrong or repeated numberino!");
                    i--;
                }
            }
        }

        public void buyTicket(Player p, int ticketType) //isRandom = true -> random ticket, isRandom = false -> fill ticket
        {
            Ticket newTicket = new Ticket();
            p.Balance -= 2.5M;
            switch (ticketType)
            {
                case 1:
                    randomTicket(newTicket);
                    break;     
                case 2:
                    fillTicket(newTicket);
                    break;
                case 3:
                    TicketReader(newTicket);
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
            p.OwnedTickets.Add(newTicket);
            this.numApostas += 1;
        }



        public void resetPrize()
        {
            this.prize = 0;
            this.numApostas = 0;
        }

        public void buildPrize()
        {
            for (int i = 0; i < numApostas; i++)
            {
                this.prize += +2.5M;
            }

            //this.prize *= 10;
        }

        public void exportBigPlayerList()
        {
            string path = @".\BigPlayerList.txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                for (int i = 0; i < this.theBigPlayerList.Count; i++)
                {
                    sw.WriteLine(this.theBigPlayerList[i].ToString());
                }
            }
        }

        public Player createPlayer()
        {
            string name = "";
            int nif = 0;
            bool validInput = false;

            Console.WriteLine("Introduza o nome do jogador: ");
            name = Console.ReadLine();
            while (!validInput)
            {
                Console.WriteLine("Introduza o NIF do jogador: ");
                string input = Console.ReadLine();
                if (input.Length == 9 && int.TryParse(input, out nif))
                {
                    nif = int.Parse(input);
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("This shit not right my diggah");
                }
            }
            Player newPlayer = new Player(name, nif);
            this.theBigPlayerList.Add(newPlayer);
            return newPlayer;
        }


        public int MatchCount(Ticket t, Ticket winT, bool isNumber) //pass nums with true, stars with false
        {
            HashSet<int> commons;

            if (isNumber)
            {
                commons = new HashSet<int>(t.GetTicketNumbers());
                commons.IntersectWith(winT.GetTicketNumbers());
                return commons.Count;
            }
            else
            {
                commons = new HashSet<int>(t.GetTicketStars());
                commons.IntersectWith(winT.GetTicketStars());
                return commons.Count;
            }
        }


        public bool IsItFridayYet()
        {
            if (this.initDate.DayOfWeek == DayOfWeek.Friday)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PassDay()
        {
            this.InitDate = this.InitDate.AddDays(1);
        }

        public bool CheckPrize(int numbersMatch, int starsMatch)
        {
            if (numbersMatch == 5 && starsMatch == 2) { return true; }
            else { return false; }
        }


        public Player ImportPlayer()
        {
            Console.WriteLine("Introduza o nome do jogador para importar: ");
            string pname = Console.ReadLine();
            //find player in file
            string path = @".\BigPlayerList.txt";
            string[] lines = File.ReadAllLines(path);
            //import player from file
            Player player = new Player();


            return player;
        }

        public void Continue()
        {
            while (true)
            {
                Console.Write("Import player? (S/N): ");
                string input = Console.ReadLine().ToUpper();
                if (input == "S")
                {
                    ImportPlayer();
                    break;
                }
                else if (input == "N")
                {
                    Console.WriteLine("Continuing without importing player...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                }
            }
        }

    }
}
