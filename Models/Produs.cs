namespace WebApplication1.Models
{
    public class Produs
    {
        public int ProdusId { get; set; }
        public string Nume { get; set; }
        public string Descriere { get; set; }
        public decimal Pret { get; set; }
        public List<DetaliiComanda> DetaliiComenzi { get; set; }
    }
}