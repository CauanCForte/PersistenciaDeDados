using ClinicaOdonto.Aplicacao.Domain;
using Microsoft.EntityFrameworkCore;
using ClinicaOdonto.EF.DTO;

namespace ClinicaOdonto.EF;
public class AppDbContext : DbContext
{
    public DbSet<PacienteDTO> Pacientes { get; set; }

    public DbSet<ConsultaDTO> Consultas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        string host = "127.0.0.1";
        string port = "5432";
        string username = "postgres";
        string password = "W@sd2809";

        string database = "ClinicaOdonto";

        string connectionString = $"Host={host};Port={port};Username={username};Password={password};Database={database}";

        optionsBuilder.UseNpgsql(connectionString);
    }
}
