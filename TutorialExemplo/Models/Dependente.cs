using System;

namespace TutorialExemplo.Models
{
    public class Dependente
    {
        public Dependente(int id, Funcionario funcionario, string nome, string cpf, DateTime dataAniversario)
        {
            Id = id;
            Funcionario = funcionario;
            Nome = nome;
            CPF = cpf;
            DataAniversario = dataAniversario;
        }

        public int Id { get; set; }
        public Funcionario Funcionario { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataAniversario { get; set; }

        public Dependente AtualizarDependente(Dependente dependente)
        {
            Funcionario = dependente.Funcionario;
            Nome = dependente.Nome;
            CPF = dependente.CPF;
            DataAniversario = dependente.DataAniversario;
            return this;
        }
    }
}
