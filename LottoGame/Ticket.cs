using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoGame
{
    public class Ticket
    {
        int cumulation;
        public  int day;
        readonly int idNumber = 0;
        static int  tmp;
        public int[] numbersInTicket;
        public int winningAmount;

        public Ticket(int cumulation, int day,int[]numbersInTicket)
        {
            tmp++;
            this.cumulation = cumulation;
            this.day = day;
            this.numbersInTicket = numbersInTicket;
            idNumber += tmp;
          
        }
        public void ShowTicket()
        {
            Console.WriteLine();
            Console.WriteLine("Cumulation :" + cumulation);
            Console.WriteLine("day :" + day);
            Console.WriteLine("idNumber" + idNumber);
            foreach (var item in numbersInTicket)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }
        public override string ToString()
        {
            return cumulation + "  KK" + idNumber; 
        }

    }
    
    
}
