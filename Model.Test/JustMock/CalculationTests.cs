using NUnit.Framework;
using Telerik.JustMock;

namespace Model.Tests.JustMock
{
    [TestFixture]
    public class CalculationTests
    {
        [Test]
        public void GetName_ShouldGetValueFromBusinessContext()
        {
            var businessContextMock = Mock.Create<IBusinessContext>();
            var calculation = new Calculation(businessContextMock);
            string expectedName = "foo";
            Mock.Arrange(() => businessContextMock.GetTransalation(calculation, nameof(Calculation.Name)))
                .Returns(expectedName)
                .OccursOnce();

            var actualName = calculation.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void SetName_ShouldPassValueToBusinessContext()
        {
            var businessContextMock = Mock.Create<IBusinessContext>();
            var calculation = new Calculation(businessContextMock);
            var expectedName = "foo";
            Mock.Arrange(() => businessContextMock.SetTranslation(calculation, nameof(Calculation.Name), expectedName))
                .OccursOnce();

            calculation.Name = expectedName;
        }
    }
}