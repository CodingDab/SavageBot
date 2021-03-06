﻿using System;
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
            [Command(null)]
            public async Task SettingsAsync()
            {
                GuildData g_data = GuildCenter.GetGuild(Context.Guild.Id);
                if (g_data.Id == 0) await ReplyAsync(Context.User.Mention + " no server settings saved.");
                else
                {
                    var builder = new EmbedBuilder();
                    builder.WithTitle("$AVAGE Bot settings for: " + Context.Guild.Name);
                    builder.AddField("Default Channel",
                        (g_data.defaultChannel==0?"Not set.": Context.Guild.GetChannel(g_data.defaultChannel).Id.ToString()));
                    builder.WithThumbnailUrl(Context.Guild.IconUrl);
                    await Context.Channel.SendMessageAsync("", false, builder);
                }
            }
            [Command("save")]
            public async Task SaveAsync()
            {
                GuildCenter.SaveGuilds();
                await ReplyAsync(Context.User.Mention + " guild settings have been saved.");
            }
            [Command("default-channel")]
            [RequireBotPermission(GuildPermission.ManageChannels)]
            public async Task DefaultChannelAsync(SocketChannel channel)
            {
                GuildData g_data = GuildCenter.GetGuild(Context.Guild.Id);
                if (g_data.Id == 0) g_data = new GuildData(Context.Guild.Id, Context.Guild.Name);
                g_data.defaultChannel = channel.Id;
                GuildCenter.Guilds.Add(g_data);
                GuildCenter.SaveGuilds();
                await ReplyAsync(Context.User.Mention + ", guild settings updated.");
            }
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
            builder.WithThumbnailUrl(Context.Guild.IconUrl);

            await Context.Channel.SendMessageAsync("", false, builder);
        }
    }
}
