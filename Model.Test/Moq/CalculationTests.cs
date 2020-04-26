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
            var businessContextMock = new Mock<IBusinessContext>();
            var calculation = new Calculation(businessContextMock.Object);
            string expectedName = "foo";
            businessContextMock
                .Setup(m => m.GetTransalation(calculation, nameof(Calculation.Name)))
                .Returns(expectedName);

            var actualName = calculation.Name;

            businessContextMock
                .Verify(m => m.GetTransalation(calculation, nameof(Calculation.Name)), Times.Once);
            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void SetName_ShouldPassValueToBusinessContext()
        {
            var businessContextMock = new Mock<IBusinessContext>();
            var calculation = new Calculation(businessContextMock.Object);

            var expectedName = "foo";
            calculation.Name = expectedName;

            businessContextMock
                .Verify(m => m.SetTranslation(calculation, nameof(Calculation.Name), expectedName), Times.Once);
        }
    }
}