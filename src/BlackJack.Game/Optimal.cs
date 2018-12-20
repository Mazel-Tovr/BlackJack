using System;
using System.Collections.Generic;
using System.Linq;


namespace BlackJack
{
    /// <summary>
    /// Оптимальная игра: максимизация выигрыша игрока при известной колоде 
    /// </summary>
    public class Optimal : CardDeck
    {




        /// <summary>
        /// Замешивание колоды с определенным количеством карт
        /// </summary> 
        /// <param name="cardCount">Количество карт в игре</param>
        public Optimal(int cardCount)
        {
            deck.Shuffle(cardCount);
        }



        /// <summary>
        /// Максимальный выигрыш игрока
        /// </summary>
        public int MaxReward
        {
            get
            {
                return BJ(0);
            }
        }

        /// <summary>
        /// Стратегия игрока  
        /// </summary>
        public string Way
        {
            get
            {
                return StrategyBJ(0);
            }
            private set { }
        }

        private CardDeck deck = new CardDeck();
        private List<int> options = new List<int>() { 0 };
        private List<int> BJList = new List<int>();

        private double player = 0;
        private double dealer = 0;


        //private int cmp(double player1, double player2)
        //{
        //    if ((player2 <= 21 && player2 > player1) || player1 > 21)
        //    {

        //        return -1; //победа дилера  
        //    }
        //    if ((player1 <= 21 && player1 > player2) || player2 > 21)
        //    {

        //        return 1; //победа игрока  
        //    }
        //    return 0; //ничья
        //}


        private int cmp(double a, double b)
        {
            double var1 = 0;
            double var2 = 0;

            if (a > b) var1 = 1;
            if (a < b) var2 = 1;

            return Convert.ToInt32(var1 - var2);
        }

        private void ClearScopes()
        {
            player = 0;
            dealer = 0;
        }



        private int BJ(int i)
        {
            if (BJList.Contains(i)) return BJList[i];
            else
            {


                int n = deck.CardCount();

                if (n - i < 4)
                {
                    return 0;
                }
                for (var p = 2; p < n - i; p++)  //foreach (var p in Enumerable.Range(2, n - i - 2))
                {
                    player = deck.PickCard(i).GetValue() + deck.PickCard(i + 2).GetValue();

                    if (p != 2)
                    {
                        for (int j = 4 + i; j <= i + p + 2 && j < n - i; j++)
                        {
                            player += deck.PickCard(i + j).GetValue();
                        }
                    }
                    if (player > 21)
                    {
                        options.Add(-1 + BJ(i + p + 2));
                        break;
                    }
                    dealer = 0;
                    int d1 = 0;
                    for (var d = 2; d <= n - i - p + 1; d++)
                    {
                        d1 = d;
                        dealer = deck.PickCard(i + 1).GetValue() + deck.PickCard(i + 3).GetValue();

                        if (d != 2)
                        {
                            for (int j = i + p + 2; j <= i + p + d && j < n - i; j++)
                            {
                                dealer += deck.PickCard(i + j).GetValue();
                            }
                        }
                        if (dealer >= 17)
                        {
                            break;
                        }
                    }
                    if (dealer < 17 && i + p + d1 >= n)
                    {
                        dealer = 21;
                    }
                    if (dealer > 21)
                    {
                        dealer = 0;
                    }
                    dealer += 0.5;
                    options.Add(cmp(player, dealer) + BJ(i + p + d1));
                }

                var max = options.Max();
                BJList.Add(max);
                return max;
            }
        }
        #region
        private string StrategyBJ(int i)
        {
            ClearScopes();

            int n = deck.CardCount();

            if (n - i < 4)
            {
                return "";
            }
            for (var p = 2; p < n - i; p++)
            {
                player = deck.PickCard(i).GetValue() + deck.PickCard(i + 2).GetValue();
                if (p != 2)
                {
                    for (int j = 4; j <= p + 2 && j < n - i; j++)
                    {
                        player += deck.PickCard(i + j).GetValue();
                        Way += "H";
                    };
                }
                if (player > 21)
                {
                    StrategyBJ(i + p + 2);
                    break;
                }
                dealer = 0;
                int d1 = 0;
                Way += "D";
                for (var d = 2; d <= n - i - p; d++)
                {
                    d1 = d;
                    dealer = deck.PickCard(i + 1).GetValue() + deck.PickCard(i + 3).GetValue();

                    if (d != 2)
                    {
                        for (int j = p + 2; j <= p + d && j < n - i; j++)
                        {
                            dealer += deck.PickCard(i + j).GetValue();
                        }
                    }
                    if (dealer >= 17)
                    {
                        break;
                    }
                }
                if (dealer < 17 && i + p + d1 >= n)
                {
                    dealer = 21;
                }
                if (dealer > 21)
                {
                    dealer = 0;
                }

                StrategyBJ(i + p + d1);
            }
            return Way;
        }
        #endregion
    }
    /// <summary>
    /// OLD_NA_MESTE
    /// </summary>
    
