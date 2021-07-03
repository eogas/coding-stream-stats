using System;
using CodingStreamStats.Config;
using CodingStreamStats.TwitchApi;
using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CodingStreamStats
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // Get configured twitch auth details
                    var twitchConnection = hostContext.Configuration
                        .GetSection(TwitchConnection.Section)
                        .Get<TwitchConnection>();

                    // Set up twitch authentication with IdentityModel
                    services.AddAccessTokenManagement(options =>
                    {
                        options.Client.Clients.Add("twitch-oauth2", new ClientCredentialsTokenRequest
                        {
                            Address = "https://id.twitch.tv/oauth2/token",
                            ClientId = twitchConnection.ClientId,
                            ClientSecret = twitchConnection.ClientSecret
                            //Scope = ""
                        });
                    });

                    // Configure HttpClient for twitch API
                    services.AddHttpClient("twitch", client =>
                    {
                        client.BaseAddress = new Uri("https://api.twitch.tv/helix/");
                        client.DefaultRequestHeaders.Add("Client-Id", twitchConnection.ClientId);
                    })
                    .AddClientAccessTokenHandler("twitch-oauth2");

                    services.AddSingleton<StreamService>();

                    services.AddHostedService<Worker>();
                })
                .ConfigureLogging(builder => {
                    builder.ClearProviders();
                    builder.AddConsole();
                });
    }
}
