
using WebApplication1.Areas.Identity.Data;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IProductoRepositorio
    {
        ICollection<Producto> GetProductos();

        Producto GetProducto(string id);

    }
}
