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
        [HttpPost("AddJob")]
        public async Task<ActionResult<jobs>> AddJob(jobs myjob)
        {
            try
            {
                _Jobs.CreateJob(myjob);
                return myjob;
            }
            catch (Exception)
            {

                return NotFound();
            }
        }




        //Update job Details  
        [HttpPut("{id}")]
        public async Task<ActionResult<jobs>> UpdateJob(jobs j)
        {
            var jobs = _Jobs.GetById(j.Id);
            if (jobs == null)
            {
                return NotFound();
            }
            _Jobs.UpdateJob(j);
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
