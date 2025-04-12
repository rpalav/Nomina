using DatosNomina.Dtos;
using DatosNomina.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioNomina.Servicios
{
    public interface IAuthService
    {
        public Task<AuthResult> Login(CredencialesDTO credenciales);
    }
}
