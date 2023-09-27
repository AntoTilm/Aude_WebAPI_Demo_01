using Demo_01.DAL.Entities;
using Demo_01.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Demo_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private TrainerRepository _TrainerRepository;
        public TrainerController(TrainerRepository trainerRepository) 
        { 
            _TrainerRepository = trainerRepository;
            // 1 (mauvaise) façon d'injecter notre TrainerRepository
            //_TrainerRepository = new TrainerRepository();
        }

        [HttpGet]
        public IActionResult GetTrainers()
        {
            IEnumerable<Trainer> trainers = _TrainerRepository.GetAll();
            return Ok(trainers);
            //return Ok(new { message = "Hello les .Net de Technobel" });
            //OU
            //return StatusCode(StatusCodes.Status200OK, "Hello les .Net de Technobel");
        }
    }
}
