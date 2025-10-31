using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainerLibrary.Models;
using TrainerLibrary.Repository;

namespace TrainerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TrainerController : ControllerBase
    {
        ITrainerRepository TrainerRepository;
        public TrainerController(ITrainerRepository TrainerRepository)
        {
            this.TrainerRepository = TrainerRepository;
        }
        [HttpGet]   
        public async Task<ActionResult> Get()
        {
            List<Trainer> trainers = await TrainerRepository.GetAllTrainersAsync();
            return Ok(trainers);
        }
        //type
        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetByType(string type)
        {
            try
            {
                List<Trainer> trainer = await TrainerRepository.GetTrainerByTypeAsync(type);
                return Ok(trainer);
            }
            catch (TrainerException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{trid}")]
        public async Task<ActionResult> Get(int trid)
        {
            try
            {
                Trainer trainer = await TrainerRepository.GetTrainerAsync(trid);
                return Ok(trainer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("{token}")]
        public async Task<ActionResult> Post(string token,Trainer trainer)
        {
            try
            {
                await TrainerRepository.InsertTrainerAsync(trainer);
                HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5170/api/Training/") };
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                await client.PostAsJsonAsync("Trainer", new { trainer.TrainerId });
                return Created($"api/Trainer/{trainer.TrainerId}", trainer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{trid}")]
        public async Task<ActionResult> Put(int trid, Trainer trainer)
        {
            try
            {
                await TrainerRepository.UpdateTrainerAsync(trid,trainer);
                return Ok(trainer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{trid}")]
        public async Task<ActionResult> Delete(int trid)
        {
            try
            {
                await TrainerRepository.DeleteTrainerAsync(trid);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


    