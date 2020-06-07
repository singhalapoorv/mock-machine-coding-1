using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialize board
            Board board = new Board();
            Console.WriteLine("-------Welcome to Snakes & Ladders------");

            string[] lines = File.ReadAllLines("C:\\Users\\git\\fileinput.txt");

            int j = 0;
            int snakes = Convert.ToInt32(lines[j]);
            j++;
            for (int i=j; i < snakes+j; i++)
            {
                //Console.WriteLine("Enter snake's head and tail positions separated by space...");

                int[] positions = lines[i].Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(item => int.Parse(item)).ToArray();
                board.SetupSnakes(positions[0], positions[1]);
            }
            j += snakes ;
            int ladders = Convert.ToInt32(lines[j]);
            j++;
            for (int i=j; i < ladders+j; i++)
            {
                //Console.WriteLine("Enter ladder's up and down positions separated by space...");

                int[] positions  = lines[i].Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(item => int.Parse(item)).ToArray();
                board.SetupLadders(positions[0], positions[1]);
            }
            j += ladders ;
            int players = Convert.ToInt32(lines[j]);
            j++;
            for (int i=j; i < players+j; i++)
            {
                //Console.WriteLine("Enter Player's name");

                string name = lines[i];
                board.SetupPlayers(name);
            }

            //Setup Snakes
            //Console.WriteLine("Enter no. of Snakes");
            //var snakes = Convert.ToInt32(Console.ReadLine());

            //for (int i = 0; i < Convert.ToInt32(snakes); i++)
            //{
            //    Console.WriteLine("Enter snake's head and tail positions separated by space...");
                
            //    int[] positions = Console.ReadLine().Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(item => int.Parse(item)).ToArray();
            //    board.SetupSnakes(positions[0], positions[1]);
            //}

            ////Setup Ladders
            //Console.WriteLine("Enter no. of Ladders");
            //var ladders = Convert.ToInt32(Console.ReadLine());

            //for (int i = 0; i < Convert.ToInt32(ladders); i++)
            //{
            //    Console.WriteLine("Enter ladder's up and down positions separated by space...");

            //    int[] positions = Console.ReadLine().Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(item => int.Parse(item)).ToArray();
            //    board.SetupLadders(positions[0], positions[1]);
            //}

            ////Setup Players
            //Console.WriteLine("Enter no. of players(greater than 2) for a game");
            //var players = Convert.ToInt32(Console.ReadLine());
            //while (players <2)
            //{
            //    Console.WriteLine("Please enter 2 or more players for a game");
            //    players = Convert.ToInt32(Console.ReadLine());
            //}

            //for (int i = 0; i < players; i++)
            //{
            //    Console.WriteLine("Enter Player's name");

            //    string name = Console.ReadLine();
            //    board.SetupPlayers(name);
            //}

            //Begin game
            Console.WriteLine("------Let the Game Begin!!------");

            int playerCount = board.Players.Count;
            int turns = 0;
            while (true)
            {
                var currentPlayer = board.Players[turns % playerCount];
                var dicenumber = board.Dice.RollDice();
                Console.WriteLine(currentPlayer.name +  " rolled a " + dicenumber + " and moved from " + currentPlayer.position + " to " + board.EvaluateDiceRoll(dicenumber, currentPlayer));
                Console.WriteLine();
                if( board.CheckIfWon(currentPlayer.position))
                {
                    Console.WriteLine(currentPlayer.name + " won the game!!");
                    Console.WriteLine("Press 1 to continue with other players or 2 to exit");
                    var input = Convert.ToInt32(Console.ReadLine());
                    if(input==1)
                    {
                        board.Players.Remove(currentPlayer);
                        playerCount = board.Players.Count;
                    }
                    else
                    {
                        Console.WriteLine("Thanks for playing!!");
                        break;
                    }
                    
                }
                turns++;
            }

        }
    }
}
