using System;

namespace AgenciaBancariaDominio
{
    public class Cliente
    {

        public Cliente(string nome, string cpf, Endereco endereco)
        {
            Nome = nome.ValidacaoString();
            CPF = cpf.ValidacaoString();
            Endereco = endereco ?? throw new Exception();
        }

        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string RG { get; private set; }
        public Endereco Endereco { get; private set; }
    }
}
