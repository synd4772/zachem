using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Game_Uss
{
    public class Barriers:Figure
    {
        public Barriers(int yLeft, int yRight, int x, char sym)
        {
            pList = new List<Point>();
            for (int y = yLeft; y <= yRight; y++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
        }

        //pList = new List<Point>();
        //Point p1 = new Point(4, 4, '*');
        //Point p2 = new Point(5, 4, '*');
        //Point p3 = new Point(6, 4, '*');
        //pList.Add(p1);
        //pList.Add(p2);
        //pList.Add(p3);
        public void Drow()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            base.Draw();
        }
    }
}
