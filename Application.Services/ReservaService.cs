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
    public class ReservaService
    {
        private readonly IReservaRepository _repo;

        public ReservaService(IReservaRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ReservaDTO>> GetAllAsync()
        {
            var reservas = await _repo.GetAllAsync();
            return reservas.Select(reserva => new ReservaDTO
            {
                Id = reserva.Id,
                FechaHoraReserva = reserva.FechaHoraReserva,
                UsuarioId = reserva.UsuarioId,
            }).ToList();
        }
        public async Task<ReservaDTO> AddAsync(ReservaCreateDTO dto)
        {
            Reserva reserva = new Reserva(dto.FechaHoraReserva, dto.UsuarioId);
            await _repo.AddAsync(reserva);
            ReservaDTO reservaDTO = new ReservaDTO
            {
                Id = reserva.Id,
                FechaHoraReserva = reserva.FechaHoraReserva,
                UsuarioId = reserva.UsuarioId,
            };
            return reservaDTO;
        }

    }
}
