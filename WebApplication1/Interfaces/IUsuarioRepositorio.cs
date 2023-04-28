
using WebApplication1.Areas.Identity.Data;

namespace WebApplication1.Interfaces
{
    public interface IUsuarioRepositorio
    {
        ICollection<Usuario> GetUsuarios();

        Usuario GetUsuario(string id);

        Usuario ActualizarUsuario(Usuario usuario);

        Usuario EliminarUsuario(Usuario usuario);
    }
}
