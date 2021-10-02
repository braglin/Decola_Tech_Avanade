namespace AgenciaBancariaDominio
{
    public class Endereco
    {
        public Endereco(string logradouro, string cep, string cidade, string estado)
        {
            Logradouro = logradouro.ValidacaoString();
            CEP = cep.ValidacaoString();
            Cidade = cidade.ValidacaoString();
            Estado = estado.ValidacaoString();
        }
        public string Logradouro { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
    }
}