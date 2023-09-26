using Microsoft.EntityFrameworkCore;
using webapi.health_clinic.Domain;

namespace webapi.health_clinic.Contexts
{
    public class HealthClinicContext : DbContext
    {
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<FeedBack> FeedBack { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE06-S14; Database=WebApi_HealthClinic; User Id = sa; Pwd = Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
