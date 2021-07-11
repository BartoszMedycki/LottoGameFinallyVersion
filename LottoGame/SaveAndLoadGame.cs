using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace LottoGame
{
    class SaveAndLoadGame
    {
        public int[] drawnNumbers;
        public int cumulation;
        public double playerBalance;
        public List<Ticket> listOfTickets = new List<Ticket>();
        public int day;
        public SaveAndLoadGame()
        {

        }
        public SaveAndLoadGame(int[] drawnNumbers, int cumulation, double playerBalance , List<Ticket> listOfTickets, int day)
        {
            this.drawnNumbers = drawnNumbers;
            this.cumulation = cumulation;
            this.playerBalance = playerBalance;
            this.listOfTickets = listOfTickets;
            this.day = day;
        }
        public void SafeGame(int[] drawnNumbers, int cumulation, double playerBalance, List<Ticket> listOfTickets, int day)
        {
            this.drawnNumbers = drawnNumbers;
            this.cumulation = cumulation;
            this.playerBalance = playerBalance;
            this.listOfTickets = listOfTickets;
            this.day = day;

            string path = @"C:\Users\barme\OneDrive\Pulpit\JsonSafe\Safe.json";

            SaveAndLoadGame safeGame = new SaveAndLoadGame(drawnNumbers, cumulation, playerBalance, listOfTickets, day);
            String serializeSafe = JsonConvert.SerializeObject(safeGame);
            Console.WriteLine(serializeSafe);
            File.WriteAllText(path, serializeSafe);
            Console.ReadLine();

        }
        public SaveAndLoadGame LoadGame()
        {
            string path = @"C:\Users\barme\OneDrive\Pulpit\JsonSafe\Safe.json";
            string deserializedString = File.ReadAllText(path);
            SaveAndLoadGame deserializedGame = JsonConvert.DeserializeObject<SaveAndLoadGame>(deserializedString);
            return deserializedGame;

        }
    }
}
