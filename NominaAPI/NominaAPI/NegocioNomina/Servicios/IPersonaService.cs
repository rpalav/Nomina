using DatosNomina.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioNomina.Servicios
{
    public interface IPersonaService
    {
        public Task<PersonaDTO> GetByIdAsync(int id);
        public Task<IEnumerable<PersonaDTO>> GetAllAsync();
        public Task AddAsync(PersonaDTO loteProducto, int iduser);
        public Task UpdateAsync(PersonaDTO loteProducto, int iduser);
        public Task DeleteAsync(int id);

        public Task<PaginacionResponse<PersonaDTO>> GetPersonas(PaginacionRequestDTO filtroBusqueda);

    }
}
