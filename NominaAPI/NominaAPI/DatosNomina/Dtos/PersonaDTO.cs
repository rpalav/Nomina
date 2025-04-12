using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosNomina.Dtos
{
    public class PersonaDTO
    {
        public int IdPersona { get; set; }

        public string Apellidos { get; set; }

        public string Nombres { get; set; }

        public int? Edad { get; set; }

        public string Genero { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public string LugarNacimiento { get; set; }
    }
}
