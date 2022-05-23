using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using API_CITSWebAPI.Controllers;
using System.Linq;
using API_CITSWebAPI.DAL;
using API_CITSWebAPI.Entities;
using Microsoft.EntityFrameworkCore;


namespace API_CITSWebAPI.UnitTestss
{
    [TestClass]
    public class AttendanceManagementControllerUnitTest
    {
        [TestMethod]
        public void Get_Test()
        {
            var options = SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), "SERVER=(LocalDB)\\MSSQLLocalDB;DATABASE=Company;TRUSTED_CONNECTION=TRUE;MULTIPLEACTIVERESULTSETS=TRUE;").Options;
            var dbContext = new CompanyDbContext(options);
            var Controller = new AttendanceManagementsApiController(dbContext);
            var getResult = Controller.GetAttendanceManagements().Result.Value;
            Assert.IsInstanceOfType(getResult, typeof(IEnumerable<AttendanceManagement>));

        }
    }
}
