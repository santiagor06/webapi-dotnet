using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Tarea
    {
        //[Key]
        public Guid TareaId{set;get;}
        //[ForeignKey("CategoriaId")]
        public Guid CategoriaId{set;get;}
        //[Required]
        //[MaxLength(250)]
        public string Titulo{set;get;}
        public string Descripcion{set;get;}
        public Prioridad Prioridad{set;get;}
        public DateTime Fecha{set;get;}
        //[NotMapped]
        public string Resumen{set;get;}
        public virtual Categoria Categoria{set;get;}
    }

    public enum Prioridad{
        Alta,
        Media,
        Baja

    }
}