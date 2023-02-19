namespace ControleEstacionamento.Domain.Entidades
{
    public class Carro : EntidadeBase
    {
        public Carro()
        {

        }

        public Carro(string placa)
        {
            Placa = placa;
        }

        public string Placa { get; set; }
    }
}
