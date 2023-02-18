namespace ControleEstacionamento.Domain.Entidades
{
    public class Registro
    {
        public int Id { get; set; }

        public DateTime HorarioEntrada { get; set; }

        public DateTime? HorarioSaida { get; set; }

        public decimal ValorHora { get; set; }

        public Carro Carro { get; set; }

        public int CarroId { get; set; }
    }
}
