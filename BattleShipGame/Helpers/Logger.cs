using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame.Helpers
{
    public class Logger
    {
        string Log;

        public void AppendLog(string line)
        {
            Log = line + Environment.NewLine + Log; 
        }

        public void DumpLog()
        {
            Console.Write(Log);
            Log = "";
        }
    }
}
