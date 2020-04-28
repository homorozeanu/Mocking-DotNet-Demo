using Moq;
using NUnit.Framework;

namespace Model.Tests.Moq
{
    [TestFixture]
    public class CalculationTests
    {
        [Test]
        public void GetName_ShouldGetValueFromBusinessContext()
        {
            // Arrange
            var businessContextMock = new Mock<IBusinessContext>();
            var calculation = new Calculation(businessContextMock.Object);
            string expectedName = "foo";
            businessContextMock
                .Setup(m => m.GetTransalation(calculation, nameof(Calculation.Name)))
                .Returns(expectedName);

            // Act
            var actualName = calculation.Name;

            // Assert
            businessContextMock
                .Verify(m => m.GetTransalation(calculation, nameof(Calculation.Name)), Times.Once);
            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void SetName_ShouldPassValueToBusinessContext()
        {
            // Arrange
            var businessContextMock = new Mock<IBusinessContext>();
            var calculation = new Calculation(businessContextMock.Object);
            var expectedName = "foo";

            // Act
            calculation.Name = expectedName;

            // Assert
            businessContextMock
                .Verify(m => m.SetTranslation(calculation, nameof(Calculation.Name), expectedName), Times.Once);
        }
    }
}