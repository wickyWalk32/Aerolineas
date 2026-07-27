using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IPasajeroRepository
    {
        Task<List<Pasajero>> GetAllAsync();
        Task<Pasajero?> GetByIdAsync(int id);
        Task AddAsync(Pasajero pasajero);
        Task UpdateAsync(Pasajero pasajero);
        Task DeleteAsync(Pasajero pasajero);
    }
}
