using cloud_computing_trabalho_4.DTO;
using Microsoft.AspNetCore.Mvc;

namespace cloud_computing_trabalho_4.Controllers
{
    [ApiController]
    [Route("status")]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var result = new StatusResult
            {
                Nome = "API monitoramento e segurança",
                Versao = "1.0.0",
                Status = "OK"
            };

            return Ok(result);
        }
    }
}
