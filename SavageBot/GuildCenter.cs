using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavageBot
{
    class GuildCenter
    {
        public static List<GuildData> Guilds = new List<GuildData>();
        public static GuildData GetGuild(ulong id)
        {
            foreach(var x in Guilds)
            {
                if (x.Id == id) return x;
            }
            return new GuildData(0); // 0 id means that the guild was not found
        }
    }
}
