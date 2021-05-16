using System.Collections.Generic;
using Domain.Commands;
using Domain.Contracts.Handlers;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IProductHandler _handler;
        public ProductController(IProductRepository repository, IProductHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        public CommandResult Create(ProductCreateCommand command)
        {
            return _handler.Handle(command);

        }

        [HttpPut("{id}")]
        public CommandResult Update(string id, ProductUpdateCommand command)
        {
            if (id != command.Id)
                return new CommandResult(false, "Id inválido. ", null);

            return _handler.Handle(command);
        }

        [HttpPut("AddPromotion/{id}")]
        public CommandResult AddPromotion(string id, ProductPromotionCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete("{id}")]
        public CommandResult Delete(ProductDeleteCommand command)
        {
            return _handler.Handle(command);
        }


        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id}")]
        public Product GetById(string id)
        {
            return _repository.GetById(id);            
        }

        [HttpGet("Search/{filter}")]
        public IEnumerable<Product> Search(string filter)
        {
            filter = (filter == "empty") ? "" : filter;
            return _repository.Search(filter);            
        }
    }
}