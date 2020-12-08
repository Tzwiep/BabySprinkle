using DotNetDiapers.Controllers;
using DotNetDiapers.Data;
using DotNetDiapers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

        [TestInitialize]
        public void TestInitialize()
        {
            // set up in-memory db -- added Nuget Package to test solution*
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;
           
            _context = new ApplicationDbContext(options);

            // create testing data and add the data to the in-memory db
            var guest = new Guest { GuestId = 20, Name = "Gonzo Wright", Email = "g.wright@test.com", Username = "Gonz" };
            _context.Guests.Add(guest);
            _context.SaveChanges();

            babyPredictions.Add(new BabyPrediction { Id = 25, Baby_Gender = "Boy", Baby_Name = "Fleetwood", Birth_Weight = 7,
                    Due_Date = new DateTime(2021-30-01), GuestId=20 });
            babyPredictions.Add(new BabyPrediction { Id = 30, Baby_Gender = "Girl", Baby_Name = "Betty", Birth_Weight = 6.4,
                   Due_Date = new DateTime(2021-02-02), GuestId=20 });
            babyPredictions.Add(new BabyPrediction { Id = 33, Baby_Gender = "Boy", Baby_Name = "Bowie", Birth_Weight = 8.2,
                    Due_Date = new DateTime(2021-02-10), GuestId=20 });

            foreach (var bp in babyPredictions)
            {
                _context.BabyPredictions.Add(bp);
            }
            _context.SaveChanges();

            // instantiate controller
            controller = new BabyPredictionsController(_context);
        }
        #region Edit

        [TestMethod]
        public void EditNoIdReturnsError()
        {
            // act - result with null id
            var result = (ViewResult)controller.Edit(null).Result;

            // assert - should result in Error page
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void EditInvalidIdReturnsError()
        {
            // act -set result variable with an INVALID ID -- not 25, 30, or 33
            var result = (ViewResult)controller.Edit(20).Result;

            // assert - should result in Error page
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void EditValidIdReturnsEditView()
        {
            // act -set result variable with a VALID ID --  25, 30, or 33
            var result = (ViewResult)controller.Edit(30).Result;

            // assert - should return the Edit page
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditValidIdReturnsMatchingBabyPrediction()
        {
            // act -set result variable with a VALID ID --  25, 30, or 33
            var result = (ViewResult)controller.Edit(33).Result;
            var model = (BabyPrediction)result.Model;

            // assert - should return BabyPrediction with id=33 --- Third item in array of mock data
            Assert.AreEqual(babyPredictions[2], model);
        }

        #endregion Edit
    }
}
