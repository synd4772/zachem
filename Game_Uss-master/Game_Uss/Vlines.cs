using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Uss
{
    public class VLines:Figure
    {
        
        public VLines(int yUP, int yDown, int x, char sym)
        {
            pList = new List<Point>();
            for (int y = yUP; y <= yDown; y++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
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
