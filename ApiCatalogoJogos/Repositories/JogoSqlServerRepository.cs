using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ApiCatalogoJogos.Entities;
using Microsoft.Extensions.Configuration;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoSqlServerRepository : IJogoRepository
    {
        private readonly SqlConnection sqlConnection;

        public JogoSqlServerRepository(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        public Task Atualizar(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            sqlConnection?.Close();
            sqlConnection?.Dispose();
        }

        public Task Inserir(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            throw new NotImplementedException();
        }

        public Task<Jogo> Obter(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}