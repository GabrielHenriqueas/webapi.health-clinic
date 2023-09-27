using webapi.health_clinic.Contexts;
using webapi.health_clinic.Domain;
using webapi.health_clinic.Interfaces;

namespace webapi.health_clinic.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly HealthClinicContext ctx;

        public EspecialidadeRepository()
        {
            ctx = new HealthClinicContext();
        }

        //==================================================================

        public void Cadastrar(Especialidade especialidade)
        {
            try
            {
                ctx.Especialidade.Add(especialidade);

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
            Especialidade especialidade = ctx.Especialidade.FirstOrDefault(x => x.IdEspecialidade == id)!;

            ctx.Especialidade.Remove(especialidade);

            ctx.SaveChanges();
        }

        //==================================================================

        public List<Especialidade> Listar()
        {
            List<Especialidade> especialidades = ctx.Especialidade.ToList();

            return especialidades;
        }
    }
}
