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
        
        
        
        [HttpGet]
        public IActionResult Get()
        {
            List<Job> jobs = _context.Jobs.ToList();
            return Ok(jobs);
        }

        
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Job job = _context.Jobs.FirstOrDefault(j => j.ID == id);
            if (job == null)
                return NotFound("Job was not found :( ");
            return Ok(job);
        }

        
        
        [HttpPost]
        public IActionResult Post(Job newJob)
        {
            if (ModelState.IsValid)
            {
                _context.Jobs.Add(newJob);
                _context.SaveChanges();
                return Ok(newJob);
            }
            return BadRequest(ModelState);

        }

        
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //Recording from 10/01/2020 ---- 30:00
        }

        
        
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Jobs.FirstOrDefault(p => p.ID == id);
            if (product == null)
            {
                return NotFound("Product not fount :( ");
            }

            _context.Jobs.Remove(product);
            _context.SaveChanges();

            return Ok(product);
        }
    }
}
