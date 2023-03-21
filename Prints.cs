using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace euromilhoes
{
    class Prints
    {
        void printLogo()
        {
            string asciiArt = @"
                ______                           _ ____
               / ____/_  ___________  ____ ___  (_) / /_  ____  ___  _____
              / __/ / / / / ___/ __ \/ __ `__ \/ / / __ \/ __ \/ _ \/ ___/
             / /___/ /_/ / /  / /_/ / / / / / / / / / / / /_/ /  __(__  )
            /_____/\__,_/_/   \____/_/ /_/ /_/_/_/_/ /_/\____/\___/____/
                 A criar excentricos todas as DateTime.Now.AddDays(8)";
            
            Console.WriteLine(asciiArt);
        }
        void printMenu()
        {
            Console.WriteLine("1 - Gerar chave");
            Console.WriteLine("2 - Verificar chave");
            Console.WriteLine("3 - Sair");
        }
        void printStatus()
        {
            Console.WriteLine("");
        }
    }
}