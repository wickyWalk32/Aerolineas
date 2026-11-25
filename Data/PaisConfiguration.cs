using Microsoft.CodeAnalysis.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            // Configuración de la tabla y clave primaria
            builder.ToTable("Paises");

            builder.HasKey(pais => pais.Id);

            builder.Property(pais => pais.Id)
                .ValueGeneratedOnAdd();

            builder.Property(pais => pais.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            // Nota: El Seed Data masivo se quitó de acá para evitar scripts SQL gigantescos 
            // que causan timeouts en el arranque. Ahora se inicializa de forma controlada en el DbInitializer.

        }
    }
}