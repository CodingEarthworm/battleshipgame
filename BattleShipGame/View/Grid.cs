using BattleShipGame.Helpers;
using BattleShipGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame.View
{
    public class Grid
    {
        public Field[,] PlayerMap;
        public Field[,] EnemyMap;

        public Fleet EnemyFleet;
        public Fleet PlayerFleet;

        public Grid()
        {
            PlayerMap = new Field[10, 10];
            EnemyMap = new Field[10, 10];

            PlayerMap.FillFields();
            EnemyMap.FillFields();

            EnemyFleet = new Fleet("Enemy");
            PlayerFleet = new Fleet("Player");

            DistributeShips();

            this.DrawGrid();
        }

        public void DrawGrid()
        {
            Console.Clear();

            Console.WriteLine(" Your Battleship grid:");
            GenerateSingleTable(PlayerMap, true);

            Console.WriteLine();

            Console.WriteLine(" Enemy Battleship grid:");
            GenerateSingleTable(EnemyMap, false);

            Console.WriteLine();
            Console.WriteLine("-----");
        }

        public static void GenerateSingleTable(Field[,] map, bool showShips)
        {
            int x = map.GetLength(0), y = map.GetLength(1);

            char letter = (char)65;
            char number = (char)48;

            Console.Write("   ");

            for (int k = 0; k < 10; k++)
            {
                Console.Write(" " + (char)(number + k) + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < x; i++)
            {
                Console.Write(" " + (char)(letter + i) + " ");

                for (int j = 0; j < y; j++)
                {
                    if (showShips && map[i, j].State == State.basic && map[i, j].isShip) Console.Write(" # ");
                    else if (map[i, j].State == State.basic) Console.Write(" . ");
                    if (map[i, j].State == State.hit) Console.Write(" X ");
                    if (map[i, j].State == State.miss) Console.Write(" O ");
                }
                Console.WriteLine();
            }
        }

        public void DistributeShips()
        {
            Random rng = new Random();

            PlaceShip(4, PlayerMap, rng, PlayerFleet);
            PlaceShip(4, PlayerMap, rng, PlayerFleet);
            PlaceShip(5, PlayerMap, rng, PlayerFleet);

            PlaceShip(4, EnemyMap, rng, EnemyFleet);
            PlaceShip(4, EnemyMap, rng, EnemyFleet);
            PlaceShip(5, EnemyMap, rng, EnemyFleet);
        }

        public void PlaceShip(int length, Field[,] map, Random rng, Fleet fleet)
        {
            bool isPlaced = false;
            int x, y, turn;

            do
            {
                x = rng.Next(10);
                y = rng.Next(10);
                turn = rng.Next(2);

                for (int i = length - 1; i >= 0; i--)
                {
                    if (map.GetLength(0) <= x + (i * turn)
                        || map.GetLength(1) <= y + i * (int)Math.Pow(0, turn)
                        || map[x + (i * turn), y + i * (int)Math.Pow(0, turn)].isShip)
                        break;

                    if (i == 1)
                    {
                        Ship ship = new Ship(length);
                        for (int j = 0; j < length; j++)
                        {
                            int z = y + j * (int)Math.Pow(0, turn);
                            int t = x + (j * turn);
                            map[x + (j * turn), y + j * (int)Math.Pow(0, turn)].AssignShip(ship);
                        }
                        fleet.AddShip(ship);
                        isPlaced = true;
                        break;
                    }
                }
            } while (!isPlaced);
        }
    }
}
