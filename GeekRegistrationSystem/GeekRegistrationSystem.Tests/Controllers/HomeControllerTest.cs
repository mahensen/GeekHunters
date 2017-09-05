using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeekRegistrationSystem;
using GeekRegistrationSystem.Controllers;
using GeekRegistrationSystem.Models;

namespace GeekRegistrationSystem.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestIndexPage()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void TestIndexPageWithParams()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void TestDetailsPageWithParams()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Details(1) as ViewResult;

            // Assert
            Assert.AreEqual("Jon", ((Candidate)result.Model).FirstName);
        }


        


    }
}
