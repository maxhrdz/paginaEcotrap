using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebPlatformServer
{
    public class Server
    {
        private readonly int _port;
        private readonly string _rootDir;
        private readonly Dictionary<string, string> _mounts; // prefix -> physical dir
        private TcpListener? _listener;
        private CancellationTokenSource? _cts;

        // content type mapa
        private static readonly Dictionary<string, string> _mime = new(StringComparer.OrdinalIgnoreCase)
        {
            [".html"] = "text/html",
            [".htm"]  = "text/html",
            [".css"]  = "text/css",
            [".js"]   = "application/javascript",
            [".png"]  = "image/png",
            [".jpg"]  = "image/jpeg",
            [".jpeg"] = "image/jpeg",
            [".gif"]  = "image/gif",
            [".svg"]  = "image/svg+xml",
            [".ico"]  = "image/x-icon",
            [".json"] = "application/json",
            [".txt"]  = "text/plain"
        };

        // crea el servidor 
        public Server(int port = 8080, string rootDir = "static")
        {
            _port = port;
            _rootDir = rootDir;
            _mounts = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        // monta el directorio con prefijo 
        public void Mount(string prefix, string directory)
        {
            if (string.IsNullOrWhiteSpace(prefix) || !prefix.StartsWith("/"))
                throw new ArgumentException("el prefijo debe iniciar con '/'.", nameof(prefix));

            _mounts[prefix.TrimEnd('/')] = directory; // normaliza
        }

        // inicia el servidor 
        public async Task Start()
        {
            _cts = new CancellationTokenSource();
            _listener = new TcpListener(IPAddress.Any, _port);
            _listener.Start();
            Console.WriteLine($"servidor escuchando en http://localhost:{_port}/");

            while (!_cts.IsCancellationRequested)
            {
                var client = await _listener.AcceptTcpClientAsync();
                _ = Task.Run(() => HandleClient(client));
            }
        }

        public void Stop()
        {
            _cts?.Cancel();
            _listener?.Stop();
        }

        private void HandleClient(TcpClient client)
        {
            using var stream = client.GetStream();

            
            var utf8NoBom = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
            using var reader = new StreamReader(stream, utf8NoBom, detectEncodingFromByteOrderMarks: false, bufferSize: 1024, leaveOpen: true);
            using var writer = new StreamWriter(stream, utf8NoBom, bufferSize: 1024, leaveOpen: true)
            {
                AutoFlush = true,
                NewLine = "\r\n" 
            };

            try
            {
                // request-line
                var requestLine = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(requestLine))
                {
                    SendError(writer, 400, "Bad Request");
                    return;
                }

                var parts = requestLine.Split(' ');
                if (parts.Length < 3)
                {
                    SendError(writer, 400, "Bad Request");
                    return;
                }

                var method = parts[0];
                var rawPath = parts[1];
                var http    = parts[2];

                if (!http.StartsWith("HTTP/"))
                {
                    SendError(writer, 400, "Bad Request");
                    return;
                }

                // solo get
                if (!method.Equals("GET", StringComparison.OrdinalIgnoreCase))
                {
                    SendError(writer, 405, "Method Not Allowed");
                    return;
                }

                // consumir headers hasta linea en blanco
                string? line;
                while (!string.IsNullOrEmpty(line = reader.ReadLine())) { /* no-op */ }

                // resolver a ruta fisica
                
                var path = Uri.UnescapeDataString(rawPath);
                string filePath = ResolvePath(path);
                Console.WriteLine($"map: '{path}' -> '{filePath}' exists={File.Exists(filePath)}");

                if (!File.Exists(filePath))
                {
                    SendError(writer, 404, "Not Found");
                    return;
                }

                // leer y responder
                var body = File.ReadAllBytes(filePath);
                var ext = Path.GetExtension(filePath);
                var contentType = _mime.TryGetValue(ext, out var ct) ? ct : "application/octet-stream";

                writer.WriteLine("HTTP/1.1 200 OK");
                writer.WriteLine($"Content-Type: {contentType}");
                writer.WriteLine($"Content-Length: {body.Length}");
                writer.WriteLine("Connection: close");
                writer.WriteLine();

                stream.Write(body, 0, body.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[error] {ex}");
                
                SendError(writer, 500, "Internal Server Error");
            }
        }

        // traduce la url 
        private string ResolvePath(string urlPath)
        {
            if (string.IsNullOrEmpty(urlPath)) urlPath = "/";

            // prefijos montados
            foreach (var mount in _mounts)
            {
                var pref = mount.Key;   // /portafoli
                var root = mount.Value; 

                if (urlPath.Equals(pref, StringComparison.OrdinalIgnoreCase))
                {
                    // "root/index.html"
                    return Path.Combine(root, "index.html");
                }

                if (urlPath.StartsWith(pref + "/", StringComparison.OrdinalIgnoreCase))
                {
                    
                    var relative = urlPath.Substring(pref.Length).TrimStart('/');
                    if (relative.Length == 0 || urlPath.EndsWith("/"))
                        relative = Path.Combine(relative, "index.html");
                    return Path.Combine(root, relative);
                }
            }

            // raiz por defecto
            if (urlPath == "/" || urlPath.EndsWith("/"))
                urlPath = urlPath.TrimEnd('/') + "/index.html";

            var clean = urlPath.TrimStart('/');
            return Path.Combine(_rootDir, clean);
        }

        private void SendError(StreamWriter writer, int code, string message)
        {
            string body = $"<html><body><h1>{code} {message}</h1></body></html>";
            writer.WriteLine($"HTTP/1.1 {code} {message}");
            writer.WriteLine("Content-Type: text/html");
            writer.WriteLine($"Content-Length: {Encoding.UTF8.GetByteCount(body)}");
            writer.WriteLine("Connection: close");
            writer.WriteLine();
            writer.Write(body);
        }
    }
}
