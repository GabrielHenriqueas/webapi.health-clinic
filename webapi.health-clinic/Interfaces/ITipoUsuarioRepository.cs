using webapi.health_clinic.Domain;

namespace webapi.health_clinic.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuario tipoUsuario);

        List<TipoUsuario> Listar();

        void Deletar(Guid id);

    }
}
