using System;
using System.Collections.Generic;
using System.Net.Http;
using CodingStreamStats.TwitchApi.Model;
using Microsoft.Extensions.Logging;

namespace CodingStreamStats.TwitchApi
{
    public class StreamService
    {
        protected readonly ILogger logger;
        protected readonly IHttpClientFactory httpClientFactory;

        public StreamService(ILogger logger, IHttpClientFactory httpClientFactory)
        {
            this.logger = logger ??
                throw new ArgumentNullException(nameof(logger));
            this.httpClientFactory = httpClientFactory ??
                throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async IAsyncEnumerable<TwitchStream> GetAllProgrammingStreams()
        {
            var client = httpClientFactory.CreateClient("twitch");

            // TODO

            yield return null;
        }
    }
}