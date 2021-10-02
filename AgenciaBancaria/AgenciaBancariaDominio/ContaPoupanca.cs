namespace AgenciaBancariaDominio
{
    public class ContaPoupanca : ContaBancaria
    {
        public ContaPoupanca(Cliente cliente): base(cliente)
        {
            PercentualRendimento = 0.003M;
        }

        public decimal PercentualRendimento { get; private set;}
    }
}