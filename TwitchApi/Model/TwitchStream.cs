using System;

namespace CodingStreamStats.TwitchApi.Model
{
    // https://dev.twitch.tv/docs/api/reference#get-streams
    public class TwitchStream
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserName { get; set; }
        public string GameId { get; set; }
        public string GameName { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public int ViewerCount { get; set; }
        public DateTimeOffset StartedAt { get; set; }
        public string Language { get; set; }
        public string ThumbnailUrl { get; set; }
        public Guid[] TagIds { get; set; }
        public bool IsMature { get; set; }
    }
}