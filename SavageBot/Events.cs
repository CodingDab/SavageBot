using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavageBot
{
    class Events // static functions that define events to be carried out 
    {                   // if some criteria are met
        public static async Task UserJoined(SocketGuildUser user)
        {
            SocketGuild guild = user.Guild;
            SocketTextChannel channel = guild.DefaultChannel;

            await channel.SendMessageAsync(user.Mention + " has joined. Don't stare :eyes:");
        }
        public static async Task UserBanned(SocketUser user, SocketGuild guild)
        {
            SocketTextChannel channel = guild.DefaultChannel;

            await channel.SendMessageAsync(user.Username + " has been banned... :scream:");
        }
    }
}
