
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpMessageParser.Models;

namespace HttpMessageParser
{
   /// <summary>
   /// Implementación de IResponseWriter que serializa un HttpResponse a texto HTTP.
   /// </summary>
   public class HttpResponseWriter : IResponseWriter
   {
      public string WriteResponse(HttpResponse response)
      {
         // 1) Validaciones
         if (response is null)
            throw new ArgumentNullException(nameof(response));

         if (string.IsNullOrWhiteSpace(response.Protocol))
            throw new ArgumentException("Response.Protocol is required.");

         if (string.IsNullOrWhiteSpace(response.StatusText))
            throw new ArgumentException("Response.StatusText is required.");

         if (response.Headers is null)
            throw new ArgumentException("Response.Headers must not be null.");

         // 2) Línea de estado: "HTTP/x.y {StatusCode} {StatusText}"
         var sb = new StringBuilder();
         sb.Append($"{response.Protocol} {response.StatusCode} {response.StatusText}");

         // 3) Headers: cada uno en su propia línea, sin línea en blanco extra
         foreach (var kvp in response.Headers)
         {
            sb.Append($"\n{kvp.Key}: {kvp.Value}");
         }

         // 4) Body: si existe, una sola nueva línea antes del contenido
         if (response.Body is not null)
         {
            sb.Append($"\n{response.Body}");
         }

         return sb.ToString();
      }
   }
}