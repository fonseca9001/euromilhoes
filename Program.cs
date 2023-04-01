using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Euromilhoes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Euromilhoes game = new Euromilhoes();
            Player p = game.createPlayer();
            game.buyTicket(p, true);
            game.buyTicket(p, true);
            game.buyTicket(p, false);
            p.exportJsonTicket();
            p.exportJsonTicket();

        }

        private static void PrintLogo()
        {
            string logo = @"Euromilhoes";
            Console.WriteLine(logo);
        }

        private static void PrintMainMenu()
        {
            Console.WriteLine("1 - Apostar");
            Console.WriteLine("2 - Importar");
            Console.WriteLine("3 - Procurar");
            Console.WriteLine("4 - Proximo Dia");
            Console.WriteLine("5 - Sorteio\n");
            Console.WriteLine("0 - Sair");
        }

        private static void PrintImportMenu()
        {
            Console.WriteLine("1 - Importar chave");
            Console.WriteLine("2 - Exportar chave");
        }

        private static void PrintSearchMenu()
        {
            Console.WriteLine("1 - Procurar por data");
            Console.WriteLine("2 - Procurar por nif");
            Console.WriteLine("3 - Procurar por sorteio");
        }

        private static void Sorteio(List<Player> pl, Euromilhoes game)
        {
            Ticket winningTicket = game.randomTicket();
            bool winner = false;
            game.buildPrize();
            foreach (Player p in pl)
            {
                foreach (Ticket t in p.OwnedTickets)
                {
                    int nums = game.MatchCount(t, winningTicket, true);
                    int stars = game.MatchCount(t, winningTicket, false);
                    if (game.CheckPrize(nums, stars))
                    {
                        p.Balance += game.Prize;
                        winner = true;
                        break;
                    }
                }
                if (winner)
                {
                    break;
                }
            }
        }
    }
}