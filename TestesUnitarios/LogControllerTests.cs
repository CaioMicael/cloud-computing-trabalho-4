using cloud_computing_trabalho_4.Controllers;
using cloud_computing_trabalho_4.DTO;
using cloud_computing_trabalho_4.Services;
using Microsoft.AspNetCore.Mvc;

namespace TestesUnitarios
{
    [TestClass]
    public class LogControllerTests
    {
        private sealed class EventoServiceStub(List<EventoSeguranca> eventos) : IEventoService
        {
            public List<EventoSeguranca> ObterEventos() => eventos;
        }

        private static List<EventoSeguranca> EventosFixos() =>
        [
            new() { Id = 1, Timestamp = new DateTime(2026, 6, 21, 0, 3, 11, DateTimeKind.Utc),
                    Tipo = "Tentativa de Acesso Não Autorizado", Severidade = "Alta",
                    Dispositivo = "SRV-WEB-01", EnderecoIp = "192.168.1.10",
                    OrigemAtaque = "203.0.113.45", UsuarioAfetado = "admin",
                    Descricao = "Múltiplas tentativas de login com credenciais inválidas.",
                    Status = "Em Investigação" },
            new() { Id = 2, Timestamp = new DateTime(2026, 6, 21, 0, 17, 44, DateTimeKind.Utc),
                    Tipo = "Malware Detectado", Severidade = "Crítica",
                    Dispositivo = "WKS-FINANC-07", EnderecoIp = "192.168.2.37",
                    Descricao = "Ransomware identificado em estação de trabalho.",
                    Status = "Aberto" }
        ];

        [TestMethod]
        public void GetEventos_RetornaHttp200_QuandoExistemEventos()
        {
            var controller = new LogController(new EventoServiceStub(EventosFixos()));

            var resultado = controller.GetEventos();

            Assert.IsInstanceOfType<OkObjectResult>(resultado);
        }

        [TestMethod]
        public void GetEventos_RetornaEstruturaCorreta_ComCamposObrigatorios()
        {
            var controller = new LogController(new EventoServiceStub(EventosFixos()));

            var okResult = (OkObjectResult)controller.GetEventos();
            var eventos = (List<EventoSeguranca>)okResult.Value!;
            var evento = eventos.First();

            Assert.IsNotNull(evento.Tipo,       "Campo 'Tipo' ausente");
            Assert.IsNotNull(evento.Severidade,  "Campo 'Severidade' ausente");
            Assert.IsNotNull(evento.Dispositivo, "Campo 'Dispositivo' ausente");
            Assert.IsNotNull(evento.Descricao,   "Campo 'Descricao' ausente");
            Assert.IsNotNull(evento.Status,      "Campo 'Status' ausente");
            Assert.IsTrue(evento.Id > 0,         "Campo 'Id' deve ser positivo");
            Assert.AreNotEqual(default(DateTime), evento.Timestamp, "Campo 'Timestamp' ausente");
        }

        [TestMethod]
        public void GetEventoPorId_RetornaHttp404_QuandoIdNaoExiste()
        {
            var controller = new LogController(new EventoServiceStub(EventosFixos()));

            var resultado = controller.GetEventoPorId(999);

            Assert.IsInstanceOfType<NotFoundObjectResult>(resultado);
        }

        [TestMethod]
        public void GetEventos_RetornaHttp204_QuandoListaEstaVazia()
        {
            var controller = new LogController(new EventoServiceStub([]));

            var resultado = controller.GetEventos();

            Assert.IsInstanceOfType<NoContentResult>(resultado);
        }
    }
}
