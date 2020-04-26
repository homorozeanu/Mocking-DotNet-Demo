using NUnit.Framework;

namespace Model.Tests
{
    [TestFixture]
    public class CalculationTests
    {
        [Test]
        public void GetName_ShouldGetValueFromBusinessContext()
        {
            var businessContextMock = new BusinessContextMock();
            var calculation = new Calculation(businessContextMock);

            var _ = calculation.Name;

            Assert.IsTrue(businessContextMock.IsGetTranslationCalled);
        }

        [Test]
        public void SetName_ShouldPassValueToBusinessContext()
        {
            var businessContextMock = new BusinessContextMock();
            var calculation = new Calculation(businessContextMock);

            var newName = "foo";
            calculation.Name = newName;

            Assert.AreEqual(newName, businessContextMock.PassedTranslationValue);
        }

        class BusinessContextMock : IBusinessContext
        {
            public string GetTransalation(IPersistableObject persistableObject, string propertyName)
            {
                IsGetTranslationCalled = true;
                return "";
            }

            public void SetTranslation(IPersistableObject persistableObject, string propertyName, string value)
            {
                PassedTranslationValue = value;
            }

            public string PassedTranslationValue { get; private set; }

            public bool IsGetTranslationCalled { get; private set; }
        }
    }
}