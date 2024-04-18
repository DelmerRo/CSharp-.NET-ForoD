using FORO_D.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FORO_D.Data
{
    public class UsuariosFalsoRepo
    {
        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new();
            Usuario u = new() { Nombre = "Delmer", Apellido = "Rodriguez", Email = "admin@admin.com", FechaAlta = DateTime.Now, UserName = "admin" };
            Usuario u1 = new() { Nombre = "Jorge", Apellido = "Castillo", Email = "admin1@admin.com", FechaAlta = DateTime.Now, UserName = "admin1" };
            Usuario u2 = new() { Nombre = "Matias", Apellido = "Lopez", Email = "admin2@admin.com", FechaAlta = DateTime.Now, UserName = "admin2" };
            Usuario u3 = new() { Nombre = "Ana", Apellido = "Aquino", Email = "admin3@admin.com", FechaAlta = DateTime.Now, UserName = "admin3" };
            Usuario u4 = new() { Nombre = "Maria", Apellido = "Gonzales", Email = "admin4@admin.com", FechaAlta = DateTime.Now, UserName = "admin4" };
           
            usuarios.Add(u);
            usuarios.Add(u1);
            usuarios.Add(u2);
            usuarios.Add(u3);
            usuarios.Add(u4);

            return usuarios;
        }
    }
}
