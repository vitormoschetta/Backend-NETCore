using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Entities
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void Product_Valid()
        {
            var product = new Product("Produto A", 500);
            Assert.IsTrue(product.Valid);
        }

        [TestMethod]
        public void Product_Empty_Name_Invalid()
        {
            var product = new Product("", 5.95m);
            Assert.IsTrue(product.Invalid, "Nome do produto é de preenchimento obrigatório. ");
        }

        [TestMethod]
        public void Product_Null_Name_Invalid()
        {
            var product = new Product(null, 5.95m);
            Assert.IsTrue(product.Invalid, "Nome do produto é de preenchimento obrigatório. ");
        }

        [TestMethod]
        public void Product_Lenght_Name_4_Invalid()
        {
            var product = new Product("Pro", 5.95m);
            Assert.IsTrue(product.Invalid, "Nome do produto deve conter pelo menos 4 caracteres. ");
        }

        [TestMethod]
        public void Product_Negative_Price_Invalid()
        {
            var product = new Product("Produto A", -1);
            Assert.IsTrue(product.Invalid, "Preço do produto não pode ser 0, nulo ou negativo. ");
        }

    }
}