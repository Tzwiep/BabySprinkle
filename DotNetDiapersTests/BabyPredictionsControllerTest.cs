using DotNetDiapers.Controllers;
using DotNetDiapers.Data;
using DotNetDiapers.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DotNetDiapersTests
{
    [TestClass]
    public class BabyPredictionsControllerTest
    {
        // arrange - declare db connection, list of baby predictions, and instance of controller for all tests to use
        private ApplicationDbContext _context;
        List<BabyPrediction> babyPredictions = new List<BabyPrediction>();
        BabyPredictionsController controller;

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
