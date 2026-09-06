using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data
{
    // Esta clase representa la conexion con la base de datos en SQL Server

    public class AppDbContext : DbContext
    {
        //DbSets
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Ciudad> Cuidades { get; set; }
        public DbSet<Pasajero> Pasajeros { get; set; }
        public DbSet<Pasaje> Pasajes { get; set; }
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

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100);

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
                
                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasMaxLength(20);

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

                entity.Navigation(e => e.Pasajes)
                    .HasField("_pasajes");

                entity.HasMany(e => e.Pasajes)
                    .WithOne(p => p.Reserva)
                    .HasForeignKey(p => p.ReservaId);
            });

            modelBuilder.Entity<Pasaje>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Estado)
                    .IsRequired();

                entity.Navigation(e => e.Reserva)
                    .HasField("_reserva");

                entity.HasOne(e => e.Reserva)
                    .WithMany()
                    .HasForeignKey(p => p.ReservaId);

                entity.Navigation(e => e.Pasajero)
                    .HasField("_pasajero");

                entity.HasOne(e => e.Pasajero)
                    .WithOne()
                    .HasForeignKey<Pasaje>(p => p.PasajeroId);
            });

            modelBuilder.Entity<Pasajero>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TipoDocumento)
                    .IsRequired();

                entity.Property(e => e.NroDocumento)
                    .IsRequired();

                entity.Property(e => e.Tipo)
                    .IsRequired();

            });

            modelBuilder.Entity<Pais>(entity =>
            {
                // Primary Key
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Ciudad>(entityCiudad =>
            {
                // Primary Key
                entityCiudad.HasKey(ciudad => ciudad.Id);

                // Relación Pais -> Ciudades (1 a muchos)
                entityCiudad.HasOne(ciudad => ciudad.Pais)
                            .WithMany(pais => pais.Ciudades)
                            .HasForeignKey(ciudad => ciudad.IdPais);

            });

        }
    }
}
