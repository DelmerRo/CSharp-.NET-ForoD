using FORO_D.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FORO_D.Models
{  
    public class PrecargaDatos
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<Rol> _roleManager;
        private readonly ForoContext _context;
        private const string passwordDefault= "Password1!";
        public PrecargaDatos(UserManager<Usuario> userManager, RoleManager<Rol> roleManager,ForoContext context) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void TraerInformacionDeData() {
            if (!_roleManager.Roles.Any()) {
                CargarRoles();
            }
            CargarUsuarios();
            CargarMiembros();
            CargarCategorias();
            CargarEntradas();
            CargarMiembrosHabilitados();
            CargarPreguntas();
            CargarRespuestas();
            CargarReacciones();
        }

        public void CargarRoles() {
            _roleManager.CreateAsync(new Rol() { Name = "Miembro" }).Wait();
            _roleManager.CreateAsync(new Rol() { Name = "Usuario" }).Wait();
        }

        public void CargarUsuarios()
        {
            if (!_context.Usuarios.Any()) {
                List<Usuario> usuarios = UsuariosFalsoRepo.GetUsuarios();
                var nombreRol = "Usuario";
                foreach (Usuario unUsuario in usuarios) {
                    if (_userManager.FindByEmailAsync(unUsuario.Email).Result==null) {
                        var seCreoUsuario = _userManager.CreateAsync(unUsuario,passwordDefault).Result;
                        if (seCreoUsuario.Succeeded) {
                            _userManager.AddToRoleAsync(unUsuario,nombreRol).Wait();
                        }
                    }

                }
            }

        }

        public void CargarMiembros ()
        {
            if (!_context.Miembros.Any())
            {
                List<Miembro> miembros = MiembrosFalsoRepo.GetMiembros();
                var nombreRol = "Miembro";
                foreach (Miembro unMiembro in miembros)
                {
                    if (_userManager.FindByEmailAsync(unMiembro.Email).Result == null)
                    {
                        var seCreoMiembro = _userManager.CreateAsync(unMiembro, passwordDefault).Result;
                        if (seCreoMiembro.Succeeded)
                        {
                            _userManager.AddToRoleAsync(unMiembro, nombreRol).Wait();
                        }
                    }

                }
            }

        }

        public void CargarCategorias() {
            if (!_context.Categorias.Any())
            {
                List<Categoria> categorias = CategoriasFalsoRepo.GetCategorias();
                foreach (Categoria unaCategoria in categorias)
                {
                    var categoriaEncontrada = _context.Categorias.FirstOrDefault(c => c.Nombre == unaCategoria.Nombre);
                    if (categoriaEncontrada == null)
                    {
                        Categoria categoria = new();
                        categoria.Nombre = unaCategoria.Nombre;
                        _context.Add(categoria);
                        _context.SaveChangesAsync().Wait();
                    }
                }
            }
         }

        public void CargarEntradas()
        {
            if (!_context.Entradas.Any())
            {
                List<Entrada> entradas = EntradasFalsoRepo.GetEntradas();
                foreach (Entrada unaEntrada in entradas)
                {
                    var entradaEncontrada = _context.Entradas.FirstOrDefault(c => c.Titulo == unaEntrada.Titulo);
                    if (entradaEncontrada == null)
                    {
                        _context.Add(unaEntrada);
                        _context.SaveChangesAsync().Wait();
                    }
                }
            }
        }
        public void CargarMiembrosHabilitados()
        {
            if (!_context.MiembrosHabilitados.Any())
            {
                List<MiembrosHabilitados> mh = MiembrosHabilitadosFalsoRepo.GetMiembrosHabilitados();
                foreach (MiembrosHabilitados unMh in mh)
                {
                    var habilitadoExiste = _context.MiembrosHabilitados.FirstOrDefault(c => c.MiembroId == unMh.MiembroId && c.EntradaId == unMh.EntradaId);
                    if (habilitadoExiste == null)
                    {
                        _context.Add(unMh);
                        _context.SaveChangesAsync().Wait();
                    }
                }
            }
        }

        public void CargarPreguntas()
        {
            if (!_context.Preguntas.Any())
            {
                List<Pregunta> preguntas = PreguntasFalsoRepo.GetPreguntas();
                foreach (Pregunta unaPregunta in preguntas)
                {
                    var preguntaEncontrada = _context.Preguntas.FirstOrDefault(c => c.Descripcion == unaPregunta.Descripcion);
                    if (preguntaEncontrada == null)
                    {
                        _context.Add(unaPregunta);
                        _context.SaveChangesAsync().Wait();
                    }
                }
            }
        }

        public void CargarRespuestas()
        {
            if (!_context.Respuestas.Any())
            {
                List<Respuesta> respuestas = RespuestasFalsoRepo.GetRespuestas();
                foreach (Respuesta unaRespuesta in respuestas)
                {
                    var respuestaEncontrada = _context.Respuestas.FirstOrDefault(c => c.Descripcion == unaRespuesta.Descripcion);
                    if (respuestaEncontrada == null)
                    {
                        _context.Add(unaRespuesta);
                        _context.SaveChangesAsync().Wait();
                    }
                }
            }
        }
        public void CargarReacciones()
        {
            if (!_context.Reacciones.Any())
            {
                List<Reaccion> reacciones = ReaccionesFalsoRepo.GetReacciones();
                foreach (Reaccion unaReaccion in reacciones)
                {
                    var reaccionesEncontrada = _context.Reacciones.FirstOrDefault(c => c.MiembroId == unaReaccion.MiembroId && c.RespuestaId == unaReaccion.RespuestaId);
                    if (reaccionesEncontrada == null)
                    {
                        _context.Add(unaReaccion);
                        _context.SaveChangesAsync().Wait();
                    }
                }

            }
        }
    }
    
}