    public class OldOptimal
    {
        //public List<int> c = new List<int>() { 10, 7, 4, 2, 7, 6 }; //true 


        //public  List<int> c;
        // public List<int> c = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
        public List<int> c = new List<int>() { 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        //public List<int> c = new List<int>() { 10,10,10,10,8};

        // public List<int> c = new List<int>(){ 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };

        List<int> options = new List<int>() { 0 };

        public string way = "";

        private List<int> BJList = new List<int>();



        private double player = 0;
        private double dealer = 0;
       

        //private int cmp(double player1, double player2)
        //{
        //    if ((player2 <= 21 && player2 > player1) || player1 > 21)
        //    {
        //        dealer_wins++;

        //        return -1; //победа дилера  
        //    }
        //    if ((player1 <= 21 && player1 > player2) || player2 > 21)
        //    {
        //        player_wins++;
        //        return 1; //победа игрока  
        //    }
        //    draws++;
        //    return 0; //ничья
        //}

        private int cmp(double a, double b)
        {
            double var1 = 0;
            double var2 = 0;

            if (a > b) var1 = 1;

            if (a < b) var2 = 1;
            
            return Convert.ToInt32(var1 - var2);
        }
        


        private int BJ(int i)
        {
            if (BJList.Contains(i)) return BJList[i];

            int n = c.Count;

            if (n - i < 4)
            {
                Console.WriteLine("No Enough Cards!");
                return 0;
            }
            int p1=0;
            //for (var p = 2; p < n - i; p++)
            foreach (var p in Enumerable.Range(2,n-i-2)) 
            {

                
                p1 = p;
                player = c[i] + c[i + 2] ; //+player += c[Enumerable.Range(i + 4, i + p + 2).Sum()];

                if (p != 2)
                {

                    for (int z = i + 4, x = i + p + 2; x >= z && z < n - 1; z++)
                    {
                        player += c[z];
                        p1 += 1;
                    }
                }
                    //for (int j = 4 + i; j <= i + p + 2 && j < n - i; j++)
                    //{
                    //    player += c[i + j];
                    //}
                    
                
                Console.WriteLine("Player = " + player);

                if (player > 21)
                {
                    Console.WriteLine("Player Bust"); 
                    options.Add(-1 + BJ(i + p + 2));
                    
                    break;
                }
                dealer = 0;
                int d1 = 0;
                //for (var d = 2; d <= n - i - p + 1; d++)
                foreach (var d in Enumerable.Range(2, n - i - p + 1-2))
                {

                    d1 = d;

                    dealer = c[i + 1] + c[i + 3];//+sum(c[i+p+2:i+p+d])


                    if (d != 2)
                    {

                        for (int z = i + p + 2, x = i + p + d; x >= z && dealer <= 16 && z < n - 1; z++)
                        {

                            dealer += c[z];
                            

                        }
                    }

                       //for (int z = 0, j = i + p + 2+z ; j <= i + p + d && j < n - i; j++)
                            //{

                            //        dealer += c[i + j+1];                                
                                

                            //}
                   
                        Console.WriteLine("Dealer = " + dealer);
                    if (dealer >= 17)
                    {
                         Console.WriteLine("Dealer Stop Drawing");
                        break;
                    }
                }
                if (dealer < 17 && i + p + d1 >= n)
                {
                    dealer = 21;
                    Console.WriteLine("What");
                }
                if (dealer > 21)
                {
                    dealer = 0;
                    Console.WriteLine("DEALER BUST");
                }  
                Console.WriteLine("Dealer = " + dealer);
                dealer += 0.5;
                options.Add(cmp(player, dealer) + BJ(i + p1 + d1));
                // Короче ошибка в d1 оно должно быть на единицу , а иногда и на двойку больше, ну тоесть делать больше оперций , хз как пофиксить
                
            }
            var max = options.Max();
            BJList.Add(max);
            return max;
        }


        public int GetWinsCount()
        {

            System.Console.WriteLine("Array:");
            for (int i = 0; i < c.Count; i++)
            {
                System.Console.Write(c[i] + " ");
            }
            System.Console.WriteLine();

            return BJ(0);
            System.Console.WriteLine("jj");
        }
    }
}
