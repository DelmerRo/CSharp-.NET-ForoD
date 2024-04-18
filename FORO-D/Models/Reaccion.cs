using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FORO_D.Helpers;
using System.ComponentModel.DataAnnotations;

namespace FORO_D.Models
{
    public class Reaccion
    {
        #region Propiedades
        
        [Key]
        [Required(ErrorMessage = ErrorMsg.ErrMsgRequired)]
        public int RespuestaId { get; set; }

        [Key]
        [Required(ErrorMessage = ErrorMsg.ErrMsgRequired)]
        public int MiembroId { get; set; }

        public Respuesta Respuesta { get; set; }

        public Miembro Miembro { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = ErrorMsg.ErrMsgNotValid)]
        public DateTime Fecha { get; set; }=DateTime.Now;

        public Boolean MeGusta { get; set; }
        #endregion
    }

}