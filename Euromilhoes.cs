using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Euromilhoes
{
    internal class Euromilhoes
    {

        private List<Player> theBigPlayerList;
        private decimal prize;
        private int numApostas;

        private DateTime initDate = DateTime.Now.Date;

        internal List<Player> TheBigPlayerList { get => theBigPlayerList; set => theBigPlayerList = value; }
        public decimal Prize { get => prize; set => prize = value; }
        public int NumApostas { get => numApostas; set => numApostas = value; }
        public DateTime InitDate { get => initDate; set => initDate = value; }


        public Euromilhoes()
        {
            this.theBigPlayerList = new List<Player>();
            this.prize = 0;
            this.numApostas = 0;
        }

        //Ticket Stuff
        public Ticket randomTicket()
        {
            HashSet<int> nums = new HashSet<int>();
            HashSet<int> stars = new HashSet<int>();
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                int num = random.Next(1, 51);
                nums.Add(num);
            }
            for (int i = 0; i < 2; i++)
            {
                int star = random.Next(1, 13);
                stars.Add(star);
            }
            return new Ticket(nums, stars);
        }

        private void fillTicket(Ticket t)
        {
            HashSet<int> nums = new HashSet<int>();
            HashSet<int> stars = new HashSet<int>();
            Console.WriteLine("Introduza os números do boletim: \n");
            AddToList(5, nums);
            Console.WriteLine("Introduza as estrelas do boletim: \n");
            AddToList(2, stars);
        }


        public void buyTicket(Player p, bool isRandom) //isRandom = true -> random ticket, isRandom = false -> fill ticket
        {
            Ticket newTicket = new Ticket();
            p.Balance -= 2.5M;
            if (isRandom)
            {
                newTicket = randomTicket();
            }
            else
            {
                fillTicket(newTicket);
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
            for(int i = 0; i < numApostas; i++)
            {
                this.prize += + 2.5M;
            }

            this.prize *= 10;
        }

        public void exportPlayerList()
        {
            string json = JsonConvert.SerializeObject(theBigPlayerList, Formatting.Indented);
            File.WriteAllText("playerlist.json", json);
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

        private void AddToList(int length, HashSet<int> list)
        {
            int minValue = 1;
            int maxValue = length == 5 ? 50 : 12;
    
            for(int i = 1; i <= length; i++)
            {
                Console.Write("Enter a number: ");
                int input = int.Parse(Console.ReadLine());

                if (input >= minValue && input <= maxValue && !list.Contains(input) ) 
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
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
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
            if (numbersMatch == 5 && starsMatch == 2) {return true;}
            else {return false;}
        }
        private void Continue()
        {
            Console.WriteLine("Deseja continuar do ultimo jogo? (S/N)");
            string input = Console.ReadLine().ToUpper();
            if (input == "S")
            { 
                //do all necessary imports
            }
            else if (input == "N")
            {
                //just start a new game
            }
            else
            {
                Console.WriteLine("Wrong input, try again (S/N)");
            }
        }
    }
}
