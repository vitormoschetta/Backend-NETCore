using System.Linq;
using Domain.Commands;
using Domain.Commands.Handlers;
using Tests.Mock;
using Xunit;

namespace Tests.Commands.Handlers
{
    public class AddPromotionTest
    {
       [Fact]
        public void AddPromotionHandler_valid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductCommandHandler(repository);

            var command = new ProductPromotionCommand();
            command.Id = repository.GetAll().FirstOrDefault().Id;            
            command.Price = 1.5m;

            var result = handler.Handle(command);
            Assert.True(result.Success, result.Message);
        }

        [Fact]
        public void AddPromotionHandler_price_invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductCommandHandler(repository);

            var command = new ProductPromotionCommand();
            command.Id = repository.GetAll().FirstOrDefault().Id;            
            command.Price = 11.5m;

            var result = handler.Handle(command);
            Assert.False(result.Success, result.Message);
        }
    }
}