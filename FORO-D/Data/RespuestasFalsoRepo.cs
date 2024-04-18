using FORO_D.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FORO_D.Data
{
    public class RespuestasFalsoRepo
    {
        public static List<Respuesta> GetRespuestas()
        {
            Respuesta res1 = new() { PreguntaId = 13, MiembroId =6, Descripcion = "En el lugar donde vivo aun no existe esa tecnologia", Fecha = new(2022, 02, 09, 06, 13, 50) };
            Respuesta res2 = new() { PreguntaId = 20, MiembroId = 6, Descripcion = "Tendrias que activar por los medios formales", Fecha = new(2022, 02, 09, 06, 14, 50) };
            Respuesta res3 = new() { PreguntaId = 28, MiembroId = 6, Descripcion = "A mi pareces es  fredy mercury", Fecha = new(2022, 02, 09, 06, 15, 50) };
            Respuesta res4 = new() { PreguntaId = 7, MiembroId = 6, Descripcion = "La version 2019 no me trajo ningun problema", Fecha = new(2022, 02, 09, 06, 16, 50) };
            Respuesta res5 = new() { PreguntaId = 8, MiembroId = 6, Descripcion = "Al parecer y por muchas estadisticas es David Robinson", Fecha = new(2022, 02, 09, 06, 17, 50) };
            Respuesta res6 = new() { PreguntaId = 17, MiembroId = 6, Descripcion = "Yo recomiendo los modelos telecaster son los mejores", Fecha = new(2022, 02, 09, 06, 18, 50) };
            Respuesta res7 = new() { PreguntaId = 17, MiembroId = 6, Descripcion = "El Stratocaster Standard  es uno de los modelos en calidad y precio", Fecha = new(2022, 02, 09, 06, 19, 50) };
            Respuesta res8 = new() { PreguntaId = 13, MiembroId = 7, Descripcion = "La verdad que esta buenisimo y se nota el cambio", Fecha = new(2022, 02, 09, 06, 20, 50) };
            Respuesta res9 = new() { PreguntaId = 2, MiembroId = 7, Descripcion = "En la Universidad de Buenos Aires", Fecha = new(2022, 02, 09, 06, 21, 50) };
            Respuesta res10 = new() { PreguntaId = 17, MiembroId = 7, Descripcion = "Una fender mexicana no tiene pierde", Fecha = new(2022, 02, 09, 06, 22, 50) };

            Respuesta res11 = new() { PreguntaId = 22, MiembroId = 7, Descripcion = "Son solo mentiras", Fecha = new(2022, 02, 09, 06, 23, 50) };
            Respuesta res12 = new() { PreguntaId = 29, MiembroId = 7, Descripcion = "Seguro que quisiste decir cuesta, aproximadamente estan en 500 dolares", Fecha = new(2022, 02, 09, 06, 24, 50) };
            Respuesta res13 = new() { PreguntaId = 13, MiembroId = 7, Descripcion = "No note la diferencia", Fecha = new(2022, 02, 09, 06, 25, 50) };
            Respuesta res14 = new() { PreguntaId = 2, MiembroId = 8, Descripcion = "Y si mejor no estudias", Fecha = new(2022, 02, 09, 06, 26, 50) };
            Respuesta res15 = new() { PreguntaId = 2, MiembroId = 8, Descripcion = "En cualquier universidad si sos aplicado siempre te va ir bien", Fecha = new(2022, 02, 09, 06, 27, 50) };
            Respuesta res16 = new() { PreguntaId = 8, MiembroId = 8, Descripcion = "Algunos dicen que es Alvin Robertson", Fecha = new(2022, 02, 09, 06, 28, 50) };
            Respuesta res17 = new() { PreguntaId = 7, MiembroId = 8, Descripcion = "Yo no recomiendo la version 2020", Fecha = new(2022, 02, 09, 06, 29, 50) };
            Respuesta res18 = new() { PreguntaId = 23, MiembroId = 8, Descripcion = "Hay un modelo que se llama Shark y me parece que es el mejor para Gamming", Fecha = new(2022, 02, 09, 06, 30, 50) };
            Respuesta res19 = new() { PreguntaId = 23, MiembroId = 8, Descripcion = "En calidad y precio me conformaria con la version Note Pro", Fecha = new(2022, 02, 09, 06, 31, 50) };
            Respuesta res20 = new() { PreguntaId = 5, MiembroId = 9, Descripcion = "Ryzen 5 es el mejor", Fecha = new(2022, 02, 09, 06, 32, 50) };

            Respuesta res21 = new() { PreguntaId = 2, MiembroId = 9, Descripcion = "Yo estudie en la UBA y la enseñanza es buena", Fecha = new(2022, 02, 09, 06, 33, 50) };
            Respuesta res22 = new() { PreguntaId = 29, MiembroId = 9, Descripcion = "En argentina aun no lo venden de manera oficial", Fecha = new(2022, 02, 09, 06, 34, 50) };
            Respuesta res23 = new() { PreguntaId =10, MiembroId = 9, Descripcion = "En los modelos APU y anteriores pasaba eso, ahora no", Fecha = new(2022, 02, 09, 06, 35, 50) };
            Respuesta res24 = new() { PreguntaId = 8, MiembroId = 9, Descripcion = "Creo que Dwight Howard", Fecha = new(2022, 02, 09, 06, 36, 50) };
            Respuesta res25 = new() { PreguntaId = 3, MiembroId = 9, Descripcion = "Los profesores todos son muy buenos", Fecha = new(2022, 02, 09, 06, 37, 50) };
            Respuesta res26 = new() { PreguntaId = 2, MiembroId = 10, Descripcion = "En la UBA obvio", Fecha = new(2022, 02, 09, 06, 38, 50) };
            Respuesta res27 = new() { PreguntaId = 7, MiembroId = 10, Descripcion = "No soy usuario Windows", Fecha = new(2022, 02, 09, 06, 39, 50) };
            Respuesta res28 = new() { PreguntaId = 30, MiembroId = 10, Descripcion = "Los celulares motorola tienen muy buena autonomia", Fecha = new(2022, 02, 09, 06, 40, 50) };
            Respuesta res29 = new() { PreguntaId = 14, MiembroId =10, Descripcion = "En Mexico esta 400 dolares", Fecha = new(2022, 02, 09, 06, 41, 50) };
            Respuesta res30 = new() { PreguntaId = 5, MiembroId = 10, Descripcion = "Y yo creo que es Intel I5", Fecha = new(2022, 02, 09, 06, 42, 50) };

            Respuesta res31 = new() { PreguntaId = 29, MiembroId = 10, Descripcion = "Yo no recomiendo ese celular pero si lo quieres adelante", Fecha = new(2022, 02, 09, 06, 43, 50) };
            Respuesta res32 = new() { PreguntaId = 7, MiembroId = 10, Descripcion = "Todas son buenas, depende de cual te guste", Fecha = new(2022, 02, 09, 06, 44, 50) };
            Respuesta res33 = new() { PreguntaId = 2, MiembroId = 11, Descripcion = "No te sabria decir", Fecha = new(2022, 02, 09, 06, 45, 50) };
            Respuesta res34 = new() { PreguntaId = 13, MiembroId = 11, Descripcion = "Yo la probe y no note diferencia en lo absoluto", Fecha = new(2022, 02, 09, 06, 46, 50) };
            Respuesta res35 = new() { PreguntaId = 20, MiembroId = 11, Descripcion = "Compra la licencia", Fecha = new(2022, 02, 09, 06, 47, 50) };
            Respuesta res36 = new() { PreguntaId = 10, MiembroId = 11, Descripcion = "Antes si, ahora los modelos Ryzen no", Fecha = new(2022, 02, 09, 06, 48, 50) };
            Respuesta res37 = new() { PreguntaId = 29, MiembroId = 11, Descripcion = "Cuesta 350 dolares en CellPgoneMarket", Fecha = new(2022, 02, 09, 06, 49, 50) };
            Respuesta res38 = new() { PreguntaId = 17, MiembroId = 11, Descripcion = "Yo tengo una Telecaster y el sonido es tan dulce", Fecha = new(2022, 02, 09, 06, 50, 50) };
            Respuesta res39 = new() { PreguntaId = 7, MiembroId = 11, Descripcion = "Siempre la ultima para  estar a la vanguardia", Fecha = new(2022, 02, 09, 06, 51, 50) };
            Respuesta res40 = new() { PreguntaId = 2, MiembroId = 12, Descripcion = "Mi primo estudio en la UBA, y ya se encuentra ejerciendo", Fecha = new(2022, 02, 09, 06, 52, 50) };

            Respuesta res41 = new() { PreguntaId = 20, MiembroId = 12, Descripcion = "Sigue esta pagina: www.serialOffice.com", Fecha = new(2022, 02, 09, 06, 53, 50) };
            Respuesta res42 = new() { PreguntaId = 26, MiembroId = 12, Descripcion = "Las Vaio de ahora no son tan buenas", Fecha = new(2022, 02, 09, 06, 54, 50) };
            Respuesta res43 = new() { PreguntaId = 29, MiembroId = 12, Descripcion = "Es mejor que lo compres en Paraguay", Fecha = new(2022, 02, 09, 06, 55, 50) };
            Respuesta res44 = new() { PreguntaId = 17, MiembroId = 12, Descripcion = "Yo te dirira que vayas por una Gibson", Fecha = new(2022, 02, 09, 06, 56, 50) };
            Respuesta res45 = new() { PreguntaId = 23, MiembroId = 12, Descripcion = "El que mas te guste jajajaja", Fecha = new(2022, 02, 09, 06, 57, 50) };

            List<Respuesta> respuestas = new();
            respuestas.Add(res1);
            respuestas.Add(res2);
            respuestas.Add(res3);
            respuestas.Add(res4);
            respuestas.Add(res5);
            respuestas.Add(res6);
            respuestas.Add(res7);
            respuestas.Add(res8);
            respuestas.Add(res9);
            respuestas.Add(res10);

            respuestas.Add(res11);
            respuestas.Add(res12);
            respuestas.Add(res13);
            respuestas.Add(res14);
            respuestas.Add(res15);
            respuestas.Add(res16);
            respuestas.Add(res17);
            respuestas.Add(res18);
            respuestas.Add(res19);
            respuestas.Add(res20);

            respuestas.Add(res21);
            respuestas.Add(res22);
            respuestas.Add(res23);
            respuestas.Add(res24);
            respuestas.Add(res25);
            respuestas.Add(res26);
            respuestas.Add(res27);
            respuestas.Add(res28);
            respuestas.Add(res29);
            respuestas.Add(res30);

            respuestas.Add(res31);
            respuestas.Add(res32);
            respuestas.Add(res33);
            respuestas.Add(res34);
            respuestas.Add(res35);
            respuestas.Add(res36);
            respuestas.Add(res37);
            respuestas.Add(res38);
            respuestas.Add(res39);
            respuestas.Add(res40);

            respuestas.Add(res41);
            respuestas.Add(res42);
            respuestas.Add(res43);
            respuestas.Add(res44);
            respuestas.Add(res45);
            return respuestas;
        }
    }
}
