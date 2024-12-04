using ClinicaOdonto.Aplicacao.Interface;
using ClinicaOdonto.Aplicacao.Validação;
using ClinicaOdonto.EF;
using ClinicaOdonto.EF.DTO;
using ClinicaOdonto.EF.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdonto.Aplicacao.Domain

{
    public class Agenda
    {
        private static List<Consulta> lista;
        private static bool ordenada;

        public Agenda()
        {
            RepositorioConsulta r = new(AppSession.Db);
            lista = new List<Consulta>();
            Lista.AddRange(r.BuscaTodos());
        }

        public static List<Consulta> Lista
        {
            get { return lista; }
        }

        public static bool Ordenada
        {
            get { return ordenada; }
            set { ordenada = value; }
        }

        public static void AgendarConsulta()
        {
            Consulta c = new Consulta();
            RepositorioConsulta r = new(AppSession.Db);
            Console.Write("CPF: ");
            c.CpfPaciente = Console.ReadLine();
            Console.Write("Data da consulta: ");
            c.Data = Console.ReadLine();
            Console.Write("Hora inicial: ");
            c.HoraInicial = Console.ReadLine();
            Console.Write("Hora final: ");
            c.HoraFinal = Console.ReadLine();
            InterfaceMenu.AgendamentoRealizado();
            Lista.Add(c);
            r.Adiciona(c);
            Ordenada = false;
        }

        public static void CancelarAgendamento(string cpf, string data, string horaI)
        {
            int i = Lista.FindIndex(c => c.Data == data && c.HoraInicial == horaI);

            if (data.ValidarDataFutura() && horaI.ValidarHoraFutura(data))
            {
                RepositorioConsulta r = new(AppSession.Db);
                Lista.Remove(Lista[i]);
                r.Remove(Lista[i]);
                int j = Cadastro.Lista.FindIndex(p => p.Cpf == cpf);
                Cadastro.Lista[j].AnularAgendamento();
                InterfaceMenu.AgendamentoCancelado();
            }
            else
            {
                InterfaceErro.AgendamentoPassado();
            }
        }

        public static void ListarConsultas()
        {
            if (Lista.Count == 0)
            {
                InterfaceMenu.AgendaVazia();
            }
            else
            {
                if (Ordenada == false)
                {
                    Lista.Sort();
                    Ordenada = true;
                }

                string maiorNome = Lista[0].PacienteMarcado.Nome;
                for (int i = 0; i < Lista.Count; i++)
                {
                    if (Lista[i].PacienteMarcado.Nome.Length > maiorNome.Length)
                    {
                        maiorNome = Lista[i].PacienteMarcado.Nome;
                    }
                }

                string espacoNome = new string(' ', maiorNome.Length - 4);
                string tracoNome = new string('-', maiorNome.Length);
                InterfaceMenu.HeadAgenda(tracoNome, espacoNome);
                string dataReferencia = "01/01/0001";
                foreach (Consulta c in Lista)
                {
                    string restoNome = new string(' ', maiorNome.Length - c.PacienteMarcado.Nome.Length + 1);

                    if (c.Data == dataReferencia)
                    {
                        InterfaceMenu.LinhaAgendaSemData(c, restoNome);
                    }
                    else
                    {
                        InterfaceMenu.LinhaAgendaComData(c, restoNome);
                        dataReferencia = c.Data;
                    }
                }
                InterfaceMenu.TracejadoAgenda(tracoNome);
            }
        }
    }
}

