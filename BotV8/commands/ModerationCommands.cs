class ModerationCommands : BaseCommandModule
{
    [Command("Ban"), Aliases("outlaw")]
    [Description("Bans a mentioned user from the server")]
    public async Task BanUser(CommandContext ctx, DiscordMember member, [RemainingText] string banReason)
    {
        await member.BanAsync(reason: banReason);
        DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
        embed.Title = "User has been banned";
        embed.Description = $"{member.Username + member.Discriminator} has been banned for {banReason}";
        embed.Color = DiscordColor.Red;
        //embed.AddField("name", "value", true);
        await ctx.RespondAsync(embed: embed);
    }

    [Command("Kick"), Aliases("boot")]
    [Description("Kicks a mentioned user from the server")]
    public async Task KickUser(CommandContext ctx, DiscordMember member, [RemainingText] string kickReason)
    {
        await member.RemoveAsync(reason: kickReason);
        DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
        embed.Title = "User has been removed from the server";
        embed.Description = $"{member.Username + member.Discriminator} has been removed from the server for {kickReason}";
        embed.Color = DiscordColor.Red;
        //embed.AddField("name", "value", true);
        await ctx.RespondAsync(embed: embed);
    }
}