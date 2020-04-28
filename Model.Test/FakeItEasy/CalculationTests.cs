using FakeItEasy;
using NUnit.Framework;

namespace Model.Tests.FakeItEasy
{
    [TestFixture]
    public class CalculationTests
    {
        [Test]
        public void GetName_ShouldGetValueFromBusinessContext()
        {
            // Arrange
            var businessContextMock = A.Fake<IBusinessContext>();
            var calculation = new Calculation(businessContextMock);
            string expectedName = "foo";
            A.CallTo(() => businessContextMock.GetTransalation(calculation, nameof(Calculation.Name)))
                .Returns(expectedName);

            // Act
            var actualName = calculation.Name;

            // Assert
            A.CallTo(() => businessContextMock.GetTransalation(calculation, nameof(Calculation.Name)))
                .MustHaveHappened();
            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void SetName_ShouldPassValueToBusinessContext()
        {
            // Arrange
            var businessContextMock = A.Fake<IBusinessContext>();
            var calculation = new Calculation(businessContextMock);
            var expectedName = "foo";

            // Act
            calculation.Name = expectedName;

            // Assert
            A.CallTo(() => businessContextMock.SetTranslation(calculation, nameof(Calculation.Name), expectedName))
                .MustHaveHappened();
        }
    }
}