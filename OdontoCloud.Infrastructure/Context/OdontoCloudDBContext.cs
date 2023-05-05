using Microsoft.EntityFrameworkCore;
using OdontoCloud.Domain.Entities;

namespace OdontoCloud.Infrastructure.Context
{
    public class OdontoCloudDBContext : DbContext
    {
        public OdontoCloudDBContext(DbContextOptions<OdontoCloudDBContext> options) : base(options) { }
        public DbSet<Anamnese> Anamnese { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Atendimento> Atendimento { get; set; }
        public DbSet<DetalheAtendimento> DetalheAtendimento { get; set; }
        public DbSet<Item> Item { get; set; }

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

                entity.HasOne(e => e.Cliente)
                        .WithMany(e => e.Anamneses)
                        .HasForeignKey(e => e.IdCliente)
                        .IsRequired(true);
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

                entity.HasOne(e => e.Cliente)
                        .WithMany(e => e.Atendimentos)
                        .HasForeignKey(e => e.IdCliente)
                        .IsRequired(true);
                        //.OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<DetalheAtendimento>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("DetalheAtendimento_PK");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.Atendimento)
                        .WithMany(e => e.DetalheAtendimentos)
                        .HasForeignKey(e => e.IdAtendimento)
                        .IsRequired(true);

                entity.HasOne(e => e.Item)
                        .WithMany(e => e.DetalheAtendimentos)
                        .HasForeignKey(e => e.IdItem)
                        .IsRequired(true);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Item_PK");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            //modelBuilder.Entity<Atendimento>()
            //    .HasMany(e => e.DetalhesAtendimento)
            //    .WithOne(e => e.IdAtendimento)
            //    .HasForeignKey(e => e.Id)
            //    .HasPrincipalKey(e => e.IdAtendimento);
        }
    }
}
