using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ClinicaOdonto.Aplicacao.Domain;

namespace ClinicaOdonto.EF.DTO
{
    public class PacienteDTO
    {

        public string cpf { get; set; }
        public string nome { get; set; }
        public string dataNascimento { get; set; }
        public int idade { get; set; }
        public string agendamentoFuturoID { get; set; }

        public PacienteDTO(string cpf, string nome, string dataNascimento, int idade, string agendamentoFuturoID)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.dataNascimento = dataNascimento;
            this.idade = idade;
            this.agendamentoFuturoID = agendamentoFuturoID;
        }
    }
}
