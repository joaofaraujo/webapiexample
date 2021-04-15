using System;
using System.Collections.Generic;
using System.Linq;
using TutorialExemplo.Interfaces;
using TutorialExemplo.Models;

namespace TutorialExemplo.Services
{
    public class FuncionarioServico : IFuncionarioServico
    {
        public IList<Funcionario> Funcionarios { get; set; }

        public FuncionarioServico()
        {
            this.Funcionarios = new List<Funcionario>();
        }

        public void AtualizarEmailFuncionario(int id, string email)
        {
            this.Funcionarios.SingleOrDefault(x => x.Id == id).Email = email;
        }

        public void AtualizarFuncionario(int id, Funcionario funcionario)
        {
            this.Funcionarios.Single(x => x.Id == id).AtualizarFuncionario(funcionario);
        }

        public void ExcluirFuncionario(int id)
        {
            this.Funcionarios = this.Funcionarios.Where(x => x.Id != id).ToList();
        }

        public void InserirFuncionario(Funcionario funcionario)
        {
            this.Funcionarios.Add(funcionario);
        }

        public Funcionario ObterFuncionarioPorId(int id)
        {
            return this.Funcionarios.SingleOrDefault(x => x.Id == id);
        }

        public IList<Funcionario> SelecionarFuncionariosPorDataContratacao(DateTime dataContratacao)
        {
            return this.Funcionarios.Where(x => x.DataContratado.Date == dataContratacao.Date).ToList();
        }

        public IList<Funcionario> SelecionarFuncionariosPorNomes(string primeiroNome, string ultimoNome)
        {
            List<Funcionario> funcionarios = this.Funcionarios?.ToList();
            if(!string.IsNullOrEmpty(primeiroNome))
                funcionarios = this.Funcionarios.Where(x => x.PrimeiroNome.ToUpper().Contains(primeiroNome.ToUpper())).ToList();
            if (!string.IsNullOrEmpty(ultimoNome))
                funcionarios = funcionarios.Where(x => x.UltimoNome.ToUpper().Contains(ultimoNome.ToUpper())).ToList();
            return funcionarios;
        }

        public IList<Funcionario> SelecionarTodos()
        {
            return this.Funcionarios;
        }

        public void InserirDependente(int idFuncionario, Dependente dependente)
        {
            this.Funcionarios.Single(x => x.Id == idFuncionario).Dependentes.Add(dependente);
        }

        public void AtualizarDependente(int idFuncionario, int idDependente, Dependente dependente)
        {
            this.Funcionarios.Single(x => x.Id == idFuncionario).AtualizarDependente(dependente);
        }

        public IList<Dependente> SelecionarDependentesPorFuncionario(int idFuncionario)
        {
            return this.Funcionarios.SingleOrDefault(x => x.Id == idFuncionario)?.Dependentes;
        }

        public Dependente ObterDependentePorId(int idFuncionario, int idDependente)
        {
            return this.Funcionarios.SingleOrDefault(x => x.Id == idFuncionario)?.Dependentes?.SingleOrDefault(x => x.Id == idDependente);
        }
    }
}
