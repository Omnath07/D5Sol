using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer.Data;
using DataLayer.Models;
using D5Sol.Interface;

namespace D5Sol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class jobsController : ControllerBase
    {
        private readonly IRepository<jobs> _Jobs;
        
        public jobsController(IRepository<jobs> Jobs)
        {
            _Jobs = Jobs;

        }

        //Add job  
        [HttpPost("AddPerson")]
        public async Task<Object> AddJob([FromBody] jobs myjob)
        {
            try
            {
                await _Jobs.CreateJob(myjob);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }




        //Update job Details  
        [HttpPut("Update")]
        public async Task<ActionResult<jobs>> Update(int id)
        {
            var jobs = _Jobs.GetById(id);
            if (jobs == null)
            {
                return NotFound();
            }
            _Jobs.UpdateJob(jobs);
            return jobs;
        }




        //Get all job Details  
        // GET: api/jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<jobs>>> GetJobs()
        {
            return _Jobs.GetAll().ToList();
        }



        //Get job job by ID  
        // GET: api/jobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<jobs>> GetjobsID(int id)
        {
            var jobs =  _Jobs.GetById(id);

            if (jobs == null)
            {
                return NotFound();
            }

            return jobs;
        }

        // DELETE: api/test/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<jobs>> Deletejobs(int id)
        {
            var jobs = _Jobs.GetById(id);
            if (jobs == null)
            {
                return NotFound();
            }
            _Jobs.DeleteJob(jobs);  
            return jobs;
        }

    }
}
