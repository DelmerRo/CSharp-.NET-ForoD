using FORO_D.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FORO_D.Models
{
    public class Pregunta
    {
        #region Propiedades
        public int PreguntaId { get; set; }

        [Required(ErrorMessage = ErrorMsg.ErrMsgRequired)]
        public int MiembroId { get; set; }

        [Required(ErrorMessage = ErrorMsg.ErrMsgRequired)]
        public int EntradaId { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [StringLength(Restrictions.MaxDescPregunta, MinimumLength = Restrictions.MinDescPregunta, ErrorMessage = ErrMsgs.StrMaxMin)]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [Display(Name = Alias.FechaDePublicacion)]
        [DataType(DataType.DateTime, ErrorMessage = ErrMsgs.ErrMsgNotValid)]
        public DateTime Fecha { get; set; } = DateTime.UtcNow;

        public Boolean Activa { get; set; } = true;

        public Entrada Entrada { get; set; }

        public Miembro Miembro { get; set; }

        public List<Respuesta> Respuestas{ get; set; }

        [NotMapped]
        public int CantidadDeRespuestas
        {
            get
            {
                int resultado = 0;
                if (Respuestas != null)
                {
                    resultado = Respuestas.Count;
                }
                return resultado;
            }
        }
        #endregion
    }
}
