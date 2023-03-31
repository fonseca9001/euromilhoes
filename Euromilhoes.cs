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



        int[] winNums = new int[5];
        int[] winStars = new int[2];
        int[] Unums = new int[5];
        int[] Ustars = new int[2];


        internal List<Player> TheBigPlayerList { get => theBigPlayerList; set => theBigPlayerList = value; }
        public decimal Prize { get => prize; set => prize = value; }
        public int NumApostas { get => numApostas; set => numApostas = value; }
        public int[] WinNums { get => winNums; set => winNums = value; }
        public int[] WinStars { get => winStars; set => winStars = value; }
        public int[] Unums1 { get => Unums; set => Unums = value; }
        public int[] Ustars1 { get => Ustars; set => Ustars = value; }

        public Euromilhoes()
        {
            this.theBigPlayerList = new List<Player>();
            this.prize = 0;
            this.numApostas = 0;
        }


        public void randomTicket()
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
            // return new Ticket(nums, stars);

            ////////////////////////////////////
            ///
            winNums = nums.ToArray();
            winStars = stars.ToArray();


        }

        public void fillTicket(Ticket t)
        {
            HashSet<int> nums = new HashSet<int>();
            HashSet<int> stars = new HashSet<int>();
            Console.WriteLine("Introduza os números do boletim: \n");
            AddToList(5, nums);
            Console.WriteLine("Introduza as estrelas do boletim: \n");
            AddToList(2, stars);

            Unums = nums.ToArray();
            Ustars = stars.ToArray();
        }


        public void buyTicket(Player p)
        {
            Ticket newTicket = new Ticket();
            HashSet<int> nums = new HashSet<int>();
            HashSet<int> stars = new HashSet<int>();
            p.Saldo -= 2.5M;

            Console.WriteLine("Introduza os números do boletim: \n");
            AddToList(5, nums);
            Console.WriteLine("Introduza as estrelas do boletim: \n");
            AddToList(2, stars);


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


    }
}
