using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IReservaRepository
    {
        Task<List<Reserva>> GetAllAsync();
        Task<List<Reserva>> GetAllWithDetallesAsync();
        Task<Reserva?> GetByIdAsync(int id);
        Task<List<string>> GetAsientosOcupadosPorVueloAsync(int vueloId);
        Task<bool> ExisteAsientoOcupadoEnVueloAsync(int vueloId, int idAvion, string codigoAsiento);
        Task<Reserva> AddAsync(Reserva reserva);
        Task UpdateAsync(Reserva reserva);
        Task DeleteAsync(Reserva reserva);
    }
}