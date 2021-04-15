using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TutorialExemplo.Interfaces;
using TutorialExemplo.ViewModels;

namespace TutorialExemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioServico _funcionarioServico;

        public FuncionarioController(IFuncionarioServico funcionarioServico)
        {
            this._funcionarioServico = funcionarioServico;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FuncionarioViewModel>> Get()
        {
            var funcionarios = _funcionarioServico.SelecionarTodos();
            if (funcionarios == null || !funcionarios.Any())
                return NoContent();

            return Ok(funcionarios.Select(x => new FuncionarioViewModel(x)).ToList());
        }

        [HttpGet("nomes")]
        public ActionResult<IEnumerable<FuncionarioViewModel>> Get(string primeiroNome = "", string ultimoNome = "")
        {
            var funcionarios = _funcionarioServico.SelecionarFuncionariosPorNomes(primeiroNome, ultimoNome);
            if (funcionarios == null || !funcionarios.Any())
                return NoContent();

            return Ok(funcionarios.Select(x => new FuncionarioViewModel(x)).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<FuncionarioViewModel> Get(int id)
        {
            var funcionario = _funcionarioServico.ObterFuncionarioPorId(id);
            if (funcionario == null)
                return NotFound();

            return Ok(new FuncionarioViewModel(funcionario));
        }

        [HttpPost]
        public ActionResult<FuncionarioViewModel> Post([FromBody] FuncionarioViewModel funcionarioViewModel)
        {
            if (funcionarioViewModel == null)
                return BadRequest(new { mensagem = "Informações inválidas." });
            if (funcionarioViewModel.CPF.Length != 11)
                return BadRequest(new { mensagem = "CPF inválido." });
            if (!funcionarioViewModel.Email.Contains("@") && !funcionarioViewModel.Email.Contains("."))
                return BadRequest(new { mensagem = "e-mail inválido." });

            var funcionario = funcionarioViewModel.SetFuncionario();
            _funcionarioServico.InserirFuncionario(funcionario);

            return CreatedAtAction(nameof(Get), funcionarioViewModel);
        }

        [HttpPut("{id}")]
        public ActionResult<FuncionarioViewModel> Put(int id, [FromBody] FuncionarioViewModel funcionarioViewModel)
        {
            if (funcionarioViewModel == null)
                return BadRequest(new { mensagem = "Informações inválidas." });
            if (funcionarioViewModel.CPF.Length != 11)
                return BadRequest(new { mensagem = "CPF inválido." });
            if (!funcionarioViewModel.Email.Contains("@") && !funcionarioViewModel.Email.Contains("."))
                return BadRequest(new { mensagem = "e-mail inválido." });

            var funcionarioExiste = _funcionarioServico.ObterFuncionarioPorId(id);
            if (funcionarioExiste == null)
                return Post(funcionarioViewModel);

            var funcionario = funcionarioViewModel.SetFuncionario();
            _funcionarioServico.AtualizarFuncionario(id, funcionario);
            return Ok(funcionarioViewModel);
        }

        [HttpPatch("{id}/email")]
        public ActionResult Patch(int id, [FromBody] FuncionarioViewModel funcionarioViewModel)
        {
            if (!funcionarioViewModel.Email.Contains("@") && !funcionarioViewModel.Email.Contains("."))
                return BadRequest(new { mensagem = "e-mail inválido." });

            _funcionarioServico.AtualizarEmailFuncionario(id, funcionarioViewModel.Email);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _funcionarioServico.ExcluirFuncionario(id);
            return Ok();
        }

        [HttpGet("{id}/dependente")]
        public ActionResult<IEnumerable<FuncionarioViewModel>> GetDependentes(int id)
        {
            var dependentes = _funcionarioServico.SelecionarDependentesPorFuncionario(id);
            if (dependentes == null || !dependentes.Any())
                return NoContent();

            return Ok(dependentes.Select(x => new DependenteViewModel(x)).ToList());
        }

        [HttpPost("{id}/dependente")]
        public ActionResult<FuncionarioViewModel> Post(int id, [FromBody] DependenteViewModel dependenteViewModel)
        {
            if (dependenteViewModel == null)
                return BadRequest(new { mensagem = "Informações inválidas." });
            if (dependenteViewModel.CPF.Length != 11)
                return BadRequest(new { mensagem = "CPF inválido." });

            var dependente = dependenteViewModel.SetDependente();
            _funcionarioServico.InserirDependente(id, dependente);

            return CreatedAtAction(nameof(GetDependentes), new { id }, dependenteViewModel);
        }
    }
}
