using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeekRegistrationSystem.Controllers;
using System.Web.Mvc;
using GeekRegistrationSystem.Models;

namespace GeekRegistrationSystem.Tests.Controllers
{
    /// <summary>
    /// Summary description for SkillControllerTest
    /// </summary>
    [TestClass]
    public class SkillsControllerTest
    {
        [TestMethod]
        public void TestDetailsPageWithParams()
        {
            // Arrange
            SkillsController controller = new SkillsController();

            // Act
            ViewResult result = controller.Details(2) as ViewResult;

            // Assert
            Assert.AreEqual(2, ((CandidateSkill)result.Model).CandidateId);
        }
    }
}
