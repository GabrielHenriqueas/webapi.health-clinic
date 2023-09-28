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

    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        //==================================================================

        /// <summary>
        /// CADASTRAR CLÍNICA
        /// </summary>
        /// <param name="clinica"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Clinica clinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(clinica);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================

        /// <summary>
        /// LISTAR CLÍNICA
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                List<Clinica> ListarClinicas = _clinicaRepository.Listar();

                return StatusCode(200, ListarClinicas);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================

        /// <summary>
        /// ATUALIZAR CLÍNICA
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clinica"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Clinica clinica)
        {
            try
            {
                _clinicaRepository.Atualizar(id, clinica);

                return StatusCode(200);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================

        /// <summary>
        /// DELETAR CLÍNICA
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _clinicaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
