namespace ControleEstacionamento.Domain.Entidades
{
    public class VigenciaPreco : EntidadeBase
    {
        public DateTime InicioVigencia { get; set; }

        public DateTime FimVigencia { get; set; }

        public decimal ValorHora { get; set; }
    }
}
