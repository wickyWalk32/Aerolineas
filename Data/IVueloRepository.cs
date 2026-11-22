using Domain.Model;

namespace Data
{
    public interface IVueloRepository
    {
        Task<List<Vuelo>> GetAllAsync();
        Task<Vuelo?> GetByIdAsync(int id);
        Task AddAsync(Vuelo vuelo);
        Task UpdateAsync(Vuelo vuelo);
        Task DeleteAsync(Vuelo vuelo);
        Task<List<Pasaje>> GetAllPasajesByVuelo(int vueloId);

    }
}