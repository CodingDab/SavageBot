﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using System.IO;

namespace SavageBot.Modules
{
    [Group("werd")]
    [Summary("A game where you try to guess a five letter word generated by the bot.")]
    public class Werd : ModuleBase<SocketCommandContext>
    {
        private string werd;

        [Summary("Start a game.")]
        public class Start : ModuleBase<SocketCommandContext>
        {
            [Command("start")]
            public async Task StartAsync()
            {
                throw new NotImplementedException();
            }
        }

        [Summary("Guess a word.")]
        public class Guess : ModuleBase<SocketCommandContext>
        {

        }

        [Summary("End the current game.")]
        [RequireUserPermission(Discord.GuildPermission.Administrator)] // only admins can end a game prematurely unless a vote is passed
        public class End : ModuleBase<SocketCommandContext>
        {

        }

        [Summary("Vote to end the game.")]
        public class Vote : ModuleBase<SocketCommandContext>
        {

        }

        public static string GenerateWerd()
        {
            Random rng = new Random();
            int line = (int)((5757-1) * rng.NextDouble()); // 5757 werds in the file

            FileStream werd_list = File.OpenRead("../../werds.txt");
            werd_list.Seek(6 * line, SeekOrigin.Begin);

            byte[] buffer = new byte[5];
            werd_list.Read(buffer, 0, 5);

            return System.Text.Encoding.Default.GetString(buffer);
        }
    }
}
