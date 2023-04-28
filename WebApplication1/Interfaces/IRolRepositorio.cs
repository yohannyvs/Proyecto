using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Repositories
{
    public interface IRolRepositorio
    {
        ICollection<IdentityRole> GetRoles();
    }
}
