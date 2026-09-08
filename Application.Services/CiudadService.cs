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
    public class CiudadService
    {
        private readonly ICiudadRepository _repo;

        public CiudadService(ICiudadRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CiudadDTO>> GetAllAsync()
        {
            var ciudades = await _repo.GetAllAsync();
            return ciudades.Select(ciudad => new CiudadDTO
            {
                Id = ciudad.Id,
                Nombre = ciudad.Nombre,
                CodigoPostal = ciudad.CodigoPostal,
                CodigoAeropuerto = ciudad.CodigoAeropuerto,

            }).ToList();
        }

        public async Task<CiudadDTO?> GetByIdAsync(int id)
        {
            var ciudad = await _repo.GetByIdAsync(id);
            if (ciudad == null) return null;
            return new CiudadDTO
            {
                Id = ciudad.Id,
                Nombre = ciudad.Nombre,
                CodigoPostal = ciudad.CodigoPostal,
                CodigoAeropuerto = ciudad.CodigoAeropuerto,
            };
        }

        public async Task<CiudadDTO> AddAsync(CiudadCreateDTO ciudadCreateDTO)
        {
            Ciudad ciudad = new Ciudad(ciudadCreateDTO.Nombre, ciudadCreateDTO.CodigoPostal, ciudadCreateDTO.CodigoAeropuerto,
                ciudadCreateDTO.PaisId);
            await _repo.AddAsync(ciudad);
            CiudadDTO ciudadDTO = new CiudadDTO
            {
                Id = ciudad.Id,
                Nombre = ciudad.Nombre,
                CodigoPostal = ciudad.CodigoPostal,
                CodigoAeropuerto = ciudad.CodigoAeropuerto,
                PaisId = ciudad.PaisId,
            };
            return ciudadDTO;
        }
        /*
           // var resultado = await _repo.AddAsync(ciudadDTO);
          */
        public async Task<bool> UpdateAsync(int id, CiudadUpdateDTO ciudadUpdateDTO)
        {

            Ciudad ciudad = new Ciudad
            {
                Id = ciudadUpdateDTO.Id,
                Nombre = ciudadUpdateDTO.Nombre,
                CodigoPostal = ciudadUpdateDTO.CodigoPostal,
                CodigoAeropuerto = ciudadUpdateDTO.CodigoAeropuerto,
                PaisId = ciudadUpdateDTO.PaisId,
            };
            if (id != ciudad.Id)
                return false;

            await _repo.UpdateAsync(ciudad);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return false;

            await _repo.DeleteAsync(user);
            return true;
        }


    }
}

