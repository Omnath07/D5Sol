using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer.Data;
using DataLayer.Models;

namespace D5Sol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public testController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/test
        [HttpGet]
        public async Task<ActionResult<IEnumerable<jobs>>> GetJobs()
        {
            return await _context.Jobs.ToListAsync();
        }

        // GET: api/test/5
        [HttpGet("{id}")]
        public async Task<ActionResult<jobs>> Getjobs(int id)
        {
            var jobs = await _context.Jobs.FindAsync(id);

            if (jobs == null)
            {
                return NotFound();
            }

            return jobs;
        }

        // PUT: api/test/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putjobs(int id, jobs jobs)
        {
            if (id != jobs.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!jobsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/test
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<jobs>> Postjobs(jobs jobs)
        {
            _context.Jobs.Add(jobs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getjobs", new { id = jobs.Id }, jobs);
        }

        // DELETE: api/test/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<jobs>> Deletejobs(int id)
        {
            var jobs = await _context.Jobs.FindAsync(id);
            if (jobs == null)
            {
                return NotFound();
            }

            _context.Jobs.Remove(jobs);
            await _context.SaveChangesAsync();

            return jobs;
        }

        private bool jobsExists(int id)
        {
            return _context.Jobs.Any(e => e.Id == id);
        }
    }
}
