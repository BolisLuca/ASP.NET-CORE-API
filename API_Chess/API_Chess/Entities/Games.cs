using System.Collections.Generic;

namespace API_Chess.Entities
{
    public partial class Games
    {
        public Games()
        {
            Moves = new HashSet<Moves>();
        }

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

        public virtual Players Fkblack { get; set; }
        public virtual Players Fkwhite { get; set; }
        public virtual Opening OpeningEcoNavigation { get; set; }
        public virtual ICollection<Moves> Moves { get; set; }
    }
}
