using NUnit.Framework;

namespace Model.Tests
{
    [TestFixture]
    public class CalculationTests
    {
        [Test]
        public void GetName_ShouldGetValueFromBusinessContext()
        {
            // Arrange
            var businessContextMock = new BusinessContextMock();
            var calculation = new Calculation(businessContextMock);

            // Act
            var _ = calculation.Name;

            // Assert
            Assert.IsTrue(businessContextMock.IsGetTranslationCalled);
        }

        [Test]
        public void SetName_ShouldPassValueToBusinessContext()
        {
            // Arrange
            var businessContextMock = new BusinessContextMock();
            var calculation = new Calculation(businessContextMock);
            var newName = "foo";

            // Act
            calculation.Name = newName;

            // Assert
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