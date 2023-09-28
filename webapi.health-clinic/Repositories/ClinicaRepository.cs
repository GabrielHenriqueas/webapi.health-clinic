using webapi.health_clinic.Contexts;
using webapi.health_clinic.Domain;
using webapi.health_clinic.Interfaces;

namespace webapi.health_clinic.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthClinicContext ctx;

        public ClinicaRepository()
        {
            ctx = new HealthClinicContext();
        }

        //==================================================================

        public void Atualizar(Guid id, Clinica clinica)
        {
            Clinica clinicaBuscada = ctx.Clinica.FirstOrDefault(x => x.IdClinica == id)!;

            if (clinicaBuscada != null)
            {
                clinicaBuscada.NomeFantasia = clinica.NomeFantasia;
                clinicaBuscada.CNPJ = clinica.CNPJ;
                clinicaBuscada.RazaoSocial = clinica.RazaoSocial;
                clinicaBuscada.HoraAbertura = clinica.HoraAbertura;
                clinicaBuscada.HoraFechamento = clinica.HoraFechamento;
                clinicaBuscada.Endereco = clinica.Endereco;
               
            }

            ctx.Clinica.Update(clinicaBuscada!);

            ctx.SaveChanges();
        }

        //==================================================================

        public void Cadastrar(Clinica clinica)
        {
            try
            {
                ctx.Clinica.Add(clinica);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //==================================================================

        public void Deletar(Guid id)
        {
            Clinica clinica = ctx.Clinica.FirstOrDefault(x => x.IdClinica == id)!;

            ctx.Clinica.Remove(clinica);

            ctx.SaveChanges();
        }

        //==================================================================

        public List<Clinica> Listar()
        {
            List<Clinica> clinicas = ctx.Clinica.ToList();

            return clinicas;
        }
    }
}
