using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FORO_D.Data;
using FORO_D.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace FORO_D.Controllers
{
    [Authorize]
    public class RespuestasController : Controller
    {
        private readonly ForoContext _context;
        private readonly UserManager<Usuario> _userManager;

        public RespuestasController(ForoContext context,UserManager<Usuario>userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Respuestas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respuesta = await _context.Respuestas
                .Include(r => r.Miembro)
                .Include(r => r.Pregunta)
                .FirstOrDefaultAsync(m => m.RespuestaId == id);
            if (respuesta == null)
            {
                return NotFound();
            }

            return View(respuesta);
        }

        [Authorize(Roles = "Miembro")]
        // GET: Respuestas/Create
        public IActionResult Create(int? id)
        {
            int miId = Int32.Parse(_userManager.GetUserId(User));
            Pregunta preg = _context.Preguntas.FirstOrDefault(p => p.PreguntaId == id);
            if (!preg.Activa || id == null || preg.MiembroId==miId)
            {
                return NotFound();
            }
            var existe = _context.Preguntas.Any(p => p.PreguntaId == id);
           
            if (!existe)
            {
                return NotFound();
            }

            Respuesta respuesta = new Respuesta()
            {
                PreguntaId = id.Value,

            };
            var pregunta =  _context.Preguntas
               .FirstOrDefault(m => m.PreguntaId == id);
            if (pregunta == null)
            {
                return NotFound();
            }

            ViewBag.Pregunta = pregunta;
            return View(respuesta);
        }

        [Authorize(Roles = "Miembro")]
        // POST: Respuestas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RespuetaId,MiembroId,PreguntaId,Descripcion,Fecha")] Respuesta respuesta)
        {
            if (ModelState.IsValid)
            {
                respuesta.MiembroId = Int32.Parse(_userManager.GetUserId(User));
                respuesta.Fecha = DateTime.Now;
                respuesta.Miembro = respuesta.Miembro;
                respuesta.Descripcion = respuesta.Descripcion;
                respuesta.PreguntaId = respuesta.PreguntaId;

                _context.Add(respuesta);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Details", "Preguntas", new { id = respuesta.PreguntaId });
            }
            return NotFound();
        }

        [Authorize(Roles = "Miembro")]
        // GET: Respuestas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respuesta = await _context.Respuestas.FindAsync(id);
            if (respuesta == null)
            {
                return NotFound();
            }
            ViewData["MiembroId"] = new SelectList(_context.Miembros, "Id", "Apellido", respuesta.MiembroId);
            ViewData["PreguntaId"] = new SelectList(_context.Preguntas, "PreguntaId", "Descripcion", respuesta.PreguntaId);
            return View(respuesta);
        }

        [Authorize(Roles = "Miembro")]
        // POST: Respuestas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RespuestaId,PreguntaId,MiembroId,Descripcion,Fecha")] Respuesta respuesta)
        {
            if (id != respuesta.RespuestaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(respuesta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespuestaExists(respuesta.RespuestaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Preguntas", new { id = respuesta.PreguntaId });
            }
            ViewData["MiembroId"] = new SelectList(_context.Miembros, "Id", "Apellido", respuesta.MiembroId);
            ViewData["PreguntaId"] = new SelectList(_context.Preguntas, "PreguntaId", "Descripcion", respuesta.PreguntaId);
            return View(respuesta);
        }

        [Authorize(Roles = "Miembro")]
        // GET: Respuestas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Respuesta respAct = _context.Respuestas.FirstOrDefault(p => p.RespuestaId == id);
            int miId = Int32.Parse(_userManager.GetUserId(User));
            

            if (miId != respAct.MiembroId || id == null)
            {
                return NotFound();
            }

            var respuesta = await _context.Respuestas
                .Include(r => r.Miembro)
                .Include(r => r.Pregunta)
                .FirstOrDefaultAsync(m => m.RespuestaId == id);
            if (respuesta == null)
            {
                return NotFound();
            }

            return View(respuesta);
        }

        [Authorize(Roles = "Miembro")]
        // POST: Respuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var respuesta = await _context.Respuestas.FindAsync(id);
            var reacciones= await _context.Reacciones.Where(p=>p.Respuesta.RespuestaId==id).ToListAsync();
            _context.Respuestas.Remove(respuesta);
            _context.Reacciones.RemoveRange(reacciones);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Preguntas", new { id = respuesta.PreguntaId });
        }

        private bool RespuestaExists(int id)
        {
            return _context.Respuestas.Any(e => e.RespuestaId == id);
        }
    }
}
