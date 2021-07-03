namespace CodingStreamStats.Config
{
    public class TwitchConnection
    {
        public const string Section = "TwitchConnection";

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }   
}