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
    public class FeedBackController : ControllerBase
    {
        private IFeedBackRepository _feedBackRepository { get; set; }

        public FeedBackController()
        {
            _feedBackRepository = new FeedBackRepository();
        }

        //==================================================================

        /// <summary>
        /// CADASTRAR FEEDBACK
        /// </summary>
        /// <param name="feedBack"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(FeedBack feedBack)
        {
            try
            {
                _feedBackRepository.Cadastrar(feedBack);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================

        /// <summary>
        /// LISTAR FEEDBACKS
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                List<FeedBack> ListarFeedBacks = _feedBackRepository.Listar();

                return StatusCode(200, ListarFeedBacks);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //==================================================================
    }
}
