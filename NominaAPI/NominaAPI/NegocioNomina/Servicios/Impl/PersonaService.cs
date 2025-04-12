using AutoMapper;
using DatosNomina.Dtos;
using DatosNomina;
using Microsoft.EntityFrameworkCore;
using DatosNomina.Repositorio.Personas;
using DominioNomina.Modelos;

namespace NegocioNomina.Servicios.Impl
{
    public class PersonaService : IPersonaService
    {

        private readonly IMapper _mapper;
        private readonly IPersonaRepositorio _personaRepositorio;
        private readonly NominaContext _context;

        public PersonaService(IPersonaRepositorio personaRepositorio, IMapper mapper, NominaContext context)
        {
            _personaRepositorio = personaRepositorio;
            _context = context;
            _mapper = mapper;
        }

        public async Task<PersonaDTO> GetByIdAsync(int id)
        {
            var result = await _personaRepositorio.GetByIdAsync(id);
            return _mapper.Map<PersonaDTO>(result);
        }

        public async Task<IEnumerable<PersonaDTO>> GetAllAsync()
        {
            var result = await _personaRepositorio.GetAllAsync();
            return _mapper.Map<List<PersonaDTO>>(result);
        }

        public async Task AddAsync(PersonaDTO persona, int iduser)
        {
            var data = _mapper.Map<Persona>(persona);
            await _personaRepositorio.AddAsync(data);
        }

        public async Task UpdateAsync(PersonaDTO persona, int iduser)
        {
            var data = _mapper.Map<Persona>(persona);
            await _personaRepositorio.UpdateAsync(data);
        }

        public async Task DeleteAsync(int id)
        {
            await _personaRepositorio.DeleteAsync(id);
        }


        public async Task<PaginacionResponse<PersonaDTO>> GetPersonas(PaginacionRequestDTO filtroBusqueda)
        {
            var query = _context.Persona.AsQueryable();

            if (!string.IsNullOrEmpty(filtroBusqueda.Filter))
            {
                query = query.Where(x => x.Nombres != null && (x.Nombres.Contains(filtroBusqueda.Filter) || x.Apellidos.Contains(filtroBusqueda.Filter)));
            }

            if (filtroBusqueda.SortDirection.ToLower() == "asc")
            {
                query = query.OrderBy(x => EF.Property<object>(x, filtroBusqueda.SortField));
            }
            else
            {
                query = query.OrderByDescending(x => EF.Property<object>(x, filtroBusqueda.SortField));
            }


            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((filtroBusqueda.Page - 1) * filtroBusqueda.PageSize)
                .Take(filtroBusqueda.PageSize)
                .Select(a => new PersonaDTO
                {
                    Apellidos = a.Apellidos,
                    Edad = a.Edad,
                    FechaNacimiento = a.FechaNacimiento,
                    Genero = a.Genero,
                    IdPersona = a.IdPersona,
                    LugarNacimiento = a.LugarNacimiento,
                    Nombres = a.Nombres,
                })
                .ToListAsync();

            if (totalCount == 0)
            {
                throw new BusinessException("No se encontro informacion");
            }

            return new PaginacionResponse<PersonaDTO> { Items = items, TotalCount = totalCount };
        }
    }
}
