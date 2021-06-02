using System;
using System.Collections.Generic;
using Domain.Commands;
using Domain.Commands.Responses;
using Domain.Contracts.Commands;
using Domain.Contracts.Queries;
using Domain.Queries.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        [HttpPost]
        public GenericResponse Create([FromServices] IProductCommandHandler handler,
            [FromBody] ProductCreateCommand command)
        {
            return handler.Handle(command);

        }


        [HttpPut("{id}")]
        public GenericResponse Update([FromServices] IProductCommandHandler handler,
            Guid id, [FromBody] ProductUpdateCommand command)
        {
            if (id != command.Id)
                return new GenericResponse(false, "Id inválido. ", null);

            return handler.Handle(command);
        }


        [HttpPut("AddPromotion/{id}")]
        public GenericResponse AddPromotion([FromServices] IProductCommandHandler handler,
            Guid id, [FromBody] ProductPromotionCommand command)
        {
            return handler.Handle(command);
        }


        [HttpDelete("{id}")]
        public GenericResponse Delete([FromServices] IProductCommandHandler handler,
            [FromBody] ProductDeleteCommand command)
        {
            return handler.Handle(command);
        }


        [HttpGet]
        public IEnumerable<ProductResponse> GetAll([FromServices] IProductQueryHandler handler)
        {
            return handler.Handle();
        }


        [HttpGet("{id}")]
        public ProductResponse GetById([FromServices] IProductQueryHandler handler,
            Guid id)
        {
            return handler.Handle(id);
        }


        [HttpGet("Search/{filter}")]
        public IEnumerable<ProductResponse> Search([FromServices] IProductQueryHandler handler,
            string filter)
        {
            filter = (filter == "empty") ? "" : filter;
            return handler.Handle(filter);
        }
    }
}