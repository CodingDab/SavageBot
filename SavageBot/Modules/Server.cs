using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord.Commands;
using Discord;

namespace SavageBot.Modules
{
    [Group("server")]
    public class Server : ModuleBase<SocketCommandContext>
    {
        [Group("settings")]
        public class Settings : ModuleBase<SocketCommandContext>
        {

        }

        [Command("info")]
        public async Task InfoAsync()
        {
            var builder = new EmbedBuilder();

            builder.WithTitle(Context.Guild.Name);
            builder.AddInlineField("Server Id", Context.Guild.Id);
            builder.AddInlineField("Owner", Context.Guild.Owner);
            builder.AddInlineField("Owner's Id", Context.Guild.OwnerId);
            builder.AddInlineField("Member count", Context.Guild.Users.Count);
            //builder.AddInlineField("Default channel", )
            builder.WithThumbnailUrl(Context.Guild.IconUrl);

            await Context.Channel.SendMessageAsync("", false, builder);
        }
    }
}
