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

        private readonly ICiudadRepository _repository;

        public CiudadService(ICiudadRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CiudadDTO>> GetAllAsync()
        {
            var ciudades = await _repository.GetAllAsync();

            return ciudades.Select(ciudad => new CiudadDTO
            {
                Id = ciudad.Id,
                Nombre = ciudad.Nombre,
                CodigoPostal = ciudad.CodigoPostal,
                CodigoAeropuerto = ciudad.CodigoAeropuerto,
                PaisId = ciudad.PaisId,
                PaisNombre = ciudad.Pais.Nombre

            }).ToList();
        }

        public async Task<CiudadDTO?> GetByIdAsync(int id)
        {
            var ciudad = await _repository.GetByIdAsync(id);

            if (ciudad == null) return null;

            return new CiudadDTO
            {
                Id = ciudad.Id,
                Nombre = ciudad.Nombre,
                CodigoPostal = ciudad.CodigoPostal,
                CodigoAeropuerto = ciudad.CodigoAeropuerto,
                PaisId = ciudad.PaisId,
                PaisNombre = ciudad.Pais.Nombre
            };

        }

        public async Task<CiudadDTO> AddAsync(CiudadCreateDTO ciudadCreateDto)
        {
            // 1. Creamos la entidad de dominio con los datos que mandó el usuario (Windows Forms)
            Ciudad ciudad = new Ciudad(
                ciudadCreateDto.Nombre,
                ciudadCreateDto.CodigoPostal,
                ciudadCreateDto.CodigoAeropuerto,
                ciudadCreateDto.PaisId
            );

            // 2. Guardamos en la base de datos (aquí SQL Server genera el ID, ej: 15)
            await _repository.AddAsync(ciudad);

            // 3. LA CONSULTA EXTRA: 
            // Como necesitamos el nombre del país y el INSERT no lo trae, 
            // usamos el GetByIdAsync que ya tiene el .Include(c => c.Pais) para buscarla de nuevo.
            var ciudadCreadaConPais = await _repository.GetByIdAsync(ciudad.Id);

            // 4. Mapeamos el DTO de respuesta usando los datos completos
            CiudadDTO ciudadDTO = new CiudadDTO
            {
                Id = ciudadCreadaConPais!.Id,
                Nombre = ciudadCreadaConPais.Nombre,
                CodigoPostal = ciudadCreadaConPais.CodigoPostal,
                CodigoAeropuerto = ciudadCreadaConPais.CodigoAeropuerto,
                PaisId = ciudadCreadaConPais.PaisId,
                PaisNombre = ciudadCreadaConPais.Pais?.Nombre ?? "Sin país" // Ahora si tiene el país
            };

            return ciudadDTO;

        }
        
        public async Task<bool> UpdateAsync(int id, CiudadUpdateDTO ciudadUpdateDto)
        {

            if (id != ciudadUpdateDto.Id)
                return false;

            Ciudad ciudad = new Ciudad
            (
                ciudadUpdateDto.Id,
                ciudadUpdateDto.Nombre,
                ciudadUpdateDto.CodigoPostal,
                ciudadUpdateDto.CodigoAeropuerto,
                ciudadUpdateDto.PaisId
            );

            await _repository.UpdateAsync(ciudad);

            return true;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ciudad = await _repository.GetByIdAsync(id);
            if (ciudad == null) return false;

            await _repository.DeleteAsync(ciudad);
            return true;
        }


    }
}

