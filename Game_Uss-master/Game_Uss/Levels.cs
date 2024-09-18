using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Game_Uss
{
    public class Levels
    {
        public int CurrentLevel = 1;
        public int Speed = 100;
        public Walls walls;
        public string lvlupMessage = "LEVEL UP";
        public List<int> levelStatus;
        public Snake snake { get; private set; }
        public Player currentPlayer { get; private set; }

        public Levels(Walls walls, Snake snake, Player player)
        {
            levelStatus = new List<int>() { 0, lvlupMessage.Length };
            this.currentPlayer = player;
            this.snake = snake;
            this.walls = walls;
        }
        public void DrawLevel()
        {
            this.levelStatus[0] = 1;
            Console.SetCursorPosition(walls.mapWidth + 1, 0);
            Console.WriteLine($"Level: {CurrentLevel}");
        }
        public void DrawScore(int count)
        {
            string line = $"Punktid: {count}";
            Console.SetCursorPosition((walls.mapWidth / 2) - line.Length / 2 - 1, 0);
            Console.WriteLine(line);
        }

        public void DrawBestScore()
        {
            Console.SetCursorPosition(walls.mapWidth + 1, 2);
            Console.WriteLine($"Parim skoor: {this.currentPlayer.BestScore}");
        }
        public int Counter(int count)
        {
            if (this.levelStatus[0] == 1)
            {
                this.levelStatus[0] = 0;
                Console.SetCursorPosition(walls.mapWidth + 1, 2);
                Console.Write(string.Concat("", new string(' ', levelStatus[1])));
            }
            count++;
            this.DrawScore(count);

            if (count % 5 == 0)
            {
                Console.ForegroundColor = snake.currentColor;
                Console.SetCursorPosition(walls.mapWidth + 1, 2);
                Console.WriteLine(lvlupMessage);
                Console.ForegroundColor = ConsoleColor.White;
                LevelUp();
            }
            return count;
        }
        public void LevelUp()
        {
            if (CurrentLevel <= 4)
            {
                CurrentLevel++;
                Speed -= 25;
                this.DrawLevel();
                Console.ForegroundColor = ConsoleColor.White;
                ChangeLevelColor(CurrentLevel);

            }
        }
        public void ChangeLevelColor(int level)
        {
            switch (level)
            {
                case 1:
                    Console.Clear();
                    snake.currentColor = ConsoleColor.Cyan;
                    break;
                case 2:
                    snake.currentColor = ConsoleColor.Green;
                    break;
                case 3:
                    snake.currentColor = ConsoleColor.Red;
                    break;
                case 4:
                    snake.currentColor = ConsoleColor.Blue;
                    break;

                default:
                    Console.ResetColor();
                    break;
            }
        }
        public void GameOver()
        {
            if (CurrentLevel == 3)
            {
                Console.SetCursorPosition((walls.mapWidth / 2) - "Sa võitsid!".Length / 2 - 1, walls.mapHeight / 2 - 1);
                Console.WriteLine("Sa võitsid!");
                Console.SetCursorPosition((walls.mapWidth / 2) - $"Teie punktid: {CurrentLevel}".Length / 2 - 1, walls.mapHeight / 2);
                Console.WriteLine($"Teie punktid: {CurrentLevel}");
            }
            else
            {
                Console.SetCursorPosition((walls.mapWidth / 2) - "Sa suri!".Length / 2 - 1, walls.mapHeight / 2 - 1);
                Console.WriteLine("Sa suri!");
                Console.SetCursorPosition((walls.mapWidth / 2) - $"Teie punktid: {CurrentLevel}".Length / 2 - 1, walls.mapHeight / 2);
                Console.WriteLine($"Teie punktid: {CurrentLevel}");
            }
        }     
    }
}


