using WebApplication1.Areas.Identity.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositorio
{
    public class CategoriaRepositorio: ICategoriaRepositorio
    {
        private readonly dbContext _context;
        public CategoriaRepositorio(dbContext context) {
            _context = context;
        }

        public Categoria GetCategoria(string id)
        {
            return _context.Categorias.FirstOrDefault(u => u.Id.ToString() == id);
        }

        public ICollection<Categoria> GetCategorias()
        {
            return _context.Categorias.ToList();
        }

    }
}
