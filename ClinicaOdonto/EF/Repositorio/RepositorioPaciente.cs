using ClinicaOdonto.Aplicacao.Domain;
using ClinicaOdonto.EF.DTO;
using Microsoft.EntityFrameworkCore;

namespace ClinicaOdonto.EF.Repositorio;

public class RepositorioPaciente
{
    private readonly AppDbContext db;

    public RepositorioPaciente(AppDbContext db) => this.db = db;

    public void Adiciona(Paciente p)
    {
        PacienteDTO dto = new(p.Cpf, p.Nome, p.DataNascimento, p.Idade, p.AgendamentoFuturoId);
        db.Pacientes.Add(dto);
        db.SaveChanges();
    }

    public void Atualiza(Paciente p)
    {
        PacienteDTO dto = new(p.Cpf, p.Nome, p.DataNascimento, p.Idade, p.AgendamentoFuturoId);
        db.Pacientes.Update(dto);
        db.SaveChanges();
    }

    public void Remove(Paciente p)
    {
        PacienteDTO dto = new(p.Cpf, p.Nome, p.DataNascimento, p.Idade, p.AgendamentoFuturoId);
        db.Pacientes.Remove(dto);
        db.SaveChanges();
    }

    public PacienteDTO? BuscaPorCPF(string cpf) => db.Pacientes.FirstOrDefault(p => p.cpf == cpf);

    //public Aluno? BuscaPorCPFComTurmas(string cpf) => db.Alunos.Include(a => a.Turmas).FirstOrDefault(a => a.Cpf == cpf);

    public List<Paciente> BuscaTodos()
    {
        List<Paciente> pacientesBD = db.Pacientes.Select(p => new Paciente
        {
            Cpf = p.cpf,
            Nome = p.nome,
            DataNascimento = p.dataNascimento,

        }).ToList();

        return pacientesBD;
    }

}
