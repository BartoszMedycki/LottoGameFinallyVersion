using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoGame
{
    class Tote
    {
        public int cumulation { get; private set; }
        public int[] rndNumbers { get;private set; }
        public int day = 1;
       public  List<CurrentDay> history = new List<CurrentDay>();
       
     

        public Tote( )
        {
            DrawCumulation();
            DrawNumbers();
             
        }


        private int DrawCumulation()
        {
            int tmpNumber;
            Random random = new Random();
            tmpNumber = random.Next(10000000, 30000000);
            cumulation = tmpNumber;
            return tmpNumber;
        }
        
        
        private int[] DrawNumbers()
        {
            rndNumbers = new int[6];
            int i = 0;
            int tmpRandomNumber = 0;
            do
            {
                Random random = new Random();
                 tmpRandomNumber = random.Next(1, 50);
             
                if (!rndNumbers.Contains(tmpRandomNumber))
                {
                    rndNumbers[i] = tmpRandomNumber;
                    i++;
                } }while (i < 6) ;
            
            return rndNumbers;
        }
        public void NextDay(CurrentDay currentDay)
        {
            history.Add(currentDay);
            DrawCumulation();
            DrawNumbers();
            day++;
            
            currentDay.NextDay(cumulation, rndNumbers, day);
            
            
        }
        public void CheckTicket(Player player)
        {
            for (int i = 0; i < player.listOfTickets.Count; i++)
            {
                Console.WriteLine("Your drawn numbers from {0} ticket :", i+1);

                Ticket tab = player.listOfTickets[i];
                tab.ShowTicket();

                Console.WriteLine("\n\n\n");
                
                Console.WriteLine("Numbers drawn by totalizer :");
                Console.Write("=====================");
                for (int ki = 0; ki < rndNumbers.Length; ki++)
                {
                    
                    {
                        
                        Console.Write(rndNumbers[ki] + ",");
                        
                    }
                }
                Console.Write("=====================");
                Console.ReadLine();
                Console.Clear();
              
            }
        
        }
        public void WinWerification(Player player, CurrentDay currentDay)
        {
            for (int i = 0; i < player.listOfTickets.Count; i++)
            {
                int numbersOfValid = 0;
                Ticket tmpTicket = player.listOfTickets[i];
                int[] tmpTab = tmpTicket.numbersInTicket;
               
                    for (int j = 0; j < tmpTab.Length; j++)


                    {
                        for (int k = 0; k < currentDay.rndNumbers.Length; k++)
                        {
                            if (tmpTab[j] == currentDay.rndNumbers[k])
                            {
                                numbersOfValid++;
                            }
                        }
                    }
                
                Console.WriteLine("Ticket nr {0} chose well {1}", i + 1, numbersOfValid);
                switch (numbersOfValid)
                {
                    
                    case 3: Console.WriteLine("this ticket won 24$"); player.Win( 24); break;
                    case 4: Console.WriteLine("this ticket won 24$ {0}zl", cumulation - (cumulation * 0.97)); player.Win ((cumulation - (cumulation * 0.97))); break;
                    case 5: Console.WriteLine("this ticket won 24$ {0}zl", cumulation - (cumulation * 0.87)); player.Win (cumulation - (cumulation * 0.87)); break;
                    case 6: Console.WriteLine("this ticket won 24$ {0}zl", cumulation); player.Win(cumulation); break;
                    default: Console.WriteLine("You didn't win anything, good luck in the next draws"); break; ;


                }
                numbersOfValid = 0;
                Console.ReadLine();
            }

        }
        


    }
}
