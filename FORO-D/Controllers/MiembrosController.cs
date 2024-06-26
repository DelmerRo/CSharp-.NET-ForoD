﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FORO_D.Data;
using FORO_D.Models;
using Microsoft.AspNetCore.Authorization;

namespace FORO_D.Controllers
{
    [Authorize]
    public class MiembrosController : Controller
    {
        private readonly ForoContext _contextMiembro;

        public MiembrosController(ForoContext context)
        {
            _contextMiembro = context;
        }

        [Authorize(Roles = "Miembro, Usuario")]
        // GET: Miembros
        public async Task<IActionResult> Index()
        {
            
            var listaOrdenadaPorFecha = await _contextMiembro.Miembros.OrderByDescending(p=>p.FechaAlta).ToListAsync();
           
            return View(listaOrdenadaPorFecha);
        }

        public async Task<IActionResult> Details(int? id)
        {
           
            if (id == null)
            {
                return NotFound();
            }

            var miembro = await _contextMiembro.Miembros.FirstOrDefaultAsync(m => m.Id == id);
            if (miembro == null)
            {
                return NotFound();
            }
           
            int cantPreguntas = await _contextMiembro.Preguntas.CountAsync(p => p.MiembroId == id);
            int cantRespuestas = await _contextMiembro.Respuestas.CountAsync(r => r.MiembroId == id);
            int cantReacciones = await _contextMiembro.Reacciones.CountAsync(reac => reac.MiembroId == id);

            ViewBag.cantPreguntas = cantPreguntas;
            ViewBag.cantRespuestas = cantRespuestas;
            ViewBag.cantReacciones = cantReacciones;
            return View(miembro);
        }

        [Authorize(Roles = "Miembro")]
        // GET: Miembros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var miembro = await _contextMiembro.Miembros.FindAsync(id);
            if (id == null || id != Int32.Parse(User.Claims.First().Value) ||  miembro == null)
            {
                return NotFound();
            }
            return View(miembro);
        }

        [Authorize(Roles = "Miembro")]
        // POST: Miembros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Telefono,Id,Nombre,Apellido,Email")] Miembro miembro)
        {
            if (id != miembro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Miembro miembroEnDb = _contextMiembro.Miembros.Find(miembro.Id);
                  
                    miembroEnDb.Telefono = miembro.Telefono;

                    _contextMiembro.Update(miembroEnDb);
                    await _contextMiembro.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiembroExists(miembro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index","Miembros");
            }
            return View(miembro);
        }

        

        private bool MiembroExists(int id)
        {
            return _contextMiembro.Miembros.Any(e => e.Id == id);
        }
    }
}
