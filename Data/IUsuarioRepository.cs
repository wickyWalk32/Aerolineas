using Domain.Model;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
        public interface IUsuarioRepository
        {
            Task<List<Usuario>> GetAllAsync();
            Task<Usuario?> GetByIdAsync(int id);
            Usuario? GetByEmail(string email);    
            Task<Usuario> AddAsync(Usuario usuario);
            Task UpdateAsync(Usuario usuario);
            Task DeleteAsync(Usuario usuario);
            Task<bool> ExistsAsync(int id);
            
    }
    
}