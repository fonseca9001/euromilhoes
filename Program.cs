
using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace euromilhoes
{
    internal class Program
    {
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

        static void Main(string[] args)
        {
            Random rnd = new Random();
            int num = 0, star;
            ArrayList checkNum = new ArrayList();
            ArrayList winKeys = new ArrayList();
            ArrayList winStars = new ArrayList();

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
            checkNif();

            float aposta = 2,5;
            float saldo = 100;
            int qtd;
            Console.WriteLine("Quantas chaves quer jogar? ");
            do
            {
                
                qtd = int.Parse(Console.ReadLine());
                saldo -= qtd * aposta;
                if (aposta > saldo)
                    Console.WriteLine("Não tem saldo suficiente! Tente outra vez");
                else
                    break;
            } while (saldo > aposta);
        }
    }
}