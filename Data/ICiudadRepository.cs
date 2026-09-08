using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface ICiudadRepository
    {
        Task<List<Ciudad>> GetAllAsync();
        Task<Ciudad?> GetByIdAsync(int id);
        Task AddAsync(Ciudad ciudad);
        Task UpdateAsync(Ciudad ciudad);
        Task DeleteAsync(Ciudad ciudad);
    }
}
