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
        // hard data
        public ulong Id;
        // hard data
        public string Name;
        // hard data
        public ulong defaultChannel;
        public WerdData werdData;
        public GuildData(ulong Id, string Name, ulong defaultChannel = 0)
        {
            this.Id = Id;
            this.Name = Name;
            this.defaultChannel = defaultChannel; // null
        }
    }
}
