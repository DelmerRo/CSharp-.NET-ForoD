using FORO_D.Helpers;
using FORO_D.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FORO_D.ViewModels
{
    public class HomeViewModel
    {
        [Display(Name = Alias.CincoRecientes)]
        public List<Entrada> Top5EntradasMasRecientes { get; set; }

        [Display(Name = Alias.TopCinco)]
        public List<Entrada> Top5EntradasConMasPreguntaYRespuestas { get; set; }

        [Display(Name = Alias.TopTres)]
        public List<Miembro> Top3MiembrosConMasEntradasUltimoMes { get; set; }

        public int SesionUserId { get; set; }

    }
}