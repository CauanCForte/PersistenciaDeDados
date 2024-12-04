using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using ClinicaOdonto.Aplicacao.Interface;
using ClinicaOdonto.EF;
using ClinicaOdonto.EF.DTO;
using ClinicaOdonto.EF.Repositorio;

namespace ClinicaOdonto.Aplicacao.Domain
{
    public class Cadastro
    {
        private static List<Paciente> lista;
        private static bool ordenadoCPF;
        private static bool ordenadoNome;

        public Cadastro()
        {
            RepositorioPaciente r = new(AppSession.Db);
            lista = new List<Paciente>();
            Lista.AddRange(r.BuscaTodos());
        }

        public static List<Paciente> Lista
        {
            get { return lista; }
        }

        public static bool OrdenadoCPF
        {
            get { return ordenadoCPF; }
            set { ordenadoCPF = value; }
        }

        public static bool OrdenadoNome
        {
            get { return ordenadoNome; }
            set { ordenadoNome = value; }
        }

        public static void CadastrarPaciente()
        {
            Paciente p = new Paciente();
            RepositorioPaciente r = new(AppSession.Db);
            Console.Write("CPF: ");
            p.Cpf = Console.ReadLine();
            Console.Write("Nome: ");
            p.Nome = Console.ReadLine();
            Console.Write("Data de Nascimento: ");
            p.DataNascimento = Console.ReadLine();
            InterfaceMenu.PacienteCadastrado();
            Lista.Add(p);
            r.Adiciona(p);
            OrdenadoCPF = false;
            OrdenadoNome = false;
        }

        public static void ExcluirPaciente(string cpf)
        {
            RepositorioPaciente rPaci = new(AppSession.Db);
            RepositorioConsulta rCons = new(AppSession.Db);
            int i = Lista.FindIndex(p => p.Cpf == cpf);
            Paciente p = Lista[i];
            if (p.AgendamentoFuturo == null)
            {
                Lista.Remove(p);
                rPaci.Remove(p);
                foreach (Consulta c in Agenda.Lista)
                {
                    if (c.CpfPaciente == cpf)
                    {
                        Agenda.Lista.Remove(c);
                        rCons.Remove(c);
                        InterfaceMenu.PacienteExcluido();
                    }
                }
            }
            else
            {
                InterfaceErro.PacienteAgendado();
            }
        }

        public static void ListarPacientesCPF()
        {
            if (Lista.Count == 0)
            {
                InterfaceMenu.CadastroVazio();
            }
            else
            {
                if (OrdenadoCPF == false)
                {
                    Lista.Sort((p1, p2) => p1.Cpf.CompareTo(p2.Cpf));
                    OrdenadoCPF = true;
                }

                ListarPacienteAux();
            }
        }

        public static void ListarPacientesNome()
        {
            if (Lista.Count == 0)
            {
                InterfaceMenu.CadastroVazio();
            }
            else
            {
                if (OrdenadoNome == false)
                {
                    Lista.Sort();
                    OrdenadoNome = true;
                }

                ListarPacienteAux();
            }
        }

        public static void ListarPacienteAux()
        {
            string maiorNome = Lista[0].Nome;
            for (int i = 0; i < Lista.Count; i++)
            {
                if (Lista[i].Nome.Length > maiorNome.Length)
                {
                    maiorNome = Lista[i].Nome;
                }
            }

            string espacoNome = new string(' ', maiorNome.Length - 4);
            string tracoNome = new string('-', maiorNome.Length);
            InterfaceMenu.HeadCadastro(tracoNome, espacoNome);
            foreach (Paciente p in Lista)
            {
                string restoNome = new string(' ', maiorNome.Length - p.Nome.Length + 1);
                InterfaceMenu.LinhaCadastro(p, restoNome);
                if (p.AgendamentoFuturo != null)
                {
                    DateTime dataDT = DateTime.Parse(p.AgendamentoFuturo.Data);
                    DateTime hoje = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                    int h = int.Parse(p.AgendamentoFuturo.HoraInicial.Substring(0, 2));
                    int min = int.Parse(p.AgendamentoFuturo.HoraInicial.Substring(3, 2));
                    DateTime dataHora = new DateTime(dataDT.Year, dataDT.Month, dataDT.Day, h, min, 0);

                    if (dataDT > hoje || dataDT == hoje && dataHora > DateTime.Now)
                    {
                        InterfaceMenu.LinhaCadastroAgendamento(p);
                    }
                }
            }
            InterfaceMenu.TracejadoCadastro(tracoNome);
        }
    }
}
