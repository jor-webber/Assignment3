using Assignment3.Controllers;
using Assignment3.Data;
using assignment3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.Common.Exceptions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Assignment_3_Test
{
    [TestClass]
    public class UnitTest1
    {
        private Assignment3Context context;


        [TestInitialize]
        public void SetUp()
        {
            context = new Assignment3Context(new DbContextOptions<Assignment3Context>());
        }

        [TestMethod]
        public void TestGetAllPatients()
        {
            var logger = new Logger<PatientController>(new LoggerFactory());

            // Arrange
            var controller = new PatientController(context, logger);
        }
    }
}
