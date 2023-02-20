namespace ControleEstacionamento.Domain.Entidades
{
    public class Registro : EntidadeBase
    {
        public DateTime HorarioEntrada { get; set; }

        public DateTime? HorarioSaida { get; set; }

        public decimal ValorHora { get; set; }

        public decimal? ValorTotal { get; set; }

        public Carro Carro { get; set; }

        public int CarroId { get; set; }
    }
}
