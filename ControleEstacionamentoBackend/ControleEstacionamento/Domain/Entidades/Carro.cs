using System.Text.RegularExpressions;

namespace ControleEstacionamento.Domain.Entidades
{
    public class Carro : EntidadeBase
    {
        public string Placa { get; set; }

        public Carro()
        {

        }

        public Carro(string placa)
        {
            if (!Regex.IsMatch(placa, "[a-zA-Z]{3}([-]?)[0-9]([a-zA-Z]|[0-9])[0-9]{2}"))
                throw new Exception("A placa informada está em formato inválido!");

            Placa = placa.Replace("-", "").ToUpper();
        }
    }
}
