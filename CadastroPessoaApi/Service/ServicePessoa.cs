using CadastroPessoaApi.Data;
using CadastroPessoaApi.ViewModel;

namespace CadastroPessoaApi.Service
{
    public class ServicePessoa
    {
        public IEnumerable<PessoaViewModel> GetAll()
        {
            var repository = new Repository();
            return repository.GetAll().ToList();
        }

        public PessoaViewModel GetById(int pessoaId)
        {
            var repository = new Repository();
            return repository.GetById(pessoaId);
        }

        public PessoaViewModel GetByPrimeiroNome(string primeiroNome)
        {
            var repository = new Repository();
            return repository.GetByPrimeiroNome(primeiroNome);
        }

        public void UpdateById(int pessoaId, string primeiroNome)
        {
            var repository = new Repository();
            repository.UpdateById(pessoaId, primeiroNome);
        }

        public dynamic Create(PessoaViewModel pessoa)
        {
            if (pessoa == null)
                return "Os dados são obrigatórios";
            if (string.IsNullOrEmpty(pessoa.nomeMeio))
                return "O campo NomeMeio é obrigatório";
            if (string.IsNullOrEmpty(pessoa.ultimoNome))
                return "O campo UltimoNome é obrigatório";
            if (string.IsNullOrEmpty(pessoa.CPF))
                return "O campo CPF é obrigatório";

            var repository = new Repository();
            return repository.Create(pessoa);
        }

        public bool DeleteById(int pessoaId)
        {
            var repository = new Repository();
            return repository.DeleteById(pessoaId);
        }
    }
}
