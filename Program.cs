using System.Numerics;
using System.Runtime.CompilerServices;

namespace Euromilhoes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Euromilhoes euromilhoes = new Euromilhoes();

            Player testPlayer = euromilhoes.createPlayer();
            Console.WriteLine(testPlayer.ToString());

        }
    
        
    }
}