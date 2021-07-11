using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoGame
{
    class CurrentDay
    {
        
       public int cumulation;
        public int[] rndNumbers;
        public int day;
        public CurrentDay(int cumulation, int[] rndNumbers, int day)
        {
            this.cumulation = cumulation;
            this.rndNumbers = rndNumbers;
            this.day = day;
        }

         
        public void ShowCurrentDay()
        {
            Console.WriteLine("Day :" + day +"\n cumulation " + cumulation + "\n" );
            Console.Write("drawn numbers :");
            foreach (var item in rndNumbers)
            {
                Console.Write(item + " ,");
            }
        }
        public void NextDay(int cumulation, int[] rndNumbers, int day)
        {
            this.cumulation = cumulation;
            this.rndNumbers = rndNumbers;
            this.day = day;
        }
        public void ReadGame(int readCumulation, int readDay, int[] readRndNumbers)
        {
            this.cumulation = readCumulation;
            this.day = readDay;
            this.rndNumbers = readRndNumbers;
        }
    }
}
