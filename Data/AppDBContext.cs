using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
public class ApplicationDbContext : DbContext
{
    public DbSet<Utilizator> Utilizatori { get; set; }
    public DbSet<Produs> Produse { get; set; }
    public DbSet<Comanda> Comenzi { get; set; }
    public DbSet<DetaliiComanda> DetaliiComenzi { get; set; }
    public ApplicationDbContext() : base()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Utilizator>()
            .HasMany(u => u.Comenzi)
            .WithOne(c => c.Utilizator)
            .HasForeignKey(c => c.UtilizatorId);

        modelBuilder.Entity<DetaliiComanda>()
            .HasKey(dc => new { dc.ComandaId, dc.ProdusId });

        modelBuilder.Entity<DetaliiComanda>()
            .HasOne(dc => dc.Comanda)
            .WithMany(c => c.DetaliiComenzi)
            .HasForeignKey(dc => dc.ComandaId);

        modelBuilder.Entity<DetaliiComanda>()
            .HasOne(dc => dc.Produs)
            .WithMany(p => p.DetaliiComenzi)
            .HasForeignKey(dc => dc.ProdusId);
    }
}
