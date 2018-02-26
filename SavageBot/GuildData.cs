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
        public string Name;
        public SocketChannel defaultChannel;
        public WerdData werdData;
        public GuildData(ulong Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
