using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosNomina.Seguridad
{
    public class AuthResult
    {
        public string AccessToken { get; set; } = string.Empty;
        public string ExpireIn { get; set; } = string.Empty;
        public bool IsLogin { get; set; }
    }
}
