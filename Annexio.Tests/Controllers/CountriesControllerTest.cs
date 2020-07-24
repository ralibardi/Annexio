using System.Collections.Generic;
using Annexio.Controllers;
using Annexio.Mediators;
using Annexio.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PagedList;

namespace Annexio.Tests.Controllers
{
    public class CountriesControllerTest
    {
        private readonly Mock<ICountriesMediator> _mediator = new Mock<ICountriesMediator>();

        [Test]
        public void CountriesController_Index_IsNotNull()
        {
            // Arrange
            var controller = new CountriesController(_mediator.Object);

            // Act
            var result = controller.Index(1).Result;

            // Assert
            result.Should().NotBeNull();
        }

        [Test]
        public void CountriesController_CountriesTable_IsNotNull()
        {
            var list = new List<Country>();
            // Arrange
            var controller = new CountriesController(_mediator.Object);

            // Act
            var result = controller.CountriesTable(list.ToPagedList(1, 1));

            // Assert
            result.Should().NotBeNull();
        }
    }
}
