using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Middlewares
{
 class TimeMiddleware{

    readonly RequestDelegate next; // Esta prop de tipo RequestDelegate es para que ayude a pasar al siguiente middleware

    public TimeMiddleware(RequestDelegate nextRequest){

        next = nextRequest; //En el constructor se le asigna el proximo middleware

    }

  

    public async Task Invoke(HttpContext context){//Metodo asincrono que debe tener todo middleware.

        await next(context);// Pasamos el contexto de la consulta http ante todo.
        
		//A partir de aqui empieza la logica a la que va destinada el middleware.
        if(context.Request.Query.Any(prop => prop.Key == "time")){//Evaluamos si existe un queryParam con el nombre de llave "time"

            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());// Si existe el la url entorces acompañamos la respuesta con la hora actual.

        }

    }

}

  

public static class TimeMiddlewareExtension{ // Clase encargada de seleccionar el middleware que queremos utilizar.

    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder){// Mediante este metodo contruimos el llamado al middleware.

        return builder.UseMiddleware<TimeMiddleware>();//Retornamos la llamada al middleware.

    }

}
}