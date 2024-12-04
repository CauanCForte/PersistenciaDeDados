using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdonto.Aplicacao.Interface
{
    public class InterfaceErro
    {
        public static void CPFFormato()
        {
            Console.WriteLine("Erro: O CPF deve estar de acordo com a validação oficial!\r\n");
            Console.Write("CPF: ");
        }

        public static void CPFRepetido()
        {
            Console.WriteLine("Erro: CPF já cadastrado!\r\n");
            Console.Write("CPF: ");
        }

        public static void NomeFormato()
        {
            Console.WriteLine("Erro: O Nome deve ter ao menos 5 caracteres!\r\n");
            Console.Write("Nome: ");
        }

        public static void Idade()
        {
            Console.WriteLine("Erro: O paciente deve ter pelo menos 13 anos!\r\n");
            Console.Write("Data: ");
        }

        public static void PacienteNaoCadastrado()
        {
            Console.WriteLine("Erro: Paciente não cadastrado!\r\n");
        }

        public static void DataFormato()
        {
            Console.WriteLine("Erro: A data deve ser inserida no formato DDMMAAAA!\r\n");
            Console.Write("Data: ");
        }

        public static void AgendamentoInexistente()
        {
            Console.WriteLine("Erro: Agendamento não encontrado!\r\n");
        }

        public static void AgendamentoFuturo()
        {
            Console.WriteLine("Erro: O agendamento não pode ser feito para um momento que já passou!\r\n");
            Console.Write("Data: ");
        }

        public static void AgendamentoExcesso()
        {
            Console.WriteLine("Erro: O paciente já tem uma consulta agendada!\r\n");
            Console.Write("CPF: ");
        }

        public static void HoraFormato()
        {
            Console.WriteLine("Erro: Hora inicial e final devem ser fornecidos no formato HHMM (padrão brasileiro)!\r\n");
            Console.Write("Hora: ");
        }

        public static void HoraDisponivel()
        {
            Console.WriteLine("Erro: Um agendamento deve ser feito no entre 08:00h e 19:00h!\r\n");
            Console.Write("Hora: ");
        }

        public static void Hora15()
        {
            Console.WriteLine("Erro: As consultas ocorrem em múltiplos de 15 minutos. Marque um horário com o final 00, 15, 30 ou 45!\r\n");
            Console.Write("Hora: ");
        }

        public static void HoraFinal()
        {
            Console.WriteLine("Erro: Hora final deve ser depois da inicial!\r\n");
            Console.Write("Hora Final: ");
        }

        public static void HoraSobreposta()
        {
            Console.WriteLine("Erro: Já existe uma consulta agendada nesse horário!\r\n");
            Console.Write("Hora: ");
        }

        public static void PacienteAgendado()
        {
            Console.WriteLine("Erro: Este paciente tem uma consulta agendada! Cancele o agendamento antes de excluir o paciente!\r\n");
            Console.Write("CPF: ");
        }

        public static void AgendamentoPassado()
        {
            Console.WriteLine("Erro: Não possível cancelar o agendamento de uma consulta que já aconteceu ou está acontecendo!\r\n");
            Console.Write("Hora: ");
        }

    }
}
