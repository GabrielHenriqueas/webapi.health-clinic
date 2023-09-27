using webapi.health_clinic.Domain;

namespace webapi.health_clinic.Interfaces
{
    public interface IEspecialidadeRepository
    {
        void Cadastrar(Especialidade especialidade);

        List<Especialidade> Listar();

        void Deletar(Guid id);
    }
}
