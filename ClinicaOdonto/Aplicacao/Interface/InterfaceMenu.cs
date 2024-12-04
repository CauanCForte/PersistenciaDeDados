using ClinicaOdonto.Aplicacao.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdonto.Aplicacao.Interface
{
    public static class InterfaceMenu
    {
        public static void ExibirMenuPrincipal()
        {
            Console.WriteLine("Menu Principal");
            Console.WriteLine("1-Cadastro Paciente");
            Console.WriteLine("2-Agenda");
            Console.WriteLine("3-Fim\r\n");
        }

        public static void ExibirMenuCadastro()
        {
            Console.WriteLine("Menu do Cadastro de Pacientes");
            Console.WriteLine("1-Cadastrar novo paciente");
            Console.WriteLine("2-Excluir paciente");
            Console.WriteLine("3-Listar pacientes (ordenado por CPF)");
            Console.WriteLine("4-Listar pacientes (ordenado por nome)");
            Console.WriteLine("5-Voltar p/ menu principal\r\n");
        }

        public static void CadastroVazio()
        {
            Console.WriteLine("O Cadastro está vazio!\r\n");
        }

        public static void ExibirMenuAgenda()
        {
            Console.WriteLine("Agenda");
            Console.WriteLine("1-Agendar consulta");
            Console.WriteLine("2-Cancelar agendamento");
            Console.WriteLine("3-Listar agenda");
            Console.WriteLine("4-Voltar p/ menu principal\r\n");
        }

        public static void NaoExibirMenuAgenda()
        {
            Console.WriteLine("O Cadastro não possui pacientes, não é possível usar a Agenda!\r\n");
        }

        public static void AgendaVazia()
        {
            Console.WriteLine("A Agenda está vazia!\r\n");
        }

        public static void PacienteCadastrado()
        {
            Console.WriteLine("Paciente cadastrado com sucesso!\r\n");
        }

        public static void PacienteExcluido()
        {
            Console.WriteLine("Paciente excluído com sucesso!\r\n");
        }

        public static void TracejadoCadastro(string tracos)
        {
            Console.WriteLine("------------" + tracos + "-----------------");
        }

        public static void HeadCadastro(string tracos, string espacos)
        {
            TracejadoCadastro(tracos);
            Console.WriteLine("CPF         Nome" + espacos + " Dt. Nasc. Idade");
            TracejadoCadastro(tracos);
        }

        public static void LinhaCadastro(Paciente p, string espaco)
        {
            Console.WriteLine(p.Cpf + " " + p.Nome + espaco + p.DataNascimento + "   " + p.Idade);
        }

        public static void LinhaCadastroAgendamento(Paciente p)
        {
            Console.WriteLine("            Agendado para: " + p.AgendamentoFuturo.Data);
            Console.WriteLine("            " + p.AgendamentoFuturo.HoraInicial + " às " + p.AgendamentoFuturo.HoraFinal);
        }

        public static void AgendamentoRealizado()
        {
            Console.WriteLine("Agendamento realizado com sucesso!\r\n");
        }

        public static void AgendamentoCancelado()
        {
            Console.WriteLine("Agendamento cancelado com sucesso!\r\n");
        }

        public static void TracejadoAgenda(string traco)
        {
            Console.WriteLine("-----------------------------" + traco + "-----------");
        }

        public static void HeadAgenda(string traco, string espaco)
        {
            TracejadoAgenda(traco);
            Console.WriteLine("   Data    H.Ini H.Fim Tempo Nome" + espaco + " Dt.Nasc. ");
            TracejadoAgenda(traco);
        }

        public static void LinhaAgendaSemData(Consulta c, string espaco)
        {
            Console.WriteLine("          " + " " + c.HoraInicial + " " + c.HoraFinal + " " + c.Duracao + " "
                            + c.PacienteMarcado.Nome + espaco + c.PacienteMarcado.DataNascimento);
        }

        public static void LinhaAgendaComData(Consulta c, string espaco)
        {
            Console.WriteLine(c.Data + " " + c.HoraInicial + " " + c.HoraFinal + " " + c.Duracao + " "
                            + c.PacienteMarcado.Nome + espaco + c.PacienteMarcado.DataNascimento);
        }
    }
}
