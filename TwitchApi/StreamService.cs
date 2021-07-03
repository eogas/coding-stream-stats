using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using CodingStreamStats.TwitchApi.Model;

namespace CodingStreamStats.TwitchApi
{
    public class StreamService
    {
        protected readonly IHttpClientFactory httpClientFactory;

        public StreamService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async IAsyncEnumerable<TwitchStream> GetAllCodingStreamsAsync(
            [EnumeratorCancellation]CancellationToken token = default)
        {
            var client = httpClientFactory.CreateClient("twitch");

            var response = await client.GetAsync("streams", token);
            var jsonRaw = await response.Content.ReadAsStringAsync();

            yield return null;
        }
    }
}