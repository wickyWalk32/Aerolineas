using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IVueloRepository
    {
        Task<List<Vuelo>> GetAllAsync();
        Task<Vuelo?> GetByIdAsync(int id);
        Task AddAsync(Vuelo vuelo);
        Task UpdateAsync(Vuelo vuelo);
        Task DeleteAsync(Vuelo vuelo);
    }

}