using ClinicaOdonto.Aplicacao.Validação;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdonto.Aplicacao.Domain
{
    public class Consulta : IComparable<Consulta>
    {
        private DateTime data;
        private DateTime horaInicial;
        private DateTime horaFinal;
        private string duracao;
        private string cpfPaciente;
        private Paciente pacienteMarcado;

        public string Data
        {
            get { return data.ToString("d"); }
            set
            {
                if (value.ValidarDataC())
                {
                    DateTime dataDT = DateTime.Parse(value);
                    data = dataDT;
                }
                else
                {
                    Data = Console.ReadLine();
                }
            }
        }

        public string HoraInicial
        {
            get { return horaInicial.ToString("HH:mm"); }
            set
            {
                if (value.ValidarHoraInicial(Data))
                {
                    DateTime horaDT = DateTime.ParseExact(value, "HH:mm", null);
                    horaInicial = horaDT;
                }
                else
                {
                    HoraInicial = Console.ReadLine();
                }
            }
        }

        public string HoraFinal
        {
            get { return horaFinal.ToString("HH:mm"); }
            set
            {
                if (value.ValidarHoraFinal(HoraInicial, Data))
                {
                    DateTime horaDT = DateTime.ParseExact(value, "HH:mm", null);
                    horaFinal = horaDT;
                    TimeSpan t = horaFinal - horaInicial;
                    int min = (int)t.TotalMinutes;
                    int h = (int)t.TotalHours;
                    if (min >= 60)
                    {
                        min = min - h * 60;
                    }
                    if (min == 0)
                    {
                        duracao = h + ":00";
                    }
                    else
                    {
                        duracao = h + ":" + min;
                    }
                }
                else
                {
                    HoraFinal = Console.ReadLine();
                }
            }
        }

        public string Duracao
        {
            get { return duracao; }
        }

        public string CpfPaciente
        {
            get { return cpfPaciente; }
            set
            {
                if (value.ValidarCpf() && value.ValidarPacienteExiste() && value.ValidarAgendamentoFuturo())
                {
                    cpfPaciente = value;
                    int i = Cadastro.Lista.FindIndex(p => p.Cpf == value);
                    Cadastro.Lista[i].AgendamentoFuturo = this;
                    pacienteMarcado = Cadastro.Lista[i];
                }
                else
                {
                    CpfPaciente = Console.ReadLine();
                }
            }
        }

        public Paciente PacienteMarcado
        {
            get { return pacienteMarcado; }
        }

        public override bool Equals(object obj)
        {
            if (obj is Consulta c)
            {
                return c.Data == Data && c.HoraInicial == HoraInicial;
            }
            return false;
        }

        public int CompareTo(Consulta c)
        {
            if (c == null)
            {
                return 1;
            }

            int dataComparacao = Data.CompareTo(c.Data);

            if (dataComparacao == 0)
            {
                return HoraInicial.CompareTo(c.HoraInicial);
            }

            return dataComparacao;
        }
    }
}
