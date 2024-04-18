using FORO_D.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FORO_D.Data
{
    public class CategoriasFalsoRepo
    {
        public static List<Categoria> GetCategorias()
        {
            Categoria cat1 = new () { Nombre = "Tecnología" };
            Categoria cat2 = new() { Nombre = "Espectáculo" };
            Categoria cat3 = new() { Nombre = "Cine" };
            Categoria cat4 =new (){ Nombre = "Música" };
            Categoria cat5 = new() { Nombre = "Entretenimiento" };
            Categoria cat6 = new() { Nombre = "Deporte" };
            Categoria cat7 = new() { Nombre = "Computacion" };
            Categoria cat8 = new() { Nombre = "Educación" };
            Categoria cat9 = new() { Nombre = "Auto" };

            List<Categoria> categorias = new();
            categorias.Add(cat1);
            categorias.Add(cat2);
            categorias.Add(cat3);
            categorias.Add(cat4);
            categorias.Add(cat5);
            categorias.Add(cat6);
            categorias.Add(cat7);
            categorias.Add(cat8);
            categorias.Add(cat9);
            return categorias;
        }
    }
}
