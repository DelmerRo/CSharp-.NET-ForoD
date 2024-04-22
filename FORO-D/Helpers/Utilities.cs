using FORO_D.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Linq;

namespace FORO_D.Helpers
{
    public class Utilities
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Utilities(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string RenderizarEntrada(Entrada item, int userId, IUrlHelper urlHelper)
        {
            var urlEntradaDetails = urlHelper.Action("Details", "Entradas", new { entradaID = item.EntradaId });
            var urlMhCreate = urlHelper.Action("Create", "MiembrosHabilitados", new { entradaId = item.EntradaId });
            var renderizado = "";

            if (_httpContextAccessor.HttpContext.User.IsInRole("Miembro"))
            {
                if (!item.MiembrosHabibilitados.Any(am => am.MiembroId == userId && am.EntradaId == item.EntradaId) && item.Privada && item.MiembroId != userId)
                {
                    renderizado = RenderizarEntradaPrivada(item, urlMhCreate);
                }
                else if (item.MiembrosHabibilitados.Any(am => am.MiembroId == userId && am.EntradaId == item.EntradaId && !am.Habilitado) && item.Privada && item.MiembroId != userId)
                {
                    renderizado = RenderizarEntradaMiembroAutorizacionPendiente(item, urlEntradaDetails);
                }
                else if (item.MiembrosHabibilitados.Any(am => am.MiembroId == userId && am.EntradaId == item.EntradaId && am.Habilitado) && item.Privada && item.MiembroId != userId)
                {
                    renderizado = RenderizarEntradaMiembroAutorizado(item, urlEntradaDetails);
                }
                else if (item.MiembroId == userId)
                {
                    renderizado = RenderizarEntradaMiembroMiEntrada(item, urlEntradaDetails);
                }
                else
                {
                    if ((_httpContextAccessor.HttpContext.User.IsInRole("Miembro") && item.MiembroId != userId && !item.Privada))
                    {
                        renderizado = RenderizarEntradaPublica(item, urlEntradaDetails);
                    }
                }
            }
            else
            {
                if (!item.Privada)
                {
                    renderizado = RenderizarEntradaPublica(item, urlEntradaDetails);
                }
                else if (_httpContextAccessor.HttpContext.User.IsInRole("Usuario"))
                {
                    renderizado = RenderizarEntradaPrivadaLink(item, urlEntradaDetails);
                }
                else
                {
                    renderizado = RenderizarEntradaPrivada(item, urlMhCreate);
                }
            }

            return renderizado;
        }

        private string RenderizarEntradaPrivada(Entrada item, string url)
        {
            return $@"
        <div class=""card-header alert-info py-1"">
            <h5 class=""card-title"">
                {item.Titulo}
                <span>
                    <a class=""btn btn-danger btn-sm m-1 text-white"" href=""{url}"">
                        privado
                    </a>
                </span>
            </h5>
        </div>
        <p class=""card-text ml-3 mt-2"">{item.Descripcion}</p>
        <div class=""card-footer text-muted py-0"">
            <small class=""card-text"">
                Publicado por: {item.Miembro.NombreCompleto} el: {item.Fecha}
            </small>
        </div>";
        }

        private string RenderizarEntradaPrivadaLink(Entrada item, string url)
        {
            return $@"
                <div class=""card-header alert-info py-1"">
                    <a href=""{url}"">
                        <h5 class=""card-title"">{item.Titulo} <span><a class=""btn btn-danger btn-sm m-1 text-white""> privado</a></span></h5>
                    </a>
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
                    <h5 class=""card-title""><h5 class=""card-title"">{item.Titulo} <span><a class=""btn btn-warning btn-sm m-1 text-white""> privado: Autorización pendiente</a></span></h5></a>
                </div>
                <p class=""card-text ml-3 mt-2""> {item.Descripcion}</p>
                <div class=""card-footer text-muted py-0"">
                    <small class=""card-text"">Publicado por: {item.Miembro.NombreCompleto} el: {item.Fecha}</small>
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
                    <small class=""card-text"">Publicado por: {item.Miembro.NombreCompleto} el: {item.Fecha} </small>
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
                </div>";
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
