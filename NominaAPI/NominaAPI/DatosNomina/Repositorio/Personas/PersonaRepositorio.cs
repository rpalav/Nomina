using DominioNomina.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosNomina.Repositorio.Personas
{
    public class PersonaRepositorio : IPersonaRepositorio
    {

        private readonly NominaContext _context;

        public PersonaRepositorio(NominaContext context)
        {
            _context = context;
        }

        public async Task<Persona?> GetByIdAsync(int id)
        {
            return await _context.Persona.FindAsync(id);
        }

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Persona.ToListAsync();
        }

        public async Task AddAsync(Persona persona)
        {
            await _context.Persona.AddAsync(persona);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Persona persona)
        {
            _context.Persona.Update(persona);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var producto = await GetByIdAsync(id);
            if (producto != null)
            {
                _context.Persona.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
