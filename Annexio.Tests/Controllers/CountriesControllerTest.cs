using System.Web.Mvc;
using Annexio.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Annexio.Tests.Controllers
{
    [TestClass]
    public class CountriesControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new CountriesController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
