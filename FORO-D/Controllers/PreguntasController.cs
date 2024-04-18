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
    public class PreguntasController : Controller
    {
        private readonly ForoContext _context;
        private const Boolean sePuedeEliminar = false;
        private readonly UserManager<Usuario> _userManager;
        public PreguntasController(ForoContext context,UserManager<Usuario> userManager)
        {
            _context = context;
           _userManager = userManager;
        }
   

        // GET: Preguntas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregunta = await _context.Preguntas
                .Include(p => p.Entrada)
                .Include(p => p.Miembro)
                .Include(p=>p.Respuestas)
                .FirstOrDefaultAsync(m => m.PreguntaId == id);

            List<Respuesta> respuestas = new();
            respuestas = await _context.Respuestas
             .Include(p => p.Miembro)
             .Include(p => p.Pregunta)
             .Include(p => p.Reacciones)
             .OrderBy(p=>p.Fecha)
             .Where(m => m.PreguntaId == id).ToListAsync();

            if (pregunta == null) 
            {
                return NotFound();
            }
            ViewBag.idMasLikes = ObtenerMasLikes(pregunta);
            ViewBag.idMasDisLikes = ObtenerMasDislike(pregunta);

            ViewBag.pregunta = pregunta;
            return View(respuestas);
        }

        [Authorize(Roles = "Miembro")]
        
        // GET: Preguntas/Create
        public IActionResult Create(int? id)
        {
            var MiID= Int32.Parse(_userManager.GetUserId(User)); 
            if (id == null )
            {
                return NotFound();
            }
            var unaEntrada = _context.Entradas.FirstOrDefault(e => e.EntradaId == id);
            if (unaEntrada.MiembroId!=MiID) {
                if (unaEntrada == null || unaEntrada.Privada)
                {
                    return NotFound();
                }
            }
            Pregunta pregunta = new ()
            {
                EntradaId = id.Value,
            };
            var entrada = _context.Entradas.FirstOrDefault(m => m.EntradaId == id);
            ViewBag.Entrada = entrada;
            return View(pregunta);
        }

        [Authorize(Roles = "Miembro")]
        // POST: Preguntas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize(Roles = "Miembro")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PreguntaId,EntradaId,Descripcion,Activa")] Pregunta pregunta)
        {
            if (ModelState.IsValid)
            {
                pregunta.MiembroId=Int32.Parse(_userManager.GetUserId(User));
                pregunta.Fecha=DateTime.Now;
                _context.Add(pregunta);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Entradas", new { id = pregunta.EntradaId});

            }
            return NotFound();
        }

        [Authorize(Roles = "Miembro")]
        // GET: Preguntas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            int usuarioId = Int32.Parse(User.Claims.First().Value);
       
            Pregunta preg = _context.Preguntas.FirstOrDefault(p=>p.PreguntaId==id);
            if (id == null || preg.MiembroId!=usuarioId)
            {
                return NotFound();
            }

            Pregunta pregunta = await _context.Preguntas.FindAsync(id);
            int cantRespuestas = _context.Respuestas.Count(p=>p.PreguntaId==id);
            if (pregunta == null)
            {
                return NotFound();
            }
            ViewData["EntradaId"] = new SelectList(_context.Entradas, "EntradaId", "Descripcion", pregunta.EntradaId);
            ViewData["MiembroId"] = new SelectList(_context.Miembros, "Id", "Apellido", pregunta.MiembroId);
            ViewData["Fecha"] = new SelectList(_context.Preguntas, "Fecha","Fecha", pregunta.Fecha);
            ViewBag.cantRespuestas = cantRespuestas;
            return View(pregunta);
        }
        public int ObtenerMasLikes(Pregunta pregunta)
        {
            if (!pregunta.Respuestas.Any())
            {
                return 0;
            }
            var liked = pregunta.Respuestas
                     .OrderByDescending(r => r.Reacciones.Count(r => r.MeGusta))
                     .Take(1)
                     .ToList();

            return liked[0].Reacciones.Any(p => p.MeGusta) ? liked[0].RespuestaId : 0;
        }

        public int ObtenerMasDislike(Pregunta pregunta)
        {
            if (!pregunta.Respuestas.Any())
            {
                return 0;
            }
            var disLiked = pregunta.Respuestas
                     .OrderByDescending(r => r.Reacciones.Count(r => !r.MeGusta))
                     .Take(1)
                     .ToList();
            //int cant = liked[0].Reacciones.Count;
            return disLiked[0].Reacciones.Any(p => !p.MeGusta) ? disLiked[0].RespuestaId : 0;
        }

        [Authorize(Roles = "Miembro")]
        // POST: Preguntas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PreguntaId,MiembroId,EntradaId,Descripcion,Fecha,Activa")] Pregunta pregunta)
        {
            if (id != pregunta.PreguntaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pregunta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreguntaExists(pregunta.PreguntaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Preguntas", new { id = pregunta.PreguntaId });
            }
            ViewData["EntradaId"] = new SelectList(_context.Entradas, "EntradaId", "Descripcion", pregunta.EntradaId);
            ViewData["MiembroId"] = new SelectList(_context.Miembros, "Id", "Apellido", pregunta.MiembroId);
            return View(pregunta);
        }

        private bool PreguntaExists(int id)
        {
            return _context.Preguntas.Any(e => e.PreguntaId == id);
        }
    }
}
