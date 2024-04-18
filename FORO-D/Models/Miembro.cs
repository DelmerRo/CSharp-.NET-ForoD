using FORO_D.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace FORO_D.Models
{
    public class Miembro : Usuario
    {
        #region Propiedades
        [Display(Name = Alias.Telefono)]
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [StringLength(15, MinimumLength = 8, ErrorMessage = ErrMsgs.StrMaxMin)]
        [DataType(DataType.PhoneNumber, ErrorMessage = ErrMsgs.NoValido)]
        [RegularExpression(@"[0-9]{2}[0-9]{4}[0-9]{4}", ErrorMessage = ErrorMsg.FormatoCelularInvalido)]
        public string Telefono { get; set; }

        public List<Reaccion> PreguntasYRespuestasQueMeGustan { get; set; }

        public List<MiembrosHabilitados> Entradas { get; set; }

        public List<Pregunta> Preguntas { get; set; }

        public List<Respuesta> Respuestas { get; set; }


        #endregion


    }
}
