using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

    public DbSet<TipoCurso> TipoCursos { get; set; } = null!;
    public DbSet<Leitor> Leitor { get; set; } = null!;

    public DbSet<Email> Email { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Leitor>()
            .Property(p => p.DataNascimento)
            .HasColumnType("date");
    }
}