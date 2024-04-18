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
using FORO_D.ViewModels;
using System.Security.Claims;

namespace FORO_D.Controllers
{
  
    public class EntradasController : Controller
    {
        private readonly ForoContext _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signinManager;
        public EntradasController(ForoContext context, UserManager<Usuario> userManager, SignInManager<Usuario> signinManager)
        {
            _context = context;
            _userManager = userManager;
            _signinManager = signinManager;
        }

        public async Task<IActionResult> SolicitudesPendientes()
        {
            List<MiembrosHabilitados> miembrosRelacionados;
            int usuarioId = Int32.Parse(User.Claims.First().Value);
            if (!User.IsInRole("Miembro"))
            {
                return RedirectToAction("Index", "Home");
            }
            miembrosRelacionados = await _context.MiembrosHabilitados.Include(mh => mh.Miembro).Include(mh => mh.Entrada).Where(mh => !mh.Habilitado && mh.MiembroId != usuarioId && mh.Entrada.MiembroId == usuarioId).ToListAsync();

            return View(miembrosRelacionados);
        }

        
        public async Task<IActionResult> Index()
        {
            List<Entrada> listaDeEntradas = new();

            listaDeEntradas = await _context.Entradas.
               Include(e => e.Categoria).
               Include(e => e.Miembro).
               Include(e => e.MiembrosHabibilitados).
               OrderByDescending(e => e.Fecha).
               ToListAsync();

            return View(listaDeEntradas);
        }

        //[Authorize(Roles = "Miembro,Usuario")]
        // GET: Entradas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Entrada laEntrada = _context.Entradas.FirstOrDefault(p => p.EntradaId == id);
            if (_signinManager.IsSignedIn(User))
            {
                int miID = Int32.Parse(User.Claims.First().Value);
                var estaPendienteDeAutorizacion = _context.MiembrosHabilitados.Any((mh => mh.MiembroId == miID && mh.EntradaId == id && !mh.Habilitado));
                var hayRegistro = _context.MiembrosHabilitados.Any(mh => mh.EntradaId == id && mh.MiembroId == miID && mh.Habilitado);
                if (User.IsInRole("Miembro") && (id == null || estaPendienteDeAutorizacion || (laEntrada.MiembroId != miID && !hayRegistro && laEntrada.Privada)))
                {
                    return NotFound();
                }
            }

            if(!_signinManager.IsSignedIn(User) &&  laEntrada.Privada)
            {
                return NotFound();
            }
        
            var entrada = await _context.Entradas
                .Include(e => e.Categoria)
                .Include(e => e.Miembro)
                .Include(e => e.Preguntas)
                .ThenInclude(e => e.Respuestas)
                .OrderBy(p => p.Fecha)
                .FirstOrDefaultAsync(m => m.EntradaId == id);

            List<Pregunta> listaDePreguntas = new();
            listaDePreguntas = await _context.Preguntas
              .Include(e => e.Miembro)
              .Include(e => e.Entrada)
              .OrderBy(p => p.Fecha)
              .Where(m => m.EntradaId == id).ToListAsync();

            if (entrada == null || listaDePreguntas == null)
            {
                return NotFound();
            }

           
            ViewBag.Entrada = entrada;
            return View(listaDePreguntas);
  
        }
       
            [Authorize(Roles = "Miembro")]
        // GET: Entradas/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias.OrderBy(p => p.Nombre), "CategoriaId", "Nombre");
            return View();
        }

        [Authorize(Roles = "Miembro")]
        // POST: Entradas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntradaId,CategoriaId,Titulo,Descripcion,Fecha,Privada")] Entrada entrada)       
        {
            var MiembroId = Int32.Parse(_userManager.GetUserId(User));
            Entrada entrad = null;
            if (ModelState.IsValid)
            {
                  entrad = new Entrada()
                {
                    MiembroId = MiembroId,
                    CategoriaId = entrada.CategoriaId,
                    Titulo = entrada.Titulo,
                    Descripcion = entrada.Descripcion,
                    Privada = entrada.Privada,
                     Fecha = DateTime.Now
                };
                _context.Add(entrad);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Preguntas", new { id = entrad.EntradaId});

            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nombre", entrad.CategoriaId);
            ViewData["MiembroId"] = new SelectList(_context.Miembros, "Id", "Apellido", entrad.MiembroId);
            return View(entrad);
        }

        [Authorize(Roles = "Miembro")]
        // GET: Entradas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            int usuarioId = Int32.Parse(User.Claims.First().Value);
            Entrada ent = _context.Entradas.FirstOrDefault(p => p.EntradaId == id);
            if (id == null || ent.MiembroId!=usuarioId)
            {
                return NotFound();
            }

            var entrada =await _context.Entradas.Include(p => p.Preguntas).FirstOrDefaultAsync(p => p.EntradaId == id);
            
            if (entrada == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nombre", entrada.CategoriaId);
            ViewData["MiembroId"] = new SelectList(_context.Miembros, "Id", "Apellido", entrada.MiembroId);
            ViewData["Fecha"] = new SelectList(_context.Entradas, "Fecha", "Fecha", entrada.Fecha);
            return View(entrada);
        }

        [Authorize(Roles = "Miembro")]
        // POST: Entradas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntradaId,CategoriaId,MiembroId,Titulo,Descripcion,Fecha,Privada")] Entrada entrada)
        {
            if (id != entrada.EntradaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entrada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntradaExists(entrada.EntradaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Entradas", new { id = entrada.EntradaId });
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nombre", entrada.CategoriaId);
            ViewData["MiembroId"] = new SelectList(_context.Miembros, "Id", "Apellido", entrada.MiembroId);
            return View(entrada);
        }

        [Authorize(Roles = "Usuario")]
        // GET: Entradas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrada = await _context.Entradas
                .Include(e => e.Categoria)
                .Include(e => e.Miembro)
                .FirstOrDefaultAsync(m => m.EntradaId == id);
            if (entrada == null)
            {
                return NotFound();
            }

            return View(entrada);
        }

        // POST: Entradas/Delete/5
        [Authorize(Roles = "Usuario")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entrada = await _context.Entradas.FindAsync(id);
            _context.Entradas.Remove(entrada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntradaExists(int id)
        {
            return _context.Entradas.Any(e => e.EntradaId == id);
        }

        public async Task<IActionResult> MisEntradas()
        {
            var idMiembro = Int32.Parse(_userManager.GetUserId(User));
            if (idMiembro == 0)
            {
                return NotFound();
            }
            List<Entrada> misEntradas = new ();

                    misEntradas =await _context.Entradas.
                    Include(e => e.Categoria).
                    Include(e => e.Miembro).
                    OrderByDescending(e => e.Fecha).
                      Where(e => e.MiembroId == idMiembro).
                    ToListAsync();

            var listaDeCategorias = await _context.Categorias.
                Include(c => c.Entradas).
                OrderBy(c => c.Nombre).
                ToListAsync();


            ViewBag.Categorias = listaDeCategorias;
            return View(misEntradas);
        }
    }
}
