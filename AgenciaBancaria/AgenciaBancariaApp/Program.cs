using System;
using AgenciaBancariaDominio;

namespace AgenciaBancariaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Agencia Bancaria");

            try
            {
                Endereco endereco = new Endereco(
                    "Rua Nelson Pereira Bueno",  
                    "13184-000",
                    "Hortolândia", 
                    "São Paulo");
                Cliente cliente = new Cliente(
                    "Fabio", 
                    "12345678913", 
                    endereco);

                ContaCorrente conta = new ContaCorrente(cliente, 150);
                Console.WriteLine("Número da conta: " + conta.NumeroConta + "-" + conta.DigitoVerificador);
                
                string senha = "asdf1234";
                
                conta.Abrir(senha);
                Console.WriteLine("Situação da conta: " + conta.Situacao);

                conta.Sacar(10, senha);
                Console.WriteLine("Saldo: " + conta.Saldo);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
