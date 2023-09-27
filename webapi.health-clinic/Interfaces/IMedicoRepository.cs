using webapi.health_clinic.Domain;

namespace webapi.health_clinic.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);

        List<Medico> Listar();

        void Atualizar(Guid id, Medico medico);

        void Deletar(Guid id);
    }
}
