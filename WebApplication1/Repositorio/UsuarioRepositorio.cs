using WebApplication1.Areas.Identity.Data;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositorio
{
    public class UsuarioRepositorio: IUsuarioRepositorio
    {
        private readonly dbContext _context;
        public UsuarioRepositorio(dbContext context) {
            _context = context;
        }

        public Usuario ActualizarUsuario(Usuario usuario)
        {
            _context.Update(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public Usuario EliminarUsuario(Usuario usuario)
        {
            _context.Remove(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public Usuario GetUsuario(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public ICollection<Usuario> GetUsuarios()
        {
            return _context.Users.ToList();
        }

    }
}
