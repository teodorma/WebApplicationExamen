namespace WebApplication1.Models
{
    public class Comanda
    {
        public int ComandaId { get; set; }
        public int UtilizatorId { get; set; }
        public DateTime DataComanda { get; set; }
        public List<DetaliiComanda> DetaliiComenzi { get; set; }
        public Utilizator Utilizator { get; set; }
    }
}