using FORO_D.Data;
using FORO_D.Models;
using FORO_D.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FORO_D.Controllers
{
    public class HomeController : Controller
    {
        public readonly ForoContext _context;
        public readonly ILogger<HomeController> _logger;
        
    
        public HomeController(ILogger<HomeController> logger, ForoContext context)
        {
            _context = context;
            _logger = logger;            
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel home = new ();

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                home.SesionUserId = Int32.Parse(claim.Value);
            }
            else
            {
                home.SesionUserId = 0;
            }
            var entradasTemp = _context.Entradas
                            .Include(p => p.Miembro)
                            .Include(p => p.MiembrosHabibilitados)
                            .Include(p => p.Preguntas)
                            .ThenInclude(p => p.Respuestas)
                            .ToList();

            home.Top5EntradasConMasPreguntaYRespuestas = entradasTemp.OrderByDescending(e => e.CantidadDePreguntasYRespuestas).Take(5).ToList();
            home.Top5EntradasMasRecientes = await _context.Entradas.Include(p => p.Miembro).Include(p => p.MiembrosHabibilitados).OrderByDescending(p => p.Fecha).Take(5).ToListAsync();

            var entradasUltimoMesAux = _context.Entradas.Where(p => p.Fecha > DateTime.Today.AddDays(-30));
            
            if (entradasUltimoMesAux.Any()) 
            {
                var top3 = ObtenerTop3(entradasUltimoMesAux);
                home.Top3MiembrosConMasEntradasUltimoMes = top3;
            }
            return View(home);
        }

        private List<Miembro> ObtenerTop3(IQueryable<Entrada> entradasUltimoMesAux)
        {
            int cant =_context.Usuarios.Count();
            int[] cantidadDeEntradasPorMiembro = new int[cant];
            foreach (Entrada e in entradasUltimoMesAux)
            {
                cantidadDeEntradasPorMiembro[e.MiembroId-1]++;
            }
           return Top3(cantidadDeEntradasPorMiembro);
        }

        private List<Miembro> Top3(int[] cantidadDeEntradasPorMiembro)
        {
            List<Miembro> top3= new();
            int maxCantEntradas = cantidadDeEntradasPorMiembro.Max();
            int i = 0;
            while(i<cantidadDeEntradasPorMiembro.Length  && top3.Count  <3)
            {
                if (maxCantEntradas > 0 && maxCantEntradas == cantidadDeEntradasPorMiembro[i])
                {
                    Miembro unMiembro = _context.Miembros.First(p => p.Id - 1 == i);
                    top3.Add(unMiembro);
                    cantidadDeEntradasPorMiembro[i] = 0;
                    maxCantEntradas = cantidadDeEntradasPorMiembro.Max();
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
            return top3;
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult InformacionInstitucional()
        {
            return View();
        }

    }
}