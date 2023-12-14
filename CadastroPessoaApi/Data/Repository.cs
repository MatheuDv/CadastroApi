using CadastroPessoaApi.ViewModel;
using Dapper;
using System.Data.SqlClient;
using System.Linq.Expressions;
namespace CadastroPessoaApi.Data
{
    public class Repository
    {
        string conexao = @"Server=(localdb)\mssqllocaldb;Database=CADASTROPESSOAS;Trusted_Connection=True;MultipleActiveResultSets=True";
        public IEnumerable<PessoaViewModel> GetAll()
        {
            string query = "SELECT TOP 1000 * FROM PESSOAS";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.Query<PessoaViewModel>(query);
            }

        }
        public PessoaViewModel GetById(int pessoaId)
        {
            string query = "SELECT * FROM PESSOAS WHERE pessoaId = @pessoaId";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.QueryFirstOrDefault<PessoaViewModel>(query, new { pessoaId = pessoaId });
            }
        }
        public PessoaViewModel GetByPrimeiroNome(string primeiroNome)
        {
            string query = "SELECT * FROM PESSOAS WHERE primeiroNome = @primeiroNome";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                return con.QueryFirstOrDefault<PessoaViewModel>(query, new { primeiroNome = primeiroNome });
            }
        }
        public void UpdateById(int pessoaId, string primeiroNome)
        {
            string query = "UPDATE PESSOAS SET primeiroNome = @primeiroNome WHERE pessoaId = @pessoaId";
            using (SqlConnection con = new SqlConnection(conexao))
            {
                con.QueryFirstOrDefault<PessoaViewModel>(query, new { primeiroNome = primeiroNome, pessoaId = pessoaId });
            }
        }
        public string Create(PessoaViewModel pessoa)
        {
            try
            {
                string query = @"INSERT INTO PESSOAS(PrimeiroNome, NomeMeio, UltimoNome, CPF)Values(@primeiroNome, @nomeMeio, @ultimoNome, @CPF)";
                using (SqlConnection con = new SqlConnection(conexao))
                {
                    con.Execute(query, new
                    {
                        primeiroNome = pessoa.primeiroNome,
                        nomeMeio = pessoa.nomeMeio,
                        CPF = pessoa.CPF,
                        ultimoNome = pessoa.ultimoNome,
                    });
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }


        }

        internal bool DeleteById(int pessoaId)
        {
            throw new NotImplementedException();
        }
    }
}
