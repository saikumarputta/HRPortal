using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRPortal.Models;

namespace HRPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeskillsController : ControllerBase
    {
        private readonly portaldbContext _context;

        public EmployeeskillsController(portaldbContext context)
        {
            _context = context;
        }

        // GET: api/Employeeskills
        [HttpGet]
        public IEnumerable<Employeeskills> Getemployeeskills()
        {
            return _context.employeeskills;
        }

        // GET: api/Employeeskills/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeskills([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeskills = await _context.employeeskills.FindAsync(id);

            if (employeeskills == null)
            {
                return NotFound();
            }

            return Ok(employeeskills);
        }

        // PUT: api/Employeeskills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeskills([FromRoute] int id, [FromBody] Employeeskills employeeskills)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeskills.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeskills).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeskillsExists(id))
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

        // POST: api/Employeeskills
        [HttpPost]
        public async Task<IActionResult> PostEmployeeskills([FromBody] Employeeskills employeeskills)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.employeeskills.Add(employeeskills);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeskills", new { id = employeeskills.Id }, employeeskills);
        }

        // DELETE: api/Employeeskills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeskills([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeskills = await _context.employeeskills.FindAsync(id);
            if (employeeskills == null)
            {
                return NotFound();
            }

            _context.employeeskills.Remove(employeeskills);
            await _context.SaveChangesAsync();

            return Ok(employeeskills);
        }

        private bool EmployeeskillsExists(int id)
        {
            return _context.employeeskills.Any(e => e.Id == id);
        }
    }
}