using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipGame.Helpers;

namespace BattleShipGame.Model
{

    public enum State { basic, miss, hit }

    public class Field
    {
        public State State;
        public bool isShip = false;
        public string SpecialEventHolder;
        Ship ship;

        public Field()
        {
            State = State.basic;
        }


        public bool AssignShip(Ship _ship)
        {
            ship = _ship;
            isShip = true;

            return true;
        }

        public bool Shoot()
        {
            if (isShip)
            {
                this.State = State.hit;
                ship.Damage();

                return true;
            }
            else
            {
                this.State = State.miss;
                return false;
            } 
        }
    }
}
