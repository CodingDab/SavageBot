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

        public class Ban : ModuleBase<SocketCommandContext>
        {
            [Command("ban")]
            [RequireUserPermission(Discord.GuildPermission.BanMembers)]
            public async Task BanAsync(SocketGuildUser user, string reason = null)
            {
                await Context.Guild.AddBanAsync(user, 0, reason);
            }
        }

        public class Unban : ModuleBase<SocketCommandContext>
        {
            [Command("unban")]
            [RequireUserPermission(Discord.GuildPermission.BanMembers)]
            public async Task UnBanAsync(ulong id)
            {
                foreach(var x in Context.Client.Guilds)
                {
                    foreach( var y in x.Users)
                    {
                        if(y.Id == id)
                        {
                            await Context.Guild.RemoveBanAsync(y);
                        }
                    }
                }
            }
        }
    }
}
