using cloud_computing_trabalho_4.Services;
using Microsoft.AspNetCore.Mvc;

namespace cloud_computing_trabalho_4.Controllers
{
    [ApiController]
    [Route("log")]
    public class LogController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public LogController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet("eventos")]
        public IActionResult GetEventos()
        {
            var eventos = _eventoService.ObterEventos();

            if (eventos.Count == 0)
                return NoContent();

            return Ok(eventos);
        }

        [HttpGet("eventos/{id:int}")]
        public IActionResult GetEventoPorId(int id)
        {
            var eventos = _eventoService.ObterEventos();
            var evento = eventos.FirstOrDefault(e => e.Id == id);

            if (evento is null)
                return NotFound(new { mensagem = $"Evento com id {id} não encontrado." });

            return Ok(evento);
        }
    }
}
