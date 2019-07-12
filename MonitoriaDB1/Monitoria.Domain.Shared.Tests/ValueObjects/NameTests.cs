using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monitoria.Domain.Shared.ValueObjects;

namespace Monitoria.Domain.Shared.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void ReturnErrorWhenFirstNamesIsLowerThan3()
        {
            var name = new Name("an","Da Silva");
            Assert.IsTrue(name.Invalid);
        }

        [TestMethod]
        public void ReturnErrorWhenLastNamesIsLowerThan3()
        {
            var name = new Name("Leandro", "Da");
            Assert.IsTrue(name.Invalid);
        }

        [TestMethod]
        public void ReturnSuccessWhenNamesIsEquals3()
        {
            var name = new Name("ana", "Sil");
            Assert.IsTrue(name.Valid);
        }

        [TestMethod]
        public void ReturnErrorWhenLastNamesIsGreaterThan50()
        {
            var name = new Name("Leandro", " Por conseguinte, o consenso sobre a necessidade de");
            Assert.IsTrue(name.Invalid);
        }

        [TestMethod]
        public void ReturnErrorWhenFirstNamesIsGreaterThan50()
        {
            var name = new Name(" Por conseguinte, o consenso sobre a necessidade de", "Da Silva");
            Assert.IsTrue(name.Invalid);
        }
    }
}
