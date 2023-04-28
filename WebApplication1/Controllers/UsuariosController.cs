using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.Data;
using System.Net;
using WebApplication1.Areas.Identity.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuariosController : Controller
    {
        private readonly IUnidadRepositorio _unidadRepositorio;
        private readonly SignInManager<Usuario> _signInManager;
        public UsuariosController(IUnidadRepositorio unidadRepositorio, SignInManager<Usuario> signInManager)
        {
            _unidadRepositorio = unidadRepositorio;
            _signInManager = signInManager;
        }
        // GET: UsuariosController
        public ActionResult Index()
        {
            var usuarios = _unidadRepositorio.Usuario.GetUsuarios();
            return View(usuarios);
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Edit/5
        public async Task<IActionResult> Editar(string id)
        {
            var usuario = _unidadRepositorio.Usuario.GetUsuario(id);
            var roles = _unidadRepositorio.Rol.GetRoles();

            var rolesUsuario = await _signInManager.UserManager.GetRolesAsync(usuario);

            var rol_Items = roles.Select(rol =>
                new SelectListItem(
                    rol.Name,
                    rol.Id,
                    rolesUsuario.Any(ur => ur.Contains(rol.Name)))).ToList();

            var vm = new EditarUsuarioViewModel
            {
                Usuario = usuario,
                Roles = rol_Items
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(EditarUsuarioViewModel data)
        {

            var usuario = _unidadRepositorio.Usuario.GetUsuario(data.Usuario.Id);
            if (usuario == null)
            {
                return NotFound();
            }

            var rolesUsuarioDB = await _signInManager.UserManager.GetRolesAsync(usuario);


            var incluirRol = new List<string>();
            var eliminarRol = new List<string>();

            foreach (var rol in data.Roles)
            {
                var asignadoDB = rolesUsuarioDB.FirstOrDefault(ur => ur == rol.Text);
                if (rol.Selected)
                {
                    if (asignadoDB == null)
                    {
                        incluirRol.Add(rol.Text);
                        await _signInManager.UserManager.AddToRoleAsync(usuario, rol.Text);
                    }
                }
                else
                {
                    if (asignadoDB != null)
                    {
                        eliminarRol.Add(rol.Text);
                        await _signInManager.UserManager.RemoveFromRoleAsync(usuario, rol.Text);
                    }
                }
            }

            usuario.Nombre = data.Usuario.Nombre;
            usuario.Email = data.Usuario.Email;

            _unidadRepositorio.Usuario.ActualizarUsuario(usuario);

            return RedirectToAction("Editar", new { id = usuario.Id });
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(string id)
        {
            var usuario = _unidadRepositorio.Usuario.GetUsuario(id);
            _unidadRepositorio.Usuario.EliminarUsuario(usuario);

            return RedirectToAction(nameof(Index));
        }

        // POST: UsuariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
