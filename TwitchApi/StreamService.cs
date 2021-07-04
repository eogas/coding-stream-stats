using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using CodingStreamStats.TwitchApi.Model;
using Microsoft.Extensions.Logging;

namespace CodingStreamStats.TwitchApi
{
    public class StreamService
    {
        // TODO Refactor out the concept of identifying whether or not a specific stream
        // constitutes a coding stream
        private static readonly string SciTechGameId = "509670";

        // TODO Get these IDs through the API rather than hardcoding. Will still probably
        // require matching against strings, but those can be configured I guess.
        private static readonly string[] CodingTags = new[]{
            "6f86127d-6051-4a38-94bb-f7b475dde109", // Software Development
            "b741fd1d-e96d-49b8-9f2d-03a631c33e04", // JavaScript
            "c23ce252-cf78-4b98-8c11-8769801aaf3a", // Web Development
            "a59f1e4e-257b-4bd0-90c7-189c3efbf917", // Programming
            "f588bd74-e496-4d11-9169-3597f38a5d25", // Game Development
        };

        protected readonly IHttpClientFactory httpClientFactory;
        protected readonly ILogger<StreamService> logger;

        public StreamService(
            IHttpClientFactory httpClientFactory,
            ILogger<StreamService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public async IAsyncEnumerable<TwitchStream> GetAllCodingStreamsAsync(
            [EnumeratorCancellation] CancellationToken token = default)
        {
            var client = httpClientFactory.CreateClient("twitch");

            string cursor = null;

            do
            {
                var afterClause = cursor != null ? $"&after={cursor}" : string.Empty;
                var twitchResponse = await client.GetFromJsonAsync<TwitchStreamResponse>(
                    $"streams?game_id={SciTechGameId}&first=100{afterClause}",
                    new JsonSerializerOptions() {
                        PropertyNameCaseInsensitive = true
                    }, token);
                
                foreach (var stream in twitchResponse.Data)
                {
                    yield return stream;
                }

                cursor = twitchResponse.Pagination.Cursor;
            }
            while (cursor != null);
        }
    }
}