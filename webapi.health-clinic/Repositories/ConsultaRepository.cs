using webapi.health_clinic.Contexts;
using webapi.health_clinic.Domain;
using webapi.health_clinic.Interfaces;

namespace webapi.health_clinic.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthClinicContext ctx;

        public ConsultaRepository()
        {
            ctx = new HealthClinicContext();
        }

        //==================================================================

        public void Atualizar(Guid id, Consulta consulta)
        {
            Consulta consultaBuscada = ctx.Consulta.FirstOrDefault(x => x.IdConsulta == id)!;

            if (consultaBuscada != null)
            {
                consultaBuscada.Situacao = consulta.Situacao;
                consultaBuscada.Descricao = consulta.Descricao;
                consultaBuscada.DataConsulta = consulta.DataConsulta;
                consultaBuscada.HoraConsulta = consulta.HoraConsulta;
                
            }

            ctx.Consulta.Update(consultaBuscada!);

            ctx.SaveChanges();
        }

        //==================================================================

        public void Cadastrar(Consulta consulta)
        {
            try
            {
                ctx.Consulta.Add(consulta);

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
            Consulta consulta = ctx.Consulta.FirstOrDefault(x => x.IdConsulta == id)!;

            ctx.Consulta.Remove(consulta);

            ctx.SaveChanges();
        }

        //==================================================================

        public List<Consulta> Listar()
        {
            List<Consulta> consultas = ctx.Consulta.ToList();

            return consultas;
        }
    }
}
