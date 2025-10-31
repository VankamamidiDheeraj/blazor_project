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
    public class TraineeController : ControllerBase
    {
        ITraineeRepository TraineeRepository;
        public TraineeController(ITraineeRepository TraineeRepository)
        {
            this.TraineeRepository = TraineeRepository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<Trainee> trainees = await TraineeRepository.GetAllTraineesAsync();
            return Ok(trainees);
        }
        //Status
        [HttpGet("status/{status}")]
        public async Task<ActionResult> GetByStatus(string status)
        {
            try
            {
                List<Trainee> trainees = await TraineeRepository.GetTraineesByStatusAsync(status);
                return Ok(trainees);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //Training
        [HttpGet("Training/{trainid}")]
        public async Task<ActionResult> GetByTrainings(int trainid)
        {
            try
            {
                List<Trainee> trainees = await TraineeRepository.GetAllTrainingByTraineeAsync(trainid);
                return Ok(trainees);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //Employee
        [HttpGet("Employee/{eid}")]
        public async Task<ActionResult> GetByEmployees(int eid)
        {
            try
            {
                List<Trainee> trainees = await TraineeRepository.GetAllTraineesByEmployeeAsync(eid);
                return Ok(trainees);
            }
            catch (TrainingException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{trainid}/{eid}")]
        public async Task<ActionResult> Get(int trainid,int eid)
        {
            try
            {
                Trainee trainee = await TraineeRepository.GetTraineeAsync(trainid,eid);
                return Ok(trainee);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> Post(Trainee trainee)
        {
            try
            {
                await TraineeRepository.AddTraineeAsync(trainee);
                return Created($"api/Trainee/{trainee.TrainingId},{trainee.EmpId}", trainee);
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Employee")]
        public async Task<ActionResult> PostEmployee(Employee employee)
        {
            try
            {
                await TraineeRepository.InsertEmployeeAsync(employee);
                return Created();
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }
       

        [HttpPut("{trainid}/{eid}")]
        public async Task<ActionResult> Put(int trainid, int eid,Trainee trainee)
        {
            try
            {
                await TraineeRepository.UpdateTraineeAsync(trainid,eid, trainee);
                return Ok(trainee);
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{trainid}/{eid}")]
        public async Task<ActionResult> Delete(int trainid,int eid)
        {
            try
            {
                await TraineeRepository.DeleteTraineeAsync(trainid,eid);
                return Ok();
            }
            catch (TrainingException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}


