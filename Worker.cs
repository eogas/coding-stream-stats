using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CodingStreamStats.TwitchApi;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CodingStreamStats
{
    public class Worker : BackgroundService
    {
        private static readonly TimeSpan Frequency = TimeSpan.FromMinutes(15);

        private readonly StreamService streamService;
        private readonly ILogger<Worker> logger;

        public Worker(
            StreamService streamService,
            ILogger<Worker> logger)
        {
            this.streamService = streamService;
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await foreach(var stream in streamService.GetAllCodingStreamsAsync(token))
                {
                    
                }

                await Task.Delay(Frequency, token);
            }
        }
    }
}
