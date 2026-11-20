using Data;
using Domain.Model;
using DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PaisService
    {
        private readonly IPaisRepository _paisRepository;

        public PaisService(IPaisRepository paisRepository)
        {
            _paisRepository = paisRepository;
        }

        public async Task<List<PaisDTO>> GetAllAsync()
        {
            var paises = await _paisRepository.GetAllAsync();

            return paises.Select(p => new PaisDTO
            {
                Id = p.Id,
                Nombre = p.Nombre
            }).ToList();
        }

        public async Task<PaisDTO?> GetByIdAsync(int id)
        {
            var pais = await _paisRepository.GetByIdAsync(id);
            if (pais == null) return null;

            return new PaisDTO
            {
                Id = pais.Id,
                Nombre = pais.Nombre
            };
        }

        public async Task AddAsync(PaisCreateDTO dto)
        {
            var pais = new Pais(dto.Nombre);
            await _paisRepository.AddAsync(pais);
        }

        public async Task<bool> UpdateAsync(int id, PaisUpdateDTO dto)
        {
            var pais = await _paisRepository.GetByIdAsync(id);
            if (pais == null) return false;

            pais.SetNombre(dto.Nombre);
            await _paisRepository.UpdateAsync(pais);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pais = await _paisRepository.GetByIdAsync(id);
            if (pais == null) return false;

            await _paisRepository.DeleteAsync(pais);
            return true;
        }
    }
}