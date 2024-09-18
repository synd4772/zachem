using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Uss
{
    public class Walls
    {
        public int mapWidth { get; private set; }
        public int mapHeight { get; private set; }
        List<Figure> wallList;
       
        public Walls(int mapWidth, int mapHeight)
        {
            wallList= new List<Figure>();
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;

            HLines UPline = new HLines(0, mapWidth - 2, 0, '+');
            HLines DownLine = new HLines(0, mapWidth -2, mapHeight - 1, '+');
            VLines leftLine = new VLines(0, mapHeight - 1, 0, '+');
            VLines rightLine = new VLines(0, mapHeight - 1, mapWidth -2, '+');
            wallList.Add( UPline);
            wallList.Add( DownLine );
            wallList.Add( leftLine );
            wallList.Add( rightLine );
            
        }
        
        public bool IsHit(Figure figure)
        {
            foreach(var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }                    
            }
            return false;
        }
        public void Draw()
        {
            foreach(var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
