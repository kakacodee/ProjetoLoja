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
    }
}
