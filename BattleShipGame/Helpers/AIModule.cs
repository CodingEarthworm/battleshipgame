using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame.Helpers
{
    class AIModule
    {
        Random rng;

        public AIModule()
        {
            rng = new Random();
        }

        public int Aim()
        {
            return rng.Next(10);
        }
    }
}
