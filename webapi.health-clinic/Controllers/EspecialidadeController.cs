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

    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeRepository _especialidadeRepository { get; set; }

        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        //==================================================================

        /// <summary>
        /// CADASTRAR ESPECIALIDADES
        /// </summary>
        /// <param name="especialidade"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Especialidade especialidade)
        {
            try
            {
                _especialidadeRepository.Cadastrar(especialidade);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================

        /// <summary>
        /// LISTAR ESPECIALIDADES
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Especialidade> ListarEspecialidades = _especialidadeRepository.Listar();

                return StatusCode(200, ListarEspecialidades);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================

        /// <summary>
        /// DELETAR ESPECIALIDADE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _especialidadeRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
