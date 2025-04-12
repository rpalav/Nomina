using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatosNomina.Repositorio
{
    public interface IRepository<T>
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T producto);
        Task UpdateAsync(T producto);
        Task DeleteAsync(int id);
    }
}
