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
            


        }

        private static void PrintLogo()
        {
            string logo = @"Euromilhoes";
            Console.WriteLine(logo);
        }

        private static void PrintMainMenu(Euromilhoes game)
        {
            //print todays date
            Console.WriteLine("Today is " + game.InitDate.ToString("dd/MM/yyyy") + "\n");
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
                        else Console.WriteLine("Não tem saldo suficiente para apostar");
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
                    /*int */nums = game.MatchCount(t, winningTicket, true);
                    /*int */stars = game.MatchCount(t, winningTicket, false);

                    // Para ver se as variaveis estavam a contar
                    Console.WriteLine($"Nums: {nums}\nEstrelas: {stars}");

                    if (game.CheckPrize(nums, stars))
                    {
                        p.Balance += (game.Prize * 10);
                        winner = true;
                        Console.WriteLine("Ganhou!!!");
                        break;
                    }
                    else if (nums == 5 && stars == 1)
                    {
                        Console.WriteLine($"Acertou em {nums} numeros e {stars} estrelas");
                        p.Balance += (0.90M * game.Prize);
                        break;
                    }
                    else if (nums == 5 && stars == 0)
                    {
                        
                        Console.WriteLine($"Acertou em {nums} numeros e {stars} estrelas");
                        p.Balance += (0.80M * game.Prize);
                        break;
                    }
                    else if (nums == 4 && stars == 2)
                    {
                        Console.WriteLine($"Acertou em {nums} numeros e {stars} estrelas");
                        p.Balance += (0.85M * game.Prize);
                        break;
                    }
                    else if (nums == 4 && stars == 1)
                    {
                        Console.WriteLine($"Acertou em {nums} numeros e {stars} estrelas");
                        p.Balance += (0.70M * game.Prize);
                        break;
                    }
                    else if (nums == 4 && stars == 0)
                    {
                        Console.WriteLine($"Acertou em {nums} numeros e {stars} estrelas");
                        p.Balance += (0.65M * game.Prize);
                        break;
                    }
                    else if (nums == 3 && stars == 2)
                    {
                        Console.WriteLine($"Acertou em {nums} numeros e {stars} estrelas");
                        p.Balance += (0.60M * game.Prize);
                        break;
                    }
                    else if (nums == 3 && stars == 1)
                    {
                        Console.WriteLine($"Acertou em {nums} numeros e {stars} estrelas");
                        p.Balance += (0.50M * game.Prize);
                        break;
                    }
                    else if (nums == 3 && stars == 0)
                    {
                        Console.WriteLine($"Acertou em {nums} numeros e {stars} estrelas");
                        p.Balance += (0.20M * game.Prize);
                        break;
                    }
                    else if (nums == 2 && stars == 2)
                    {
                        Console.WriteLine($"Acertou em {nums} numeros e {stars} estrelas");
                        p.Balance += (0.25M * game.Prize);
                        break;
                    }
                    else if (nums == 2 && stars == 1)
                    {
                        Console.WriteLine($"Acertou em {nums} numeros e {stars} estrelas");
                        p.Balance += (0.15M * game.Prize);
                        break;
                    }
                    else if (nums == 2 && stars == 0)
                    {
                        Console.WriteLine($"Acertou em {nums} numeros e {stars} estrelas");
                        p.Balance += (0.03M * game.Prize);

                        break;
                    }
                    else if (nums == 1 && stars == 2)
                    {
                        Console.WriteLine($"Acertou em {nums} numeros e {stars} estrelas");
                        p.Balance += (0.05M * game.Prize);
                        break;
                    }
                    else if (nums == 1 && stars == 1)
                    {
                        Console.WriteLine($"Acertou em {nums} numeros e {stars} estrelas");
                        p.Balance += (0.2M * game.Prize);
                        break;
                    }
                    else if (nums == 1 && stars == 0)
                    {
                        Console.WriteLine($"Apenas acertou {nums} numero");
                        break;
                    }
                    else if (nums == 0 && stars == 1)
                    {
                        Console.WriteLine($"Apenas acertou {stars} estrela");
                        break;
                    }
                    else if (nums == 0 && stars == 2)
                    {
                        Console.WriteLine($"Apenas acertou em {stars} estrelas.");
                        break;
                    }
                    else
                        Console.WriteLine("Não acertou nada");
                }
                if (winner)
                {
                    break;
                }
            } 
        }
    }
}