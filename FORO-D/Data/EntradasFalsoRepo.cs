using FORO_D.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FORO_D.Data
{
    public class EntradasFalsoRepo
    {
        public static List<Entrada> GetEntradas()
        {
            DateTime d1 = new (2022, 07, 02, 06, 52, 14);
            DateTime d2 = new (2022, 07, 01, 07, 51, 16);
            DateTime d3 = new (2022, 06, 28, 12, 50, 50);
            DateTime d4 = new (2022, 07, 02, 18, 18, 18);
            DateTime d5 = new (2022, 06, 17, 22, 59, 30);
            DateTime d6 = new (2022, 07, 08, 14, 12, 44);
            DateTime d7 = new (2021, 07, 07, 18, 50, 33);
            DateTime d8 = new (2022, 03, 28, 03, 50, 50);
            DateTime d9 = new (2022, 01, 30, 02, 50, 50);
            DateTime d10 = new(2022, 02,12, 06, 52, 14);
            DateTime d11 = new(2021, 02, 05, 07, 51, 16);
            DateTime d12 = new(2021, 11, 15, 12, 50, 50);
            DateTime d13 = new(2021, 02, 01, 06, 51, 10);
            DateTime d14 = new(2022, 02, 20, 22, 59, 30);
            DateTime d16= new(2022, 02, 02, 18, 50, 33);
            DateTime d17= new(2022, 02, 23, 03, 50, 50);
            DateTime d18= new(2022, 02, 02, 02, 50, 50);

            Entrada ent1 = new() { Titulo = "Notebook", Descripcion = "Modelos 2022", Fecha = d1, Privada = false, CategoriaId = 1, MiembroId = 6 };
            Entrada ent2 = new() { Titulo = "Pelicula Drama", Descripcion = "Recomendacion y preguntas", Fecha = d2, Privada = true, CategoriaId = 3, MiembroId = 6 };

            Entrada ent3 = new() { Titulo = "Rock", Descripcion = "Mejor rock para recomendar", Fecha = d3, Privada = false, CategoriaId = 4, MiembroId = 7 };
            Entrada ent4 = new() { Titulo = "Noticias de Espectulo", Descripcion = "Los acontecimientos que dejo el 2001", Fecha = d4, Privada = false, CategoriaId = 2, MiembroId = 7 };
            Entrada ent5 = new() { Titulo = "Instrumentos Musicales", Descripcion = "Las mejores marcas recomendadas", Fecha = d5, Privada = true, CategoriaId = 4, MiembroId = 7 };

            Entrada ent6 = new() { Titulo = "Memoria ram", Descripcion = "Que dudas tiene al respecto", Fecha = d6, Privada = true, CategoriaId = 1, MiembroId = 8 };
            Entrada ent7 = new() { Titulo = "Universidades Publicas", Descripcion = "Que opiniones y dudas tienen", Fecha = d7, Privada = false, CategoriaId = 2, MiembroId = 8 };

            Entrada ent8 = new() { Titulo = "Dota", Descripcion = "Mapas y consultas", Fecha = d8, Privada = true, CategoriaId = 5, MiembroId = 9 };
            Entrada ent9 = new() { Titulo = "PC de Escritorio", Descripcion = "Dudas y tips", Fecha = d9, Privada = false, CategoriaId = 1, MiembroId = 9 };

            Entrada ent10 = new() { Titulo = "Parques recreativos", Descripcion = "Hablemos sobre parques recreativos", Fecha = d10, Privada = true, CategoriaId = 5, MiembroId = 10 };
            Entrada ent11 = new() { Titulo = "Tecnologia 5G", Descripcion = "Cuenten sus consultas y experiencias al respecto", Fecha = d11, Privada = false, CategoriaId = 1, MiembroId = 10 };

            Entrada ent12 = new() { Titulo = "Vacaciones", Descripcion = "Compartan sus dudas", Fecha = d12, Privada = true, CategoriaId = 5, MiembroId = 11 };
            Entrada ent13 = new() { Titulo = "Celulares", Descripcion = "Que dudas tienen respecto a algunos modelos", Fecha = d13, Privada = false, CategoriaId = 1, MiembroId = 11 };

            Entrada ent14 = new() { Titulo = "Basquet", Descripcion = "Todas sus dudas se resuelven aca", Fecha = d14, Privada = true, CategoriaId = 6, MiembroId = 12 };
            Entrada ent15 = new() { Titulo = "Ofimatica", Descripcion = "Planteen sus dudas respecto a los programas de ofimatica", Fecha = d16, Privada = false, CategoriaId = 7, MiembroId = 12 };
            Entrada ent16 = new() { Titulo = "Artistas", Descripcion = "Dudas respecto a Artistas", Fecha = d17, Privada = true, CategoriaId = 2, MiembroId = 12 };
            Entrada ent17 = new() { Titulo = "Xiaomi", Descripcion = "Modelos y dudas", Fecha = d18, Privada = false, CategoriaId = 1, MiembroId = 12 };

            

            List<Entrada> entradas = new();
            entradas.Add(ent1);
            entradas.Add(ent2);
            entradas.Add(ent3);
            entradas.Add(ent4);
            entradas.Add(ent5);
            entradas.Add(ent6);
            entradas.Add(ent7);
            entradas.Add(ent8);
            entradas.Add(ent9);
            entradas.Add(ent10);
            entradas.Add(ent11);
            entradas.Add(ent12);
            entradas.Add(ent13);
            entradas.Add(ent14);
            entradas.Add(ent15);
            entradas.Add(ent16);
            entradas.Add(ent17);
            
            return entradas;
        }
    }
}
