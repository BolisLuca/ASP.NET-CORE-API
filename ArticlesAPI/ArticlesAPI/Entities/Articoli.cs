#nullable disable

namespace ArticlesAPI.Entities
{
    public partial class Articoli
    {
        public int Id { get; set; }
        public string Titolo { get; set; }
        public string Descrizione { get; set; }
        public decimal Prezzo { get; set; }
    }
}
