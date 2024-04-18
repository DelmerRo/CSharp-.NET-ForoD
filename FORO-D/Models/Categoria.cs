using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FORO_D.Helpers;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace FORO_D.Models
{
    public class Categoria
    {
        #region
        public int CategoriaId { get; set; }
    
        [StringLength(Restrictions.MaxNomCat, MinimumLength = Restrictions.MinNomCat, ErrorMessage = ErrMsgs.StrMaxMin)]
        [Display(Name = Alias.NomCat)]
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [Remote(action: "nombreDeCategoriaDisponible", controller: "Categorias")]
        public string Nombre { get; set; }
        public List<Entrada> Entradas { get; set; }

        #endregion

    }
}
