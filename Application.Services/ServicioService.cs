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
    public class ServicioService
    {

        private readonly IServicioRepository _servicioRepository;

        public ServicioService(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        public async Task<List<ServicioCargaDTO>> GetAllAsync()
        {
            var servicios = await _servicioRepository.GetAllAsync();

            return servicios.Select(servicio => new ServicioCargaDTO
            {
                Id = servicio.Id,
                Nombre = servicio.Nombre,
                Descripcion = servicio.Descripción,
                Precio = servicio.Precio
            }).ToList();
        }

        public async Task<ServicioCargaDTO?> GetByIdAsync(int id)
        {
            var servicio = await _servicioRepository.GetByIdAsync(id);

            if (servicio == null) return null;

            return new ServicioCargaDTO
            {
                Id = servicio.Id,
                Nombre = servicio.Nombre,
                Descripcion = servicio.Descripción,
                Precio = servicio.Precio
            };
        }

        public async Task AddAsync(ServicioCreateDTO servicioCreateDTO)
        {
            // Aquí se disparan las validaciones de los setters de Servicio.
            Servicio servicio = new Servicio(
                                            servicioCreateDTO.Nombre,
                                            servicioCreateDTO.Descripcion,
                                            servicioCreateDTO.Precio
                                            );

            await _servicioRepository.AddAsync(servicio);
            return;
        }

        public async Task<bool> UpdateAsync(int id, ServicioUpdateDTO servicioUpdateDto)
        {
            var servicio = await _servicioRepository.GetByIdAsync(id);

            if (servicio == null)
            {
                return false;
            }

            servicio.SetNombre(servicioUpdateDto.Nombre);
            servicio.SetDescripcion(servicioUpdateDto.Descripcion);
            servicio.SetPrecio(servicioUpdateDto.Precio);

            await _servicioRepository.UpdateAsync(servicio);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var servicio = await _servicioRepository.GetByIdAsync(id);

            if (servicio == null) return false;

            await _servicioRepository.DeleteAsync(servicio);

            return true;
        }

    }
}
