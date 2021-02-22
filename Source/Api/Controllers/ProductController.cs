using System;
using System.Collections.Generic;
using Domain;
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
            var result = _handler.Create(command);
            return result;
        }

        [HttpPut("{id}")]
        public CommandResult Update(string id, ProductUpdateCommand command)
        {
            if (id != command.Id)
                return new CommandResult(false, "Id inválido. ", null);

            var result = _handler.Update(command);
            return result;
        }

        [HttpPut("AddPromotion/{id}")]
        public CommandResult AddPromotion(string id, ProductPromotionCommand command)
        {
            var result = _handler.AddPromotion(command);
            return result;
        }

        [HttpDelete("{id}")]
        public CommandResult Delete(string id)
        {
            var result = _handler.Delete(id);
            return result;
        }


        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> products = _repository.GetAll();
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(string id)
        {
            Product product = _repository.GetById(id);
            return Ok(product);
        }

        [HttpGet("Search/{filter}")]
        public IEnumerable<Product> Search(string filter)
        {
            filter = (filter == "empty") ? "" : filter;
            var result = _repository.Search(filter);
            return result;
        }
    }
}