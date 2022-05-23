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
    public class AttendanceManagementsApiController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public AttendanceManagementsApiController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/AttendanceManagementsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendanceManagement>>> GetAttendanceManagements()
        {
            return await _context.AttendanceManagements.ToListAsync();
        }

        // GET: api/AttendanceManagementsApi/5
        [HttpGet("{AttendanceManagementId}")]
        public async Task<ActionResult<AttendanceManagement>> GetAttendanceManagement(double AttendanceManagementId)
        {
            var attendanceManagement = await _context.AttendanceManagements.FindAsync(AttendanceManagementId);

            if (attendanceManagement == null)
            {
                return NotFound();
            }

            return attendanceManagement;
        }

        // PUT: api/AttendanceManagementsApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{AttendanceManagementId}")]
        public async Task<IActionResult> PutAttendanceManagement(double AttendanceManagementId, AttendanceManagement attendanceManagement)
        {
            if (AttendanceManagementId != attendanceManagement.AttendanceManagementId)
            {
                return BadRequest();
            }

            _context.Entry(attendanceManagement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceManagementExists(AttendanceManagementId))
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

        // POST: api/AttendanceManagementsApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AttendanceManagement>> PostAttendanceManagement(AttendanceManagement attendanceManagement)
        {
            _context.AttendanceManagements.Add(attendanceManagement);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AttendanceManagementExists(attendanceManagement.AttendanceManagementId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAttendanceManagement", new { AttendanceManagementId = attendanceManagement.AttendanceManagementId }, attendanceManagement);
        }

        // DELETE: api/AttendanceManagementsApi/5
        [HttpDelete("{AttendanceManagementId}")]
        public async Task<ActionResult<AttendanceManagement>> DeleteAttendanceManagement(double AttendanceManagementId)
        {
            var attendanceManagement = await _context.AttendanceManagements.FindAsync(AttendanceManagementId);
            if (attendanceManagement == null)
            {
                return NotFound();
            }

            _context.AttendanceManagements.Remove(attendanceManagement);
            await _context.SaveChangesAsync();

            return attendanceManagement;
        }

        private bool AttendanceManagementExists(double AttendanceManagementId)
        {
            return _context.AttendanceManagements.Any(e => e.AttendanceManagementId == AttendanceManagementId);
        }
    }
}
