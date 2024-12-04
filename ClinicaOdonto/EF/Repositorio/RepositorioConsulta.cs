using ClinicaOdonto.Aplicacao.Domain;
using ClinicaOdonto.EF.DTO;
using Microsoft.EntityFrameworkCore;

namespace ClinicaOdonto.EF.Repositorio;

public class RepositorioConsulta
{
    private readonly AppDbContext db;

    public RepositorioConsulta(AppDbContext db) => this.db = db;

    public void Adiciona(Consulta c)
    {
        ConsultaDTO dto = new(c.Data, c.HoraInicial, c.HoraFinal, c.Duracao, c.CpfPaciente); 
        db.Consultas.Add(dto);
        db.SaveChanges();
    }

    public void Atualiza(Consulta c)
    {
        ConsultaDTO dto = new(c.Data, c.HoraInicial, c.HoraFinal, c.Duracao, c.CpfPaciente);
        db.Consultas.Update(dto);
        db.SaveChanges();
    }

    public void Remove(Consulta c)
    {
        ConsultaDTO dto = new(c.Data, c.HoraInicial, c.HoraFinal, c.Duracao, c.CpfPaciente);
        db.Consultas.Remove(dto);
        db.SaveChanges();
    }
    public ConsultaDTO? BuscaPorId(string id) => db.Consultas.FirstOrDefault(c => c.id.ToString() == id);

    public List<Consulta> BuscaTodos()
    {
        List<Consulta> consultasBD = db.Consultas.Select(c => new Consulta
        {
            Data = c.data,
            HoraInicial = c.horaInicial,
            HoraFinal = c.horaFinal,
            CpfPaciente = c.cpfPaciente

        }).ToList();

        return consultasBD;
    }
}
