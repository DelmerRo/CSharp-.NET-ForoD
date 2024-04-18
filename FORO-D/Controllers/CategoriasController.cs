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
  
    public class CategoriasController : Controller
    {
        private readonly ForoContext _context;
        private readonly SignInManager<Usuario> _signinManager;

        public CategoriasController(ForoContext context, SignInManager<Usuario> signinManager)
        {
            _context = context;
            _signinManager = signinManager;
        }

        [Authorize(Roles = "Usuario")]
        public IActionResult Index()
        {
            var listaDeCategorias = _context.Categorias.
                Include (c => c.Entradas).
                OrderBy(c => c.Nombre).ToList();
            return View(listaDeCategorias);
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id!=null) { 
            Entrada laEntrada = _context.Entradas.FirstOrDefault(p => p.EntradaId == id);
            }

            List<Entrada> listaDeEntradas = new ();
            if (id == null)
            {
                listaDeEntradas = _context.Entradas.
                   Include(e => e.Categoria).
                   Include(e => e.Miembro).
                   Include(e => e.MiembrosHabibilitados).
                   OrderByDescending(e => e.Fecha).
                   ToList();
            }
            else
            {
                listaDeEntradas = _context.Entradas.
                   Include(e => e.Categoria).
                   Include(e => e.Miembro).
                   Include(e => e.MiembrosHabibilitados).
                   OrderByDescending(e => e.Fecha).
                     Where(e => e.CategoriaId == id).
                   ToList();
            }

            var listaDeCategorias = await _context.Categorias.
                 OrderBy(c => c.Nombre).
                 ToListAsync();


            ViewBag.Categorias = listaDeCategorias;
            return View(listaDeEntradas);
        }


        [HttpGet]
        public async Task<IActionResult> NombreDeCategoriaDisponible(string nombre)
        {
            var nombreCategoria = await _context.Categorias.AnyAsync(p => p.Nombre == nombre);

            if (!nombreCategoria)
            {
                //Si no está el Email usado, entonces, el email está disponible.                
                return Json(true);
            }
            else
            {
                //El Email ya está en uso, entonces, no se cumple la validación, Se devuelve un mensaje de error.
                return Json($"La categoria {nombre} ya está en uso.");
            }
        }

        [Authorize(Roles = "Miembro,Usuario")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Miembro,Usuario")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaId,Nombre")] Categoria categoria)
        {
            Boolean existeCategoria = _context.Categorias.Any(c => c.Nombre == categoria.Nombre);
            if (existeCategoria)
            {
                return RedirectToAction("Index", "Categorias");
            }
            
            if (ModelState.IsValid)
            {
                    _context.Add(categoria);
                    await _context.SaveChangesAsync();
                if (User.IsInRole("Miembro"))
                {
                    return RedirectToAction("Create", "Entradas", new { id = categoria.CategoriaId });
                }
                else
                {
                    return RedirectToAction("Index", "Categorias");
                }  
            }
            
            return View(categoria);
        }
    }
}
