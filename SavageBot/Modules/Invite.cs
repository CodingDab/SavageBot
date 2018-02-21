using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace SavageBot.Modules
{
    public class Invite : ModuleBase<SocketCommandContext>
    {
        [Command("invite")]
        [Summary("Gives the sender an invite.")]
        public async Task InviteAsync(SocketTextChannel channel, bool temporary = true)
        {
            var invite = await channel.CreateInviteAsync(isTemporary: temporary);
            await ReplyAsync(Context.User.Mention + " here ya go: " + invite.Url);
        }
    }
}