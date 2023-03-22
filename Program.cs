
using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace euromilhoes
{
    internal class Program
    {
        //   Verificar se o NIF é válido
        static void checkNif()
        {
            int nif;
            bool isValidInput = false;
            string input;

            ArrayList nifs = new ArrayList();

            do
            {
                Console.WriteLine("NIF: ");
                input = Console.ReadLine();

                if (input.Length != 9)
                {
                    Console.WriteLine("O NIF tem de ter 9 números.");
                }
                else
                {
                    if (int.TryParse(input, out nif))
                    {
                        isValidInput = true;
                        nifs.Add(nif);
                    }
                    else
                    {
                        Console.WriteLine("O NIF só pode ter números.");
                    }
                }

            } while (input.Length != 9 || !isValidInput);

            foreach (int c in nifs)
            {
                Console.WriteLine(c);
            }
        }

        ///   Gerar os números da chave vencedora automaticamente
        static void genTicket()
        {
            Random rnd = new Random();
            Ticket t1 = new Ticket();

            while (t1.MainNumbers.Count < 5)
            {
                var number = rnd.Next(1, 51);
                if (!t1.MainNumbers.Contains(number))
                {
                    t1.MainNumbers.Add(number);
                }
            }

            foreach (int c in t1.MainNumbers)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine("\n");

            while (t1.LuckyStars.Count < 2)
            {
                var number = rnd.Next(1, 13);
                if (!t1.LuckyStars.Contains(number))
                {
                    t1.LuckyStars.Add(number);
                }
            }

            foreach (int c in t1.LuckyStars)
            {
                Console.WriteLine(c);
            }
        }

        
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int num = 0, star;
            ArrayList checkNum = new ArrayList();
            ArrayList winKeys = new ArrayList();
            ArrayList winStars = new ArrayList();

            //Prints.printLogo();
            //   Gerar os números
            for (int i = 0; i < 5; i++)
            {
                checkNum.Add(rnd.Next(1, 50));
                num = rnd.Next(1, 50);
                if (checkNum.Contains(num) == false)
                {
                    checkNum.Add((int)num);
                    winKeys.Add(num);
                }
                else
                {
                    i--;
                }
            }

            foreach (int i in winKeys)
            {
                Console.WriteLine(i);
            }

            checkNum.Clear();

            //   Gerar as estrelas
            for (int i = 0; i < 2; i++)
            {
                star = rnd.Next(1, 12);
                if (checkNum.Contains(star) == false)
                {
                    checkNum.Add((int)star);
                    winStars.Add(star);
                }
                else if (checkNum.Contains(star) == true)
                {
                    i--;
                }
            }

            checkNum.Clear();
            Console.WriteLine("\n");

            foreach (int i in winStars)
            {
                Console.WriteLine(i);
            }
            
            // Introduzir os números
            ArrayList chosenKeys = new ArrayList();

            for (int i = 0; i < 5; i++)
            {

                //Define a regex pattern to match 9 digits from 0 - 9
                string pattern = @"^\d{1}$";
                string input;
                //Prompt the user to enter a 9 - digit number
                do
                {
                    Console.WriteLine($"Digite o {i + 1}º número:");
                    input = Console.ReadLine();
                    //Check if the input matches the pattern
                    if (!Regex.IsMatch(input, pattern))
                    {
                        Console.WriteLine("Introduza apenas números. ");
                    }
                    else if (checkNum.Contains(input) == true)
                    {
                        Console.WriteLine("Número repetido. Introduza outro.");

                    }
                    else
                    {
                        chosenKeys.Add(input);
                    }
                } while (!Regex.IsMatch(input, pattern) || checkNum.Contains(input) == true);
                checkNum.Add(input);
            }

            checkNum.Clear();


            //Introduzir as estrelas
            ArrayList chosenStars = new ArrayList();

            for (int i = 0; i < 2; i++)
            {

                //Define a regex pattern to match 9 digits from 0 - 9
                string pattern = @"^\d{1}$";
                string input;
                //Prompt the user to enter a 9 - digit number
                do
                {
                    Console.WriteLine($"Digite a {i + 1}ª estrela:");
                    input = Console.ReadLine();
                    //Check if the input matches the pattern
                    if (!Regex.IsMatch(input, pattern))
                    {
                        Console.WriteLine("Introduza apenas números. ");
                    }
                    else if (checkNum.Contains(input) == true)
                    {
                        Console.WriteLine("Estrela repetida. Introduza outra.");

                    }
                    else
                    {
                        chosenStars.Add(input);
                    }
                } while (!Regex.IsMatch(input, pattern) || checkNum.Contains(input) == true);
                checkNum.Add(input);
            }


            genTicket();


            checkNif();

            





            float aposta = 2.5f; //o ponto decimal nao pode ser virgula, tambem tem de declarar como literal
            float saldo = 100;
            int qtd, choice;
            
            Console.WriteLine("Quantas chaves quer jogar? ");
            do
            {
                
                qtd = int.Parse(Console.ReadLine());
                saldo -= qtd * aposta;
                if (aposta > saldo)
                    Console.WriteLine("Não tem saldo suficiente! Tente outra vez");
                else
                {
                    
                    break;
                }
                    

                    
                    
            } while (saldo > aposta);

            
        }
    }
}