using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Menager menager = new Menager();
            menager.ShowMenu();
            menager.SelectAction();
        }
    }
}
