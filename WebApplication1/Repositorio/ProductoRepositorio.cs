using WebApplication1.Areas.Identity.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositorio
{
    public class ProductoRepositorio: IProductoRepositorio
    {
        private readonly dbContext _context;
        public ProductoRepositorio(dbContext context) {
            _context = context;
        }

        public Producto GetProducto(string id)
        {
            return _context.Productos.FirstOrDefault(u => u.Id.ToString() == id);
        }

        public ICollection<Producto> GetProductos()
        {
            return _context.Productos.ToList();
        }

    }
}
