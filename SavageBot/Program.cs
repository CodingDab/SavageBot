using Discord;
using Discord.Commands;
using Discord.Net.Providers.WS4Net;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SavageBot
{
    class Program
    {
        private DiscordSocketClient _client;
        private CommandService _command;
        private IServiceProvider _services;
        private string token;

        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult(); // pretty freaking cool if you ask me

        public async Task RunBotAsync()
        {
            // cuz it looks noice :D
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkRed;

            _client = new DiscordSocketClient(new DiscordSocketConfig
                                    {
                                        WebSocketProvider = WS4NetProvider.Instance
                                    });
            _command = new CommandService();

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_command)
                .BuildServiceProvider();

            getToken();

            // log messages from the client
            _client.Log += Log;

            await RegisterCommandsAsync();

            await _client.LoginAsync(Discord.TokenType.Bot, token);

            await _client.StartAsync();

            await Task.Delay(-1); // keep it alive
        }

        private Task Log(LogMessage logMsg)
        {
            Console.WriteLine(logMsg);

            return Task.FromResult<object>(null); // cuz my .Net version is old RIP
        }

        public async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _command.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        public async Task HandleCommandAsync(SocketMessage msg)
        {
            var message = msg as SocketUserMessage;

            if (message is null || message.Author.IsBot) return;

            int argPos = 0;

            if(message.HasStringPrefix("$", ref argPos) 
                || message.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var result = await _command.ExecuteAsync(
                    new SocketCommandContext(_client, message),
                    argPos,
                    _services);

                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
            }
        }

        public void getToken() // does not return the token. it sets the token from a text file
        {
            token = File.ReadAllText("C:\\Users\\NickA\\Documents\\savage_key.txt");
        }
    }
}
