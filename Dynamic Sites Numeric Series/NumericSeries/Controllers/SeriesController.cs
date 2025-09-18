using Microsoft.AspNetCore.Mvc;
using NumericSeries.Models;
using System.Numerics;

namespace NumericSeries.Controllers
{
    public class SeriesController : Controller
    {
        
        [HttpGet]
        public IActionResult Index(string? serie, int n)
        {
            if (n < 0) return BadRequest("El parámetro n no puede ser negativo."); // 400

            var s = SeriesRegistry.Get(serie);
            if (s is null) return NotFound($"La serie '{serie}' no está soportada."); // 404

            BigInteger value = s.ValueAt(n);

            var vm = new SeriesViewModel
            {
                SerieKey = s.Key,
                SerieName = s.DisplayName,
                N = n,
                Value = value,
                PrevUrl = n > 0 ? Url.RouteUrl("series", new { serie = s.Key, n = n - 1 }) : null,
                NextUrl = Url.RouteUrl("series", new { serie = s.Key, n = n + 1 })!,
                NavSeries = SeriesRegistry.All
            };

            return View("Index", vm); // una sola vista
        }
    }
}