using ClinicaOdonto.Aplicacao.Domain;
using ClinicaOdonto.Aplicacao.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicaOdonto.Aplicacao.Validação
{
    public static class ValidarConsulta
    {
        public static bool ValidarDataC(this string data)
        {
            if (!DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                InterfaceErro.DataFormato();
                return false;
            }

            if (!data.ValidarDataFutura())
            {
                InterfaceErro.AgendamentoFuturo();
                return false;
            }

            return true;
        }

        public static bool ValidarDataFutura(this string data)
        {
            DateTime dataDT = DateTime.Parse(data);
            DateTime hoje = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

            if (hoje > dataDT)
            {
                return false;
            }
            return true;
        }

        public static bool ValidarHora(this string hora, string data)
        {
            if (!DateTime.TryParseExact(hora, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                InterfaceErro.HoraFormato();
                return false;
            }

            string min = hora.Substring(3, 2);
            int intMin = int.Parse(min);

            if (intMin % 15 != 0)
            {
                InterfaceErro.Hora15();
                return false;
            }

            if (!hora.ValidarHoraFutura(data))
            {
                InterfaceErro.AgendamentoFuturo();
                return false;
            }

            return true;
        }

        public static bool ValidarHoraFutura(this string hora, string data)
        {
            int min = int.Parse(hora.Substring(3, 2));

            DateTime dataDT = DateTime.Parse(data);
            DateTime hoje = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

            if (hoje == dataDT)
            {
                int h = int.Parse(hora.Substring(0, 2));

                DateTime dataHora = new DateTime(dataDT.Year, dataDT.Month, dataDT.Day, h, min, 0);
                if (dataHora <= DateTime.Now)
                {
                    return false;
                }
            }
            return true;

        }

        public static bool ValidarHoraInicial(this string hora, string data)
        {
            if (!hora.ValidarHora(data))
            {
                return false;
            }

            string aux = hora.Remove(2, 1);
            int intHoraCompleta = int.Parse(aux);

            if (intHoraCompleta < 0900 || intHoraCompleta > 1845)
            {
                InterfaceErro.HoraDisponivel();
                return false;
            }

            return true;
        }

        public static bool ValidarHoraFinal(this string horaF, string horaI, string data)
        {
            if (!horaF.ValidarHora(data))
            {
                return false;
            }

            string auxF = horaF.Remove(2, 1);
            string auxI = horaI.Remove(2, 1);

            if (int.Parse(auxF) <= int.Parse(auxI))
            {
                InterfaceErro.HoraFinal();
                return false;
            }

            if (int.Parse(auxF) < 0945 || int.Parse(auxF) > 1900)
            {
                InterfaceErro.HoraDisponivel();
                return false;
            }

            return true;
        }

        public static bool ValidarSobreposicao(this Consulta c)
        {
            DateTime horaI = DateTime.Parse(c.HoraInicial);
            DateTime horaF = DateTime.Parse(c.HoraFinal);

            foreach (Consulta x in Agenda.Lista)
            {
                DateTime horaIX = DateTime.Parse(x.HoraInicial);
                DateTime horaFX = DateTime.Parse(x.HoraFinal);

                if (horaIX < horaF && horaFX > horaI)
                {
                    InterfaceErro.HoraSobreposta();
                    return false;
                }
            }
            return true;
        }

        public static bool ValidarPacienteExiste(this string cpf)
        {
            foreach (Paciente p in Cadastro.Lista)
            {
                if (p.Cpf == cpf)
                {
                    return true;
                }
            }
            InterfaceErro.PacienteNaoCadastrado();
            return false;
        }

        public static bool ValidarAgendamentoExiste(this string data, string hora)
        {
            foreach (Consulta c in Agenda.Lista)
            {
                if (c.Data == data && c.HoraInicial == hora)
                {
                    return true;
                }
            }
            InterfaceErro.AgendamentoInexistente();
            return false;
        }
    }
}
