using Discord;
using Discord.WebSocket;

string? token = Environment.GetEnvironmentVariable("DISCORD_BOT_TOKEN");

if (token is null) {
    Console.WriteLine("Cannot found the token");
    return;
}

DiscordSocketClient client = new(new DiscordSocketConfig {
    GatewayIntents = GatewayIntents.Guilds | GatewayIntents.GuildMessages
});

client.Ready += () => {
    _ = Task.Run(async () => await Worker());
    return Task.CompletedTask;
};

await client.LoginAsync(TokenType.Bot, token);
await client.StartAsync();

await Task.Delay(-1);

async Task Worker() {
    SocketGuild guild = client.GetGuild(1392313122022227998);
    SocketTextChannel channel = guild.GetTextChannel(1392313122504577258);

    while (true) {
        await channel.SendMessageAsync("test");
        await Task.Delay(10000);
    }
}