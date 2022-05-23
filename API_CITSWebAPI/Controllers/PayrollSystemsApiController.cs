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
    public class PayrollSystemsApiController : ControllerBase
    {
        private readonly CompanyDbContext _context;

        public PayrollSystemsApiController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: api/PayrollSystemsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendanceManagement>>> GetAttendanceManagements()
        {
            return await _context.AttendanceManagements.ToListAsync();
        }

        // GET: api/PayrollSystemsApi/5
        [HttpGet("{AttendanceManagementId}")]
        public async Task<ActionResult<double>> GetNetSalary(int AttendanceManagementId)
        {
            var Employee = await _context.EmployeeManagements.FindAsync(AttendanceManagementId);
            double BasicSalary = Employee.BasicSalary;
            var Attendance = _context.AttendanceManagements.Where(a => a.EmployeeManagementEmployeeId == AttendanceManagementId);
            var CurrentMonthAttendance = Attendance.Where(a => a.Date.Year == DateTime.Now.Year && a.Date.Month == DateTime.Now.Month);

            int NumberofDays = CurrentMonthAttendance.Sum(a => a.HalfDayLeaves) / 2;
            double Perdaysalary = BasicSalary / NumberofDays;
            double Salary = NumberofDays * Perdaysalary;
            return Salary;
        }
    }
}
