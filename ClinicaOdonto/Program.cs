using ClinicaOdonto.Aplicacao.Domain;
using ClinicaOdonto.Aplicacao;
using System;

using System.Globalization;

namespace ConsultorioOdontologico
{
    public class Program 
    {
        static void Main(string[] args) 
        {
            Cadastro Cadastro = new Cadastro();
            Agenda Agenda = new Agenda();
            Menu.MenuPrincipal();
        }
    }
}