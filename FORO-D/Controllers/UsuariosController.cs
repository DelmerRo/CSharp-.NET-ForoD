using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FORO_D.Data;
using FORO_D.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FORO_D.Controllers
{
    [Authorize(Roles = "Usuario")]
    public class UsuariosController : Controller
    {
        private readonly ForoContext _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly string dominioDeAdministrador = "@admin.com";
        public UsuariosController(UserManager<Usuario> userManager,ForoContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Usuarios
        public IActionResult Index()
        {
            List<Usuario> usuarios = new ();
            foreach (Usuario user in _context.Usuarios.ToList())
            {
                var dominio = user.Email.Substring(user.Email.Length - 10);
                if (dominio == dominioDeAdministrador)
                {
                    usuarios.Add(user);
                }
            }
            return View(usuarios);
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioEncontrado = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioEncontrado == null)
            {
                return NotFound();
            }

            return View(usuarioEncontrado);
        }


        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Email")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Usuario usuarioEnDb = _context.Usuarios.Find(usuario.Id);
                    usuarioEnDb.Nombre = usuario.Nombre;
                    usuarioEnDb.Apellido = usuario.Apellido;
                    _context.Update(usuarioEnDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }
        [Authorize(Roles = "Usuario")]
        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            int miId = Int32.Parse(_userManager.GetUserId(User));
            if (miId==id || id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [Authorize(Roles = "Usuario")]
        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
