using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{

    public static class DbInitializer
    {
        public static async Task InitializeAsync(AppDbContext context)
        {

            // Si ya existen países, asumimos que la base ya fue poblada y no hacemos nada (inicio instantáneo)
            if (await context.Paises.AnyAsync())
            {
                return;
            }

            // Si no existen, insertamos los países de forma eficiente (luego de ya creada la base de datos en el EnsureCreatedAsync)
            var paisesIniciales = new List<Pais>
            {
                /* Id (autoincremental), Nombre */

                new Pais("Afganistán"),
                new Pais("Albania"),
                new Pais("Alemania"),
                new Pais("Andorra"),
                new Pais("Angola"),
                new Pais("Antigua y Barbuda"),
                new Pais("Arabia Saudita"),
                new Pais("Argelia"),
                new Pais("Argentina"),
                new Pais("Armenia"),
                new Pais("Australia"),
                new Pais("Austria"),
                new Pais("Azerbaiyán"),
                new Pais("Bahamas"),
                new Pais("Bangladés"),
                new Pais("Barbados"),
                new Pais("Baréin"),
                new Pais("Bélgica"),
                new Pais("Belice"),
                new Pais("Benín"),
                new Pais("Bielorrusia"),
                new Pais("Birmania (Myanmar)"),
                new Pais("Bolivia"),
                new Pais("Bosnia y Herzegovina"),
                new Pais("Botsuana"),
                new Pais("Brasil"),
                new Pais("Brunéi"),
                new Pais("Bulgaria"),
                new Pais("Burkina Faso"),
                new Pais("Burundi"),
                new Pais("Bután"),
                new Pais("Cabo Verde"),
                new Pais("Camboya"),
                new Pais("Camerún"),
                new Pais("Canadá"),
                new Pais("Catar"),
                new Pais("Chad"),
                new Pais("Chile"),
                new Pais("China"),
                new Pais("Chipre"),
                new Pais("Ciudad del Vaticano"),
                new Pais("Colombia"),
                new Pais("Comoras"),
                new Pais("Corea del Norte"),
                new Pais("Corea del Sur"),
                new Pais("Costa de Marfil"),
                new Pais("Costa Rica"),
                new Pais("Croacia"),
                new Pais("Cuba"),
                new Pais("Dinamarca"),
                new Pais("Dominica"),
                new Pais("Ecuador"),
                new Pais("Egipto"),
                new Pais("El Salvador"),
                new Pais("Emiratos Árabes Unidos"),
                new Pais("Eritrea"),
                new Pais("Eslovaquia"),
                new Pais("Eslovenia"),
                new Pais("España"),
                new Pais("Estados Unidos"),
                new Pais("Estonia"),
                new Pais("Etiopía"),
                new Pais("Filipinas"),
                new Pais("Finlandia"),
                new Pais("Fiyi"),
                new Pais("Francia"),
                new Pais("Gabón"),
                new Pais("Gambia"),
                new Pais("Georgia"),
                new Pais("Ghana"),
                new Pais("Granada"),
                new Pais("Grecia"),
                new Pais("Guatemala"),
                new Pais("Guinea"),
                new Pais("Guinea-Bisáu"),
                new Pais("Guinea Ecuatorial"),
                new Pais("Guyana"),
                new Pais("Haití"),
                new Pais("Honduras"),
                new Pais("Hungría"),
                new Pais("India"),
                new Pais("Indonesia"),
                new Pais("Irak"),
                new Pais("Irán"),
                new Pais("Irlanda"),
                new Pais("Islandia"),
                new Pais("Islas Marshall"),
                new Pais("Islas Salomón"),
                new Pais("Israel"),
                new Pais("Italia"),
                new Pais("Jamaica"),
                new Pais("Japón"),
                new Pais("Jordania"),
                new Pais("Kazajistán"),
                new Pais("Kenia"),
                new Pais("Kirguistán"),
                new Pais("Kiribati"),
                new Pais("Kuwait"),
                new Pais("Laos"),
                new Pais("Lesoto"),
                new Pais("Letonia"),
                new Pais("Líbano"),
                new Pais("Liberia"),
                new Pais("Libia"),
                new Pais("Liechtenstein"),
                new Pais("Lituania"),
                new Pais("Luxemburgo"),
                new Pais("Macedonia del Norte"),
                new Pais("Madagascar"),
                new Pais("Malasia"),
                new Pais("Malaui"),
                new Pais("Maldivas"),
                new Pais("Malí"),
                new Pais("Malta"),
                new Pais("Marruecos"),
                new Pais("Mauricio"),
                new Pais("Mauritania"),
                new Pais("México"),
                new Pais("Micronesia"),
                new Pais("Moldavia"),
                new Pais("Mónaco"),
                new Pais("Mongolia"),
                new Pais("Montenegro"),
                new Pais("Mozambique"),
                new Pais("Namibia"),
                new Pais("Nauru"),
                new Pais("Nepal"),
                new Pais("Nicaragua"),
                new Pais("Níger"),
                new Pais("Nigeria"),
                new Pais("Noruega"),
                new Pais("Nueva Zelanda"),
                new Pais("Omán"),
                new Pais("Países Bajos"),
                new Pais("Pakistán"),
                new Pais("Palaos"),
                new Pais("Palestina"),
                new Pais("Panamá"),
                new Pais("Papúa Nueva Guinea"),
                new Pais("Paraguay"),
                new Pais("Perú"),
                new Pais("Polonia"),
                new Pais("Portugal"),
                new Pais("Reino Unido"),
                new Pais("República Centroafricana"),
                new Pais("República Checa"),
                new Pais("República del Congo"),
                new Pais("República Democrática del Congo"),
                new Pais("República Dominicana"),
                new Pais("Ruanda"),
                new Pais("Rumania"),
                new Pais("Rusia"),
                new Pais("Samoa"),
                new Pais("San Cristóbal y Nieves"),
                new Pais("San Marino"),
                new Pais("San Vicente y las Granadinas"),
                new Pais("Santa Lucía"),
                new Pais("Santo Tomé y Príncipe"),
                new Pais("Senegal"),
                new Pais("Serbia"),
                new Pais("Seychelles"),
                new Pais("Sierra Leona"),
                new Pais("Singapur"),
                new Pais("Siria"),
                new Pais("Somalia"),
                new Pais("Sri Lanka"),
                new Pais("Suazilandia (Esuatini)"),
                new Pais("Sudáfrica"),
                new Pais("Sudán"),
                new Pais("Sudán del Sur"),
                new Pais("Suecia"),
                new Pais("Suiza"),
                new Pais("Surinam"),
                new Pais("Tailandia"),
                new Pais("Taiwán"),
                new Pais("Tanzania"),
                new Pais("Tayikistán"),
                new Pais("Timor Oriental"),
                new Pais("Togo"),
                new Pais("Tonga"),
                new Pais("Trinidad y Tobago"),
                new Pais("Túnez"),
                new Pais("Turkmenistán"),
                new Pais("Turquía"),
                new Pais("Tuvalu"),
                new Pais("Ucrania"),
                new Pais("Uganda"),
                new Pais("Uruguay"),
                new Pais("Uzbekistán"),
                new Pais("Vanuatu"),
                new Pais("Venezuela"),
                new Pais("Vietnam"),
                new Pais("Yemen"),
                new Pais("Yibuti"),
                new Pais("Zambia"),
                new Pais("Zimbabue")

            };

            await context.Paises.AddRangeAsync(paisesIniciales);
            await context.SaveChangesAsync();

            // Insertar Ciudades vinculadas a los países creados
            var ciudadesIniciales = new List<Ciudad>
            {
                /* Id (autoincremental), Nombre, CodigoPostal, CodigoAeropuerto, PaisId */

                new Ciudad(/* 1,*/ "Rosario"             , "2000"        , "ROS", 9),
                new Ciudad(/* 2,*/ "Buenos Aires"        , "1802"        , "EZE", 9),
                new Ciudad(/* 3,*/ "Córdoba"             , "5000"        , "COR", 9),
                new Ciudad(/* 4,*/ "San Pablo"           , "07190-902"   , "GRU", 26),
                new Ciudad(/* 5,*/ "Nueva York"          , "11430"       , "JFK", 60),
                new Ciudad(/* 6,*/ "Los Ángeles"         , "90045"       , "LAX", 60),
                new Ciudad(/* 7,*/ "Madrid"              , "28042"       , "MAD", 59),
                new Ciudad(/* 8,*/ "Lima"                , "07031"       , "LIM", 141),
                new Ciudad(/* 9,*/ "Roma"                , "00054"       , "FCO", 90),
                new Ciudad(/*10,*/ "Pekín"               , "100621"      , "PEK", 39),
                new Ciudad(/*11,*/ "Tokio"               , "282-8601"    , "NRT", 92),
                new Ciudad(/*12,*/ "Dubái"               , "2525"        , "DBX", 55),
                new Ciudad(/*13,*/ "París"               , "95700"       , "CDG", 66),
                new Ciudad(/*14,*/ "Sídney"              , "2020"        , "SYD", 11),
                new Ciudad(/*15,*/ "Ciudad del Cabo"     , "7490"        , "CPT", 168),
                new Ciudad(/*16,*/ "Miami"               , "33101"       , "MIA", 60)
            };

            await context.Set<Ciudad>().AddRangeAsync(ciudadesIniciales);
            await context.SaveChangesAsync();

            // Insertar Aviones (10 ejemplos ficticios) con sus asientos

            /* 
             * Se les da capacidades pequenias para poder probar el filtro por capacidad (sin tener que comprar grandes cantidades
             * de pasajes). Chek.
             * 
             * Método CrearAvionConAsientos crea automáticamente todos los Asientos del Avion según su atributo "Capacidad" y los da 
             * de alta en la base de datos.
             */

            var avionesIniciales = new List<Avion>
            {
                /* Id (autoincremental), Descripcion, Capacidad, EstadoDisponibilidad */

                CrearAvionConAsientos(/* 1,*/ "AeroJet 320"       , 15 , "Disponible"   ),
                CrearAvionConAsientos(/* 2,*/ "Airbus A220-300"   , 12 , "Disponible"   ),
                CrearAvionConAsientos(/* 3,*/ "Apex A380"         , 52 , "Disponible"   ),
                CrearAvionConAsientos(/* 4,*/ "Breeze ATR72"      , 23 , "No disponible"),
                CrearAvionConAsientos(/* 5,*/ "EcoJet Q400"       , 42 , "Disponible"   ),
                CrearAvionConAsientos(/* 6,*/ "MetroExpress E190" ,  9 , "Disponible"   ),
                CrearAvionConAsientos(/* 7,*/ "Oceanic 350"       , 36 , "No disponible"),
                CrearAvionConAsientos(/* 8,*/ "SkyLinx 737"       , 10 , "Disponible"   ),
                CrearAvionConAsientos(/* 9,*/ "StratoCruiser 787" , 21 , "Disponible"   ),
                CrearAvionConAsientos(/*10,*/ "Titan 777"         , 29 , "Disponible"   )
            };

            await context.Set<Avion>().AddRangeAsync(avionesIniciales);
            await context.SaveChangesAsync();

            // Insertar Servicios iniciales
            var serviciosIniciales = new List<Servicio>
            {
                /* Id (autoincremental), Nombre, Descripcion, Precio */

                new Servicio
                (
                    //1,
                    "Snacks",
                    "Una bebida a eleción por persona durante el vuelo.",
                    (decimal)14999.00
                ),
                new Servicio
                (
                    //2,
                    "Comida",
                    "Una comida (desayuno, almuerzo o cena) a eleción por persona durante el vuelo." /*+ " Se contemplan " +
                    "opciones por alergias, dietas o restricciones alimentarias antes del vuelo"*/,
                    (decimal)14999.00
                ),
                new Servicio
                (
                    //3,
                    "Bebida",
                    "Una bebida a eleción por persona durante el vuelo.",
                    (decimal)20500.00
                ),
                new Servicio
                (
                    //4,
                    "Descanso y abrigo",
                    "Servicio de 1 manta, 1 almohada, 1 antifaz y tapones para los oidos por persona durante el vuelo.",
                    (decimal)7800.00
                ),
                new Servicio
                (
                    //5,
                    "Pantallas",
                    "Películas, series, música, juegos y prensa digital, ya sea en pantallas individuales o mediante streaming.",
                    (decimal)12900.00
                ),
                new Servicio
                (
                    //6,
                    "Wi-Fi a bordo",
                    "Conexión a internet para mensajería o navegación.",
                    (decimal)14900.00
                ),
                new Servicio
                (
                    //7,
                    "Tripulación de cabina",
                    "Atención durante el viaje, ayuda ante emergencias médicas básicas y coordinación de asistencia.",
                    (decimal)500.00
                )

            };

            await context.Set<Servicio>().AddRangeAsync(serviciosIniciales);
            await context.SaveChangesAsync();

            // Insertar Vuelos iniciales

            /* Info:
             * > Aerolíneas: Aerolíneas Argentinas, Air France, American Airlines, Emirates, Flybondi, Qatar Airways, LATAM Airlines
             * > 2 vuelos el 2026/12/03 y el 2026/12/09
             * > Buenos paises   para probar filtro de país   de origen:  Argentina, Estados Unidos
             * > Buenas ciudades para probar filtro de ciudad de origen:  Rosario, Los Ángeles
             * > Buenos paises   para probar filtro de país   de destino: Argentina, Brasil, Perú
             * > Buenas ciudades para probar filtro de ciudad de destino: San Pablo, Lima
             * > Buenos vuelos   para probar filtro de capacidad (ya que sus aviones asignados tienen poca capacidad): ?
             *
             * > Al aplicar el filtro de capacidad en 10, los aviones que tengan menos de 10 de capacidad no deben mostrarse: deben
             *   desaparecer. En este caso Sidney-Madrid y Rosario-San Pablo tienen el avión 6 (capacidad = 9) y deben no mostrarse al
             *   ser filtrados. > Comprobar en sistema funcionando (con semilla inicial).
            */

            var vuelosIniciales = new List<Vuelo>
            {
                /* Id (autoincremental), FechaHoraVuelo, Precio, IdCiudadOrigen, IdCiudadDestino, IdAvion */

                //1  Argentina     :Rosario       - Argentina : Buenos Aires
                new Vuelo(new DateTime(2026, 12, 08, 10, 30, 0), "Aerolíneas Argentinas", (decimal)125000.99,  1,  2,  9),

                //2  Estados Unidos: Los Ángeles  - Emiratos Árabes Unidos: Dubái
                new Vuelo(new DateTime(2026, 12, 03, 14, 50, 0), "Qatar Airways"        , (decimal)372000.99,  6, 12,  3),

                //3  Estados Unidos: Miami        - Brasil   : San Pablo
                new Vuelo(new DateTime(2026, 12, 09, 11, 30, 0), "American Airlines"    , (decimal)256000.99, 16,  4,  2),
                
                //4  Argentina     : Buenos Aires - Argentina:  Rosario
                new Vuelo(new DateTime(2027, 01, 16, 08, 30, 0), "Aerolíneas Argentinas", (decimal)125000.99,  2,  1,  1),
                
                //5  Sudáfrica: Ciudad del Cabo   - Emiratos Árabes Unidos: Dubái
                new Vuelo(new DateTime(2026, 12, 23, 14, 30, 0), "Qatar Airways"        , (decimal)196000.00, 15, 12,  3),
                
                //6  Francia       : París        - Perú     : Lima
                new Vuelo(new DateTime(2026, 12, 09, 09, 20, 0), "Aerolíneas Argentinas", (decimal)215000.00, 13,  8,  3),
                
                //7  Argentina     : Rosario      - Brasil   : San Pablo
                new Vuelo(new DateTime(2026, 12, 11, 22, 10, 0), "Aerolíneas Argentinas", (decimal)153000.00,  1,  4,  6),
                
                //8  Estados Unidos: Los Ángeles  - Italia   : Roma
                new Vuelo(new DateTime(2026, 12, 02, 14, 30, 0), "Qatar Airways"        , (decimal)305000.00,  6,  9,  5),
                
                //9  China         : Pekín        - Japón    : Tokio
                new Vuelo(new DateTime(2026, 12, 03, 17, 30, 0), "Qatar Airways"        , (decimal)140000.99, 10, 11, 10),
                
                //10 Estados Unidos: Nueva York   - Argentina: Córdoba
                new Vuelo(new DateTime(2027, 01, 05, 17, 00, 0), "Aerolíneas Argentinas", (decimal)184000.99,  5,  3,  9),
                
                //11 Estados Unidos: Los Ángeles  - Perú     : Lima
                new Vuelo(new DateTime(2026, 11, 30, 14, 00, 0), "American Airlines"    , (decimal)175000.99,  6,  8,  8),
                
                //12 Australia     : Sidney       - Espania  : Madrid
                new Vuelo(new DateTime(2027, 01, 12, 18, 05, 0), "Aerolíneas Argentinas", (decimal)233000.99, 14,  7,  6)
            };

            await context.Set<Vuelo>().AddRangeAsync(vuelosIniciales);
            await context.SaveChangesAsync();

            // Insertar Pasajeros iniciales
            var pasajerosIniciales = new List<Pasajero>
            {
                /* Id (autoincremental), Nombre, Apellido, TipoDocumento, NroDocumento, Tipo */

                new Pasajero(/* 1, */ "Marta"       , "Díaz"        , "DNI"                         , "35488657", "Mayor"),
                new Pasajero(/* 2, */ "Miguel"      , "Rodríguez"   , "DNI"                         , "53444857", "Menor"),
                new Pasajero(/* 3, */ "Diego"       , "Fernández"   , "DNI"                         , "39111222", "Mayor"),
                new Pasajero(/* 4, */ "Facundo"     , "Sanchez"     , "Libreta de Enrolamiento (LE)", "28222333", "Mayor"),
                new Pasajero(/* 5, */ "Matías"      , "García"      , "DNI"                         , "41333444", "Mayor"),
                new Pasajero(/* 6, */ "Joaquín"     , "Días"        , "DNI (Extranjero)"            , "35555777", "Mayor"),
                new Pasajero(/* 7, */ "Florencia"   , "Acosta"      , "DNI"                         , "34666333", "Mayor"),
                new Pasajero(/* 8, */ "Armando"     , "Sanchez"     , "DNI"                         , "50999555", "Menor"),
                new Pasajero(/* 9, */ "José"        , "Sanchez"     , "DNI"                         , "31333666", "Mayor"),
                new Pasajero(/* 10,*/ "Enrique"     , "Gonzáles"    , "Libreta Cívica (LC)"         , "34222111", "Mayor"),
                new Pasajero(/* 11,*/ "María"       , "Silva"       , "DNI"                         , "39111777", "Mayor"),
                new Pasajero(/* 12,*/ "Clara"       , "Torres"      , "DNI"                         , "28555333", "Mayor"),
                new Pasajero(/* 13,*/ "Carlos"      , "Rodríguez"   , "DNI"                         , "41756765", "Mayor"),
                new Pasajero(/* 14,*/ "Sebastián"   , "Ramírez"     , "DNI"                         , "35333555", "Mayor"),
                new Pasajero(/* 15,*/ "Marcos"      , "Benítez"     , "DNI (Extranjero)"            , "36123123", "Mayor"),
                new Pasajero(/* 16,*/ "Mario"       , "Pérez"       , "DNI"                         , "35456576", "Mayor"),
                new Pasajero(/* 17,*/ "Sandra"      , "Medina"      , "DNI"                         , "39234456", "Mayor"),
                new Pasajero(/* 18,*/ "Miguel"      , "Días"        , "DNI"                         , "28234234", "Mayor"),
                new Pasajero(/* 19,*/ "Dalma"       , "Martínez"    , "DNI"                         , "34111444", "Mayor"),
                new Pasajero(/* 20,*/ "Damián"      , "Fernández"   , "DNI"                         , "31555888", "Mayor"),
                new Pasajero(/* 21,*/ "Matías"      , "García"      , "DNI"                         , "34888777", "Mayor"),
                new Pasajero(/* 22,*/ "Nicolás"     , "Sanchez"     , "DNI (Extranjero)"            , "51444666", "Menor"),
                new Pasajero(/* 23,*/ "Ramona"      , "Acosta"      , "DNI"                         , "35222777", "Mayor"),
                new Pasajero(/* 24,*/ "Ezequiel"    , "Sosa"        , "DNI"                         , "47666777", "Menor"),
                new Pasajero(/* 25,*/ "Tatiana"     , "Domínguez"   , "Libreta Cívica (LC)"         , "36666222", "Mayor"),
                new Pasajero(/* 26,*/ "Ramon"       , "Días"        , "DNI"                         , "41888333", "Mayor"),
                new Pasajero(/* 27,*/ "Ángel"       , "Ortiz"       , "DNI"                         , "31333666", "Mayor"),
                new Pasajero(/* 28,*/ "Rosa"        , "Gómez"       , "DNI"                         , "35234634", "Mayor"),
                new Pasajero(/* 29,*/ "Ricardo"     , "López"       , "DNI"                         , "28111222", "Mayor"),
                new Pasajero(/* 30,*/ "Sergio"      , "Ruiz"        , "Libreta de Enrolamiento (LE)", "36222333", "Mayor"),
                new Pasajero(/* 31,*/ "Juan"        , "Pérez"       , "DNI"                         , "39333444", "Mayor"),
                new Pasajero(/* 32,*/ "Sofía"       , "Pereyra"     , "DNI"                         , "28555666", "Mayor"),
                new Pasajero(/* 33,*/ "Pedro"       , "Romero"      , "DNI (Extranjero)"            , "47777788", "Menor"),
                new Pasajero(/* 34,*/ "Mariana"     , "Rojas"       , "DNI"                         , "41333777", "Mayor"),
                new Pasajero(/* 35,*/ "Briza"       , "Gómez"       , "DNI (Extranjero)"            , "36888333", "Mayor"),
                new Pasajero(/* 36,*/ "Carla"       , "Sosa"        , "DNI"                         , "31445445", "Mayor"),
                new Pasajero(/* 37,*/ "Hector"      , "García"      , "DNI"                         , "35776776", "Mayor"),
                new Pasajero(/* 38,*/ "Orlando"     , "Sanchez"     , "DNI"                         , "49888777", "Menor"),
                new Pasajero(/* 39,*/ "Mario"       , "Ramírez"     , "Libreta Cívica (LC)"         , "39555111", "Mayor"),
                new Pasajero(/* 40,*/ "Sabrina"     , "Álvarez"     , "DNI"                         , "36090909", "Mayor"),
                new Pasajero(/* 41,*/ "Marta"       , "Molina"      , "DNI"                         , "45384657", "Mayor"),
                new Pasajero(/* 42,*/ "Miguel"      , "Quiroga"     , "DNI"                         , "51222857", "Menor"),
                new Pasajero(/* 43,*/ "Diego"       , "Castro"      , "DNI"                         , "24165423", "Mayor"),
                new Pasajero(/* 44,*/ "Facundo"     , "Giménez"     , "Libreta de Enrolamiento (LE)", "23444554", "Mayor"),
                new Pasajero(/* 45,*/ "Matías"      , "Álvarez"     , "DNI"                         , "36111432", "Mayor"),
                new Pasajero(/* 46,*/ "Joaquín"     , "Suárez"      , "DNI (Extranjero)"            , "25555444", "Mayor"),
                new Pasajero(/* 47,*/ "Florencia"   , "Herrera"     , "DNI"                         , "27444666", "Mayor"),
                new Pasajero(/* 48,*/ "Armando"     , "Molina"      , "DNI"                         , "51876987", "Menor"),
                new Pasajero(/* 49,*/ "José"        , "Aguirre"     , "DNI"                         , "33677889", "Mayor"),
                new Pasajero(/* 50,*/ "Enrique"     , "Vera"        , "Libreta Cívica (LC)"         , "39122334", "Mayor"),
                new Pasajero(/* 51,*/ "María"       , "Muñoz"       , "DNI"                         , "39323232", "Mayor"),
                new Pasajero(/* 52,*/ "Clara"       , "Álvarez"     , "DNI"                         , "26543534", "Mayor"),
                new Pasajero(/* 53,*/ "Carlos"      , "Quiroga"     , "DNI"                         , "42654654", "Mayor"),
                new Pasajero(/* 54,*/ "Sebastián"   , "Flores"      , "DNI"                         , "41765765", "Mayor"),
                new Pasajero(/* 55,*/ "Marcos"      , "Peralta"     , "DNI (Extranjero)"            , "42987987", "Mayor"),
                new Pasajero(/* 56,*/ "Mario"       , "Castro"      , "DNI"                         , "23444555", "Mayor"),
                new Pasajero(/* 57,*/ "Sandra"      , "Gutiérrez"   , "DNI"                         , "33555666", "Mayor"),
                new Pasajero(/* 58,*/ "Miguel"      , "Ojeda"       , "DNI"                         , "34111222", "Mayor"),
                new Pasajero(/* 59,*/ "Dalma"       , "Godoy"       , "DNI"                         , "22411353", "Mayor"),
                new Pasajero(/* 60,*/ "Damián"      , "Álvarez"     , "DNI"                         , "32833445", "Mayor"),
                new Pasajero(/* 61,*/ "Matías"      , "Vera"        , "DNI"                         , "37711113", "Mayor"),
                new Pasajero(/* 62,*/ "Nicolás"     , "Herrera"     , "DNI (Extranjero)"            , "54612122", "Menor"),
                new Pasajero(/* 63,*/ "Ramona"      , "Suárez"      , "DNI"                         , "32773434", "Mayor"),
                new Pasajero(/* 64,*/ "Ezequiel"    , "Giménez"     , "DNI"                         , "48765656", "Menor"),
                new Pasajero(/* 65,*/ "Tatiana"     , "Ojeda"       , "Libreta Cívica (LC)"         , "32299987", "Mayor"),
                new Pasajero(/* 66,*/ "Ramon"       , "Álvarez"     , "DNI"                         , "27334445", "Mayor"),
                new Pasajero(/* 67,*/ "Ángel"       , "Quiroga"     , "DNI"                         , "37611133", "Mayor"),
                new Pasajero(/* 68,*/ "Rosa"        , "Gutiérrez"   , "DNI"                         , "33434543", "Mayor"),
                new Pasajero(/* 69,*/ "Ricardo"     , "Aguirre"     , "DNI"                         , "36212345", "Mayor"),
                new Pasajero(/* 70,*/ "Sergio"      , "Muñoz"       , "Libreta de Enrolamiento (LE)", "26331231", "Mayor"),
                new Pasajero(/* 71,*/ "Juan"        , "Peralta"     , "DNI"                         , "39412343", "Mayor"),
                new Pasajero(/* 72,*/ "Sofía"       , "Vera"        , "DNI"                         , "28667890", "Mayor"),
                new Pasajero(/* 73,*/ "Pedro"       , "Domínguez"   , "DNI (Extranjero)"            , "49777855", "Menor"),
                new Pasajero(/* 74,*/ "Mariana"     , "Molina"      , "DNI"                         , "42799988", "Mayor"),
                new Pasajero(/* 75,*/ "Briza"       , "Herrera"     , "DNI (Extranjero)"            , "34335665", "Mayor"),
                new Pasajero(/* 76,*/ "Carla"       , "Suárez"      , "DNI"                         , "32522233", "Mayor"),
                new Pasajero(/* 77,*/ "Hector"      , "Giménez"     , "DNI"                         , "35111222", "Mayor"),
                new Pasajero(/* 78,*/ "Orlando"     , "Aguirre"     , "DNI"                         , "49333888", "Menor"),
                new Pasajero(/* 79,*/ "Mario"       , "Gutiérrez"   , "Libreta Cívica (LC)"         , "37155453", "Mayor"),
                new Pasajero(/* 80,*/ "Sabrina"     , "Álvarez"     , "DNI"                         , "26591115", "Mayor"),
                new Pasajero(/* 81,*/ "Julian"      , "Castro"      , "DNI"                         , "26491114", "Mayor"),
                new Pasajero(/* 82,*/ "Valentina"   , "Herrera"     , "DNI"                         , "36965893", "Mayor"),
                new Pasajero(/* 83,*/ "Daniel"      , "Suárez"      , "DNI"                         , "39657387", "Mayor")
            };

            await context.Set<Pasajero>().AddRangeAsync(pasajerosIniciales);
            await context.SaveChangesAsync();

            // Insertar Tarjetas de Clientes iniciales
            var tarjetasClientesIniciales = new List<TarjetaCliente>
            {
                /* Id (autoincremental), UltimosCuatroDigitos, FechaVencimiento */

                new TarjetaCliente(/*  1,*/ "3635", new DateTime(2027, 07, 01, 0, 0, 0) ),
                new TarjetaCliente(/*  2,*/ "1423", new DateTime(2028, 10, 01, 0, 0, 0) ),
                new TarjetaCliente(/*  3,*/ "6795", new DateTime(2030, 11, 01, 0, 0, 0) ),
                new TarjetaCliente(/*  4,*/ "2439", new DateTime(2027, 03, 01, 0, 0, 0) ),
                new TarjetaCliente(/*  5,*/ "4239", new DateTime(2028, 12, 01, 0, 0, 0) ),
                new TarjetaCliente(/*  6,*/ "0985", new DateTime(2029, 01, 01, 0, 0, 0) ),
                new TarjetaCliente(/*  7,*/ "6482", new DateTime(2028, 12, 01, 0, 0, 0) ),
                new TarjetaCliente(/*  8,*/ "1029", new DateTime(2027, 02, 01, 0, 0, 0) ),
                new TarjetaCliente(/*  9,*/ "6278", new DateTime(2029, 09, 01, 0, 0, 0) ),
                new TarjetaCliente(/* 10,*/ "0913", new DateTime(2028, 03, 01, 0, 0, 0) ),
                new TarjetaCliente(/* 11,*/ "1296", new DateTime(2027, 11, 01, 0, 0, 0) ),
                new TarjetaCliente(/* 12,*/ "9383", new DateTime(2029, 04, 01, 0, 0, 0) )
            };

            await context.Set<TarjetaCliente>().AddRangeAsync(tarjetasClientesIniciales);
            await context.SaveChangesAsync();

            // Insertar Reservas iniciales

            /* 
             * > Reservas para los 12 vuelos cargados inicialmente.
             * > Vuelo sin reservas: vuelo de id = 11.
             * > Vuelo con más reservas: vuelo de id = 7 (tiene 5 reservas).
             */

            var reservasIniciales = new List<Reserva>
            {
                /* id (autogenerada), FechaHoraReserva (fecha y hora en que se registró la reserva), UsuarioId (usu que hizo la 
                 * reserva), IdTarjetaCliente (tarjeta que usó, que puede ser de otra persona que no sea el usuario), VueloId (para 
                 * qué vuelo se hizo la reserva) */

                new Reserva(/*   1,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  5,  7 ),
                new Reserva(/*   2,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  8,  2 ),
                new Reserva(/*   3,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4, 11,  4 ),
                new Reserva(/*   4,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  9,  10 ),
                new Reserva(/*   5,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  4,  2 ),
                new Reserva(/*   6,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  6,  12 ),
                new Reserva(/*   7,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  1,  1 ),
                new Reserva(/*   8,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  12, 7 ),
                new Reserva(/*   9,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  7,  4 ),
                new Reserva(/*  10,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  4,  3 ),
                new Reserva(/*  11,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  10, 9 ),
                new Reserva(/*  12,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  3,  4 ),
                new Reserva(/*  13,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  6,  7 ),
                new Reserva(/*  14,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4, 12,  12 ),
                new Reserva(/*  15,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  5,  5 ),
                new Reserva(/*  16,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4, 10,  6 ),
                new Reserva(/*  17,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  2,  9 ),
                new Reserva(/*  18,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  5,  7 ),
                new Reserva(/*  19,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4, 11,  10 ),
                new Reserva(/*  20,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  2,  7 ),
                new Reserva(/*  21,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4, 12,  3 ),
                new Reserva(/*  22,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  7,  2 ),
                new Reserva(/*  23,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  1,  8 ),
                new Reserva(/*  24,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4, 10,  1 ),
                new Reserva(/*  25,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  9,  9 ),
                new Reserva(/*  26,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  8,  4 ),
                new Reserva(/*  27,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4, 11,  1),
                new Reserva(/*  28,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  3,  10),
                new Reserva(/*  29,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4,  2,  2),
                new Reserva(/*  30,*/ new DateTime(2029, 04, 01, 0, 0, 0), 4, 12,  6)
            };

            /* El vuelo  1 quedo con 3 reservas.
             * El vuelo  2 quedo con 4 reservas.
             * El vuelo  3 quedo con 2 reservas.
             * El vuelo  4 quedo con 4 reservas.
             * El vuelo  5 quedo con 1 reserva.
             * El vuelo  6 quedo con 2 reservas.
             * El vuelo  7 quedo con 5 reservas.
             * El vuelo  8 quedo con 1 reservas.
             * El vuelo  9 quedo con 3 reservas.
             * El vuelo 10 quedo con 3 reservas.
             * El vuelo 11 quedo con 0 reservas.
             * El vuelo 12 quedo con 2 reservas.
             */

            await context.Set<Reserva>().AddRangeAsync(reservasIniciales);
            await context.SaveChangesAsync();

            // Insertar Pasajes iniciales

            /*
             * 1 Pasaje para cada uno de los 83 Pasajeros distintos que se cargaron antes => 83 Pasajes.
             * La reserva 11 no tiene pasajes reservados aún.
             */

            var pasajesIniciales = new List<Pasaje>
            {
                /* Id (autoincremental), Estado, IdReserva, IdPasajero, IdAvion, CodigoAsiento */

                new Pasaje(/*  1,*/ "Confirmado",  1,  1, 6, "3"),
                new Pasaje(/*  2,*/ "Confirmado",  1,  2, 6, "4"),
                new Pasaje(/*  3,*/ "Confirmado",  2,  3, 3, "21"),
                new Pasaje(/*  4,*/ "Confirmado",  3,  4, 1, "6"),
                new Pasaje(/*  5,*/ "Confirmado",  3,  5, 1, "7"),
                new Pasaje(/*  6,*/ "Confirmado",  3,  6, 1, "8"),
                new Pasaje(/*  7,*/ "Confirmado",  3,  7, 1, "9"),
                new Pasaje(/*  8,*/ "Confirmado",  4,  8, 9, "5"),
                new Pasaje(/*  9,*/ "Confirmado",  4,  9, 9, "6"),
                new Pasaje(/* 10,*/ "Confirmado",  4, 10, 9, "15"),

                new Pasaje(/* 11,*/ "Confirmado",  4, 11, 9, "16"),
                new Pasaje(/* 12,*/ "Confirmado",  5, 12, 3, "29"),
                new Pasaje(/* 13,*/ "Confirmado",  5, 13, 3, "30"),
                new Pasaje(/* 14,*/ "Confirmado",  5, 14, 3, "31"),
                new Pasaje(/* 15,*/ "Confirmado",  6, 15, 6, "1"),
                new Pasaje(/* 16,*/ "Confirmado",  6, 16, 6, "2"),
                new Pasaje(/* 17,*/ "Confirmado",  7, 17, 9, "2"),
                new Pasaje(/* 18,*/ "Confirmado",  7, 18, 9, "3"),
                new Pasaje(/* 19,*/ "Confirmado",  7, 19, 9, "4"),

                new Pasaje(/* 20,*/ "Confirmado",  7, 20, 9, "5"),
                new Pasaje(/* 21,*/ "Confirmado",  8, 21, 6, "5"),
                new Pasaje(/* 22,*/ "Confirmado",  8, 22, 6, "6"),
                new Pasaje(/* 23,*/ "Confirmado",  9, 23, 1, "15"),
                new Pasaje(/* 24,*/ "Confirmado", 10, 24, 2, "1"),
                new Pasaje(/* 25,*/ "Confirmado", 10, 25, 2, "2"),
                new Pasaje(/* 26,*/ "Confirmado", 10, 26, 2, "3"),
                new Pasaje(/* 27,*/ "Confirmado", 10, 27, 2, "4"),
                new Pasaje(/* 28,*/ "Confirmado", 10, 28, 2, "5"),
                new Pasaje(/* 29,*/ "Confirmado", 10, 29, 2, "6"),

                new Pasaje(/* 30,*/ "Confirmado", 12, 30, 1, "11"),
                new Pasaje(/* 31,*/ "Confirmado", 12, 31, 1, "12"),
                new Pasaje(/* 32,*/ "Confirmado", 12, 32, 1, "13"),
                new Pasaje(/* 33,*/ "Confirmado", 13, 33, 6, "8"),
                new Pasaje(/* 34,*/ "Confirmado", 13, 34, 6, "9"),
                new Pasaje(/* 35,*/ "Confirmado", 14, 35, 6, "3"),
                new Pasaje(/* 36,*/ "Confirmado", 14, 36, 6, "4"),
                new Pasaje(/* 37,*/ "Confirmado", 14, 37, 6, "5"),
                new Pasaje(/* 38,*/ "Confirmado", 14, 38, 6, "6"),
                new Pasaje(/* 39,*/ "Confirmado", 15, 39, 3, "11"),

                new Pasaje(/* 40,*/ "Confirmado", 15, 40, 3, "12"),
                new Pasaje(/* 41,*/ "Confirmado", 16, 41, 3, "40"),
                new Pasaje(/* 42,*/ "Confirmado", 16, 42, 3, "41"),
                new Pasaje(/* 43,*/ "Confirmado", 16, 43, 3, "42"),
                new Pasaje(/* 44,*/ "Confirmado", 16, 44, 3, "43"),
                new Pasaje(/* 45,*/ "Confirmado", 16, 45, 3, "44"),
                new Pasaje(/* 46,*/ "Confirmado", 16, 46, 3, "45"),
                new Pasaje(/* 47,*/ "Confirmado", 16, 47, 3, "46"),
                new Pasaje(/* 48,*/ "Confirmado", 17, 48, 10, "4"),
                new Pasaje(/* 49,*/ "Confirmado", 17, 49, 10, "5"),
                new Pasaje(/* 50,*/ "Confirmado", 17, 50, 10, "6"),

                new Pasaje(/* 51,*/ "Confirmado", 18, 51, 6, "1"),
                new Pasaje(/* 52,*/ "Confirmado", 18, 52, 6, "2"),
                new Pasaje(/* 53,*/ "Confirmado", 19, 53, 9, "19"),
                new Pasaje(/* 54,*/ "Confirmado", 19, 54, 9, "20"),
                new Pasaje(/* 55,*/ "Confirmado", 19, 55, 9, "21"),
                new Pasaje(/* 56,*/ "Confirmado", 20, 56, 6, "7"),
                new Pasaje(/* 57,*/ "Confirmado", 21, 57, 2, "8"),
                new Pasaje(/* 58,*/ "Confirmado", 21, 58, 2, "9"),
                new Pasaje(/* 59,*/ "Confirmado", 22, 59, 3, "4"),
                new Pasaje(/* 60,*/ "Confirmado", 23, 60, 5, "10"),

                new Pasaje(/* 61,*/ "Confirmado", 23, 61, 5, "11"),
                new Pasaje(/* 62,*/ "Confirmado", 23, 62, 5, "12"),
                new Pasaje(/* 63,*/ "Confirmado", 24, 63, 9, "11"),
                new Pasaje(/* 64,*/ "Confirmado", 24, 64, 9, "12"),
                new Pasaje(/* 65,*/ "Confirmado", 25, 65, 10, "22"),
                new Pasaje(/* 66,*/ "Confirmado", 25, 66, 10, "23"),
                new Pasaje(/* 67,*/ "Confirmado", 26, 67, 1, "1"),
                new Pasaje(/* 68,*/ "Confirmado", 27, 68, 9, "6"),
                new Pasaje(/* 69,*/ "Confirmado", 27, 69, 9, "7"),

                new Pasaje(/* 70,*/ "Confirmado", 27, 70, 9, "8"),
                new Pasaje(/* 71,*/ "Confirmado", 27, 71, 9, "9"),
                new Pasaje(/* 72,*/ "Confirmado", 28, 72, 9, "7"),
                new Pasaje(/* 73,*/ "Confirmado", 28, 73, 9, "8"),
                new Pasaje(/* 74,*/ "Confirmado", 28, 74, 9, "9"),
                new Pasaje(/* 75,*/ "Confirmado", 28, 75, 9, "10"),
                new Pasaje(/* 76,*/ "Confirmado", 28, 76, 9, "11"),
                new Pasaje(/* 77,*/ "Confirmado", 28, 77, 9, "12"),
                new Pasaje(/* 78,*/ "Confirmado", 28, 78, 9, "13"),
                new Pasaje(/* 79,*/ "Confirmado", 29, 79, 3, "7"),

                new Pasaje(/* 80,*/ "Confirmado", 29, 80, 3, "8"),
                new Pasaje(/* 81,*/ "Confirmado", 29, 81, 3, "9"),
                new Pasaje(/* 82,*/ "Confirmado", 30, 82, 3, "35"),
                new Pasaje(/* 83,*/ "Confirmado", 30, 83, 3, "36")
            };

            //  Distribución de asientos ocupados en cada avión (si tiene 2 vuelos se detallan por separado). Lista de aviones:
            //  Con esta info puedo ver el Krokis en el sistema y corroborar que se ve lo mismo que se detalla aquí.
            //
            //  (/* 1,*/ "AeroJet 320"       , 15 , "Disponible"),     > v4:1,6,7,8,9,11,12,13,15(max=15)
            //  (/* 2,*/ "Airbus A220-300"   , 12 , "Disponible"),     > v3:1,2,3,4,5,6,8,9(max = 12)
            //  (/* 3,*/ "Apex A380"         , 52 , "Disponible"),     > 3distintosVuelos:4,7,8,9,11,12,21,29,30,31,35,36,40 a 46(max=52) : TODO X1
            //  (/* 4,*/ "Breeze ATR72"      , 23 , "No disponible"),  > NO DISPONIBLE
            //  (/* 5,*/ "EcoJet Q400"       , 42 , "Disponible"),     > v8:10,11,12(max=42)
            //  (/* 6,*/ "MetroExpress E190" , 9  , "Disponible"),     > v7:1,2,3,4,5,6,7,8,9:LLENO - v12:1,2,3,4,5,6(max=9) - SE SOLAPAN 1,2,3,4,5,6
            //  (/* 7,*/ "Oceanic 350"       , 36 , "No disponible"),  > NO DISPONIBLE
            //  (/* 8,*/ "SkyLinx 737"       , 10 , "Disponible"),     > DISPONIBLE PERO NO ASIGNADO A NINGÚN VUELO
            //  (/* 9,*/ "StratoCruiser 787" , 21 , "Disponible"),     > v1:2,3,4,5,6,7,8,9,11,12 - v10:5,6,7,8,9,10,11,12,13,15,16,19,20,21(max=21) - TAMBIÉN HAY SOLAPAMIENTOS:5,6,7,8,9,11,12
            //  (/*10,*/ "Titan 777"         , 29 , "Disponible")      > v9:4,5,6,22,23(max = 29)   


            await context.Set<Pasaje>().AddRangeAsync(pasajesIniciales);
            await context.SaveChangesAsync();

            // Insertar Pasajes-Servicios iniciales

            var random = new Random(2026);
            int[] todosLosServicios = [1, 2, 3, 4, 5, 6, 7];

            for (int pasajeId = 1; pasajeId <= 83; pasajeId++)
            {
                // Distribución aproximada:
                // 0 servicios: 15% (0..14)
                // 1 servicio : 45% (15..59)
                // 2 servicios: 30% (60..89)
                // 3 servicios: 10% (90..99)
                int roll = random.Next(100);
                int cantidadServicios = roll switch
                {
                    < 15 => 0,
                    < 60 => 1,
                    < 90 => 2,
                    _ => 3
                };

                if (cantidadServicios == 0)
                    continue;

                var serviciosElegidos = todosLosServicios
                    .OrderBy(_ => random.Next())
                    .Take(cantidadServicios);

                foreach (int servicioId in serviciosElegidos)
                {
                    await context.Database.ExecuteSqlInterpolatedAsync($@"
                        IF NOT EXISTS (
                            SELECT 1
                            FROM [dbo].[PasajeServicio]
                            WHERE [PasajesId] = {pasajeId} AND [ServiciosId] = {servicioId}
                        )
                        BEGIN
                            INSERT INTO [dbo].[PasajeServicio] ([PasajesId], [ServiciosId])
                            VALUES ({pasajeId}, {servicioId});
                        END
                    ");
                }
            }


        }

        // Método para crear asientos automáticamente al dar de alta un avión según su capacidad máxima
        // Codigo es un número de asiento general: 1,2,3,4,5,6,7,8,9,10,11,... hasta capacidad del avión
        // Luego se considera que todos los aviones tienen 4 Columnas: 1,2,3,4
        // Y se agregan filas hasta llegar a cubrir la cantidad de asientos que indica la capacidad
        // Así cada asiento tiene la combinación: A1,A2,A3,A4,B1,B2,B3,B4,C1,...
        private static Avion CrearAvionConAsientos(string descripcion, int capacidad, string estadoDisponibilidad)
        {
            var avion = new Avion(descripcion, capacidad, estadoDisponibilidad);

            for (int i = 1; i <= capacidad; i++)
            {
                string codigo = i.ToString();
                int columna = ((i - 1) % 4) + 1;
                char fila = (char)('A' + ((i - 1) / 4));

                avion.AddAsiento(new Asiento(avion.Id, codigo, fila, columna, "libre"));
            }

            return avion;
        }

    }

}
