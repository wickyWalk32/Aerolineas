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
        Task<UsuarioDTO> AddAsync(UsuarioDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<UsuarioDTO?> GetAsync(int id);
        Task<List<UsuarioDTO>> GetAllAsync();
        Task<bool> UpdateAsync(UsuarioDTO dto);

    }
}
