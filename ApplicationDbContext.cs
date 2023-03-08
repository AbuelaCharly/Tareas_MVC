using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TareasMVC.Entidades;

namespace TareasMVC
{

    //Heredando de DbContext podemos crear las tablas
    //Heredando de IdentityDbContext tenemos tablas por defecto para gestionar usuarios
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        //MODIFICAR LOS ATRIBUTOS DE LOS CAMPOS DE LA TABLA (API FLUENT)
        //Este metodo NO verifica en el momento de introducir los datos (metodo IsValid)
        //Usamos API Fluent cuando no podemos aplicar convenciones ni data anotations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tarea>().Property(d => d.Descripcion).HasMaxLength(500).IsRequired();
        }

        //Utilizamos DbSet para indicar que Tareas va a ser una Tabla
        //a partir de la clase Tarea y el nombre de la tabla va a ser Tareas
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Paso> Pasos { get; set; }
        public DbSet<ArchivoAdjunto> ArchivosAdjuntos { get; set; }


    }
}

