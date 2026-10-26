using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PaisDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<CiudadDTO>? Ciudades { get; set; }
    }

    public class PaisCreateDTO
    {
        public string Nombre { get; set; }
    }
}
