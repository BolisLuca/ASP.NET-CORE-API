namespace API_Chess.Entities
{
    public partial class Moves
    {
        public int Ppkid { get; set; }
        public string PpkfkGameId { get; set; }
        public string Move { get; set; }

        public virtual Games PpkfkGame { get; set; }
    }
}
