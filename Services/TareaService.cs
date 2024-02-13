using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api;
using api.Models;

namespace webapi.Services
{
    public class TareaService:ITareaService
    {
        public TareasContext context;
        public TareaService(TareasContext tareasContext)
        {
            context=tareasContext;
        }
        public IEnumerable<Tarea>Get()
        {
            return context.Tareas;
        }
        public async Task Post(Tarea tarea)
        {
            await context.Tareas.AddAsync(tarea);
            await context.SaveChangesAsync();

        }
        public async Task Put(Tarea tarea,Guid id)
        {
            var tareaActual=context.Tareas.Find(id);
            if(tareaActual != null)
            {
                tareaActual.Titulo=tarea.Titulo;
                tareaActual.Descripcion=tarea.Descripcion;
                tareaActual.CategoriaId=tarea.CategoriaId;
                tareaActual.Prioridad=tarea.Prioridad;
                await context.SaveChangesAsync();
            }
        }

        public void Delete(Guid id)
        {
            var tareaActual=context.Tareas.Find(id);
            if(tareaActual != null)
            {
                context.Tareas.Remove(tareaActual);
            }
        }
    }
    public interface ITareaService
    {
        IEnumerable<Tarea>Get();
        Task Post(Tarea tarea);
        Task Put(Tarea tarea,Guid id);
        void Delete(Guid id);


    }
}