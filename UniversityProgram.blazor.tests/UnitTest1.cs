using Bunit;
using UniversityProgram.blazor.Pages;

namespace UniversityProgram.blazor.tests
{
    public class UnitTest1 : TestContext
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var component = RenderComponent<NewPage>();
            var button = component.Find(".myButton");

            var textComponent = component.Find("#myText");

            // Act
            button.Click();

            // Assert
            textComponent.MarkupMatches("<p id=\"myText\">user name: Պողոս</p>");
        }
    }
}