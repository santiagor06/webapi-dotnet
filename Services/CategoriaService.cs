using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api;
using api.Models;

namespace webapi.Services
{
    public class CategoriaService:ICategoriaService
    {
        public TareasContext context;
        public CategoriaService(TareasContext tareasContext)
        {
            context=tareasContext;
        }

        public IEnumerable<Categoria> Get()
        {
            return context.Categorias;
        }

        public async Task Post(Categoria categoria)
        {
            await context.Categorias.AddAsync(categoria);
            await context.SaveChangesAsync();
        }

        public async Task Put(Categoria categoria,Guid id)
        {
            var categoriaActual=context.Categorias.Find(id);
            if(categoriaActual != null){
                categoriaActual.Descripcion=categoria.Descripcion;
                categoriaActual.Nombre=categoria.Nombre;
                categoriaActual.Peso=categoria.Peso;
                await context.SaveChangesAsync();
            }
          }
        public void Delete(Guid id)
        {
            var categoria=context.Categorias.Find(id);
            if(categoria != null)
            {
                 context.Categorias.Remove(categoria);
            }
        }
    }
    public interface ICategoriaService
    {
        IEnumerable<Categoria> Get();
        Task Post(Categoria categoria);
        Task Put(Categoria categoria,Guid id);
        void Delete(Guid id);

    }
}