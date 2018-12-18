using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack;

namespace BlackJack.Console
{
    class Program 
    {  
        static void Main(string[] args)     
        { 
           // Optimal game = new Optimal(52);
            var opt = new OldOptimal();

           // System.Console.WriteLine("Максимальный выигрыш: " + game.MaxReward);
            System.Console.WriteLine("Количество побед: " + opt.GetWinsCount());
            // System.Console.WriteLine("Пожилая стратегия: " + game.Way);

            System.Console.ReadKey(); 
              
        }
    }
}
