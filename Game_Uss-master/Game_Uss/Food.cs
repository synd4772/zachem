using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Uss
{
    class Food
    {
        int mapWidth;
        int mapHeight;
        char sym;
       
        Random rand = new Random();
        public Food(int mapWidth, int mapHeight, char sym)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;
        }  
        public Point CreateFood()
        {
            int x = rand.Next(2, mapWidth - 2);
            int y = rand.Next(2, mapHeight - 2);
            return new Point(x, y, sym);
        }
    }
}
