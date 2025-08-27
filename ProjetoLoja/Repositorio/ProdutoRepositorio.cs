using Dapper;
using MySql.Data.MySqlClient;
using ProjetoLoja.Models;

namespace ProjetoLoja.Repositorio
{
    public class ProdutoRepositorio
    {
        //variavel de conexão
        private readonly string _connectionString;


        public ProdutoRepositorio(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<IEnumerable<Produto>> TodosProdutos()
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "SELECT Id, Nome, Descricao, Preco, ImageUrl, Estoque FROM Produtos";
            return await connection.QueryAsync<Produto>(sql);
        }
    }
}
