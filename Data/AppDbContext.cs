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
        public DbSet<Vuelo> Vuelos { get; set; }
        public DbSet<Avion> Aviones { get; set; }
        public DbSet<Asiento> Asientos { get; set; }

        internal AppDbContext()
        {
            this.Database.EnsureCreated();
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
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

                entity.HasData(
                    new Usuario
                    {
                        Id = 1, 
                        Nombre = "alumno",
                        Apellido = "net",
                        Email = "alum@email.com",
                        ContraseniaHash = "net123",
                        Rol = "admin"
                    },
                    new Usuario
                    {
                        Id = 2, 
                        Nombre = "usuario",
                        Apellido = "comun",
                        Email = "usu@email.com",
                        ContraseniaHash = "net321",
                        Rol = "usuario"
                    }
                );

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
                    .HasForeignKey(e => e.ReservaId);
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
                    .HasForeignKey(p => p.ReservaId).OnDelete(DeleteBehavior.NoAction);

                entity.Navigation(e => e.Pasajero)
                    .HasField("_pasajero");

                entity.HasOne(e => e.Pasajero)
                    .WithOne()
                    .HasForeignKey<Pasaje>(p => p.PasajeroId);

                entity.Navigation(e => e.Vuelo)
                    .HasField("_vuelo");
                entity.HasOne(e => e.Vuelo)
                    .WithMany()
                    .HasForeignKey(e => e.VueloId).OnDelete(DeleteBehavior.NoAction);


                entity.HasOne(e => e.Asiento)
                    .WithMany()
                    .HasForeignKey(e => new {e.AvionId,e.AsientoCodigo});

                entity.Navigation(e => e.Asiento)
                    .HasField("_asiento");
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
                entity.HasKey(entityPais => entityPais.Id);
                entity.Property(entityPais => entityPais.Id).ValueGeneratedOnAdd();

                entity.Property(entityPais => entityPais.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Navigation(entityPais => entityPais.Ciudades)
                    .HasField("_ciudades");

                entity.HasData(
                    new { Id = 1, Nombre = "Argentina" },
                    new { Id = 2, Nombre = "Brasil" });
            });

            modelBuilder.Entity<Ciudad>(entityCiudad =>
            {
                // Primary Key
                entityCiudad.HasKey(ciudad => ciudad.Id);
                entityCiudad.Property(ciudad => ciudad.Id).ValueGeneratedOnAdd();

                entityCiudad.Property(ciudad => ciudad.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                // Relación Pais -> Ciudades (1 a muchos)
                entityCiudad.HasOne(ciudad => ciudad.Pais)
                            .WithMany(pais => pais.Ciudades)
                            .HasForeignKey(ciudad => ciudad.PaisId);

                entityCiudad.Navigation(ciudad => ciudad.Pais)
                    .HasField("_pais");

            });

            modelBuilder.Entity<Asiento>(entity =>
            {
                // Primary Key
                entity.HasKey(entityAsiento => entityAsiento.Codigo);
                entity.Property(entityAsiento => entityAsiento.Codigo).ValueGeneratedOnAdd();

                entity.Property(entityPais => entityPais.Fila)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(entityPais => entityPais.Columna)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(entityPais => entityPais.Estado)
                    .IsRequired()
                    .HasMaxLength(50);

            });

            modelBuilder.Entity<Vuelo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(v => v.Origen)
                    .WithMany()
                    .HasForeignKey(v => v.OrigenId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(v => v.Destino)
                    .WithMany()
                    .HasForeignKey(v => v.DestinoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<Avion>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.EstadoDisponibilidad)
                    .IsRequired()
                    .HasMaxLength(30);

                 entity.Property(e => e.Capacidad)
                    .IsRequired();

                entity.Navigation(e => e.Asientos)
                    .HasField("_asientos");

            });

            modelBuilder.Entity<Asiento>(entity =>
            {
                entity.HasKey(e => new {  e.AvionId, e.Codigo});

                entity.Property(e => e.Fila)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Columna)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(e => e.Avion)
                    .WithMany(a => a.Asientos)
                    .HasForeignKey(e => e.AvionId);

                entity.Navigation(e => e.Avion)
                    .HasField("_avion");
            });
            modelBuilder.Entity<Vuelo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.TiempoSalida)
                    .IsRequired();

                entity.Property(e => e.TiempoLlegada)
                    .IsRequired();

                entity.Property(e => e.Precio)
                   .IsRequired();

                entity.HasOne(e=>e.Origen)
                    .WithMany()
                    .HasForeignKey(e => e.OrigenId).OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e=>e.Destino)
                    .WithMany()
                    .HasForeignKey(e => e.DestinoId).OnDelete(DeleteBehavior.NoAction);

                entity.Navigation(e => e.Origen)
                    .HasField("_origen");

                entity.Navigation(e => e.Destino)
                    .HasField("_destino");             
            });
        }
    }
}
