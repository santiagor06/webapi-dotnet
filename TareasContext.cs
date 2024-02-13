using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api
{
    public class TareasContext:DbContext
    {
        public DbSet<Categoria>Categorias{set;get;}
        public DbSet<Tarea>Tareas{set;get;}

        public TareasContext(DbContextOptions<TareasContext>options):base(options){}
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria>InitialCategorias=[];
            InitialCategorias.Add(new Categoria(){CategoriaId=Guid.Parse("c5a32371-0b2a-4694-84ce-6d08fa053c11"),Nombre="Trabajo",Peso=10});
            InitialCategorias.Add(new Categoria(){CategoriaId=Guid.Parse("c5a32371-0b2a-4694-84ce-6d08fa053c12"),Nombre="Ocio",Peso=1});
            modelBuilder.Entity<Categoria>(categoria=>{
                categoria.ToTable("Categoria");
                categoria.HasKey(p=>p.CategoriaId);
                categoria.Property(p=>p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p=>p.Descripcion).IsRequired(false);
                categoria.Property(p=>p.Peso);
                categoria.HasData(InitialCategorias);

            });
            List<Tarea>initialTareas=[];
            initialTareas.Add(new Tarea(){CategoriaId=Guid.Parse("c5a32371-0b2a-4694-84ce-6d08fa053c11"),TareaId=Guid.Parse("c5a32371-0b2a-4694-84ce-6d08fa053c13"),Prioridad=Prioridad.Alta,Fecha=DateTime.Now,Titulo="Aprender .NET"});
            initialTareas.Add(new Tarea(){CategoriaId=Guid.Parse("c5a32371-0b2a-4694-84ce-6d08fa053c12"),TareaId=Guid.Parse("c5a32371-0b2a-4694-84ce-6d08fa053c15"),Prioridad=Prioridad.Baja,Fecha=DateTime.Now,Titulo="Jugar Play"});
            modelBuilder.Entity<Tarea>(tarea=>{
                tarea.ToTable("Tarea");
                tarea.HasKey(p=>p.TareaId);
                tarea.HasOne(p=>p.Categoria).WithMany(p=>p.Tareas).HasForeignKey(p=>p.CategoriaId);
                tarea.Property(p=>p.Titulo).IsRequired().HasMaxLength(250);
                tarea.Property(p=>p.Descripcion).IsRequired(false);
                tarea.Property(p=>p.Prioridad);
                tarea.Property(p=>p.Fecha);
                tarea.Ignore(p=>p.Resumen);
                tarea.HasData(initialTareas);
            });
        }

    }
}