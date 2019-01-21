using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame.Model
{
    public class Fleet
    {
        public string Commander { get; private set; }
        int FunctionalShips = 0;

        List<Ship> Ships;

        public Fleet(string _commander)
        {
            Ships = new List<Ship>();
            Commander = _commander;
        }
        
        public void AddShip(Ship _ship)
        {
            _ship.AssignFleet(this);
            this.Ships.Add(_ship);
            FunctionalShips++;
        }

        public void DestroyShip()
        {
            FunctionalShips--;
            if (FunctionalShips == 0)
            {
                Program.logger.AppendLog(Commander + " has lost all of it's ships!");
                Program.isOver = true;
            }
        }
    }
}
