using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipGame.View;
using BattleShipGame.Model;
using BattleShipGame.Helpers;

namespace BattleShipGame
{
    class Program
    {         
        public static bool isOver = false;
        public static Logger logger;

        static void Main(string[] args)
        {
            Grid Playfield = new Grid();
            AIModule enemyAI = new AIModule();

            logger = new Logger();

            string coordinate;
            int aiX, aiY;

            Console.WriteLine("-----");
            Console.WriteLine("Greetings, commander! Welcome to the next iteration of Battleship board game implementation.");
            Console.WriteLine("Write a letter and a digit to shoot to a field! For example: A5");

            while (!isOver)
            {
                while (!isOver)
                {
                    coordinate = Console.ReadLine();

                    try
                    {
                        if (Playfield.EnemyMap[CoordinateCalculator.GetX(coordinate), CoordinateCalculator.GetY(coordinate)].State == State.basic)
                        {
                            if (Playfield.EnemyMap[CoordinateCalculator.GetX(coordinate), CoordinateCalculator.GetY(coordinate)].Shoot())
                            {
                                logger.AppendLog("You hit the enemy ship!");
                            }
                            else
                            {
                                logger.AppendLog("Miss...");
                            }
                            logger.DumpLog();
                            break;
                        }
                        Console.WriteLine("You already shot there! Try again.");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("You shot outside of the map area. The sea is not quite impressed.");
                        break;
                    }
                }

                while (!isOver)
                {
                    aiX = enemyAI.Aim();
                    aiY = enemyAI.Aim();
                    if (Playfield.PlayerMap[aiX, aiY].State == State.basic)
                    {
                        if (Playfield.PlayerMap[aiX, aiY].Shoot())
                        {
                            logger.AppendLog("Enemy hit one of your ships!");
                        }
                        else
                        {
                            logger.AppendLog("Enemy missed the shot.");
                        }
                        logger.DumpLog();
                        break;
                    }
                }

                Console.ReadKey();
                if (!isOver) Playfield.DrawGrid();
            }
        }
    }
}
