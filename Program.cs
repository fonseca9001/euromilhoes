using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Collections;

namespace Euromilhoes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Euromilhoes euromilhoes = new Euromilhoes();

            Player testPlayer = euromilhoes.createPlayer();
            //euromilhoes.TheBigPlayerList.Add(testPlayer);

            euromilhoes.randomTicket();

            //Para ver os números random para comparar
            Console.WriteLine("\n");
            foreach (int c in euromilhoes.WinNums)
            {
                Console.WriteLine(c);
            }
            foreach (int c in euromilhoes.WinStars)
            {
                Console.WriteLine(c);
            }

            Ticket aTicket = new Ticket();
            euromilhoes.fillTicket(aTicket);
            /*euromilhoes.randomTicket(testPlayer.Ticket);
            euromilhoes.fillTicket(testPlayer.Ticket);
            euromilhoes.buyTicket(testPlayer);
            euromilhoes.randomTicket(testPlayer.Ticket);*/

            //print it all
            Console.WriteLine(testPlayer);
            testPlayer.printTicketList();
            Console.WriteLine(euromilhoes);

            //for (int i = 0; i < euromilhoes.TheBigPlayerList.Count; i++)
            //{
            //    Console.WriteLine(euromilhoes.TheBigPlayerList[i]);
            //}

            Console.WriteLine("Generate ticket:");


            //Contar os números e estrelas iguais aos do random de nums e estrelas
            int winNumsCount = 0, winStarsCount = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (euromilhoes.Unums1[i] == euromilhoes.WinNums[j])
                    {
                        winNumsCount++;
                    }
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (euromilhoes.Ustars1[i] == euromilhoes.WinStars[j])
                    {
                        winStarsCount++;
                    }
                }
            }

            Console.WriteLine(winNumsCount);
            Console.WriteLine(winStarsCount);



            Console.ReadLine();






        }


    }
}