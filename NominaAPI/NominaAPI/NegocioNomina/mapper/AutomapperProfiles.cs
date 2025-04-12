using AutoMapper;
using DatosNomina.Dtos;
using DominioNomina.Modelos;

namespace NegocioNomina.mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<PersonaDTO, Persona>().ReverseMap();
        }
    }
}
