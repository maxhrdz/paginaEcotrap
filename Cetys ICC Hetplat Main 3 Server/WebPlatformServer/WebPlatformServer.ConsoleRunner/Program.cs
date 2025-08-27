using WebPlatformServer;
using System.IO;

class Program
{
    static async Task Main(string[] args)
    {
        int port = 8080;

        // raiz static si no especifico
        var defaultRoot = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "WebPlatformServer", "static")
        );

        // rutas absolutas de el portfolio y el otro
        var portfolioRoot = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "WebPlatformServer", "miPortafolio")
        );

        var otroSitioRoot = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "WebPlatformServer", "otroSitio")
        );

        var server = new Server(port, defaultRoot);

        // es el extra donde se montan los prefijos
        server.Mount("/portafolio", portfolioRoot);
        server.Mount("/otro",      otroSitioRoot);

        Console.WriteLine($"Default root: {defaultRoot}");
        Console.WriteLine($"/portafolio -> {portfolioRoot}");
        Console.WriteLine($"/otro      -> {otroSitioRoot}");

        await server.Start();
    }
}