namespace CodingStreamStats.TwitchApi.Model
{
    public class TwitchStreamResponse
    {
        public TwitchStream[] Data { get; set; }
        public TwitchPagination Pagination { get; set; }
    }
}