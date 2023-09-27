using webapi.health_clinic.Contexts;
using webapi.health_clinic.Domain;
using webapi.health_clinic.Interfaces;

namespace webapi.health_clinic.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly HealthClinicContext ctx;

        public TipoUsuarioRepository()
        {
            ctx = new HealthClinicContext();
        }

        //==================================================================

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                ctx.TipoUsuario.Add(tipoUsuario);

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
            TipoUsuario tipoUsuario = ctx.TipoUsuario.FirstOrDefault(x => x.IdTipoUsuario == id)!;

            ctx.TipoUsuario.Remove(tipoUsuario);

            ctx.SaveChanges();
        }

        //==================================================================

        public List<TipoUsuario> Listar()
        {
            List<TipoUsuario> tipoUsuarios = ctx.TipoUsuario.ToList();

            return tipoUsuarios;
        }
    }
}
