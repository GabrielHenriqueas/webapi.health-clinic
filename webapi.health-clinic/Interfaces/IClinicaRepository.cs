using webapi.health_clinic.Domain;

namespace webapi.health_clinic.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica clinica);

        List<Clinica> Listar();

        void Atualizar(Guid id, Clinica clinica);

        void Deletar(Guid id);
    }
}
