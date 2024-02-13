using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Services
{
    public class HelloWorld:IHelloWorld
    {
        public string Saludo()
        {
            return "Hello world";
        }
        public string Despedida()
        {
            return "Bye,World";
        }
    }
    public interface IHelloWorld
    {
        string Saludo();
    }
}