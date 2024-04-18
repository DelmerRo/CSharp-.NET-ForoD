using FORO_D.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FORO_D.Models
{
    public class MiembrosHabilitados
    {
        #region Propiedades
        [Key]
        [Required(ErrorMessage = ErrorMsg.ErrMsgRequired)]
        public int EntradaId { get; set; }

        [Key]
        [Required(ErrorMessage = ErrorMsg.ErrMsgRequired)]
        public int MiembroId { get; set; }

        public Entrada Entrada { get; set; }

        public Miembro Miembro { get; set; }
   
        public Boolean Habilitado { get; set; }
        #endregion
    }
}
