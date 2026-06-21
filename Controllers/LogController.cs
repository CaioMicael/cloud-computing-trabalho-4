using cloud_computing_trabalho_4.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace cloud_computing_trabalho_4.Controllers
{
    [ApiController]
    [Route("log")]
    public class LogController : ControllerBase
    {
        private static readonly string DataPath = Path.Combine(
            AppContext.BaseDirectory, "Data", "eventos.json");

        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private List<EventoSeguranca> CarregarEventos()
        {
            if (!System.IO.File.Exists(DataPath))
                return [];

            var json = System.IO.File.ReadAllText(DataPath);
            return JsonSerializer.Deserialize<List<EventoSeguranca>>(json, JsonOptions) ?? [];
        }

        [HttpGet("eventos")]
        public IActionResult GetEventos()
        {
            var eventos = CarregarEventos();
            return Ok(eventos);
        }

        [HttpGet("eventos/{id:int}")]
        public IActionResult GetEventoPorId(int id)
        {
            var eventos = CarregarEventos();
            var evento = eventos.FirstOrDefault(e => e.Id == id);

            if (evento is null)
                return NotFound(new { mensagem = $"Evento com id {id} não encontrado." });

            return Ok(evento);
        }
    }
}
