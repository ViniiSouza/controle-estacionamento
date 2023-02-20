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

        public void CalcularValorTotal()
        {
            var diferenca = HorarioSaida - HorarioEntrada;
            if (Math.Round(diferenca.Value.TotalHours, MidpointRounding.ToZero) == 0 && Math.Round(diferenca.Value.TotalMinutes, MidpointRounding.ToZero) <= 30)
            {
                ValorTotal = ValorHora / 2;
            }
            else
            {
                if ((Convert.ToDecimal(diferenca.Value.TotalMinutes) - (Convert.ToDecimal(Math.Round(diferenca.Value.TotalHours, MidpointRounding.ToZero)) * 60)) <= 10)
                {
                    ValorTotal = ValorHora * Convert.ToDecimal(Math.Round(diferenca.Value.TotalHours, MidpointRounding.ToZero));
                }
                else
                {
                    ValorTotal = ValorHora * (Convert.ToDecimal(Math.Round(diferenca.Value.TotalHours, MidpointRounding.ToZero)) + 1);
                }
            }
        }
    }
}
