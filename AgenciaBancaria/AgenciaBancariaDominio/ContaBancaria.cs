using System;
using System.Text.RegularExpressions;

namespace AgenciaBancariaDominio
{
    public abstract class ContaBancaria
    {
        public ContaBancaria(Cliente cliente)
        {
            Random random = new Random();
            NumeroConta = random.Next(10000, 99999);
            DigitoVerificador = random.Next(0,9);

            Situacao = SituacaoConta.Criada;
            Cliente = cliente ?? throw new Exception("Cliente deve ser informado!");
        }
        public void Abrir(string senha)
        {
            SetarSenha(senha);
            Situacao = SituacaoConta.Aberta;
            DataAbertura = DateTime.Now;
        }

        private void SetarSenha(string senha)
        {
            Senha = senha.ValidacaoString();
            if (!Regex.IsMatch(senha, @"^(?=.*?[a-z])(?=.*?[0-9]).{8,}$"))
            {
                throw new Exception("Senha inválida!");
            }
        }

        public virtual void Sacar(decimal valor, string senha)
        {
            if (Senha != senha)
            {
                throw new Exception("Senha Inválida!");
            }

            if (Saldo <valor)
            {
                throw new Exception("Saldo Insuficiente!");
            }

            Saldo -= valor;
        }
        public int NumeroConta { get; init; }
        public int DigitoVerificador { get; init; }
        public decimal Saldo { get; protected set; }

        public DateTime? DataAbertura { get; private set; }
        public DateTime? DataEncerramento { get; private set; }
        public SituacaoConta Situacao { get; private set; }
        public string Senha { get; private set; }
        public Cliente Cliente { get; init; }

    }
}