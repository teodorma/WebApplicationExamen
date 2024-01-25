namespace WebApplication1.Models
{
    public class Utilizator
    {
        public int UtilizatorId { get; set; }
        public string Nume { get; set; }
        public string Email { get; set; }
        public List<Comanda> Comenzi { get; set; }
    }
}