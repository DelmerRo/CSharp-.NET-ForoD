using FORO_D.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FORO_D.Data
{
    public class MiembrosHabilitadosFalsoRepo
    {
        public static List<MiembrosHabilitados> GetMiembrosHabilitados()
        {
            MiembrosHabilitados mh1 = new () { EntradaId = 5, MiembroId = 6,  Habilitado=true};
            MiembrosHabilitados mh2 = new() { EntradaId = 14, MiembroId = 6,  Habilitado = true };
            MiembrosHabilitados mh3 = new() { EntradaId = 16, MiembroId = 6,  Habilitado = true };
            MiembrosHabilitados mh4 = new() { EntradaId = 2, MiembroId = 7,  Habilitado = true };
            MiembrosHabilitados mh5 = new() { EntradaId = 14, MiembroId = 7,  Habilitado = true };
            MiembrosHabilitados mh6 = new() { EntradaId = 5,  MiembroId = 8,  Habilitado = false };
            MiembrosHabilitados mh7 = new() { EntradaId = 14, MiembroId = 8,  Habilitado = false };
            MiembrosHabilitados mh8 = new() { EntradaId = 2,  MiembroId = 9,  Habilitado = true };
            MiembrosHabilitados mh9 = new() { EntradaId = 5,  MiembroId = 9,  Habilitado = true };
            MiembrosHabilitados mh10 = new() { EntradaId = 12, MiembroId = 9,  Habilitado = true };
            MiembrosHabilitados mh11 = new() { EntradaId = 16, MiembroId = 9,  Habilitado = false };
            MiembrosHabilitados mh12 = new() { EntradaId = 2, MiembroId = 10,  Habilitado = false };
            MiembrosHabilitados mh13 = new() { EntradaId = 2, MiembroId = 11,  Habilitado = false };
            MiembrosHabilitados mh14 = new() { EntradaId = 5, MiembroId = 11,  Habilitado = false };
            MiembrosHabilitados mh15 = new() { EntradaId = 10, MiembroId = 12,  Habilitado = false };
            MiembrosHabilitados mh16 = new() { EntradaId = 8, MiembroId = 6, Habilitado = false };

            List<MiembrosHabilitados> miembrosHabilitados = new ();
            miembrosHabilitados.Add(mh1);
            miembrosHabilitados.Add(mh2);
            miembrosHabilitados.Add(mh3);
            miembrosHabilitados.Add(mh4);
            miembrosHabilitados.Add(mh5);
            miembrosHabilitados.Add(mh6);
            miembrosHabilitados.Add(mh7);
            miembrosHabilitados.Add(mh8);
            miembrosHabilitados.Add(mh9);
            miembrosHabilitados.Add(mh10);
            miembrosHabilitados.Add(mh11);
            miembrosHabilitados.Add(mh12);
            miembrosHabilitados.Add(mh13);
            miembrosHabilitados.Add(mh14);
            miembrosHabilitados.Add(mh15);
            miembrosHabilitados.Add(mh16);

            return miembrosHabilitados;
        }
    }
}
