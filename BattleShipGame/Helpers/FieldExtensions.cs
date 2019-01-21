using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipGame.View;
using BattleShipGame.Model;

namespace BattleShipGame.Helpers
{
    public static class FieldExtensions
    {
        public static Field[,] FillFields(this Field[,] fieldTable)
        {
            int x = fieldTable.GetLength(0), y = fieldTable.GetLength(1);

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    fieldTable[i, j] = new Field();
                }
            }
            return fieldTable;
        }
    }
}
