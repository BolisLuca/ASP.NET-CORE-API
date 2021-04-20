using System.Collections.Generic;

namespace API_Chess.Entities
{
    public partial class Players
    {
        public Players()
        {
            GamesFkblack = new HashSet<Games>();
            GamesFkwhite = new HashSet<Games>();
        }

        public string Pkid { get; set; }
        public int PlayerRating { get; set; }

        public virtual ICollection<Games> GamesFkblack { get; set; }
        public virtual ICollection<Games> GamesFkwhite { get; set; }
    }
}
