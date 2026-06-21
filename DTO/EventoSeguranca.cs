namespace cloud_computing_trabalho_4.DTO
{
    public record EventoSeguranca
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public required string Tipo { get; set; }
        public required string Severidade { get; set; }
        public required string Dispositivo { get; set; }
        public string? EnderecoIp { get; set; }
        public string? OrigemAtaque { get; set; }
        public string? UsuarioAfetado { get; set; }
        public required string Descricao { get; set; }
        public required string Status { get; set; }
    }
}
