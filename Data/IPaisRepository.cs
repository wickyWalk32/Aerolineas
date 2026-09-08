using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IPaisRepository
    {
        Task<List<Pais>> GetAllAsync();
        Task<Pais> GetByIdAsync(int id);

        Task AddAsync(Pais pais);
        Task DeleteAsync(Pais pais);
    }
}
