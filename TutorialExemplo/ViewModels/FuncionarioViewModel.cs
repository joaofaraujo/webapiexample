using System;
using TutorialExemplo.Models;

namespace TutorialExemplo.ViewModels
{
    public class FuncionarioViewModel
    {
        public FuncionarioViewModel()
        {
        }

        public FuncionarioViewModel(Funcionario funcionario)
        {
            Id = funcionario.Id;
            PrimeiroNome = funcionario.PrimeiroNome;
            UltimoNome = funcionario.UltimoNome;
            CPF = funcionario.CPF;
            DataAniversario = funcionario.DataAniversario;
            DataContratado = funcionario.DataContratado;
            Email = funcionario.Email;
        }

        public Funcionario SetFuncionario()
        {
            Funcionario funcionario = new Funcionario(this.Id, this.PrimeiroNome, this.UltimoNome, this.CPF, this.DataAniversario, this.DataContratado, this.Email);
            return funcionario;
        }

        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string CPF { get; set; }
        public DateTime DataAniversario { get; set; }
        public DateTime DataContratado { get; set; }
        public string Email { get; set; }
    }
}
