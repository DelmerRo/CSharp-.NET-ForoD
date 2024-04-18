using FORO_D.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FORO_D.ViewModels
{
    public class RegistracionViewModel
    {
        [Display(Name = Alias.Nombre)]
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [StringLength(Restrictions.MaxNom, MinimumLength = Restrictions.MinNom, ErrorMessage = ErrMsgs.StrMaxMin)]
        public string Nombre { get; set; }

        [Display(Name = Alias.Apellido)]
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [StringLength(Restrictions.MaxApe, MinimumLength = Restrictions.MinApe, ErrorMessage = ErrMsgs.StrMaxMin)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [StringLength(Restrictions.MaxNomUser, MinimumLength = Restrictions.MinNomUser, ErrorMessage = ErrMsgs.StrMaxMin)]
        [Remote(action: "UsuarioDisponible", controller: "Account")]
        [Display(Name = Alias.UserName)]
        public string UserName { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [EmailAddress(ErrorMessage = ErrMsgs.NoValido)]
        [Remote(action: "EmailDisponible",controller:"Account")]
        [Display(Name = Alias.Email)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [DataType(DataType.Password,ErrorMessage = ErrMsgs.NoValido)]
        [Display(Name = Alias.Contraseña)]
        public string Password { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [DataType(DataType.Password, ErrorMessage = ErrMsgs.NoValido)]
        [Compare("Password",ErrorMessage =ErrMsgs.PassMissmatch)]
        [Display(Name = Alias.PassConfirm)]
        public string ConfirmacionPassword { get; set; }
    }
}
