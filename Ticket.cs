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
        private List<HashSet<int>> ticketNumbers;
        private List<HashSet<int>> ticketStars;
        private List<HashSet<int>> winningTicketNumbers;
        private List<HashSet<int>> winningTicketStars;
        private int ticketSerial;
        private static int ticketIncrement = 1;
        private Random random = new Random();

        //Constructors

        public Ticket()
        {
            ticketNumbers = new List<HashSet<int>>();
            ticketStars = new List<HashSet<int>>();
            winningTicketNumbers = new List<HashSet<int>>(); // criado pelo pedro
            winningTicketStars = new List<HashSet<int>>(); // criado pelo pedro
            ticketSerial = ticketIncrement;
            ticketIncrement++;
            ticketNumbers.Add(new HashSet<int>());
            ticketStars.Add(new HashSet<int>());
            GenerateRandomNumbers(); //o ticket é criado com 5 números e 2 estrelas aleatórios
        }

        public Ticket(List<HashSet<int>> ticketNumbers, List<HashSet<int>> ticketStars, List<HashSet<int>> winningTicketNumbers, List<HashSet<int>> winningTicketStars)
        {
            this.ticketNumbers = ticketNumbers;
            this.ticketStars = ticketStars;
            this.winningTicketNumbers = winningTicketNumbers;
            this.winningTicketStars = winningTicketStars;
            ticketSerial = ticketIncrement;
            ticketIncrement++;
        }

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

        //   Para gerar um winningTicket
        public void generateWinningTicket()
        {
            var winningNumbers = new HashSet<int>();
            while (winningNumbers.Count < 5)
            {
                int number = random.Next(1, 51);
                winningNumbers.Add(number);
            }
            winningTicketNumbers[0].UnionWith(winningNumbers);

            var winningStars = new HashSet<int>();
            while (winningStars.Count < 2)
            {
                int star = random.Next(1, 13);
                winningStars.Add(star);
            }
            winningTicketStars[0].UnionWith(winningStars);
        }

        //   Automaticamente
        public void GenerateRandomNumbers()
        {

            ticketNumbers[0].Clear();
            ticketStars[0].Clear();

            var numbers = new HashSet<int>();
            while (numbers.Count < 5)
            {
                int number = random.Next(1, 51);
                numbers.Add(number);
            }
            ticketNumbers[0].UnionWith(numbers);

            var stars = new HashSet<int>();
            while (stars.Count < 2)
            {
                int star = random.Next(1, 13);
                stars.Add(star);
            }
            ticketStars[0].UnionWith(stars);
        }

        //   Manualmente
        public void setNums()
        {
            ticketNumbers[0].Clear();

            var numbers = new HashSet<int>();
            while (numbers.Count < 5)
            {
                Console.WriteLine($"Digite o {numbers.Count + 1}º número: ");
                int number = int.Parse(Console.ReadLine());
                if (numbers.Contains(number))
                    Console.WriteLine("Número repetido, introduza outro número.");
                else
                    numbers.Add(number);

            }
            ticketNumbers[0].UnionWith(numbers);
        }

        public void setStars()
        {
            ticketStars[0].Clear();

            var stars = new HashSet<int>();
            while (stars.Count < 2)
            {
                Console.WriteLine($"Digite a {stars.Count + 1}ª estrela: ");
                int star = int.Parse(Console.ReadLine());
                if (stars.Contains(star))
                    Console.WriteLine("Estrela repetida, introduza outra estrela.");
                else
                    stars.Add(star);
            }
            ticketStars[0].UnionWith(stars);
        }

        //   Isto seria para checkar se os números entre o user e o winning ticket eram iguais, mas dá um erro na parte da comparação (metam um botãozinho no print de debug e façam o debug para verem o erro)
        //   Adicionando um watch no winningTicketNums ou **stars, o que mostra é que essa variável não contém nada, as you will see for yourselves
        //   idk how to fix this shit, mas se um de vocês resolver, já estaremos bem encaminhados imo
        public ArrayList checkIfWon()
        {
            int equalNums = 0, equalStars = 0;
            ArrayList numStarCount = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (ticketNumbers[i] == winningTicketNumbers[j])
                    {
                        equalNums++;
                    }
                }
            }
            numStarCount.Add(equalNums);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (ticketStars[i] == winningTicketStars[j])
                    {
                        equalStars++;
                    }
                }
            }
            numStarCount.Add(equalStars);
            Console.WriteLine("DEBUG");
            return numStarCount;
        }

        public List<HashSet<int>> getNums()
        {
            return ticketNumbers;
        }

        public List<HashSet<int>> getStars()
        {
            return ticketStars;
        }

        //Gets & Sets

        public List<HashSet<int>> TicketNumbers { get => ticketNumbers; set => ticketNumbers = value; }
        public List<HashSet<int>> TicketStars { get => ticketStars; set => ticketStars = value; }
        public int TicketSerial { get => ticketSerial; set => ticketSerial = value; }
        public List<HashSet<int>> WinningTicketNumbers { get => winningTicketNumbers; set => winningTicketNumbers = value; }
        public List<HashSet<int>> WinningTicketStars { get => winningTicketStars; set => winningTicketStars = value; }
    }
}
