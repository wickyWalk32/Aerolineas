using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IPasajeRepository
    {
        Task<List<Pasaje>> GetAllAsync();
        // Task<List<Pasaje>> GetAllByUserAsync();
        Task<Pasaje?> GetByIdAsync(int id);
        Task AddAsync(Pasaje pasaje);
        Task UpdateAsync(Pasaje pasaje);
        Task DeleteAsync(Pasaje pasaje);
    }
}
