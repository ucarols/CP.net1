using Microsoft.EntityFrameworkCore;
using MotoPatioApi.Models;

namespace MotoPatioApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Patio> Patios { get; set; }
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Triagem> Triagens { get; set; }
        public DbSet<Monitoramento> Monitoramentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Se quiser, defina chaves estrangeiras e constraints aqui
        }
    }
}
