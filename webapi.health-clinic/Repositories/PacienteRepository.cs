using webapi.health_clinic.Contexts;
using webapi.health_clinic.Domain;
using webapi.health_clinic.Interfaces;

namespace webapi.health_clinic.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthClinicContext ctx;

        public PacienteRepository()
        {
            ctx = new HealthClinicContext();
        }

        //==================================================================

        public void Atualizar(Guid id, Paciente paciente)
        {
            Paciente pacienteBuscado = ctx.Paciente.FirstOrDefault(x => x.IdPaciente == id)!;

            if (pacienteBuscado != null)
            {
                pacienteBuscado.Idade = paciente.Idade;
                pacienteBuscado.Telefone = paciente.Telefone;
                pacienteBuscado.RG = paciente.RG;
                pacienteBuscado.CPF = paciente.CPF;
                pacienteBuscado.CEP = paciente.CEP;
                pacienteBuscado.Endereco = paciente.Endereco;
                pacienteBuscado.IdUsuario = paciente.IdUsuario;
            }

            ctx.Paciente.Update(pacienteBuscado!);

            ctx.SaveChanges();
        }

        public void Cadastrar(Paciente paciente)
        {
            try
            {
                ctx.Paciente.Add(paciente);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Paciente paciente = ctx.Paciente.FirstOrDefault(x => x.IdPaciente == id)!;

            ctx.Paciente.Remove(paciente);

            ctx.SaveChanges();
        }

        public List<Paciente> Listar()
        {
            List<Paciente> pacientes = ctx.Paciente.ToList();

            return pacientes;
        }
    }
}
