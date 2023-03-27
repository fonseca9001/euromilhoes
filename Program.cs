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
            Euromilhoes euromilhoes = new Euromilhoes();

            Player testPlayer = euromilhoes.createPlayer();
            euromilhoes.TheBigPlayerList.Add(testPlayer);
            /*euromilhoes.randomTicket(testPlayer.Ticket);
            euromilhoes.fillTicket(testPlayer.Ticket);
            euromilhoes.buyTicket(testPlayer);
            euromilhoes.randomTicket(testPlayer.Ticket);*/
           
            //print it all
            Console.WriteLine(testPlayer);
            Console.WriteLine(testPlayer.OwnedTickets);
            Console.WriteLine(euromilhoes);
            
            for (int i = 0; i < euromilhoes.TheBigPlayerList.Count; i++)
            {
                Console.WriteLine(euromilhoes.TheBigPlayerList[i]);
            }



            

            Console.ReadLine();


          
            
            
            
        }
    
        
    }
}