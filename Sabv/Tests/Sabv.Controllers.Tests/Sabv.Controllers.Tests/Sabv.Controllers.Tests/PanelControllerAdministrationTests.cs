namespace Sabv.Controllers.Tests
{
    using Microsoft.AspNetCore.Mvc;
    using Sabv.Web.Areas.Administration.Controllers;
    using Xunit;

    public class PanelControllerAdministrationTests
    {
        [Fact]
        public void IndexShouldReturnProperView()
        {
            // Arrange
            var controller = new PanelController();

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
    }
}
