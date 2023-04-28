using WebApplication1.Repositories;

namespace WebApplication1.Interfaces
{
    public interface IUnidadRepositorio
    {
        IUsuarioRepositorio Usuario { get; }

        IRolRepositorio Rol { get; }
    }
}
