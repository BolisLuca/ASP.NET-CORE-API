namespace API_Chess.Models
{
    public class GamesDTO
    {
        public string Pkid { get; set; }
        public bool? Rated { get; set; }
        public int CreatedAt { get; set; }
        public int LastMoveAt { get; set; }
        public int Turns { get; set; }
        public string VictoryStatus { get; set; }
        public string Winner { get; set; }
        public string IncrementCode { get; set; }
        public string FkwhiteId { get; set; }
        public string FkblackId { get; set; }
        public string OpeningEco { get; set; }
    }
}
