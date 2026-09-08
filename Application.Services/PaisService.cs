using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PaisService
    {
        private readonly IPaisRepository _repo;

        public PaisService(IPaisRepository repo)
        {
            _repo = repo;
        }


        public async Task<List<PaisDTO>> GetAllAsync()
        {
            var paiss = await _repo.GetAllAsync();
            return paiss.Select(pais => new PaisDTO
            {
                Id = pais.Id,
                Nombre = pais.Nombre,
            }).ToList();
        }
        public async Task<PaisDTO> AddAsync(PaisCreateDTO dto)
        {
            Pais pais = new Pais(dto.Nombre);
            await _repo.AddAsync(pais);
            PaisDTO paisDTO = new PaisDTO
            {
                Id = pais.Id,
                Nombre = pais.Nombre
            };
            return paisDTO;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var pais = await _repo.GetByIdAsync(id);
            if (pais == null) return false;

            await _repo.DeleteAsync(pais);
            return true;
        }
    }
}
