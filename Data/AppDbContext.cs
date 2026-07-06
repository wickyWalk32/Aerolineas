using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            // SeedInitialData();
        }
        internal AppDbContext()
        {
            this.Database.EnsureCreated();
            // SeedInitialData();
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ContraseniaHash)
                    .IsRequired()
                    .HasMaxLength(100);

                // Restricción única para Email
                entity.HasIndex(e => e.Email)
                    .IsUnique();


                entity.Navigation(e => e.Reservas)
                    .HasField("_reservas");

                entity.HasMany(e => e.Reservas)
                    .WithOne(r => r.Usuario)
                    .HasForeignKey(r => r.UsuarioId);
            });


            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FechaHoraReserva)
                    .IsRequired();


                entity.Navigation(e => e.Usuario)
                    .HasField("_usuario");

                entity.HasOne(e=> e.Usuario)
                    .WithMany()
                    .HasForeignKey(r => r.UsuarioId);

            });
        }

        }
}
