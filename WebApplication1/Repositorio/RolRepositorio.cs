using Microsoft.AspNetCore.Identity;
using WebApplication1.Areas.Identity.Data;
using WebApplication1.Repositories;

namespace WebApplication1.Repositorio
{
    public class RolRepositorio : IRolRepositorio
    {
        private readonly dbContext _context;

        public RolRepositorio(dbContext context)
        {
            _context = context;
        }

        public ICollection<IdentityRole> GetRoles() {
            return _context.Roles.ToList();
        }
    }
}
