using System;
using TutorialExemplo.Models;

namespace TutorialExemplo.ViewModels
{
    public class DependenteViewModel
    {
        public DependenteViewModel()
        {

        }

        public DependenteViewModel(Dependente dependente)
        {
            Id = dependente.Id;
            Funcionario = new FuncionarioViewModel(dependente.Funcionario);
            Nome = dependente.Nome;
            CPF = dependente.CPF;
            DataAniversario = dependente.DataAniversario;
        }

        public Dependente SetDependente()
        {
            Dependente dependente = new Dependente(this.Id, this.Funcionario.SetFuncionario(), this.Nome, this.CPF, this.DataAniversario);
            return dependente;
        }

        public int Id { get; set; }
        public FuncionarioViewModel Funcionario { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataAniversario { get; set; }
    }
}
