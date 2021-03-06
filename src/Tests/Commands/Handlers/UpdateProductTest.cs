using System.Linq;
using Domain.Commands;
using Domain.Commands.Handlers;
using Tests.Mock;
using Xunit;

namespace Tests.Commands.Handlers
{
    public class UpdateProductTest
    {
       [Fact]
        public void UpdateProductHandler_valid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductCommandHandler(repository);

            var command = new ProductUpdateCommand();
            command.Id = repository.GetAll().FirstOrDefault().Id;
            command.Name = "Product X";
            command.Price = 9.5m;

            var result = handler.Handle(command);
            Assert.True(result.Success, result.Message);
        }

       [Fact]
        public void UpdateProductHandler_Exists_Name_Invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductCommandHandler(repository);

            var command = new ProductUpdateCommand();
            command.Id = repository.GetAll().FirstOrDefault().Id;
            command.Name = "Product C";
            command.Price = 5.5m;

            var result = handler.Handle(command);
            Assert.False(result.Success, result.Message);
        }

       [Fact]
        public void UpdateProductHandler_Null_Name_Invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductCommandHandler(repository);

            var command = new ProductUpdateCommand();
            command.Id = repository.GetAll().FirstOrDefault().Id;
            command.Name = null;
            command.Price = 5.5m;

            var result = handler.Handle(command);
            Assert.False(result.Success, result.Message);
        }
    }
}