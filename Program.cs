using CodingStreamStats.TwitchApi;
using IdentityModel.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                    services.AddAccessTokenManagement(options => {
                        options.Client.Clients.Add("twitch-oauth2", new ClientCredentialsTokenRequest
                        {
                            Address = "https://id.twitch.tv/oauth2/token",
                            ClientId = "todo",
                            ClientSecret = "todo"
                            //Scope = ""
                        });
                    });

                    services.AddHttpClient("twitch");

                    services.AddSingleton<StreamService>();

                    services.AddHostedService<Worker>();
                });
    }
}
