using Microsoft.AspNetCore.Mvc;
using MyToDoList.Data;
using MyToDoList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly JobsDbContext _context;
        public JobController(JobsDbContext context)
        {
            _context = context;
        }
        // GET: api/<JobController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Job> jobs = _context.Jobs.ToList();
            return Ok(jobs);
        }

        // GET api/<JobController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Job job = _context.Jobs.FirstOrDefault(j => j.ID == id);
            if (job == null)
                return NotFound("Job was not found :( ");
            return Ok(job);
        }

        // POST api/<JobController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JobController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JobController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
