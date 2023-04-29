
using WebApplication1.Areas.Identity.Data;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface ICategoriaRepositorio
    {
        ICollection<Categoria> GetCategorias();

        Categoria GetCategoria(string id);

    }
}
