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
using System.Security.Claims;

namespace FORO_D.Controllers
{
    public class MiembrosHabilitadosController : Controller
    {
        private readonly ForoContext _context;

        public MiembrosHabilitadosController(ForoContext context)
        {
            _context = context;
        }
      
        public async Task<IActionResult> AceptarSolicitud(int entradaId, int miembroId) {

            MiembrosHabilitados existeMiembro =  _context.MiembrosHabilitados.FirstOrDefault(p => p.EntradaId == entradaId && p.MiembroId == miembroId);

            if (existeMiembro != null)
            {
                existeMiembro.Habilitado = true;
                _context.Update(existeMiembro);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("SolicitudesPendientes", "Entradas");
        }

        public async Task<IActionResult> RechazarSolicitud(int entradaId, int miembroId)
        {

            MiembrosHabilitados existeMiembro = _context.MiembrosHabilitados.FirstOrDefault(p => p.EntradaId == entradaId && p.MiembroId == miembroId);

            if (existeMiembro != null && existeMiembro.Habilitado == false)
            {
                _context.Remove(existeMiembro);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("SolicitudesPendientes", "Entradas");
        }

        // GET: MiembrosHabilitados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembrosHabilitados = await _context.MiembrosHabilitados
                .Include(m => m.Entrada)
                .Include(m => m.Miembro)
                .FirstOrDefaultAsync(m => m.MiembroId == id);
            if (miembrosHabilitados == null)
            {
                return NotFound();
            }

            return View(miembrosHabilitados);
        }

        // GET: MiembrosHabilitados/Create
        [Authorize(Roles = "Miembro")]
        public async Task<IActionResult> Create(int? entradaId)
        {
            MiembrosHabilitados miembrosHabilitados;
            //"Authorized,MemberId,PostId"
            if (entradaId != null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                var miId = Int32.Parse(claim.Value);

                bool mhExiste = _context.MiembrosHabilitados.Any(am => am.EntradaId == entradaId && am.MiembroId == miId);

                if (!mhExiste)
                {
                    miembrosHabilitados = new MiembrosHabilitados() { EntradaId = entradaId.Value, MiembroId = miId };
                    _context.Add(miembrosHabilitados);
                    await _context.SaveChangesAsync();
                 
                    return RedirectToAction("Index","Entradas");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: MiembrosHabilitados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembrosHabilitados = await _context.MiembrosHabilitados.FindAsync(id);
            if (miembrosHabilitados == null)
            {
                return NotFound();
            }
            ViewData["EntradaId"] = new SelectList(_context.Entradas, "EntradaId", "Descripcion", miembrosHabilitados.EntradaId);
            ViewData["MiembroId"] = new SelectList(_context.Miembros, "Id", "Apellido", miembrosHabilitados.MiembroId);
            return View(miembrosHabilitados);
        }

        // POST: MiembrosHabilitados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntradaId,MiembroId")] MiembrosHabilitados miembrosHabilitados)
        {
            if (id != miembrosHabilitados.MiembroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miembrosHabilitados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiembrosHabilitadosExists(miembrosHabilitados.MiembroId))
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
            ViewData["EntradaId"] = new SelectList(_context.Entradas, "EntradaId", "Descripcion", miembrosHabilitados.EntradaId);
            ViewData["MiembroId"] = new SelectList(_context.Miembros, "Id", "Apellido", miembrosHabilitados.MiembroId);
            return View(miembrosHabilitados);
        }

        // GET: MiembrosHabilitados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembrosHabilitados = await _context.MiembrosHabilitados
                .Include(m => m.Entrada)
                .Include(m => m.Miembro)
                .FirstOrDefaultAsync(m => m.MiembroId == id);
            if (miembrosHabilitados == null)
            {
                return NotFound();
            }

            return View(miembrosHabilitados);
        }

        // POST: MiembrosHabilitados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var miembrosHabilitados = await _context.MiembrosHabilitados.FindAsync(id);
            _context.MiembrosHabilitados.Remove(miembrosHabilitados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiembrosHabilitadosExists(int id)
        {
            return _context.MiembrosHabilitados.Any(e => e.MiembroId == id);
        }
    }
}
