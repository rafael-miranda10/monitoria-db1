using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monitoria.Domain.Shared.ValueObjects;

namespace Monitoria.Domain.Shared.Tests.ValueObjects
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void ReturnErrorWhenZipCodeIsGreaterThan8()
        {
            var address = new Address("Rua Nochete", "450", "Vila Operária","Presidente Prudente", "São Paulo", "Brasil", "190330409");
            Assert.IsTrue(address.Invalid);
        }

        [TestMethod]
        public void ReturnErrorWhenZipCodeIsLowerThan8()
        {
            var address = new Address("Rua Nochete", "450", "Vila Operária", "Presidente Prudente", "São Paulo", "Brasil", "1903304");
            Assert.IsTrue(address.Invalid);
        }

        [TestMethod]
        public void ReturnErrorWhenZipCodeIsNotOnlyNumber()
        {
            var address = new Address("Rua Nochete", "450", "Vila Operária", "Presidente Prudente", "São Paulo", "Brasil", "abcd5678");
            Assert.IsTrue(address.Invalid);
        }

        [TestMethod]
        public void ReturnSuccessWhenZipCodeIsOnlyNumber()
        {
            var address = new Address("Rua Nochete", "450", "Vila Operária", "Presidente Prudente", "São Paulo", "Brasil", "19033040");
            Assert.IsTrue(address.Valid);
        }

        [TestMethod]
        public void ReturnErrorWhenNumberIsNotOnlyNumber()
        {
            var address = new Address("Rua Nochete", "450A", "Vila Operária", "Presidente Prudente", "São Paulo", "Brasil", "abcd5678");
            Assert.IsTrue(address.Invalid);
        }

        [TestMethod]
        public void ReturnSuccessWhenNumberIsOnlyNumber()
        {
            var address = new Address("Rua Nochete", "450", "Vila Operária", "Presidente Prudente", "São Paulo", "Brasil", "19033040");
            Assert.IsTrue(address.Valid);
        }
    }
}
