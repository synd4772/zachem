using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Uss
{
    public class Menu:Figure
    {
        public static void PrintMenu()
        {
            Walls walls = new Walls(80, 25);
            Console.ForegroundColor = ConsoleColor.Green;
            walls.Draw();
            Console.SetCursorPosition(35, 5);
            Console.WriteLine("SNAKE");

        }

        public void Drow()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }
    }
}
