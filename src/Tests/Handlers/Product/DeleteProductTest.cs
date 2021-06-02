using System;
using System.Linq;
using Domain.Commands;
using Domain.Commands.Handlers;
using Tests.Mock;
using Xunit;

namespace Tests.Handlers
{

    public class DeleteProductTest
    {
       [Fact]
        public void DeleteProductHandler_valid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductCommandHandler(repository);

            var id = repository.GetAll().FirstOrDefault().Id;

            var command = new ProductDeleteCommand();
            command.Id = id;

            var result = handler.Handle(command);
            Assert.True(result.Success, result.Message);
        }


       [Fact]
        public void DeleteProductHandler_NotExists_Invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductCommandHandler(repository);

            var id = repository.GetAll().FirstOrDefault().Id;

            var command = new ProductDeleteCommand();
            command.Id = id;
            
            var result = handler.Handle(command);
            Assert.True(result.Success, result.Message);
        }
    }
}