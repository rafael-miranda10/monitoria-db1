using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.Enum;

namespace Monitoria.Domain.Registration.Tests.Entities
{
    [TestClass]
    public class AnimalTests
    {
        [TestMethod]
        public void ReturnErrorWhenAgeIsZeroOrSmallThan()
        {
            var animal = new Animal("Greg", 0, SpeciesEnum.Canine, true);
            Assert.IsTrue(animal.Invalid);
        }

        [TestMethod]
        public void ReturnSuccessWhenAgeIsGreaterThanZero()
        {
            var animal = new Animal("Greg", 5, SpeciesEnum.Canine, true);
            Assert.IsTrue(animal.Valid);
        }

        [TestMethod]
        public void ReturnErrorWhenNameIsSmallThan3()
        {
            var animal = new Animal("Gu", 4, SpeciesEnum.Canine, true);
            Assert.IsTrue(animal.Invalid);
        }

        [TestMethod]
        public void ReturnErrorWhenNameIsGreaterThan40()
        {
            var animal = new Animal(" Por conseguinte, o consenso sobre a rato consens", 4, SpeciesEnum.Canine, true);
            Assert.IsTrue(animal.Invalid);
        }
    }
}
