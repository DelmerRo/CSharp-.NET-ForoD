using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FORO_D.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;

namespace FORO_D.Models{
    public class Entrada
    {
        #region Propiedades
        public int EntradaId { get; set; }

        [Required(ErrorMessage = ErrorMsg.ErrMsgRequired)]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = ErrorMsg.ErrMsgRequired)]
        public int MiembroId { get; set; }

        [Display(Name = Alias.Titulo)]
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [StringLength(Restrictions.MaxTituloEntrada, MinimumLength = Restrictions.MinTituloEntrada, ErrorMessage = ErrMsgs.StrMaxMin)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = ErrorMsg.ErrMsgRequired)]
        [StringLength(Restrictions.MaxDescEntrada, MinimumLength = Restrictions.MinDescEntrada, ErrorMessage = ErrMsgs.StrMaxMin)]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [Display(Name = Alias.FechaDePublicacion)]
        [DataType(DataType.DateTime, ErrorMessage = ErrorMsg.ErrMsgNotValid)]
        public DateTime Fecha { get; set; } = DateTime.Now;

        public Boolean Privada { get; set; } = false;

        public Miembro Miembro { get; set; }

        public Categoria Categoria { get; set; }
        public List<MiembrosHabilitados> MiembrosHabibilitados { get; set; }

        public List<Pregunta> Preguntas { get; set; }

        [NotMapped]
        public int CantidadDePreguntasYRespuestas
        {
            get
            {
                int resultado = 0;
                if (Preguntas != null)
                {
                    resultado = Preguntas.Count();
                    foreach (Pregunta preg in Preguntas)
                    {
                        resultado += preg.CantidadDeRespuestas;
                    }
                }
                return resultado;
            }
        }

        #endregion

    }
}
