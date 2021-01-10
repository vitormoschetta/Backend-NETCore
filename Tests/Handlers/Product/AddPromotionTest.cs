using System.Linq;
using Domain.Commands;
using Domain.Handlers;
using Tests.Mock;
using Xunit;

namespace Tests.Handlers.Product
{   
    public class AddPromotionTest
    {
       [Fact]
        public void AddPromotionHandler_valid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            var command = new ProductPromotionCommand();
            command.Id = repository.GetAll().FirstOrDefault().Id;            
            command.Price = 1.5m;

            var result = handler.AddPromotion(command);
            Assert.True(result.Success, result.Message);
        }

        [Fact]
        public void AddPromotionHandler_price_invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            var command = new ProductPromotionCommand();
            command.Id = repository.GetAll().FirstOrDefault().Id;            
            command.Price = 11.5m;

            var result = handler.AddPromotion(command);
            Assert.False(result.Success, result.Message);
        }
    }
}