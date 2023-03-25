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
            Player testPlayer2 = euromilhoes.createPlayer();
            //Console.WriteLine(testPlayer.ToString());
            
            //Print bigplayerlist
            foreach (Player player in euromilhoes.theBigPlayerList)
            {
                Console.WriteLine(player.ToString());
            }
            //export playerlist
            euromilhoes.exportPlayerList();
            
        }
    
        
    }
}