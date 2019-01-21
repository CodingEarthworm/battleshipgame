using BattleShipGame.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame.Model
{
    public class Ship
    {
        public int ShipLength;
        public int Durability;

        Fleet Fleet;

        public Ship(int _len)
        {
            ShipLength = _len;
            Durability = _len;
        }

        public void AssignFleet(Fleet _fleet)
        {
            this.Fleet = _fleet;
        }
                
        public void Damage()
        {
            Durability--;
            if (Durability == 0)
            {
                Program.logger.AppendLog(this.Fleet.Commander + " ship has been destroyed!");
                this.Fleet.DestroyShip();
            }
        }                
    }
}
