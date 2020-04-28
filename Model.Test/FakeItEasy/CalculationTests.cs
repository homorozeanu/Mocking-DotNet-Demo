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
            var businessContextMock = A.Fake<IBusinessContext>();
            var calculation = new Calculation(businessContextMock);
            string expectedName = "foo";
            A.CallTo(() => businessContextMock.GetTransalation(calculation, nameof(Calculation.Name)))
                .Returns(expectedName);

            var actualName = calculation.Name;

            A.CallTo(() => businessContextMock.GetTransalation(calculation, nameof(Calculation.Name)))
                .MustHaveHappened();
            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void SetName_ShouldPassValueToBusinessContext()
        {
            var businessContextMock = A.Fake<IBusinessContext>();
            var calculation = new Calculation(businessContextMock);

            var expectedName = "foo";
            calculation.Name = expectedName;

            A.CallTo(()=>businessContextMock.SetTranslation(calculation, nameof(Calculation.Name), expectedName))
                .MustHaveHappened();
        }
    }}