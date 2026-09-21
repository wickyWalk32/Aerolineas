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
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Pasajero> Pasajeros { get; set; }
        public DbSet<Avion> Aviones { get; set; }
        public DbSet<Asiento> Asientos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Vuelo> Vuelos { get; set; }
        public DbSet<Pasaje> Pasajes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<TarjetaCliente> Tarjetas { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
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


            modelBuilder.ApplyConfiguration(new PaisConfiguration());


            modelBuilder.Entity<Usuario>(entity =>
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

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                // Restricción única para Email
                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.Property(e => e.ContraseniaHash)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasMaxLength(20);

                // 1 Usuario > Muchas Reservas

                entity.Navigation(e => e.Reservas)
                        .HasField("_reservas");

                entity.HasData(
                    new Usuario
                    (
                        1, 
                        "Administrador",                // nombre
                        "del sistema",                  // apellido
                        "administrador@email.com",      // email
                        "administrador",                // contrasenia
                        "admin"                         // rol
                    ),
                    new Usuario
                    (
                        2,
                        "Usuario",
                        "del sistema",
                        "usuario@email.com",
                        "usuario",
                        "usuario"
                    ),
                    new Usuario
                    (
                        3,
                        "Pedro",
                        "Gonzalez",
                        "admin@email.com",
                        "admin",
                        "admin"
                    ),
                    new Usuario
                    (
                        4,
                        "María",
                        "Suárez",
                        "usu@email.com",
                        "usu",
                        "usuario"
                    )
                );

            });

            modelBuilder.Entity<Pais>(entity =>
            {
                // Primary Key
                entity.HasKey(entityPais => entityPais.Id);

                entity.Property(entityPais => entityPais.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(entityPais => entityPais.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                // 1 Pais > Muchas ciudades

                entity.Navigation(entityPais => entityPais.Ciudades)
                    .HasField("_ciudades");

            });

            modelBuilder.Entity<Ciudad>(entityCiudad =>
            {
                // Primary Key
                entityCiudad.HasKey(ciudad => ciudad.Id);

                entityCiudad.Property(ciudad => ciudad.Id)
                    .ValueGeneratedOnAdd();

                entityCiudad.Property(ciudad => ciudad.CodigoPostal)
                            .IsRequired()
                            .HasMaxLength(10);

                entityCiudad.Property(ciudad => ciudad.CodigoAeropuerto)
                            .IsRequired()
                            .HasMaxLength(10);

                // 1 Ciudad > 1 Pais

                entityCiudad.HasOne(ciudad => ciudad.Pais)
                            .WithMany(pais => pais.Ciudades)
                            .HasForeignKey(ciudad => ciudad.PaisId);

                // 1 Ciudad > Muchos vuelos (siendo ciudad de origen)

                entityCiudad.HasMany(c => c.VuelosOrigen)
                    .WithOne(v => v.CiudadOrigen)
                    .HasForeignKey(v => v.IdCiudadOrigen)
                    .OnDelete(DeleteBehavior.Restrict);

                entityCiudad.Navigation(e => e.VuelosOrigen)
                    .HasField("_vuelosOrigen");

                // 1 Ciudad > Muchos vuelos (siendo ciudad de destino)

                entityCiudad.HasMany(c => c.VuelosDestino)
                    .WithOne(v => v.CiudadDestino)
                    .HasForeignKey(v => v.IdCiudadDestino)
                    .OnDelete(DeleteBehavior.Restrict);

                entityCiudad.Navigation(e => e.VuelosDestino)
                    .HasField("_vuelosDestino");

                // Datos iniciales (Seed Data)
                entityCiudad.HasData(
                    new Ciudad
                    (1,
                    "Rosario",
                    "2000",
                    "ROS",
                    9
                    )
                );

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
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.NroDocumento)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Tipo)
                    .IsRequired();

                // 1 Pasajero > Muchos Pasajes

                entity.Navigation(e => e.Pasajes)
                    .HasField("_pasajes");

            });

            modelBuilder.Entity<Avion>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200);

                 entity.Property(e => e.Capacidad)
                    .IsRequired();

                // 1 Avion > Muchos Vuelos

                entity.Navigation(e => e.Vuelos)
                    .HasField("_vuelos");

                // 1 Avion > Muchos Asientos

                entity.Navigation(e => e.Asientos)
                    .HasField("_asientos");

            });

            modelBuilder.Entity<Asiento>(entity =>
            {
                // Definimos la Clave Primaria Compuesta (Entidad Débil de Avión)
                entity.HasKey(e => new {e.IdAvion, e.Codigo});

                //entity.HasKey(entityAsiento => entityAsiento.Codigo);
                //entity.Property(entityAsiento => entityAsiento.Codigo).ValueGeneratedOnAdd();

                entity.Property(e => e.Fila)
                    .IsRequired();
                    //.HasMaxLength(1);

                entity.Property(e => e.Columna)
                    .IsRequired();
                    //.HasMaxLength(3);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50);

                // 1 Asiento > 1 Avión

                entity.HasOne(e => e.Avion)
                    .WithMany(a => a.Asientos)
                    .HasForeignKey(e => e.IdAvion);

                // 1 Asiento > Muchos Pasajes

                entity.Navigation(e => e.Pasajes)
                    .HasField("_pasajes");

            });

            modelBuilder.Entity<Servicio>(entityServicio =>
            {
                entityServicio.HasKey(e => e.Id);

                entityServicio.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entityServicio.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                // Restricción única para Nombre
                entityServicio.HasIndex(e => e.Nombre)
                    .IsUnique();

                entityServicio.Property(e => e.Descripción)
                    .IsRequired()
                    .HasMaxLength(200);

                entityServicio.Property(e => e.Precio)
                    .IsRequired();

                // 1 Servicio > Muchos Pasajes

                entityServicio.Navigation(e => e.Pasajes)
                    .HasField("_pasajes");

                entityServicio.HasData(
                    new Servicio
                    (
                        1,                                                                  // id
                        "Mantas",                                                           // nombre
                        "Servicio de 1 manta por persona para abrigo durante el vuelo.",    // descripción
                        (decimal)116.70                                                     // precio
                    ),
                    new Servicio
                    (
                        2,
                        "Comida",
                        "Una comida a eleción por persona durante el vuelo.",
                        (decimal)150.00

                    )
                );
            });

            modelBuilder.Entity<Vuelo>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Id).ValueGeneratedOnAdd();

                    entity.Property(e => e.FechaHoraVuelo)
                        .IsRequired();

                    entity.Property(e => e.Aerolinea)
                        .IsRequired()
                        .HasMaxLength(100);

                    entity.Property(e => e.Precio)
                        .IsRequired();

                    // 1 Vuelo > 1 Ciudad de Origen
                    entity.HasOne(e => e.CiudadOrigen)
                        .WithMany(c => c.VuelosOrigen)          // ¡Acá conectamos con la colección espejo de Ciudad!
                        .HasForeignKey(e => e.IdCiudadOrigen)   // Coincide con tu propiedad IdCiudadOrigen
                        .OnDelete(DeleteBehavior.Restrict);     // Evita borrados en cascada peligrosos

                    // 1 Vuelo > 1 Ciudad de Destino
                    entity.HasOne(e => e.CiudadDestino)
                        .WithMany(c => c.VuelosDestino)         // ¡Acá conectamos con la otra colección espejo de Ciudad!
                        .HasForeignKey(e => e.IdCiudadDestino)  // Coincide con tu propiedad IdCiudadDestino
                        .OnDelete(DeleteBehavior.Restrict);     // Evita borrados en cascada peligrosos

                    // 1 Vuelo > 1 Avion
                    entity.HasOne(e => e.Avion)
                        .WithMany(a => a.Vuelos)
                        .HasForeignKey(e => e.IdAvion)
                        .OnDelete(DeleteBehavior.Restrict);

                    // 1 Vuelo > Muchas Reservas (Mapeo explícito del campo privado / Backing Field)
                    // Como estamos aplicando un diseño profesional y encapsulado (DDD), EF Core necesita que le digamos: "Ey, cuando
                    // traigas las reservas de la base de datos, mételas a la fuerza dentro de este campo privado _reservas".
                    entity.Navigation(e => e.Reservas)
                        .HasField("_reservas");

                });

                modelBuilder.Entity<Pasaje>(entity =>
                {
                    entity.HasKey(e => e.Id);

                    entity.Property(e => e.Id)
                        .ValueGeneratedOnAdd();

                    entity.Property(e => e.Estado)
                        .IsRequired()
                        .HasMaxLength(50);

                    // 1 Pasaje > 1 Pasajero

                    entity.HasOne(e => e.Pasajero)
                        .WithMany(p => p.Pasajes)
                        .HasForeignKey(e => e.IdPasajero);

                    // 1 Pasaje > 1 Asiento

                    entity.HasOne(e => e.Asiento)
                        .WithMany(a => a.Pasajes)
                        .HasForeignKey(e => new {e.IdAvion, e.CodigoAsiento});

                    // 1 Pasaje > Muchos Servicios

                    entity.Navigation(e => e.Servicios)
                        .HasField("_servicios");

                });

                modelBuilder.Entity<Reserva>(entity =>
                {
                    entity.HasKey(e => e.Id);

                    entity.Property(e => e.Id)
                        .ValueGeneratedOnAdd();

                    entity.Property(e => e.FechaHoraReserva)
                        .IsRequired();

                    // 1 Reserva > 1 Usuario

                    entity.HasOne(e => e.Usuario)
                        .WithMany(u => u.Reservas)
                        .HasForeignKey(e => e.UsuarioId);

                    // 1 Reserva > 1 TarjetaCliente

                    entity.HasOne(e => e.TarjetaCliente)
                        .WithMany(t => t.Reservas)
                        .HasForeignKey(e => e.IdTarjetaCliente);

                    // 1 Reserva > Muchos Pasajes

                    entity.Navigation(e => e.Pasajes)
                        .HasField("_pasajes");

                });

                modelBuilder.Entity<TarjetaCliente>(entity =>
                {
                    entity.HasKey(e => e.Id);

                    entity.Property(e => e.Id)
                        .ValueGeneratedOnAdd();

                    entity.Property(e => e.UltimosCuatroDigitos)
                        .IsRequired()
                        .HasMaxLength(4);

                    entity.Property(e => e.FechaVencimiento)
                        .IsRequired();

                    // 1 TarjetaCliente > Muchas Reservas

                    entity.Navigation(e => e.Reservas)
                        .HasField("_reservas");

                });

        }
    }
}
