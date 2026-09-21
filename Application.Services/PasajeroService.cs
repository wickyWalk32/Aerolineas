using Data;
using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services
{
    public class PasajeroService
    {
        private readonly IPasajeroRepository _repo;

        public PasajeroService(IPasajeroRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<PasajeroDTO>> GetAllAsync()
        {
            var pasajeros = await _repo.GetAllAsync();
            return pasajeros.Select(pasajero => new PasajeroDTO
            {
                Id = pasajero.Id,
                Tipo = pasajero.Tipo,
                Nombre = pasajero.Nombre,
                Apellido = pasajero.Apellido,
                TipoDocumento = pasajero.TipoDocumento,
                NroDocumento = pasajero.NroDocumento,
            }).ToList();
        }
        public async Task<PasajeroDTO> GetByIdAsync(int id)
        {
            var pasajero = await _repo.GetByIdAsync(id);
            if (pasajero == null) return null;
            return  new PasajeroDTO
            {
                Id = pasajero.Id,
                Tipo = pasajero.Tipo,
                Nombre = pasajero.Nombre,
                Apellido = pasajero.Apellido,
                TipoDocumento = pasajero.TipoDocumento,
                NroDocumento = pasajero.NroDocumento,
            };
        }

        public async Task<PasajeroDTO> AddAsync(PasajeroCreateDTO dto)
        {
            Pasajero pasajero = new Pasajero( dto.Nombre,dto.Apellido, dto.TipoDocumento, dto.NroDocumento, dto.Tipo);
            await _repo.AddAsync(pasajero);
            PasajeroDTO pasajeroDTO = new PasajeroDTO
            {
                Id = pasajero.Id,
                Tipo = pasajero.Tipo,
                Nombre = pasajero.Nombre,
                Apellido = pasajero.Apellido,
                TipoDocumento = pasajero.TipoDocumento,
                NroDocumento = pasajero.NroDocumento,
            };
            return pasajeroDTO;
        }

        public async Task<bool> UpdateAsync(int id, PasajeroUpdateDTO dto)
        {
            Pasajero pasajero = await _repo.GetByIdAsync(id);

            if (pasajero == null)return false;
            pasajero.SetNombre(dto.Nombre);
            pasajero.SetApellido(dto.Apellido);
            pasajero.SetTipoDocumento(dto.TipoDocumento);
            pasajero.SetNroDocumento(dto.NroDocumento);
            pasajero.SetTipo(dto.Tipo);
            await _repo.UpdateAsync(pasajero);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pasajero = await _repo.GetByIdAsync(id);
            if (pasajero == null) return false;

            await _repo.DeleteAsync(pasajero);
            return true;
        }
    }
}
