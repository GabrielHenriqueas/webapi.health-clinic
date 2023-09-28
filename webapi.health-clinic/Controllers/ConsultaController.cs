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

    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        //==================================================================

        /// <summary>
        /// CADASTRAR CONSULTA
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                _consultaRepository.Cadastrar(consulta);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================

        /// <summary>
        /// LISTAR CONSULTAS
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                List<Consulta> ListarConsultas = _consultaRepository.Listar();

                return StatusCode(200, ListarConsultas);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================

        /// <summary>
        /// ATUALIZAR CONSULTA
        /// </summary>
        /// <param name="id"></param>
        /// <param name="consulta"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Consulta consulta)
        {
            try
            {
                _consultaRepository.Atualizar(id, consulta);

                return StatusCode(200);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================

        /// <summary>
        /// DELETAR CONSULTA
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _consultaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
