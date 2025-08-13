
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpMessageParser.Models;

namespace HttpMessageParser
{
    /// <summary>
    /// Implementación de IRequestParser que convierte texto HTTP en HttpRequest.
    /// </summary>
    public class HttpRequestParser : IRequestParser
    {
        public HttpRequest ParseRequest(string requestText)
        {
            // 1) Validaciones iniciales
            if (requestText is null)
                throw new ArgumentNullException(nameof(requestText));

            if (string.IsNullOrWhiteSpace(requestText))
                throw new ArgumentException("Request text is empty.", nameof(requestText));

            // Normalizamos saltos de línea a '\n' (para soportar CRLF y LF)
            string normalized = requestText.Replace("\r\n", "\n");

            // 2) Separamos por líneas
            string[] lines = normalized.Split('\n');

            // Primera línea obligatoria: Method SP RequestTarget SP Protocol
            string requestLine = lines[0].Trim();
            var parts = requestLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 3)
                throw new ArgumentException("Invalid request line format.");

            string method = parts[0];
            string requestTarget = parts[1];
            string protocol = parts[2];

            // 3) Reglas de validación solicitadas
            // - Método presente (ya garantizado por parts.Length==3)
            if (string.IsNullOrWhiteSpace(method))
                throw new ArgumentException("HTTP method missing.");

            // - La ruta incluye al menos el carácter "/"
            if (string.IsNullOrWhiteSpace(requestTarget) || !requestTarget.Contains('/'))
                throw new ArgumentException("Request target must include '/'.");

            // - Protocolo presente e inicia con "HTTP"
            if (string.IsNullOrWhiteSpace(protocol) || !protocol.StartsWith("HTTP", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Protocol must start with 'HTTP'.");

            // 4) Parseo de headers (hasta una línea en blanco)
            var headers = new Dictionary<string, string>();
            int i = 1; // índice de línea actual (después de la request line)

            for (; i < lines.Length; i++)
            {
                var line = lines[i];

                // Línea en blanco: marca el fin de los headers
                if (line.Length == 0)
                {
                    i++; // avanzamos para que 'i' apunte al inicio del body (si lo hay)
                    break;
                }

                // Cada header debe tener exactamente un ":" y texto antes/después
                int firstColon = line.IndexOf(':');
                if (firstColon <= 0) // <=0 implica que no hay ":" o está en la posición 0 (sin nombre)
                    throw new ArgumentException($"Invalid header line: '{line}'");

                // Debe haber exactamente un ':'
                if (line.IndexOf(':', firstColon + 1) != -1)
                    throw new ArgumentException($"Header must contain exactly one ':': '{line}'");

                string name = line.Substring(0, firstColon).Trim();
                string value = line.Substring(firstColon + 1).Trim();

                if (name.Length == 0 || value.Length == 0)
                    throw new ArgumentException($"Header name and value must be non-empty: '{line}'");

                headers[name] = value;
            }

            // 5) Body (si hay líneas después del separador en blanco)
            string? body = null;
            if (i < lines.Length)
            {
                body = string.Join("\n", lines.Skip(i));
                if (string.IsNullOrEmpty(body))
                    body = null;
            }

            // 6) Construir el HttpRequest
            return new HttpRequest
            {
                Method = method,
                RequestTarget = requestTarget,
                Protocol = protocol,
                Headers = headers,
                Body = body
            };
        }
    }
}