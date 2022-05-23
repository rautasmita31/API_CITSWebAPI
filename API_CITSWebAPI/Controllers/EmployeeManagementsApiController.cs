using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_CITSWebAPI.DAL;
using API_CITSWebAPI.Entities;

namespace API_CITSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeManagementsApiController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public EmployeeManagementsApiController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeManagementsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeManagement>>> GetEmployeeManagements()
        {
            return await _context.EmployeeManagements.ToListAsync();
        }

        // GET: api/EmployeeManagementsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeManagement>> GetEmployeeManagement(int id)
        {
            var employeeManagement = await _context.EmployeeManagements.FindAsync(id);

            if (employeeManagement == null)
            {
                return NotFound();
            }

            return employeeManagement;
        }

        // PUT: api/EmployeeManagementsApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeManagement(int id, EmployeeManagement employeeManagement)
        {
            if (id != employeeManagement.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employeeManagement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeManagementExists(id))
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

        // POST: api/EmployeeManagementsApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeeManagement>> PostEmployeeManagement(EmployeeManagement employeeManagement)
        {
            _context.EmployeeManagements.Add(employeeManagement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeManagement", new { id = employeeManagement.EmployeeId }, employeeManagement);
        }

        // DELETE: api/EmployeeManagementsApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeManagement>> DeleteEmployeeManagement(int id)
        {
            var employeeManagement = await _context.EmployeeManagements.FindAsync(id);
            if (employeeManagement == null)
            {
                return NotFound();
            }

            _context.EmployeeManagements.Remove(employeeManagement);
            await _context.SaveChangesAsync();

            return employeeManagement;
        }

        private bool EmployeeManagementExists(int id)
        {
            return _context.EmployeeManagements.Any(e => e.EmployeeId == id);
        }
    }
}
