using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Euromilhoes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            Euromilhoes game = new Euromilhoes();
            Player p = game.createPlayer();

            PrintLogo();
            menuStuff(game, p, quit);

            System.Environment.Exit(0);
        }

        private static void PrintLogo()
        {
            string logo = @"Euromilhoes";
            Console.WriteLine(logo);
        }

        private static void PrintMainMenu(Euromilhoes game)
        {
            //print todays date
            Console.WriteLine("Hoje é dia " + game.InitDate.ToString("dd/MM/yyyy") + "\n");
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

        private static void menuStuff(Euromilhoes game, Player p, bool quit)
        {
            while (!quit)
            {
                
                Console.WriteLine("\n" + p.ToString() + "\n");
                PrintMainMenu(game);
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        if (p.Balance >= 2.5M) Aposta(p, game);
                        else Console.WriteLine("Não tem saldo suficiente para apostar.\n Por favor pressione Alt+f4.");
                        break;
                    case 2:
                        Console.WriteLine("Under construction...");
                        break;
                    case 3:
                        Console.WriteLine("Under construction...");
                        break;
                    case 4:
                        game.PassDay();
                        break;
                    case 5:
                        if (game.IsItFridayYet())
                        {
                            Sorteio(game.TheBigPlayerList, game);
                        }
                        else
                        {
                            Console.WriteLine("O Sorteio so acontece às sextas-feiras");
                        }
                        break;
                    case 0:
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Opcao invalida");
                        break;
                }
            }
        }

        private static void Aposta(Player p, Euromilhoes game)
        {
            Ticket t = new Ticket();
            Console.WriteLine("1 - Gerar boletim aleatorio\n 2 - Introduzir boletim manualmente\n 3- Importar chaves");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    game.buyTicket(p, 1);
                    break;
                case 2:
                    game.buyTicket(p, 2);
                    break;
                case 3:
                    game.buyTicket(p, 3);
                    break;
                default:
                    Console.WriteLine("Opcao invalida");
                    break;
            }

        }

        private static void Sorteio(List<Player> pl, Euromilhoes game)
        {
            Ticket winningTicket = new Ticket();
            game.randomTicket(winningTicket);
            bool winner = false;
            game.buildPrize();

            int nums = 0;
            int stars = 0;

            foreach (Player p in pl)
            {
                Console.Clear();
                foreach (Ticket t in p.OwnedTickets)
                {
                    nums = game.MatchCount(t, winningTicket, true);
                    stars = game.MatchCount(t, winningTicket, false);
                    game.CheckPrize(nums, stars, p, winner);
                    if (winner) break;  
                }
                if (winner) break;
                
            }
                Console.WriteLine("Prima qualquer tecla para continuar.");
                Console.ReadKey(); 
        }
    }
}