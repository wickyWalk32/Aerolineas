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
    public class AvionService
    {
        private readonly IAvionRepository _repo;
        public AvionService(IAvionRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<AvionDTO>> GetAllAsync()
        {
            var aviones = await _repo.GetAllAsync();
            return aviones.Select(avion=> new AvionDTO
            {
                Id = avion.Id,
                Descripcion = avion.Descripcion,
                Capacidad = avion.Capacidad,
                EstadoDisponibilidad = avion.EstadoDisponibilidad,
            }).ToList();
        }

        public async Task<AvionDTO> GetByIdAsync(int id)
        {
            var avion = await _repo.GetByIdAsync(id);
            if (avion == null) return null;
            return new AvionDTO
            {
                Id = avion.Id,
                Descripcion = avion.Descripcion,
                Capacidad = avion.Capacidad,
                EstadoDisponibilidad = avion.EstadoDisponibilidad,
            };
        }

        public async Task<AvionDTO> AddAsync(AvionCreateDTO dto)
        {
            Avion avion = new Avion(dto.Descripcion, dto.Capacidad, dto.EstadoDisponibilidad);
            await _repo.AddAsync(avion);
            AvionDTO avionDTO = new AvionDTO
            {
                Id = avion.Id,
                Descripcion = avion.Descripcion,
                Capacidad = avion.Capacidad,
                EstadoDisponibilidad = avion.EstadoDisponibilidad,
            };
            return avionDTO;
        }

        public async Task<bool> UpdateAsync(int id, AvionUpdateDTO dto)
        {
            Avion avion = await _repo.GetByIdAsync(id);
            if (avion == null)
            {
                return false;
            }
            avion.SetDescripcion(dto.Descripcion);
            avion.SetEstadoDisponibilidad(dto.EstadoDisponibilidad);
            avion.SetCapacidad(dto.Capacidad);

            await _repo.UpdateAsync(avion);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var avion = await _repo.GetByIdAsync(id);
            if (avion == null) return false;

            await _repo.DeleteAsync(avion);
            return true;
        }

    }
}
