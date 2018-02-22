using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace SavageBot
{
    public class WerdData // i was getting errors because it is less accessible than a function it was passed to -.-
    {                     // sometimes, C#.......................
        public string werd;
        public ulong guildId;
        public int votes = 0;
        public List<SocketUser> players = new List<SocketUser>();
        public WerdData(ulong guildId, string werd)
        {
            this.werd = werd;
            this.guildId = guildId;
        }
    }
}
