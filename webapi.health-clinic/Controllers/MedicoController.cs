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
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }

        //==================================================================

        /// <summary>
        /// CADASTRAR MÉDICO
        /// </summary>
        /// <param name="medico"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Medico medico)
        {
            try
            {
                _medicoRepository.Cadastrar(medico);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================

        /// <summary>
        /// LISTAR MÉDICOS
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                List<Medico> ListarMedicos = _medicoRepository.Listar();

                return StatusCode(200, ListarMedicos);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================

        /// <summary>
        /// ATUALIZAR MÉDICO
        /// </summary>
        /// <param name="id"></param>
        /// <param name="medico"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Medico medico)
        {
            try
            {
                _medicoRepository.Atualizar(id, medico);

                return StatusCode(200);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================

        /// <summary>
        /// DELETAR MÉDICO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _medicoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
