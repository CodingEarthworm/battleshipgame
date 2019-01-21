using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame.Helpers
{
    public static class CoordinateCalculator
    {
        public static int GetX(string coordinate)
        {

            if (Char.IsUpper(coordinate[0]))
                return (int)coordinate[0] - 65;
            else
                return (int)coordinate[0] - 97;
        }

        public static int GetY(string coordinate)
        {
            return (int)coordinate[1] - 48;
        }
    }
}
