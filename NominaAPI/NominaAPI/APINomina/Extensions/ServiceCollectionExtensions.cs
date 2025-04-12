using DatosNomina;
using DatosNomina.Repositorio.Personas;

//using DatosNomina.Repositorio.EstadoLote;
//using DatosNomina.Repositorio.EstadoProducto;
//using DatosNomina.Repositorio.Lote;
//using DatosNomina.Repositorio.Producto;
using DatosNomina.Repositorio.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NegocioNomina.Servicios;
using NegocioNomina.Servicios.Impl;

namespace APINomina.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInventarioServices(
         this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        {
            services.AddDbContext<NominaContext>(optionsAction);

            services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddScoped<IAuthService, AuthService>();
            //services.AddScoped<ICatalogoService, CatalogoService>();
            //services.AddScoped<ILoteProductoService, LoteProductoService>();
            services.AddScoped<IPersonaService, PersonaService>();
            return services;
        }


    }
}
