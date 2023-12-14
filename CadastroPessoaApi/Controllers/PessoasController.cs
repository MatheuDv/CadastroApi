using CadastroPessoaApi.Service;
using CadastroPessoaApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IEnumerable<PessoaViewModel> GetAll()
        {
            var service = new ServicePessoa();
            return service.GetAll();
        }
        [HttpGet("GetById/{pessoaId}")]
        public PessoaViewModel GetById(int pessoaId)
        {
            var service = new ServicePessoa();
            return service.GetById(pessoaId);
        }
        [HttpGet("GetByPrimeiroNome/{primeiroNome}")]
        public PessoaViewModel GetByPrimeiroNome(string primeiroNome)
        {
            var service = new ServicePessoa();
            return service.GetByPrimeiroNome(primeiroNome);
        }
        [HttpPut("UpdateById/{pessoaId}")]
        public void UpdateById(int pessoaId,string nomeNovo)
        {
            var service = new ServicePessoa();
             service.UpdateById(pessoaId, nomeNovo);
        }
        [HttpPost("Create")]
        public IActionResult Create(PessoaViewModel pessoa)
        {
            var service = new ServicePessoa();
            var resultado = service.Create(pessoa);

            var result = new
            {
                Sucess = true,
                Data = resultado,
            };
            return Ok(result);
        }
 [HttpDelete("DeleteById/{pessoaId}")]
public IActionResult DeleteById(int pessoaId)
{
    var service = new ServicePessoa();
            var resultado = service.DeleteById(pessoaId);

    if (resultado)
    {
        return Ok(new { Success = true, Message = "Pessoa excluída com sucesso." });
    }
    else
    {
        return BadRequest(new { Success = false, Message = "Não foi possível excluir a pessoa. Verifique o ID fornecido." });
    }
}
    }

}
