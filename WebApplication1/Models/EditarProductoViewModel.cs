using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Areas.Identity.Data;

namespace WebApplication1.Models
{
    public class EditarProductoViewModel
    {
        public Producto Producto { get; set; }

        public IList<SelectListItem> Categorias { get; set; }
    }
}
