using System.Collections.Generic;

namespace API_Chess.Entities
{
    public partial class Opening
    {
        public Opening()
        {
            Games = new HashSet<Games>();
        }

        public string OpeningEco { get; set; }
        public string OpeningName { get; set; }
        public int OpeningPly { get; set; }

        public virtual ICollection<Games> Games { get; set; }
    }
}
