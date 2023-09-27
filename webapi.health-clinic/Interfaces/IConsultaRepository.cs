using webapi.health_clinic.Domain;

namespace webapi.health_clinic.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consulta);

        List<Consulta> Listar();

        void Atualizar(Guid id, Consulta consulta);

        void Deletar(Guid id);
    }
}
