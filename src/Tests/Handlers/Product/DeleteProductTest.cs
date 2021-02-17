using System;
using System.Linq;
using Domain.Handlers;
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
            var handler = new ProductHandler(repository);

            string id = repository.GetAll().FirstOrDefault().Id;
            var result = handler.Delete(id);
            Assert.True(result.Success, result.Message);
        }


       [Fact]
        public void DeleteProductHandler_NotExists_Invalid()
        {
            var repository = new FakeProductRepository();
            var handler = new ProductHandler(repository);

            string id = Guid.NewGuid().ToString();
            var result = handler.Delete(id);
            Assert.False(result.Success, result.Message);
        }
    }
}