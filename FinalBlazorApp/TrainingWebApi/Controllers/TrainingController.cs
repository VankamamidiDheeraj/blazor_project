using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingLibrary.Models;
using TrainingLibrary.Repository;

namespace TrainingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TrainingController : ControllerBase
    {
        ITrainingRepository TrainingRepository;
        public  TrainingController(ITrainingRepository TrainingRepository)
        {
            this.TrainingRepository = TrainingRepository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<Training> trainings = await TrainingRepository.GetAllTrainingsAsync();
            return Ok(trainings);
        }

        [HttpGet("Trainer/{trid}")]
        public async Task<ActionResult> GetByTrainers(int trid)
        {
            try
            {
                List<Training> trainings = await TrainingRepository.GetAllTrainingsByTrainerAsync(trid);
                return Ok(trainings);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Technology/{tid}")]
        public async Task<ActionResult> GetByTechnologys(int tid)
        {
            try
            {
                List<Training> trainings = await TrainingRepository.GetAllTechnologysInTrainingAsync(tid);
                return Ok(trainings);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{trainid}")]
        public async Task<ActionResult> Get(int trainid)
        {
            try
            {
                Training training = await TrainingRepository.GetTrainingAsync(trainid);
                return Ok(training);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post(Training training)
        {
            try
            {
                await TrainingRepository.InsertTrainingAsync(training);
                return Created($"api/Training/{training.TrainingId}", training);
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Technology")]
        public async Task<ActionResult> PostTechnology(Technology technology)
        {
            try
            {
                await TrainingRepository.InsertTechnologyAsync(technology);
                return Created();
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Trainer
        [HttpPost("Trainer")]
        public async Task<ActionResult> PostTrainer(Trainer trainer)
        {
            try
            {
                await TrainingRepository.InsertTrainerAsync(trainer);
                return Created();
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //Technology
        [HttpPut("{trainid}")]
        public async Task<ActionResult> Put(int trainid, Training training)
        {
            try
            {
                await TrainingRepository.UpdateTrainingAsync(trainid, training);
                return Ok(training);
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{trainid}")]
        public async Task<ActionResult> Delete(int trainid)
        {
            try
            {
                await TrainingRepository.DeleteTrainingAsync(trainid);
                return Ok();
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


    
