using System;
using System.Collections.Generic;
using System.Linq;

namespace TutorialExemplo.Models
{
    public class Funcionario
    {
        public Funcionario(int id, string primeiroNome, string ultimoNome, string cpf, DateTime dataAniversario, DateTime dataContratado, string email)
        {
            Id = id;
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            CPF = cpf;
            DataAniversario = dataAniversario;
            DataContratado = dataContratado;
            Email = email;
            Dependentes = new List<Dependente>();
        }

        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string CPF { get; set; }
        public DateTime DataAniversario { get; set; }
        public DateTime DataContratado { get; set; }
        public string Email { get; set; }
        public List<Dependente> Dependentes { get; set; }

        public Funcionario AtualizarFuncionario(Funcionario funcionario)
        {
            PrimeiroNome = funcionario.PrimeiroNome;
            UltimoNome = funcionario.UltimoNome;
            CPF = funcionario.CPF;
            DataAniversario = funcionario.DataAniversario;
            DataContratado = funcionario.DataContratado;
            Email = funcionario.Email;

            return this;
        }

        public Funcionario AtualizarDependente(Dependente dependente)
        {
            this.Dependentes.Single(x => x.Id == dependente.Id).AtualizarDependente(dependente);
            return this;
        }
    }
}
