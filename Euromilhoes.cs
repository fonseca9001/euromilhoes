using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromilhoes
{
    internal class Euromilhoes
    {
        private List<Player> theBigPlayerList = new List<Player>();

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
    }
}
