using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace SavageBot
{
    class GuildData
    {
        public ulong Id;
        public SocketChannel defaultChannel;
        public GuildData(ulong Id)
        {
            this.Id = Id;
        }
    }
}
