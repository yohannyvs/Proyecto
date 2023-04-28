using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Areas.Identity.Data;

namespace WebApplication1.Models
{
    public class EditarUsuarioViewModel
    {
        public Usuario Usuario { get; set; }

        public IList<SelectListItem> Roles { get; set; }
    }
}
