using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Board
    {
        public Board()
        {
            Ladders = new Dictionary<int, int>();
            Snakes = new Dictionary<int, int>();
            Players = new List<Player>();
            Dice = new Dice();
        }
        public Dictionary<int,int> Ladders { get; set; }

        public Dictionary<int, int> Snakes { get; set; }

        public List<Player> Players { get; set; }

        public Dice Dice { get; set; }

        public void SetupLadders(int down, int up)
        {
            Ladders.Add(down, up);
        }

        public void SetupSnakes(int head, int tail)
        {
            Snakes.Add(head, tail);
        }

        public void SetupPlayers(string name)
        {
            Players.Add(new Player(name));
        }


        public int EvaluateDiceRoll(int diceNumber, Player player )
        {
            int nextPosition = player.position + diceNumber;

            //Check if a ladder starts from next position
            while(Ladders.Keys.Contains(nextPosition))
            {
                nextPosition = Ladders[nextPosition];
            }

            //Check if a snake head starts from next position
            while (Snakes.Keys.Contains(nextPosition))
            {
                nextPosition = Snakes[nextPosition];
            }

            player.position = nextPosition;
            return nextPosition;
        }

        public bool CheckIfWon(int position)
        {
            return position >= 100;
        }
    }

    public class Player
    {
        public string name { get; set; }

        public int position { get; set; }

        public Player(string Name)
        {
            name = Name;
            position = 0;
        }
    }

    public class Ladder
    {
        public int down { get; set; }
        public int up { get; set; }

        public Ladder(int down, int up)
        {
            this.down = down;
            this.up = up;
        }

        
    }
    public class Snake
    {
        public KeyValuePair<int, int> snakePoints { get; set; }

        public Snake(int head, int tail)
        {
            snakePoints = new KeyValuePair<int, int>(head, tail);
        }
    }

}
