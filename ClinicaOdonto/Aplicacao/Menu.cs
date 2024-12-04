using ClinicaOdonto.Aplicacao.Domain;
using ClinicaOdonto.Aplicacao.Interface;
using ClinicaOdonto.Aplicacao.Validação;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdonto.Aplicacao
{
    public class Menu
    {
        public static void MenuPrincipal()
        {
            InterfaceMenu.ExibirMenuPrincipal();

            int selectorMP = int.Parse(Console.ReadLine());
            switch (selectorMP)
            {
                case 1:
                    {
                        MenuCadastro();
                        break;
                    }
                case 2:
                    {
                        if (Cadastro.Lista.Count != 0)
                        {
                            MenuAgenda();
                        }
                        else
                        {
                            InterfaceMenu.NaoExibirMenuAgenda();
                            MenuPrincipal();
                        }
                        break;
                    }
                case 3:
                    {
                        return;
                    }
            }
        }

        public static void MenuCadastro()
        {
            InterfaceMenu.ExibirMenuCadastro();

            int selectorMC = int.Parse(Console.ReadLine());
            switch (selectorMC)
            {
                case 1:
                    {
                        Cadastro.CadastrarPaciente();
                        MenuCadastro();
                        break;
                    }

                case 2:
                    {
                        if (Cadastro.Lista.Count != 0)
                        {
                            Console.Write("CPF: ");
                            string cpf = Console.ReadLine();
                            if (cpf.ValidarPacienteExiste())
                            {
                                Cadastro.ExcluirPaciente(cpf);
                            }
                        }
                        else
                        {
                            InterfaceMenu.CadastroVazio();
                        }
                        MenuCadastro();
                        break;
                    }

                case 3:
                    {
                        Cadastro.ListarPacientesCPF();
                        MenuCadastro();
                        break;
                    }

                case 4:
                    {
                        Cadastro.ListarPacientesNome();
                        MenuCadastro();
                        break;
                    }

                case 5:
                    {
                        MenuPrincipal();
                        break;
                    }
            }
        }

        public static void MenuAgenda()
        {
            InterfaceMenu.ExibirMenuAgenda();
            int selectorMA = int.Parse(Console.ReadLine());
            switch (selectorMA)
            {
                case 1:
                    {
                        Agenda.AgendarConsulta();
                        MenuAgenda();
                        break;
                    }
                case 2:
                    {
                        int k = 0;
                        if (Agenda.Lista.Count != 0)
                        {
                            while (k == 0)
                            {
                                Console.Write("CPF: ");
                                string cpf = Console.ReadLine();
                                if (cpf.ValidarPacienteExiste())
                                {
                                    Console.Write("Data: ");
                                    string data = Console.ReadLine();
                                    Console.Write("Hora Inicial: ");
                                    string hora = Console.ReadLine();
                                    if (data.ValidarAgendamentoExiste(hora))
                                    {
                                        Agenda.CancelarAgendamento(cpf, data, hora);
                                        k = 1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            InterfaceMenu.AgendaVazia();
                        }

                        MenuAgenda();
                        break;
                    }
                case 3:
                    {
                        Agenda.ListarConsultas();
                        MenuAgenda();
                        break;
                    }
                case 4:
                    {
                        MenuPrincipal();
                        break;
                    }
            }
        }

    }
}
