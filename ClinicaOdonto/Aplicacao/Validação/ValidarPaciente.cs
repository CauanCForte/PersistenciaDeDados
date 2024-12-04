using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using ClinicaOdonto.Aplicacao.Interface;
using ClinicaOdonto.Aplicacao.Domain;

namespace ClinicaOdonto.Aplicacao.Validação
{
    public static class ValidarPaciente
    {
        public static bool ValidarCpf(this string cpf)
        {
            if (cpf.Length != 11)
            {
                InterfaceErro.CPFFormato();
                return false;
            }
            // Verifica se todos os dígitos são iguais
            if (new string(cpf[0], cpf.Length) == cpf)
            {
                InterfaceErro.CPFFormato();
                return false;
            }

            // Calcula o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += (cpf[i] - '0') * (10 - i);
            }

            int primeiroDigitoVerificador = soma % 11;
            if (primeiroDigitoVerificador < 2)
            {
                primeiroDigitoVerificador = 0;
            }
            else
            {
                primeiroDigitoVerificador = 11 - primeiroDigitoVerificador;
            }
            // Verifica o primeiro dígito
            if (cpf[9] - '0' != primeiroDigitoVerificador)
            {
                InterfaceErro.CPFFormato();
                return false;
            }
            // Calcula o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += (cpf[i] - '0') * (11 - i);
            }

            int segundoDigitoVerificador = soma % 11;
            if (segundoDigitoVerificador < 2)
            {
                segundoDigitoVerificador = 0;
            }
            else
            {
                segundoDigitoVerificador = 11 - segundoDigitoVerificador;
            }
            // Verifica o segundo dígito
            if (cpf[10] - '0' != segundoDigitoVerificador)
            {
                InterfaceErro.CPFFormato();
                return false;
            }
            // Verifica se o cpf já não existe no sistema

            return true;
        }

        public static bool ValidarNome(this string nome)
        {
            if (nome.Length < 5)
            {
                InterfaceErro.NomeFormato();
                return false;
            }
            return true;
        }

        public static bool ValidarDataP(this string data)
        {

            if (!DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                InterfaceErro.DataFormato();
                return false;
            }

            DateTime dataDT = DateTime.Parse(data);
            TimeSpan trezeAnos = TimeSpan.FromDays(13 * 365);

            if (DateTime.Now - dataDT < trezeAnos)
            {
                InterfaceErro.Idade();
                return false;
            }
            return true;
        }

        public static bool ValidarAgendamentoFuturo(this string cpf)
        {
            int i = Cadastro.Lista.FindIndex(p => p.Cpf == cpf);
            if (Cadastro.Lista[i].AgendamentoFuturo != null)
            {
                InterfaceErro.AgendamentoExcesso();
                return false;
            }

            return true;
        }

        public static void NaListaP(Paciente p)
        {
            if (Cadastro.Lista.Contains(p))
            {
                InterfaceErro.CPFRepetido();
                p.Cpf = Console.ReadLine();
            }
        }
    }
}
