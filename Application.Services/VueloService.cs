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
    public class VueloService
    {
        private readonly IVueloRepository _vueloRepository;

        public VueloService(IVueloRepository vueloRepository)
        {
            _vueloRepository = vueloRepository;
        }

        public async Task<List<VueloDTO>> GetAllAsync()
        {
            var vuelos = await _vueloRepository.GetAllAsync();

            return vuelos.Select(vuelo => new VueloDTO
            {
                Id = vuelo.Id,
                FechaHoraVuelo = vuelo.FechaHoraVuelo,
                Aerolinea = vuelo.Aerolinea,
                Precio = vuelo.Precio,
                CiudadOrigen = new CiudadDTO 
                                { 
                                    Id = vuelo.CiudadOrigen.Id,
                                    Nombre = vuelo.CiudadOrigen.Nombre,
                                    CodigoPostal = vuelo.CiudadOrigen.CodigoPostal,
                                    CodigoAeropuerto = vuelo.CiudadOrigen.CodigoAeropuerto
                                },
                CiudadDestino = new CiudadDTO
                                {
                                    Id = vuelo.CiudadDestino.Id,
                                    Nombre = vuelo.CiudadDestino.Nombre,
                                    CodigoPostal = vuelo.CiudadDestino.CodigoPostal,
                                    CodigoAeropuerto = vuelo.CiudadDestino.CodigoAeropuerto
                                },
                Avion = new AvionDTO
                                {
                                    Id = vuelo.Avion.Id,
                                    Descripcion = vuelo.Avion.Descripcion,
                                    Capacidad = vuelo.Avion.Capacidad,
                                    EstadoDisponibilidad = vuelo.Avion.EstadoDisponibilidad
                                }
            }).ToList();
        }

        public async Task<VueloDTO?> GetByIdAsync(int id)
        {
            var vuelo = await _vueloRepository.GetByIdAsync(id);

            if (vuelo == null) return null;

            return new VueloDTO
            {
                Id = vuelo.Id,
                FechaHoraVuelo = vuelo.FechaHoraVuelo,
                Aerolinea = vuelo.Aerolinea,
                Precio = vuelo.Precio,
                CiudadOrigen = new CiudadDTO
                {
                    Id = vuelo.CiudadOrigen.Id,
                    Nombre = vuelo.CiudadOrigen.Nombre,
                    CodigoPostal = vuelo.CiudadOrigen.CodigoPostal,
                    CodigoAeropuerto = vuelo.CiudadOrigen.CodigoAeropuerto
                },
                CiudadDestino = new CiudadDTO
                {
                    Id = vuelo.CiudadDestino.Id,
                    Nombre = vuelo.CiudadDestino.Nombre,
                    CodigoPostal = vuelo.CiudadDestino.CodigoPostal,
                    CodigoAeropuerto = vuelo.CiudadDestino.CodigoAeropuerto
                },
                Avion = new AvionDTO
                {
                    Id = vuelo.Avion.Id,
                    Descripcion = vuelo.Avion.Descripcion,
                    Capacidad = vuelo.Avion.Capacidad,
                    EstadoDisponibilidad = vuelo.Avion.EstadoDisponibilidad
                }
            };
        }

        public async Task AddAsync(VueloCreateDTO vueloCreateDTO)
        {
            // Aplicando validaciones de negocio mediante el constructor de la entidad Vuelo
            Vuelo vuelo = new Vuelo(
                vueloCreateDTO.FechaHoraVuelo,
                vueloCreateDTO.Aerolinea,
                vueloCreateDTO.Precio,
                vueloCreateDTO.IdCiudadOrigen,
                vueloCreateDTO.IdCiudadDestino,
                vueloCreateDTO.IdAvion
            );

            await _vueloRepository.AddAsync(vuelo);
            return;
        }

        public async Task<bool> UpdateAsync(int id, VueloUpdateDTO vueloUpdateDto)
        {
            var vuelo = await _vueloRepository.GetByIdAsync(id);

            if (vuelo == null)
            {
                return false;
            }

            // Aquí se disparan las validaciones de los setters de Vuelo.
            vuelo.SetFechaHoraVuelo(vueloUpdateDto.FechaHoraVuelo);
            vuelo.SetAerolinea(vueloUpdateDto.Aerolinea);
            vuelo.SetPrecio(vueloUpdateDto.Precio);
            vuelo.SetIdCiudadOrigen(vueloUpdateDto.IdCiudadOrigen);
            vuelo.SetIdCiudadDestino(vueloUpdateDto.IdCiudadDestino);
            vuelo.SetIdAvion(vueloUpdateDto.IdAvion);

            await _vueloRepository.UpdateAsync(vuelo);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var vuelo = await _vueloRepository.GetByIdAsync(id);

            if (vuelo == null) return false;

            await _vueloRepository.DeleteAsync(vuelo);

            return true;
        }

    }
}
