using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monitoria.Domain.Shared.ValueObjects;
using Monitoria.Domain.Shared.Enum;

namespace Monitoria.Domain.Shared.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ReturnErrorWhenCNPJIsInvalid()
        {
            var document = new Document("12396", DocumentEnum.CNPJ);
            Assert.IsTrue(document.Invalid);
        }

        [TestMethod]
        public void ReturnSuccessWhenCNPJIsValid()
        {
            var document = new Document("22314484000186", DocumentEnum.CNPJ);
            Assert.IsTrue(document.Valid);
        }

        [TestMethod]
        public void ReturnErrorWhenCPFIsInvalid()
        {
            var document = new Document("852123", DocumentEnum.CPF);
            Assert.IsTrue(document.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("35308123071")]
        [DataRow("30478175027")]
        [DataRow("11768540039")]
        public void ReturnSuccessWhenCPFIsValid(string cpf)
        {
            var document = new Document(cpf, DocumentEnum.CPF);
            Assert.IsTrue(document.Valid);
        }
    }
}
