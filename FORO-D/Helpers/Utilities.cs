
using FORO_D.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Linq;
using System.Security.Policy;

namespace FORO_D.Helpers
{
    public class Utilities
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Utilities(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string RenderizarEntrada(Entrada item, int userId, string controller, string action, IUrlHelper urlHelper)
        {
            var url = urlHelper.Action(action, controller, new { id = item.EntradaId });
            var renderizado = "";
            if (_httpContextAccessor.HttpContext.User.IsInRole("Miembro"))
            {
                if (!item.MiembrosHabibilitados.Any(am => am.MiembroId == userId && am.EntradaId == item.EntradaId) && item.Privada && item.MiembroId != userId)
                {
                    renderizado = RenderizarEntradaPrivadoLink(item, url);
                }
                else if (item.MiembrosHabibilitados.Any(am => am.MiembroId == userId && am.EntradaId == item.EntradaId && !am.Habilitado) && item.Privada && item.MiembroId != userId)
                {
                    renderizado = RenderizarEntradaMiembroAutorizacionPendiente(item, url);
                }
                else if (item.MiembrosHabibilitados.Any(am => am.MiembroId == userId && am.EntradaId == item.EntradaId && am.Habilitado) && item.Privada && item.MiembroId != userId)
                {
                    renderizado = RenderizarEntradaMiembroAutorizado(item, url);
                }
                else if (item.MiembroId == userId)
                {
                    renderizado = RenderizarEntradaMiembroMiEntrada(item, url);
                }
                else
                {
                    if ((_httpContextAccessor.HttpContext.User.IsInRole("Miembro") && item.MiembroId != userId && !item.Privada))
                    {
                        renderizado = RenderizarEntradaPublica(item, url);
                    }
                }
            }
            else
            {
                if (!item.Privada)
                {
                    renderizado = RenderizarEntradaPublica(item, url);
                }
                else if (_httpContextAccessor.HttpContext.User.IsInRole("Usuario"))
                {
                    renderizado = RenderizarEntradaPrivada(item);
                }
                else
                {
                    renderizado = RenderizarEntradaPrivadoLink(item, url);
                }
            }
            return renderizado;

        }

        private string RenderizarEntradaPrivada(Entrada item)
        {
            return $@"
        <div class=""card-header alert-info py-1"">
        <p class=""alert-info"">Publicado por: {item.Miembro.NombreCompleto} el: {item.Fecha} <a class=""btn btn-danger btn-sm m-1 text-white""> privado</a></p>
        </div>
        <p class=""card-text ml-3 mt-2""> {item.Descripcion}</p>
        <div class=""card-footer text-muted py-0"">
        <p class=""alert-info"">Publicado por: {item.Miembro.NombreCompleto} el: {item.Fecha}</p>
        </div>";
        }

        private string RenderizarEntradaPrivadoLink(Entrada item, string url)
        {
            return $@"
        <div class=""card-header alert-info py-1"">
        <a href=""{url}""><h5 class=""card-title"">{item.Titulo} <span><a class=""btn btn-danger btn-sm m-1 text-white""> privado</a></span></h5></a>
         </div>
        <p class=""card-text  ml-3 mt-2""> {item.Descripcion}</p>
        <div class=""card-footer text-muted py-0"">
            <small class=""card-text"">Publicado por: {item.Miembro.NombreCompleto} el: {item.Fecha}</small>
        </div>";
        }

        private string RenderizarEntradaMiembroAutorizacionPendiente(Entrada item, string url)
        {
            return $@"
        <div class=""card-header alert-info py-1"">
            <a href=""{url}""><h5 class=""card-title"">{item.Titulo} <span><a class=""btn btn-warning btn-sm m-1 text-white""> privado: Autorización pendiente</a></span></h5></a>
        </div>
        <p class=""card-text ml-3 mt-2""> {item.Descripcion}</p>
        <div class=""card-footer text-muted py-0"">
            <p class=""alert-info"">Publicado por: {item.Miembro.NombreCompleto} el: {item.Fecha}</p>
        </div>";
        }

        private string RenderizarEntradaMiembroAutorizado(Entrada item, string url)
        {
            return $@"
        <div class=""card-header alert-info py-1"">
            <a href=""{url}""><h5 class=""card-title"">{item.Titulo} <span><a class=""btn btn-success btn-sm m-1 text-white""> privado: autorizado</a></span></h5></a>
        </div>
        <p class=""card-text  ml-3 mt-2""> {item.Descripcion}</p>
        <div class=""card-footer text-muted py-0"">
            <p class=""alert-success text-white"">Publicado por: {item.Miembro.NombreCompleto} el: {item.Fecha} </p>
        </div>";
        }

        private string RenderizarEntradaMiembroMiEntrada(Entrada item, string url)
        {
            return $@"
        <div class=""card-header alert-info py-1"">
            <a href=""{url}""><h5 class=""card-title"">{item.Titulo} <span><a class=""btn btn-info btn-sm m-1 text-white"">Mis entradas</a></span></h5></a>
        </div>
        <p class=""card-text ml-3 mt-2""> {item.Descripcion}</p>
        <div class=""card-footer text-muted py-0"">
            <small class=""card-text"">Publicado por: {item.Miembro.NombreCompleto} el: {item.Fecha} </small>
        </div>
            ";
        }

        private string RenderizarEntradaPublica(Entrada item, string url)
        {
            return $@"
        <div class=""card-header alert-info py-1"">
            <a href=""{url}""><h5 class=""card-title mt-1"">{item.Titulo}</h5></a>
        </div>
            <p class=""card-text ml-3 mt-2"">{item.Descripcion}</p>
        <div class=""card-footer text-muted py-0"">
            <small class=""card-text"">Publicado por: {item.Miembro.NombreCompleto} el: {item.Fecha}</small>
        </div>";
        }

    }
}
