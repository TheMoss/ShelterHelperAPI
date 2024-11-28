using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterHelperAPI.Models;

namespace ShelterHelperAPI.Controllers
{
    [Route("api/EmployeesAssignments")]
    [ApiController]
    public class EmployeesAssignmentsController : ControllerBase
    {
        private readonly ShelterContext _context;

        public EmployeesAssignmentsController(ShelterContext context)
        {
            _context = context;
        }

        // GET: api/EmployeesAssignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeesAssignments>>> GetEmployeesAssignments()
        {
            return await _context.EmployeesAssignments.ToListAsync();
        }

        // GET: api/EmployeesAssignments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeesAssignments>> GetEmployeesAssignments(int? id)
        {
            var employeesAssignments = await _context.EmployeesAssignments.FindAsync(id);

            if (employeesAssignments == null)
            {
                return NotFound();
            }

            return employeesAssignments;
        }

        // PUT: api/EmployeesAssignments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeesAssignments(int? id, EmployeesAssignments employeesAssignments)
        {
            if (id != employeesAssignments.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeesAssignments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesAssignmentsExists(id))
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

        // POST: api/EmployeesAssignments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeesAssignments>> PostEmployeesAssignments(EmployeesAssignments employeesAssignments)
        {
            _context.EmployeesAssignments.Add(employeesAssignments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeesAssignments", new { id = employeesAssignments.Id }, employeesAssignments);
        }

        // DELETE: api/EmployeesAssignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeesAssignments(int? id)
        {
            var employeesAssignments = await _context.EmployeesAssignments.FindAsync(id);
            if (employeesAssignments == null)
            {
                return NotFound();
            }

            _context.EmployeesAssignments.Remove(employeesAssignments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeesAssignmentsExists(int? id)
        {
            return _context.EmployeesAssignments.Any(e => e.Id == id);
        }
    }
}
