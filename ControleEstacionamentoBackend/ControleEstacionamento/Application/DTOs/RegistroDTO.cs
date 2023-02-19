namespace ControleEstacionamento.Application.DTOs
{
    public class RegistroDTO
    {
        public int? Id { get; set; }

        public string? PlacaCarro { get; set; }

        public string? HorarioEntrada { get; set; }

        public string? HorarioSaida { get; set; }

        public decimal ValorHora { get; set; }

        public int? CarroId { get; set; }
    }
}
