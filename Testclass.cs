/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Euromilhoes
{
    internal class Testclass
    {
           
    
    }
}
*/
/*

public class Player
{
    public int NIF { get; set; }

    public bool IsValidNIF(int nif)
    {
        return nif.ToString().Length == 9;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Player player = new Player();
        int nif;
        bool isValidNIF = false;

        while (!isValidNIF)
        {
            Console.Write("NIF: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out nif) && player.IsValidNIF(nif))
            {
                player.NIF = nif;
                isValidNIF = true;
            }
            else
            {
                Console.WriteLine("Nif invalido. do again");
            }
        }

        Console.WriteLine("Player NIF: " + player.NIF);
    }
}
*/