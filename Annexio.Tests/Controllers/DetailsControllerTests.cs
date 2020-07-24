using Annexio.Controllers;
using Annexio.Mediators;
using Annexio.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Annexio.Tests.Controllers
{
    public class DetailsControllerTests
    {
        private readonly Mock<ICountriesMediator> _mediator = new Mock<ICountriesMediator>();

        [Test]
        public void DetailsController_CountryDetailsByName_IsNotNull()
        {
            // Arrange
            var controller = new DetailsController(_mediator.Object);

            // Act
            var result = controller.CountryDetailsByName("TestCountry").Result;

            // Assert
            result.Should().NotBeNull();
        }

        [Test]
        public void DetailsController_CountryDetailsByCode_IsNotNull()
        {
            // Arrange
            var controller = new DetailsController(_mediator.Object);

            // Act
            var result = controller.CountryDetailsByCode("TC").Result;

            // Assert
            result.Should().NotBeNull();
        }

        [Test]
        public void DetailsController_RegionDetails_IsNotNull()
        {
            // Arrange
            var regionInfo = new RegionDetails()
            {
                Name = "TestRegion"
            };

            _mediator.Setup(s => s.GetRegionDetails("TestRegion")).ReturnsAsync(regionInfo);
            var controller = new DetailsController(_mediator.Object);

            // Act
            var result = controller.RegionDetails("TestRegion").Result;

            // Assert
            result.Should().NotBeNull();
        }

        [Test]
        public void DetailsController_SubRegionDetails_IsNotNull()
        {
            // Arrange
            var regionInfo = new RegionDetails()
            {
                Name = "TestSubRegion"
            };

            _mediator.Setup(s => s.GetSubRegionDetails("TestSubRegion")).ReturnsAsync(regionInfo);
            var controller = new DetailsController(_mediator.Object);

            // Act
            var result = controller.SubRegionDetails("TestSubRegion").Result;

            // Assert
            result.Should().NotBeNull();
        }
    }
}