using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoGame
{
    class Menager
    {
        //321321321
        public Player player { get; set; }
         
       public Tote tote { get; set; }
        public SaveAndLoadGame saveAndLoadGame { get; private set; }

        CurrentDay currentDay;
        public Menager()
        {
            player = new Player();
            tote = new Tote();
            currentDay = new CurrentDay(tote.cumulation, tote.rndNumbers,tote.day);
            saveAndLoadGame = new SaveAndLoadGame();
        }
        public void Restart()
        {
            player = new Player();
            tote = new Tote();
            currentDay = new CurrentDay(tote.cumulation, tote.rndNumbers, tote.day);
            ShowMenu();
            SelectAction();
        }
        public void ShowMenu()
        {

            Console.Clear();
            Console.WriteLine("Lotto Game");
            Console.WriteLine("Game Day " + currentDay.day);
            Console.WriteLine("Today you can win :" + currentDay.cumulation);
            Console.WriteLine("Balance :" + player.getBalance());
            Console.WriteLine("\n\n\nBuy ticker for 3$. Bought ({0})/(8)  Press 1", player.listOfTickets.Count);
            Console.WriteLine("\n\n\nFinish the day and check your tickets. Press 2");
            Console.WriteLine("\n\n\nPlay again. Press 3");
            Console.WriteLine("\n\n\nSave Game. Press 4");
            Console.WriteLine("\n\n\nLoad Game. Press 5");
            Console.WriteLine("\n\n\nQuit game.  Press 6");


        }
        public int[] SelectNumbers()
        {
            int[] TmpTabOfSelectNumbers = new int[6];
            
                Console.WriteLine("please select 6 numbers from 1 to 49");
            
                for (int i = 0; i < 6; i++)
                {
                    int tmpNumber;

                    bool a = int.TryParse(Console.ReadLine(), out tmpNumber);
                    if ((0 < tmpNumber && tmpNumber <= 49) && !TmpTabOfSelectNumbers.Contains(tmpNumber))
                                            TmpTabOfSelectNumbers[i] = tmpNumber;
                    else
                    {
                        
                            Console.WriteLine("you can't repeat numbers");
                        
                    }
                }
            
            return TmpTabOfSelectNumbers;

        }
        public void BuyTicket()
        {
            
            
            
            
        }
        public void SelectAction()
        {
            int tmpNumber;
            bool a = int.TryParse(Console.ReadLine(), out tmpNumber);


            if (a)
            {
                switch (tmpNumber)
                {
                    case 1:
                        if (player.CanBuyTicket())
                        {
                            player.AddTicket(currentDay, tote, SelectNumbers()); ; ShowMenu(); SelectAction(); break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("you don't have enough money, click any button to go back to the menu");
                            Console.ReadLine();
                            ShowMenu();
                            SelectAction();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            tote.CheckTicket(player);
                            Console.Clear();
                            tote.WinWerification(player, currentDay);
                            player.EndDay();
                            tote.NextDay(currentDay);
                            ShowMenu();
                            SelectAction();
                            break;
                        }
                    case 3: Restart(); break;
                    case 4:
                        saveAndLoadGame.SafeGame(currentDay.rndNumbers, currentDay.cumulation, player.getBalance(), player.listOfTickets, currentDay.day);
                        ShowMenu();
                        SelectAction();
                        break;
                    case 5:
                        saveAndLoadGame.LoadGame();
                        player.ReadGame(saveAndLoadGame.playerBalance, saveAndLoadGame.listOfTickets);
                        currentDay.ReadGame(saveAndLoadGame.cumulation, saveAndLoadGame.day, saveAndLoadGame.drawnNumbers);
                        ShowMenu();
                        SelectAction();
                     
                        

                        break;
                        //case 5: SaveAndLoadGame loadGame = saveAndLoadGame.LoadGame()

                }



            }
            else
            {
                Console.Clear();
                ShowMenu();
                SelectAction();
            }
        
        }
        

    }
}
