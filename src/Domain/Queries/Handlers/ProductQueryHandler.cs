using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Contracts.Queries;
using Domain.Contracts.Repositories;
using Domain.Queries.Responses;

namespace Domain.Queries.Handlers
{
    public class ProductQueryHandler : IProductQueryHandler
    {
        private readonly IProductRepository _repository;
        public ProductQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ProductResponse> Handle()
        {
            return from item in _repository.GetAll()
                   select new ProductResponse(item.Id, item.Name, item.Price);
        }

        public IEnumerable<ProductResponse> Handle(string filter)
        {
            return from item in _repository.Search(filter)
                   select new ProductResponse(item.Id, item.Name, item.Price);
        }

        public ProductResponse Handle(Guid id)
        {
            var item = _repository.GetById(id);
            return new ProductResponse(item.Id, item.Name, item.Price);
        }
    }
}