using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavageBot
{
    class WerdData
    {
        public string werd;
        public bool gameGoing = false;
        public ulong guildId;
        public WerdData(ulong guildId, string werd)
        {
            this.werd = werd;
            this.guildId = guildId;
        }
    }
}
