using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Data
{
    public interface IAvionRepository
    {
        Task<List<Avion>> GetAllAsync();
        Task<Avion?> GetByIdAsync(int id);
        Task AddAsync(Avion avion);
        Task UpdateAsync(Avion avion);
        Task DeleteAsync(Avion avion);

    }
}
