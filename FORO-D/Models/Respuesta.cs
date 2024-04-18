using FORO_D.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FORO_D.Models
{
    public class Respuesta
    {
        #region Propiedades
        public int RespuestaId { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public int PreguntaId { get; set; }
        
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public int MiembroId { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [StringLength(Restrictions.MaxDescRespuesta, MinimumLength = Restrictions.MinDescRespuesta, ErrorMessage = ErrMsgs.StrMaxMin)]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        public Pregunta Pregunta { get; set; }

        public Miembro Miembro { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = ErrMsgs.ErrMsgNotValid)]
        public DateTime Fecha { get; set; }= DateTime.Now;

        public List<Reaccion> Reacciones  { get; set; }
        #endregion
    }
}
