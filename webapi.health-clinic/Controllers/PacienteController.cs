using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.health_clinic.Domain;
using webapi.health_clinic.Interfaces;
using webapi.health_clinic.Repositories;

namespace webapi.health_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }

        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        //==================================================================

        /// <summary>
        /// CADASTRAR PACIENTE
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Paciente paciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(paciente);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================

        /// <summary>
        /// LISTAR PACIENTES
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                List<Paciente> ListarPacientes = _pacienteRepository.Listar();

                return StatusCode(200, ListarPacientes);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================

        /// <summary>
        /// ATUALIZAR PACIENTES
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paciente"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Paciente paciente)
        {
            try
            {
                _pacienteRepository.Atualizar(id, paciente);

                return StatusCode(200);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================

        /// <summary>
        /// DELETAR PACIENTES
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _pacienteRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
