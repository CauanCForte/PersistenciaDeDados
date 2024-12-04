using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaOdonto.Aplicacao.Domain;
using ClinicaOdonto.EF.Repositorio;

namespace ClinicaOdonto.EF.DTO
{
    public class ConsultaDTO : Entity
    {
        public string data { get; set; }
        public string horaInicial { get; set; }
        public string horaFinal { get; set; }
        public string duracao { get; set; }
        public string cpfPaciente { get; set; }

        public ConsultaDTO(string data, string horaInicial, string horaFinal, string duracao, string cpfPaciente)
        {
            id = new Guid();
            this.data = data;
            this.horaInicial = horaInicial;
            this.horaFinal = horaFinal;
            this.duracao = duracao;
            this.cpfPaciente = cpfPaciente;
            int i = Cadastro.Lista.FindIndex(p => p.Cpf == cpfPaciente);
            Cadastro.Lista[i].AgendamentoFuturoId = id.ToString();
        }
    }
}
