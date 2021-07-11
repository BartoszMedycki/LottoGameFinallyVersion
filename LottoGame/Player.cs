using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoGame
{
    class Player
    {
        private double balance = 30;
        public List<Ticket> listOfTickets = new List<Ticket>();
        private List<Ticket> HistoryOfTickets = new List<Ticket>();

        public List<Ticket> ListOfTickets => listOfTickets;

        public bool CanBuyTicket()
        {
            if (balance >= 3)
                return true;
            else
            {
                Console.WriteLine("you don't have enough money, click any button to go back to the menu");
            } return false;
        }

        public void AddTicket(CurrentDay current, Tote tote, int[] drawnNumbers)
        {
            PayForTicket();
            listOfTickets.Add(new Ticket(current.cumulation, current.day,drawnNumbers));
        }
        public void Win(double win)
        {
            balance += win;
        }
        public double getBalance()
        {
            return balance;
        }
        public void PayForTicket()
        {
            balance -= 3;
        }
        public void EndDay( )
        {
            for (int i = 0; i < listOfTickets.Count; i++)
            {
                HistoryOfTickets.Add( listOfTickets[i]);
            }
            listOfTickets.Clear();
        }
        public void ReadGame(double readBalance, List<Ticket> readListOfTickets)
        {
            this.balance = readBalance;
            this.listOfTickets = readListOfTickets;
        }
      
    }
}
