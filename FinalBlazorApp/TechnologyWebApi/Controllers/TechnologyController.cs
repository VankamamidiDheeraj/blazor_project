using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnologyLibrary.Models;
using TechnologyLibrary.Repository;

namespace TechnologyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TechnologyController : ControllerBase
    {
        ITechnologyRepository TechnologyRepository;
        public TechnologyController(ITechnologyRepository TechnologyRepository)
        {
            this.TechnologyRepository = TechnologyRepository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<Technology> technologies = await TechnologyRepository.GetAllTechnologysAsync();
            return Ok(technologies);
        }

        //level
        [HttpGet("level/{level}")]
        public async Task<IActionResult> GetByLevel(string level)
        {
            try
            {
                List<Technology> technologies = await TechnologyRepository.GetTechnologyByLevelAsync(level);
                return Ok(technologies);
            }
            catch (TechnologyException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{tid}")]
        public async Task<ActionResult> Get(int tid)
        {
            try
            {
                Technology technologies = await TechnologyRepository.GetTechnologyAsync(tid);
                return Ok(technologies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("{token}")]
        public async Task<ActionResult> Post(string token,Technology technology)
        {
            try
            {
                await TechnologyRepository.InsertTechnologyAsync(technology);
                HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5170/api/Training/") };
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                await client.PostAsJsonAsync("Technology", new { technology.TechnologyId});
                return Created($"api/Technology/{technology.TechnologyId}", technology);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{tid}")]
        public async Task<ActionResult> Put(int tid, Technology technology)
        {
            try
            {
                await TechnologyRepository.UpdateTechnologyAsync(tid, technology);
                return Ok(technology);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{tid}")]
        public async Task<ActionResult> Delete(int tid)
        {
            try
            {
                await TechnologyRepository.DeleteTechnologyAsync(tid);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }  }

