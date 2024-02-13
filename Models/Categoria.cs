using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace api.Models
{
    public class Categoria
    {
        //[Key]
        public Guid CategoriaId{set;get;}
        //[Required]
        //[MaxLength(150)]
        public string Nombre{set;get;}
        public int Peso{set;get;}
        public string Descripcion{set;get;}
        [JsonIgnore]
        public virtual ICollection<Tarea>Tareas{set;get;}
    }
}