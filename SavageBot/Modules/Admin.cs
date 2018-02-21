using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace SavageBot.Modules
{
    [Group("admin")]
    public class Admin : ModuleBase<SocketCommandContext>
    {
        public class Kick : ModuleBase<SocketCommandContext>
        {
            [Command("kick")]
            [RequireUserPermission(Discord.GuildPermission.KickMembers)]
            public async Task KickAsync(SocketGuildUser user, string reason = null)
            {
                await user.KickAsync(reason ?? null);
            }
        }
    }
}
