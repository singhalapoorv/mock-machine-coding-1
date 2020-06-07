using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Dice
    {
        private int randomNumber { get; set; }

        private int GetRandom()
        {
            Random random = new Random();
            return random.Next(1,7);
        }
        public int RollDice()
        {
            randomNumber = GetRandom();
            int count = 0;
            while (randomNumber % 6 == 0 && count < 2)
            {
                randomNumber += GetRandom();
                count++;
            }
            if (randomNumber%6==0)
            {
                return 0;
            }
            else
            {
                return randomNumber;
            }
        }

    }
}
