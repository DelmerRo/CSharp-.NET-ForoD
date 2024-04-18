using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FORO_D.Data;
using FORO_D.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace FORO_D.Controllers
{
    [Authorize]
    public class ReaccionesController : Controller
    {
        private readonly ForoContext _context;


        public ReaccionesController(ForoContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Miembro")]
        public async Task<IActionResult> Like(int respuestaId, int preguntaId)
        {
            var idMiembroLogueado = ObtenerIdMiembroLogueado();
            var miembroQueReacciona = _context.Respuestas.FirstOrDefault(p => p.RespuestaId == respuestaId);
            if (miembroQueReacciona==null || idMiembroLogueado == miembroQueReacciona.MiembroId)
            {
                return NotFound();
            }

            Reaccion reaccion = new () {RespuestaId= respuestaId, MiembroId=idMiembroLogueado };
            Reaccion existeReaccion = _context.Reacciones.FirstOrDefault(r => r.RespuestaId == reaccion.RespuestaId && r.MiembroId == reaccion.MiembroId);

            if (existeReaccion== null)
            {
                reaccion.MeGusta = true;
                reaccion.Fecha = DateTime.Now;
                _context.Add(reaccion);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Preguntas", new { id = preguntaId });
            }
            else
            {
                try
                {
                    if (!existeReaccion.MeGusta)
                    {
                        existeReaccion.MeGusta = true;
                        existeReaccion.Fecha = DateTime.Now;
                        _context.Update(existeReaccion);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.Reacciones.Remove(existeReaccion);
                        await _context.SaveChangesAsync();
                    }
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!ExisteReaccion(reaccion.RespuestaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("Details", "Preguntas", new { id = preguntaId});
        }

        [Authorize(Roles = "Miembro")]
        public async Task<IActionResult> Dislike(int respuestaId, int preguntaId)
        {
            var idMiembroLogueado = ObtenerIdMiembroLogueado();
            var miembroQueReacciona = _context.Respuestas.FirstOrDefault(p => p.RespuestaId == respuestaId);
            if (miembroQueReacciona == null || idMiembroLogueado == miembroQueReacciona.MiembroId)
            {
                return NotFound();
            }
            Reaccion reaccion = new () { RespuestaId = respuestaId, MiembroId = idMiembroLogueado };
            Reaccion existeReaccion = _context.Reacciones.FirstOrDefault(r => r.RespuestaId == reaccion.RespuestaId && r.MiembroId == reaccion.MiembroId);

            if (existeReaccion == null)
            {
                reaccion.MeGusta = false;
                reaccion.Fecha = DateTime.Now;
                _context.Add(reaccion);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Preguntas", new { id = preguntaId });
            }
            else
            {
                try
                {
                    if (existeReaccion.MeGusta)
                    {
                        existeReaccion.MeGusta = false;
                        existeReaccion.Fecha = DateTime.UtcNow;
                        _context.Update(existeReaccion);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.Reacciones.Remove(existeReaccion);
                        await _context.SaveChangesAsync();

                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExisteReaccion(reaccion.RespuestaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }


            return RedirectToAction("Details", "Preguntas", new { id = preguntaId });
        }

        private int ObtenerIdMiembroLogueado()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var idMiembroLogueado = Int32.Parse(claim.Value);
            return idMiembroLogueado;
        }

        private bool ExisteReaccion(int id)
        {
            return _context.Reacciones.Any(e => e.RespuestaId == id);
        }

    }
}
