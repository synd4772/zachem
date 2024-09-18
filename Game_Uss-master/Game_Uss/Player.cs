using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Uss
{
    public class Player
    {
        public string Name { get; private set; }
        public int BestScore { get; set; }
        public int CurrentScore { get; private set; }

        public Player(string name, int BestScore, int currentScore)
        {
            this.CurrentScore = currentScore;
            this.Name = name;
            this.BestScore = BestScore;
        }

        public Player(string name, int BestScore)
        {
            this.Name = name;
            this.BestScore = BestScore;
        }
        
        public void Counter()
        {
            this.CurrentScore++;
            if (this.CurrentScore > this.BestScore)
            {
                this.BestScore = this.CurrentScore;
            }
        }

    }
}
