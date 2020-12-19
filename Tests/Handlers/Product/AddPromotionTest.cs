using System.Linq;
using Domain.Commands;
using Domain.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Mock;

namespace Tests.Handlers.Product
{
    [TestClass]
    public class AddPromotionTest
    {
        [TestMethod]
        public void AddPromotionHandler_valid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            var command = new AddPromotionProductCommand();
            command.Id = repository.GetAll().FirstOrDefault().Id;            
            command.Price = 1.5m;

            var result = handler.AddPromotion(command);
            Assert.IsTrue(result.Success, result.Message);
        }

        [TestMethod]
        public void AddPromotionHandler_price_invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            var command = new AddPromotionProductCommand();
            command.Id = repository.GetAll().FirstOrDefault().Id;            
            command.Price = 11.5m;

            var result = handler.AddPromotion(command);
            Assert.IsFalse(result.Success, result.Message);
        }
    }
}