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
    public class CompanyDetailsApiController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public CompanyDetailsApiController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/CompanyDetailsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDetails>>> GetCompanyDetails()
        {
            return await _context.CompanyDetail.ToListAsync();
        }

        // GET: api/CompanyDetailsApi/5
        [HttpGet("{companyName}")]
        public async Task<ActionResult<CompanyDetails>> GetCompanyDetail(string companyName)
        {
            var companyDetails = await _context.CompanyDetail.FindAsync(companyName);

            if (companyDetails == null)
            {
                return NotFound();
            }
            await _context.Entry(companyDetails).Collection(d => d.EmployeeManagements).LoadAsync();

            return companyDetails;
        }

        // PUT: api/CompanyDetailsApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{companyName}")]
        public async Task<IActionResult> PutCompanyDetails(string companyName, CompanyDetails companyDetails)
        {
            if (companyName != companyDetails.CompanyName)
            {
                return BadRequest();
            }

            _context.Entry(companyDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyDetailsExists(companyName))
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

        // POST: api/CompanyDetailsApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CompanyDetails>> PostCompanyDetails(CompanyDetails companyDetails)
        {
            _context.CompanyDetail.Add(companyDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompanyDetailsExists(companyDetails.CompanyName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompanyDetails", new { companyName = companyDetails.CompanyName }, companyDetails);
        }

        // DELETE: api/CompanyDetailsApi/5
        [HttpDelete("{companyName}")]
        public async Task<ActionResult<CompanyDetails>> DeleteCompanyDetails(string companyName)
        {
            var companyDetails = await _context.CompanyDetail.FindAsync(companyName);
            if (companyDetails == null)
            {
                return NotFound();
            }

            _context.CompanyDetail.Remove(companyDetails);
            await _context.SaveChangesAsync();

            return companyDetails;
        }

        private bool CompanyDetailsExists(string companyName)
        {
            return _context.CompanyDetail.Any(e => e.CompanyName == companyName);
        }
    }
}
