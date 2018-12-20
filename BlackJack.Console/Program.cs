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
            //int i = 0;
            //int p = 2;
            //int d=0;
            ////int[] c = new int[] { 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            //int[] c = new int[] { 1, 10, 10, 10, 8 };
            ////int n = c.Length;
            ////foreach (var d in Enumerable.Range(2, n - i - p + 1 - 2))
            //for (int z = i+p;z<4; z++)
            //{

            //    d += c[z];

            //}
            //System.Console.WriteLine(d);

            System.Console.ReadKey(); 
              
        }
    }
}
