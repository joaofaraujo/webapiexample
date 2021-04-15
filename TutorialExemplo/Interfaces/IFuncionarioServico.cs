using System;
using System.Collections.Generic;
using TutorialExemplo.Models;

namespace TutorialExemplo.Interfaces
{
    public interface IFuncionarioServico
    {
        void InserirFuncionario(Funcionario funcionario);
        void AtualizarFuncionario(int id, Funcionario funcionario);
        void AtualizarEmailFuncionario(int id, string email);
        void ExcluirFuncionario(int id);
        Funcionario ObterFuncionarioPorId(int id);
        IList<Funcionario> SelecionarFuncionariosPorDataContratacao(DateTime dataContratacao);
        IList<Funcionario> SelecionarFuncionariosPorNomes(string primeiroNome, string ultimoNome);
        IList<Funcionario> SelecionarTodos();
        void InserirDependente(int idFuncionario, Dependente dependente);
        void AtualizarDependente(int idFuncionario, int idDependente, Dependente dependente);
        IList<Dependente> SelecionarDependentesPorFuncionario(int idFuncionario);
        Dependente ObterDependentePorId(int idFuncionario, int idDependente);
    }
}
