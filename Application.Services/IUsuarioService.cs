using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Application.Services
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>> GetAllAsync();
        Task<UsuarioDTO?> GetAsync(int id);
        Task<UsuarioDTO> AddAsync(UsuarioDTO dto);
        Task<bool> UpdateAsync(UsuarioDTO dto);
        Task<bool> DeleteAsync(int id);
        UsuarioLoginResultDTO ValidarLogin(UsuarioLoginRequestDTO usuariologinRequestDto);
    }
}
