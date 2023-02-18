namespace ControleEstacionamento.Domain.Entidades
{
    public class VigenciaPreco
    {
        public int Id { get; set; }

        public DateTime InicioVigencia { get; set; }

        public DateTime FimVigencia { get; set; }

        public decimal ValorHora { get; set; }
    }
}
