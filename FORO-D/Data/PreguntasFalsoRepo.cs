using FORO_D.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FORO_D.Data
{
    public class PreguntasFalsoRepo
    {
        public static List<Pregunta> GetPreguntas()
        {
            Pregunta pre1 = new() { MiembroId = 6, EntradaId = 7, Descripcion = "¿Que universidad recomiendan para estudiar Ingenieria de Sistemas?", Fecha = new(2022, 02, 08, 06, 01, 50), Activa = true };
            Pregunta pre2 = new() { MiembroId = 6, EntradaId = 7, Descripcion = "¿Donde puedo estudiar Ingenieria Civil?", Fecha = new(2022, 02, 08, 06,02, 50), Activa = true };
            Pregunta pre3 = new() { MiembroId = 6, EntradaId = 7, Descripcion = "¿Que opinan de la UBA?", Fecha = new(2022, 02, 08, 06, 03, 50), Activa = false };
            Pregunta pre4 = new() { MiembroId = 6, EntradaId = 1, Descripcion = "¿Que notebook recomiendan para usar Visual Studio?", Fecha = new(2022, 02, 08, 06, 04, 50), Activa = true };
            Pregunta pre5 = new() { MiembroId = 6, EntradaId = 1, Descripcion = "¿Es mejor Intel I5 o Ryzen 5?", Fecha = new(2022, 02, 08, 06, 05, 50), Activa = false };
            Pregunta pre6 = new() { MiembroId = 7, EntradaId = 4, Descripcion = "¿Que es lo que paso en la ultima semana?", Fecha = new(2022, 02, 08, 06, 06, 50), Activa = true };
            Pregunta pre7 = new() { MiembroId = 7, EntradaId = 15, Descripcion = "¿Que version de Office recomiendan?", Fecha = new(2022, 02, 08, 06, 07, 50), Activa = true };
            Pregunta pre8 = new() { MiembroId = 7, EntradaId = 14, Descripcion = "¿Cual es el mejor defensa de la historia?", Fecha = new(2022, 02, 08, 06, 08, 50), Activa = false };
            Pregunta pre9 = new() { MiembroId = 7, EntradaId = 3, Descripcion = "¿Rock de los  80 o Rock   de los 90?", Fecha = new(2022, 02, 08, 06, 09, 50), Activa = true };
            Pregunta pre10 = new() { MiembroId = 7, EntradaId = 1, Descripcion = "¿Las notebook ryzen sobrecalientan?", Fecha = new(2022, 02, 08, 06, 10, 50), Activa = false };


            Pregunta pre11 = new() { MiembroId = 6, EntradaId = 1, Descripcion = "¿Es mejor un procesador I3 gen10 o I5 gen8?", Fecha = new(2022, 02, 08, 06, 11, 50), Activa = false };
            Pregunta pre12 = new() { MiembroId = 8, EntradaId = 7, Descripcion = "¿Es muy dificil la CBC?", Fecha = new(2022, 02, 08, 06, 12, 50), Activa = true };
            Pregunta pre13 = new() { MiembroId = 8, EntradaId = 11, Descripcion = "¿Alguien probo la tecnologia 5G?", Fecha = new(2022, 02, 08, 06, 13, 50), Activa = true };
            Pregunta pre14 = new() { MiembroId = 8, EntradaId = 15, Descripcion = "¿Donde  encuentro informacion sobre Excel?", Fecha = new(2022, 02, 08, 06, 14, 50), Activa = true };
            Pregunta pre15 = new() { MiembroId = 8, EntradaId = 13, Descripcion = "¿Samsung A52 o Xiaomi Note Pro 10?", Fecha = new(2022, 02, 08, 06, 15, 50), Activa = false };
            Pregunta pre16 = new() { MiembroId = 9, EntradaId = 9, Descripcion = "¿Que gabinete recomiendan para una optima refirgeracion?", Fecha = new(2022, 02, 08, 06, 16, 50), Activa = true };
            Pregunta pre17 = new() { MiembroId = 9, EntradaId = 5, Descripcion = "¿Que guitarra  Fender recomiendan?", Fecha = new(2022, 02, 08, 06, 17, 50), Activa = true };
            Pregunta pre18 = new() { MiembroId = 9, EntradaId = 2, Descripcion = "¿Que pelicula de drama recomiendan?", Fecha = new(2022, 02, 08, 06, 18, 50), Activa = true };
            Pregunta pre19 = new() { MiembroId = 9, EntradaId = 7, Descripcion = "¿Donde queda ubicado la facultad de derecho?", Fecha = new(2022, 02, 08, 06, 19, 50), Activa = true };
            Pregunta pre20 = new() { MiembroId = 10, EntradaId = 15, Descripcion = "¿Donde encuentro numeros de serial para activar Office?", Fecha = new(2022, 02, 08, 06, 20, 50), Activa = true };


            Pregunta pre21 = new() { MiembroId = 10, EntradaId = 17, Descripcion = "¿Calidad y precio?", Fecha = new(2022, 02, 08, 06, 21, 50), Activa = true };
            Pregunta pre22 = new() { MiembroId = 10, EntradaId = 11, Descripcion = "¿Es dañino para la salud?", Fecha = new(2022, 02, 08, 06, 22, 50), Activa = true };
            Pregunta pre23 = new() { MiembroId = 10, EntradaId = 17, Descripcion = "¿Cual es el mejor celular de Xiaomi?", Fecha = new(2022, 02, 08, 06, 23, 50), Activa = false };
            Pregunta pre24 = new() { MiembroId = 11, EntradaId = 7, Descripcion = "¿Donde queda ubicado la sede de Ingenieria?", Fecha = new(2022, 02, 08, 06, 24, 50), Activa = false };
            Pregunta pre25 = new() { MiembroId = 11, EntradaId = 13, Descripcion = "¿Donde encuentro celulares de la marca Readme?", Fecha = new(2022, 02, 08, 06, 25, 50), Activa = true };
            Pregunta pre26 = new() { MiembroId = 11, EntradaId = 1, Descripcion = "¿Es mejor Vaio que Lenovo?", Fecha = new(2022, 02, 08, 06, 26, 50), Activa = true };
            Pregunta pre27 = new() { MiembroId = 13, EntradaId = 7, Descripcion = "¿Que opinan de la UTN?", Fecha = new(2022, 02, 08, 06, 27, 50), Activa = true };
            Pregunta pre28 = new() { MiembroId = 13, EntradaId = 3, Descripcion = "¿Quien es mejor vocalista de la historia?", Fecha = new(2022, 02, 08, 06, 28, 50), Activa = true };
            Pregunta pre29 = new() { MiembroId = 13, EntradaId = 17, Descripcion = "¿Cuanto cuenta el PocoPhone x3?", Fecha = new(2022, 02, 08, 06, 29, 50), Activa = true };
            Pregunta pre30 = new() { MiembroId = 13, EntradaId = 13, Descripcion = "¿Cual son los celulares de gama media que tienen mejor bateria?", Fecha = new(2022, 02, 08, 06, 30, 50), Activa = false };

            List<Pregunta> preguntas = new();
            preguntas.Add(pre1);
            preguntas.Add(pre2);
            preguntas.Add(pre3);
            preguntas.Add(pre4);
            preguntas.Add(pre5);
            preguntas.Add(pre6);
            preguntas.Add(pre7);
            preguntas.Add(pre8);
            preguntas.Add(pre9);
            preguntas.Add(pre10);

            preguntas.Add(pre11);
            preguntas.Add(pre12);
            preguntas.Add(pre13);
            preguntas.Add(pre14);
            preguntas.Add(pre15);
            preguntas.Add(pre16);
            preguntas.Add(pre17);
            preguntas.Add(pre18);
            preguntas.Add(pre19);
            preguntas.Add(pre20);

            preguntas.Add(pre21);
            preguntas.Add(pre22);
            preguntas.Add(pre23);
            preguntas.Add(pre24);
            preguntas.Add(pre25);
            preguntas.Add(pre26);
            preguntas.Add(pre27);
            preguntas.Add(pre28);
            preguntas.Add(pre29);
            preguntas.Add(pre30);
            return preguntas;
        }
    }
}
