global using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using BotV8;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;

namespace V8_Bot
{
    class Bot
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var json = string.Empty;

            var p1 = Directory.GetCurrentDirectory();
            var p2 = "config.json";

            var fullPath = Path.Combine(p1, p2);

            using (var fs = File.OpenRead(fullPath))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            var discord = new DiscordClient(new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,

            });

            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { configJson.Prefix},
            });

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}