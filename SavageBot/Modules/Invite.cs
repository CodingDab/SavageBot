using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace SavageBot.Modules
{
    public class Invite : ModuleBase<SocketCommandContext>
    {
        [Command("invite")]
        [Summary("Experimental: Gives the sender a one-time only invite.")]
        public async Task InviteAsync()
        {
            await ReplyAsync(Context.User.Mention + " here ya go: "/*+ invite link*/);
            // giving a weird output for the invite
        }
    }
}
