using webapi.health_clinic.Domain;

namespace webapi.health_clinic.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente paciente);

        List<Paciente> Listar();

        void Atualizar(Guid id, Paciente paciente);

        void Deletar(Guid id);
    }
}
