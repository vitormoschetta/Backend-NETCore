using Domain.Commands;
using Domain.Handlers;
using Tests.Mock;
using Xunit;

namespace Tests.Handlers
{
    
    public class CreateProductTest
    {

        [Fact]
        public void AddProductHandler_valid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            var command = new ProductCreateCommand();
            command.Name = "Product D";
            command.Price = 5.5m;

            var result = handler.Create(command);
            Assert.True(result.Success, result.Message);
        }

        [Fact]
        public void AddProductHandler_Null_Name_Invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            var command = new ProductCreateCommand();
            command.Name = null;
            command.Price = 5.5m;

            var result = handler.Create(command);
            Assert.False(result.Success, result.Message);
        }

        [Fact]
        public void AddProductHandler_Empty_Name_Invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            var command = new ProductCreateCommand();
            command.Name = "";
            command.Price = 5.5m;

            var result = handler.Create(command);
            Assert.False(result.Success, result.Message);
        }

        [Fact]
        public void AddProductHandler_Lenght_Name_4_Invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            var command = new ProductCreateCommand();
            command.Name = "Pro";
            command.Price = 5.5m;

            var result = handler.Create(command);
            Assert.False(result.Success, result.Message);
        }

        [Fact]
        public void AddProductHandler_Negative_Price_Invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            var command = new ProductCreateCommand();
            command.Name = "Product D";
            command.Price = -1;            

            var result = handler.Create(command);
            Assert.False(result.Success, result.Message);
        }

        [Fact]
        public void AddProductHandler_Exists_Name_Invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);
            
            var command = new ProductCreateCommand();
            command.Name = "Product A";
            command.Price = 5.5m;            

            var result = handler.Create(command);
            Assert.False(result.Success, result.Message);
        }

    }
}