using Microsoft.EntityFrameworkCore;
using OdontoCloud.Domain.Entities;

namespace OdontoCloud.Infrastructure.Context
{
    public class OdontoCloudDBContext: DbContext
    {
        public OdontoCloudDBContext(DbContextOptions<OdontoCloudDBContext> options): base(options) { }
        public DbSet<Anamnese> Anamnese { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Atendimento> Atendimento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:odontocloud.database.windows.net,1433;Initial Catalog=OdontoCloud;Persist Security Info=False;User ID=odontocloud@hotmail.com@odontocloud;Password=Od0nt0cl0ud;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anamnese>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Anamnese_PK");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Cliente_PK");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Endereco_PK");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Atendimento>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Atendimento_PK");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
