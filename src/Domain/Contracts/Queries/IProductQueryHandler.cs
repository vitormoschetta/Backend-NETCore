using System;
using System.Collections.Generic;
using Domain.Queries.Responses;

namespace Domain.Contracts.Queries
{
    public interface IProductQueryHandler
    {
        IEnumerable<ProductResponse> Handle();
        IEnumerable<ProductResponse> Handle(string filter);
        ProductResponse Handle(Guid id);
    }
}