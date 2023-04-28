using WebApplication1.Interfaces;
using WebApplication1.Repositories;

namespace WebApplication1.Repositorio
{
    public class UnidadRepositorio : IUnidadRepositorio
    {
        public IUsuarioRepositorio Usuario { get; }

        public IRolRepositorio Rol { get; }

        public UnidadRepositorio(IUsuarioRepositorio usuario, IRolRepositorio rol)
        {
            Usuario = usuario;
            Rol = rol;
        }
    }
}
