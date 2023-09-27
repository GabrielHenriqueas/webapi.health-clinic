using webapi.health_clinic.Contexts;
using webapi.health_clinic.Domain;
using webapi.health_clinic.Interfaces;

namespace webapi.health_clinic.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthClinicContext ctx;

        public MedicoRepository()
        {
            ctx = new HealthClinicContext();
        }

        //==================================================================

        public void Atualizar(Guid id, Medico medico)
        {
            Medico medicoBuscado = ctx.Medico.FirstOrDefault(x => x.IdMedico == id)!;

            if (medicoBuscado != null)
            {
                medicoBuscado.CRM = medico.CRM;
                medicoBuscado.Estado = medico.Estado;
                medicoBuscado.IdUsuario = medico.IdUsuario;
                medicoBuscado.IdEspecialidade = medico.IdEspecialidade;
                medicoBuscado.IdClinica = medico.IdClinica;
            }

            ctx.Medico.Update(medicoBuscado!);

            ctx.SaveChanges();
        }

        //==================================================================

        public void Cadastrar(Medico medico)
        {
            try
            {
                ctx.Medico.Add(medico);

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
            Medico medico = ctx.Medico.FirstOrDefault(x => x.IdMedico == id)!;

            ctx.Medico.Remove(medico);

            ctx.SaveChanges();
        }

        //==================================================================

        public List<Medico> Listar()
        {
            List<Medico> medicos = ctx.Medico.ToList();

            return medicos;
        }
    }
}
