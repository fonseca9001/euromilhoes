using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace euromilhoes
{

    public class Ticket
    {
        HashSet<int> mainNumbers = new HashSet<int>();
        HashSet<int> luckyStars = new HashSet<int>();
        Random rnd = new Random();
        

        public Ticket()
        {
            this.MainNumbers = new HashSet<int>();
            this.LuckyStars = new HashSet<int>();
        }

        public Ticket(HashSet<int> mainNumbers, HashSet<int> luckyStars)
        {
            this.mainNumbers = mainNumbers;
            this.luckyStars = luckyStars;
        }

        public HashSet<int> MainNumbers { get => mainNumbers; set => mainNumbers = value; }
        public HashSet<int> LuckyStars { get => luckyStars; set => luckyStars = value; }

        
    }

    

}







            
    

    
        
        
    
        

        

        //return new Ticket(mainNumbers, luckyStars);

    


//    public class Ticket
//    {
//        public List<int> MainNumbers { get; set; }
//        public List<int> LuckyStars { get; set; }

//        public Ticket(List<int> mainNumbers, List<int> luckyStars)
//        {
//            MainNumbers = mainNumbers;
//            LuckyStars = luckyStars;
//        }

//        public void FillFromUserInput()
//        {
//            // Prompt the user for input
//            Console.WriteLine("Enter 5 main numbers (between 1 and 50):");
//            MainNumbers = ParseNumberListFromUserInput();
//            Console.WriteLine("Enter 2 lucky stars (between 1 and 12):");
//            LuckyStars = ParseNumberListFromUserInput();
//        }

//        private static List<int> ParseNumberListFromUserInput()
//        {
//            var input = Console.ReadLine();
//            var numbers = new List<int>();
//            foreach (var str in input.Split(' '))
//            {
//                if (int.TryParse(str, out var number))
//                {
//                    numbers.Add(number);
//                }
//            }
//            return numbers;
//        }
//    }
//}