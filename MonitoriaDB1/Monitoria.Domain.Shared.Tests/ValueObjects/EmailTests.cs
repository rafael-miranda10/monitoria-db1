using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monitoria.Domain.Shared.ValueObjects;

namespace Monitoria.Domain.Shared.Tests.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void ReturnErrorWhenEMailIsInvalid()
        {
            var email = new Email("emailinvalido.com.br");
            Assert.IsTrue(email.Invalid);
        }

        [TestMethod]
        public void ReturnSuccessWhenEMailIsValid()
        {
            var email = new Email("arthur.rafa10@gmail.com");
            Assert.IsTrue(email.Valid);
        }
    }
}
