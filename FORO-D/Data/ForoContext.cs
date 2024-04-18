using FORO_D.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FORO_D.Data
{
    public class ForoContext:IdentityDbContext<IdentityUser<int>,IdentityRole<int>,int>
    {
        public ForoContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //relaciones muchos a muchos entre Miembro y Entrada, por medui de Fluent API
            modelBuilder.Entity<MiembrosHabilitados>().HasKey(ac => new { ac.MiembroId, ac.EntradaId });

            modelBuilder.Entity<MiembrosHabilitados>().HasOne(ac => ac.Miembro).WithMany(a => a.Entradas).HasForeignKey(ac => ac.MiembroId);
            modelBuilder.Entity<MiembrosHabilitados>().HasOne(ac => ac.Entrada).WithMany(mc => mc.MiembrosHabibilitados).HasForeignKey(ac => ac.EntradaId);

            //relaciones muchos a muchos entre Miembro Y Respuesta, por medui de Fluent API
            modelBuilder.Entity<Reaccion>().HasKey(ac => new { ac.MiembroId, ac.RespuestaId });

            modelBuilder.Entity<Reaccion>().HasOne(ac => ac.Miembro).WithMany(a => a.PreguntasYRespuestasQueMeGustan).HasForeignKey(ac => ac.MiembroId);
            modelBuilder.Entity<Reaccion>().HasOne(ac => ac.Respuesta).WithMany(mc => mc.Reacciones).HasForeignKey(ac => ac.RespuestaId);

            //Definicion de nonmbre de tablas
            modelBuilder.Entity<IdentityUser<int>>().ToTable("Usuarios");
            modelBuilder.Entity<IdentityRole<int>>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UsuariosRoles");
        }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Miembro> Miembros { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<MiembrosHabilitados> MiembrosHabilitados { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<Reaccion> Reacciones { get; set; }


    }
}
