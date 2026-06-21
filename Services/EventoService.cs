using cloud_computing_trabalho_4.DTO;
using System.Text.Json;

namespace cloud_computing_trabalho_4.Services
{
    public class EventoService : IEventoService
    {
        private static readonly string DataPath = Path.Combine(
            AppContext.BaseDirectory, "Data", "eventos.json");

        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public List<EventoSeguranca> ObterEventos()
        {
            if (!File.Exists(DataPath))
                return [];

            var json = File.ReadAllText(DataPath);
            return JsonSerializer.Deserialize<List<EventoSeguranca>>(json, JsonOptions) ?? [];
        }
    }
}
