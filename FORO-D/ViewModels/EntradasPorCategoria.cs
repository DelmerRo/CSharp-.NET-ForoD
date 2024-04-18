using FORO_D.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FORO_D.ViewModels
{
    public class EntradasPorCategoria
    {
        public int CategoriaId { get; set; }

        public List<Categoria> Categorias { get; set; }

        public int UsuarioLogueadoId { get; set; }

        public List<Miembro> Miembros { get; set; }

        public List<Entrada> Entradas { get; set; }
       
    }
}
