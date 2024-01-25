namespace WebApplication1.Models
{
    public class DetaliiComanda
    {
        public int ComandaId { get; set; }
        public int ProdusId { get; set; }
        public int Cantitate { get; set; }
        public Comanda Comanda { get; set; }
        public Produs Produs { get; set; }
    }
}
