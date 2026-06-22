using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
        public DbSet<Usuario> Usuarios {  get; set; }
    }
}
