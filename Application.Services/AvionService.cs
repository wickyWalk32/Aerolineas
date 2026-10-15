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
                Asientos = avion.Asientos.Select(asiento => new AsientoDTO
                {
                    AvionId = asiento.AvionId,
                    Codigo = asiento.Codigo,
                    Fila = asiento.Fila,
                    Columna = asiento.Columna,
                    Estado = asiento.Estado,

                }).ToList(),
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
            foreach (var asiento in dto.AsientosCreateDTO)
            {
                avion.AddAsiento(new Asiento(avion.Id, asiento.Codigo, asiento.Fila, asiento.Columna, asiento.Estado));
            }
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
            if(avion.Capacidad == dto.Capacidad)
            {

            }
            else if (avion.Capacidad < dto.Capacidad)
            {
                var agregarAsientos = dto.Asientos.Where(a1 => !avion.Asientos.Select(a2 => a2.Codigo).Contains(a1.Codigo))
                    .Select(a3 => new Asiento(avion.Id,a3.Codigo,a3.Fila,a3.Columna,a3.Estado )).ToList();
                foreach (var asiento in agregarAsientos)
                {
                    avion.AddAsiento(asiento);
                }
            }
            else if (avion.Capacidad > dto.Capacidad)
            {
                var eliminarAsientos = avion.Asientos.Where(a1 => !dto.Asientos.Select(a2 => a2.Codigo).Contains(a1.Codigo)).ToList();
                foreach (var asiento in eliminarAsientos)
                {
                    avion.RemoveAsiento(asiento);
                }
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
